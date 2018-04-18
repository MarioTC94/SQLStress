using SQLStress.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SQLStress.Web.Commons.Utils
{
    public class SqlConnectionSessionManager
    {
        private static SqlConnectionStringBuilder ConnecitonStringBuilder;

        public static void SaveConnection(ConecctionCredential model)
        {
            HttpContext.Current.Session["StringConnection"] = model;
        }

        public static ConecctionCredential GetActualConnectionCredentials()
        {
            return HttpContext.Current.Session["StringConnection"] as ConecctionCredential;
        }
	
	}
}