using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Core.ViewModels {
	public class InfoRequestModel {
		[Required]
		[DisplayName("Cantidad de Hilos")]
		public int CantThreads { get; set; }

		[Required]
		[DisplayName("Cantidad de Consultas")]
		public int CantRequest { get; set; }

		
		[DisplayName("Fecha Inicio del proceso")]
		public DateTime InitialDateRequest { get; set; }

		
		[DisplayName("Fecha Final del proceso")]
		public DateTime FinishDateRequest { get; set; }

		
		[DisplayName("Duración del proceso")]
		public TimeSpan DurationRequest { get; set; }

		
		[DisplayName("Consultas con exito")]
		public int SuccessRequest { get; set; }

		
		[DisplayName("Consultas Fallidas")]
		public int FailRequest { get; set; }

		[Required]
		[DisplayName("Nombre de la Tabla")]
		public String TableName { get; set; }

		[Required]
		[DisplayName("Nombre de la base de datos")]
		public String DataBaseName { get; set; }
	}
}
