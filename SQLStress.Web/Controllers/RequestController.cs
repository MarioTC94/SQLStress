﻿using SQLStress.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLStress.Web.Controllers
{
    public class RequestController : Controller
    {


		[HttpGet]
		public ViewResult CreateRequest() {
			return View();
		}

		[HttpPost]
		public JsonResult CreateRequest(InfoRequestModel model) {
				model.InitialDateRequest = DateTime.Now;
				//_ManageRequestServer(model);
				model.FinishDateRequest = DateTime.Now;
				return Json(model);
		}
	
    }
}