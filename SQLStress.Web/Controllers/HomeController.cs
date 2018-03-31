using SQLStress.Business.Interfaces;
using SQLStress.Web.Commons.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLStress.Web.Controllers
{
    public class HomeController : Controller{

		private readonly ISqlCall _ISqlCall;
		private readonly lReport _IReport;

		public HomeController(ISqlCall _ISqlCall, lReport _IReport) {
			this._ISqlCall = _ISqlCall;
			this._IReport = _IReport;

		}

        public ActionResult Index()
        {
			_ISqlCall.RequestTo(100);
            return View();
        }


		public JsonResult TryRequest() {
			_ISqlCall.RequestWithThread(500, 100, "Employees", "HR_Operaions");
			return Json(new { Success = true});
		}

		public JsonResult ShowInfoRequest() {
			var request = _IReport.GetInfoOfLastRequest();
			return Json(request);
		}

        public JsonResult TestStrest()
        {
            try
            {
                return JsonHelper.Success("La prueba de estres fué exitosa");
            }
            catch (Exception)
            {
                return JsonHelper.Fail("Sucedió un error en el request");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}