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

        public static void SaveConnection(ConnectionCredentialModel model)
        {
            HttpContext.Current.Session["StringConnection"] = model;
        }

        public ConnectionCredentialModel GetActualConnectionCredentials()
        {
            return HttpContext.Current.Session["StringConnection"] as ConnectionCredentialModel;
        }
    }
}