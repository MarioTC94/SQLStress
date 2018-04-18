using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLStress.Data;
using SQLStress.Core.ViewModels;
using System.Data;
using System.Data.SqlClient;
using SQLStress.Business.Interfaces;
using SQLStress.Data.Repositories;
using SQLStress.Business.Helpers;
using System.Threading;

namespace SQLStress.Business {
	public class SQLBL : ISQL {


		private SQLRepository _SQLRepository;


		public SQLBL() {
			_SQLRepository = new SQLRepository();
		}


		public List<DataBaseModel> GetAllDatabases(ConecctionCredential credential) {
			return _SQLRepository.GetDatabasesNames(credential).ToEntityList<DataBaseModel>();
		}

		public List<TableModel> GetAllTables(ConecctionCredential credential, string database) {
			credential.Database = database;
			return _SQLRepository.GetAllTables(credential).ToEntityList<TableModel>();
		}

		public InfoRequestModel StressRequest(InfoRequestModel request, ConecctionCredential credential) {
			credential.Database = request.DataBaseName;
			request.SuccessRequest = 0;
			request.FailRequest = 0;
			bool Exception = false;
			request.InitialDateRequest = DateTime.Now; 
			var Hilo = new Thread[request.CantThreads];

			for (int i = 0; i < request.CantThreads; i++) {
				Hilo[i] =
						new Thread(new ThreadStart((Action) ( () => {
							for (int j = 0; j < request.CantRequest; j++) {
								try {
									_SQLRepository.StressRequest(request, credential);
									request.SuccessRequest++;
								} catch (Exception) {
									request.FailRequest++;
									Exception = true;
								}
							}				
						} )));
			}

			for (int i = 0; i < request.CantThreads; i++) {
				Hilo[i].Start();
			}
			for (int i = 0; i < request.CantThreads; i++) {
				Hilo[i].Join();
			}

			request.FinishDateRequest = DateTime.Now;
			request.DurationRequest = (request.InitialDateRequest - request.FinishDateRequest);
			return request;
		}

		public bool TestConnection(ConecctionCredential model) {
			return _SQLRepository.TestConnection(model);
		}

	}
}

