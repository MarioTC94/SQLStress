using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLStress.Data;
using SQLStress.Core.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace SQLStress.Business {
	public class EnviarConexion {

		SQLDatabase vSqlDatabase = new SQLDatabase();
		CredencialesConexion credenciales = new CredencialesConexion();


		public void EnvioConexion() {
			try {
				vSqlDatabase.BD = credenciales.Dato;
				vSqlDatabase.Conexion = credenciales.Servidor;
				vSqlDatabase.OpenConnection();
			} catch (Exception ex) {

				throw new Exception(ex.Message);
			}
		}

		public DataTable NombreBases(String Nombre) {
			
				vSqlDatabase.BD = credenciales.Dato;
				vSqlDatabase.Conexion = credenciales.Servidor;
				SqlCommand  oSQLC= new SqlCommand( "SELECT name FROM master.dbo.sysdatabases WHERE name NOT IN('master', 'tempdb', 'model', 'msdb','DWDiagnostics','DWConfiguration','DWQueue');");

			return new SQLDatabase().SelectData(oSQLC);
				
		}
	}
}
