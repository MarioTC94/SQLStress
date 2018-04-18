using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace SQLStress.Web.Commons.Utils {
	public static class ViewExtensions {
		public static string RenderToString(this PartialViewResult partialView) {
			if (HttpContext.Current == null)
				throw new NotSupportedException("An HTTP context is required to render the partial view to a string");
			ControllerContext controllerContext = new ControllerContext(HttpContext.Current.Request.RequestContext, (ControllerBase) ControllerBuilder.Current.GetControllerFactory().CreateController(HttpContext.Current.Request.RequestContext, HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString()));
			IView view = ViewEngines.Engines.FindPartialView(controllerContext, partialView.ViewName).View;
			StringBuilder sb = new StringBuilder();
			using (var sw = new StringWriter(sb)) {
				using (var tw = new HtmlTextWriter(sw)) {
					view.Render(new ViewContext(controllerContext, view, partialView.ViewData, partialView.TempData, tw), tw);
				}
			}
			return sb.ToString();
		}
	}

}