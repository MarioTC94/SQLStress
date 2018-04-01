using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Core.ViewModels {
	public class InfoRequestModel {

		public int CantThreads { get; set; }
		public int CantRequest { get; set; }
		public DateTime InitialDateRequest { get; set; }
		public DateTime FinishDateRequest { get; set; }
		public TimeSpan DurationRequest { get; set; }
		public int SuccessRequest { get; set; }
		public int FailRequest { get; set; }
		public String  TableName { get; set; }
		public String DataBaseName { get; set; }
	}
}
