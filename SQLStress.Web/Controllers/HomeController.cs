using SQLStress.Business.Interfaces;
using SQLStress.Core.ViewModels;
using SQLStress.Web.Commons.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLStress.Web.Controllers {
	public class HomeController : Controller {

		private readonly ISQL _ISQL;

		public HomeController(ISQL _ISQL) {
			this._ISQL = _ISQL;
		}

		public ViewResult Index() {
			return View();
		}

		[HttpPost]
		public JsonResult Index(ConecctionCredential model) {
			if (_ISQL.TestConnection(model)) {
				SqlConnectionSessionManager.SaveConnection(model);
				return JsonHelper.Success("La conexión con el servidor fué exitosa");
			}
			return JsonHelper.Fail("Lo sentimos, servidor no encontrado o fuera del alcance");
		}
	}
}
