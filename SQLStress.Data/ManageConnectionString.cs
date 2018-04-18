using SQLStress.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Data {
	public static class ManageConnectionString {

		/// <summary>
		/// Este metodo genera un string de conexión al servidor de SQL Server
		/// </summary>
		/// <param name="model">El objeto para obtener las credenciales para generar el string</param>
		/// <returns>El String de conexión</returns>
		public static String GetConnectionString(ConecctionCredential model) {
			SqlConnectionStringBuilder manageString = new SqlConnectionStringBuilder();

			if (!model.WindowsAuthentication) {
				manageString.UserID = model.User;
				manageString.Password = model.Password;
			}

			if (!String.IsNullOrEmpty(model.Database)) {
				manageString.InitialCatalog = model.Database;
			}
			manageString.IntegratedSecurity = model.WindowsAuthentication;
			manageString.DataSource = model.Server;
			manageString.ConnectTimeout = 10;
			return manageString.ConnectionString;
		}
	}
}
