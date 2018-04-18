using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Core.ViewModels {
	public class TableModel {

		[Required]
		[DisplayName("Nombre de las Tablas")]
		public String TableName { get; set; }
	}
}
