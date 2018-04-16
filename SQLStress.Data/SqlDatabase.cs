using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Data {
	public class SQLDatabase {

		public SqlConnection oCN { get; }
		public String Conexion { get; set; }
		public string BD { get; set; }

		public SQLDatabase() {

			oCN = new SqlConnection("Data Source=" + Conexion + "\\SQL2016;Initial Catalog=" + BD + ";Integrated Security=True");
		}

		public bool OpenConnection() {
			try {
				oCN.Open();
				return true;
			} catch (Exception ex) {
				throw new Exception("No se puede abrir la conexión con la base de datos", ex);
			}
		}

		public bool CloseConnection() {
			try {
				if (oCN.State != System.Data.ConnectionState.Closed) {
					oCN.Close();
				}
				return true;
			} catch (Exception ex) {
				throw new Exception("No se puede cerrar la conexión con la base de datos", ex);
			}
		}

		internal bool CMD(SqlCommand oSQLC) {

			try {
				if (OpenConnection()) {
					SqlTransaction transaction = oCN.BeginTransaction();
					oSQLC.Connection = oCN;
					oSQLC.Transaction = transaction;
					oSQLC.ExecuteNonQuery();
					transaction.Commit();
					oCN.Close();
					return true;
				}
				oCN.Close();
				return false;
			} catch (Exception ex) {
				oSQLC.Transaction.Rollback();
				oCN.Close();
				throw new Exception("No se pudo completar la solicitud", ex);
			}
		}

		public DataTable SelectData(SqlCommand oSQLC) {
			try {
				oSQLC.Connection = oCN;
				DataTable oDT = new DataTable();
				SqlDataAdapter oSQLDA = new SqlDataAdapter(oSQLC);
				if (OpenConnection()) {
					oSQLDA.Fill(oDT);
				}
				CloseConnection();
				return oDT;
			} catch (Exception ex) {
				throw new Exception("No se pudo obtener la información deseada", ex);
			}
		}
	}
}
