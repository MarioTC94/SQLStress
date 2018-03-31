using SQLStress.Business.Interfaces;
using SQLStress.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Business.Logic {
	class ReportBL : lReport {

		private readonly ISqlCall _SqlCall;

		public ReportBL(ISqlCall _SqlCall) {
			this._SqlCall = _SqlCall;
		}

		public InfoRequestModel GetInfoOfLastRequest() {
			var request = new InfoRequestModel() {
				CantRequest = 5,
				DateRequest = DateTime.Now,
				DurationRequest = new TimeSpan(5000),
				CantThreads = 100,
				FailRequest = 0,
				SuccessRequest = 500
			};

			return request;
		}
	}
}
