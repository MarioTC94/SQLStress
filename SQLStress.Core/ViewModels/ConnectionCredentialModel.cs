using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Core.ViewModels
{
    public class ConnectionCredentialModel
    {
        public String UserName { get; set; }
        public String Pass { get; set; }
        public String Database { get; set; }
        public bool WindowsAuthentication { get; set; }
    }
}
