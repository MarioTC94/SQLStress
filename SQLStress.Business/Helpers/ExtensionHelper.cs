using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace SQLStress.Business.Helpers {
	public static class ExtensionHelper {

		/// <summary>
		/// Converts a DataTable to a list with generic objects
		/// </summary>
		/// <typeparam name="T">Generic object</typeparam>
		/// <param name="table">DataTable</param>
		/// <returns>List with generic objects</returns>
		public static List<T> ToEntityList<T>(this DataTable table) where T : class, new() {
			try {
				List<T> list = new List<T>();

				foreach (var row in table.AsEnumerable()) {
					T obj = new T();

					foreach (var prop in obj.GetType().GetProperties()) {
						try {
							PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
							propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
						} catch {
							continue;
						}
					}

					list.Add(obj);
				}

				return list;
			} catch {
				return null;
			}
		}

		/// <summary>
		/// Converts a DataRow to a entity
		/// </summary>
		/// <typeparam name="T">Yhe destiny model</typeparam>
		/// <param name="row">The datarow to convert</param>
		/// <returns>The converted entity</returns>
		public static T ToEntity<T>(this DataRow row) where T : class, new() {
			try {

				T obj = new T();

				foreach (var prop in obj.GetType().GetProperties()) {
					try {
						PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
						propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
					} catch {
						continue;
					}
				}

				return obj;
			} catch {
				return null;
			}
		}

	}
}
