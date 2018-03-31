using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SQLStress.Web.Commons.Utils {
    public static class JsonHelper {
        public static JsonResult Success() {
            return new JsonResult() { Data = new { isSuccess = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public static JsonResult Success(String responseText) {
            return new JsonResult { Data = new { isSuccess = true, responseText }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public static JsonResult Success(String responseText, dynamic data) {
            return new JsonResult() { Data = new { isSuccess = true, responseText, data }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public static JsonResult Fail() {
            return new JsonResult() { Data = new { isSuccess = false }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public static JsonResult Fail(String responseText) {
            return new JsonResult() { Data = new { isSuccess = false, responseText }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public static JsonResult Fail(String responseText, dynamic data) {
            return new JsonResult() { Data = new { isSuccess = false, responseText, data }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public static JsonResult UnknownFail() {
            return new JsonResult() { Data = new { isSuccess = false, responseText = "Error desconocido, si el problema persiste por favor comunicarse a SQlStress@support.com" }, ContentEncoding = Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}