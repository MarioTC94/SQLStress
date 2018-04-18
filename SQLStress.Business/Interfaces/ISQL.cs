using SQLStress.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Business.Interfaces {
	public interface ISQL {

		List<DataBaseModel> GetAllDatabases(ConecctionCredential credential);
		List<TableModel> GetAllTables(ConecctionCredential credential, string database);
		bool TestConnection(ConecctionCredential model);

		InfoRequestModel StressRequest(InfoRequestModel request, ConecctionCredential credential);
	}
}
