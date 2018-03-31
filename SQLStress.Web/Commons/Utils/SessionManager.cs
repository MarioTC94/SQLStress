using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLStress.Web.Commons.Utils
{
    /// <summary>
    /// class to manage the sessions 
    /// </summary>
    public class SessionManager
    {
        /// <summary>
        /// method that clear all the keys in the session
        /// </summary>
        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        /// <summary>
        /// method to remove a key from the current session
        /// </summary>
        /// <param name="key">session key</param>
        public static void RemoveSession(String key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        /// <summary>
        /// method that return the key in a list , from the current sesssion or create one if not exist 
        /// </summary>
        /// <typeparam name="T">type of the session key </typeparam>
        /// <param name="key">key name </param>
        /// <returns></returns>
        public static List<T> GetListSession<T>(String key)
        {
            if (HttpContext.Current.Session[key] is null)
            {
                HttpContext.Current.Session[key] = new List<T>();
            }
            return (List<T>)HttpContext.Current.Session[key];
        }
    }
}