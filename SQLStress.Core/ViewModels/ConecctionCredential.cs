using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Core.ViewModels
{
    public class ConecctionCredential
    {
		[Required]
		[DisplayName("Servidor")]
		public string Server { get; set; }

		[Required]
		[DefaultValue(true)]
		[DisplayName("Usa Windows Authentication")]
		public bool WindowsAuthentication { get; set; }

		[Required]
		[DisplayName("Nombre Usuario")]
		public String User { get; set; }

		[Required]
		[DisplayName("Contraseña")]
		public String Password { get; set; }

		public String Database { get; set; }
	}
}
