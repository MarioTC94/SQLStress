using SQLStress.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SQLStress.Business;
using SQLStress.Business.Interfaces;
using SQLStress.Web.Commons.Util;
using SQLStress.Web.Commons.Utils;

namespace SQLStress.Web.Controllers {
	public class RequestController : Controller {

		private readonly ISQL _SQL;

		public RequestController(ISQL _SQL) {
			this._SQL = _SQL;
		}

		public ViewResult Index() {
			return View();
		}

		public ViewResult CreateRequest() {
			var credentials = SqlConnectionSessionManager.GetActualConnectionCredentials();
			ViewBag.DatabaseNameList = DropDownHelper.GetDropdown(_SQL.GetAllDatabases(credentials), x => x.Name, x => x.Name);		
		return View();
		}

		[HttpPost]
		public JsonResult CreateRequest(InfoRequestModel request) {
			var credentials = SqlConnectionSessionManager.GetActualConnectionCredentials();
			request =_SQL.StressRequest(request, credentials);
			return JsonHelper.Success("Estrés Terminado",request);
		}

		[HttpPost]
		public JsonResult GetTablesDB(string database) {
			var credentials = SqlConnectionSessionManager.GetActualConnectionCredentials();
			return Json(new { tablesnames = _SQL.GetAllTables(credentials, database) });
		}

	
	}
}
