using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SQLStress.Data.Repositories;
using SQLStress.Core.ViewModels;

namespace SQLStress.Data.Repositories {
	public class SQLRepository {

		public DataTable GetDatabasesNames(ConecctionCredential credential) {
			using (var DB = new SQLDatabase(credential)) {
				return DB.SelectData(new SqlCommand("SELECT name as Name FROM master.dbo.sysdatabases WHERE name NOT IN('master', 'tempdb', 'model', 'msdb','DWDiagnostics','DWConfiguration','DWQueue');"));
			}
		}

		public DataTable GetAllTables(ConecctionCredential credential) {
			using (var DB = new SQLDatabase(credential)) {
				return DB.SelectData(new SqlCommand("SELECT TABLE_NAME AS TableName FROM INFORMATION_SCHEMA.TABLES"));
			}
		}

		public bool TestConnection(ConecctionCredential model) {
			using (var DB = new SQLDatabase(model)) {
				return DB.OpenConnection();
			}
		}

		public void StressRequest(InfoRequestModel request, ConecctionCredential credential) {
			using (var DB = new SQLDatabase(credential)) {
			 DB.SelectData(new SqlCommand($"SELECT * FROM {request.TableName} "));
			}
		}
	}
}
