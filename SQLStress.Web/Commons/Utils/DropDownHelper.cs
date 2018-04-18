using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SQLStress.Web.Commons.Util {
	/// <summary>
	/// Generic class to generate all the DropDownList
	/// </summary>
	public static class DropDownHelper {

		/// <summary>
		/// Generate a list of SelectListItem
		/// </summary>
		/// <typeparam name="T">The Model type for generate the list</typeparam>
		/// <param name="listModel">The list source of the model</param>
		/// <param name="key">A function to get the property of the model to use as a key of the dropdown</param>
		/// <param name="text">A function to get the property of the model to use as a value text of the dropdown</param>
		/// <param name="selected">Index of which element whatns to be selected of the begining, default 0</param>
		/// <returns>A list of SelectedListItem ready to use as a source of a dropdown with Razor</returns>
		public static List<SelectListItem> GetDropdown<T>(List<T> listModel, Func<T, String> key, Func<T, String> text, int selected = 0) {
			var listSelectListItem = new List<SelectListItem>();

			listModel.ForEach(x => {
				listSelectListItem.Add(new SelectListItem { Text = text(x), Value = key(x), Selected = false });
			});

			listSelectListItem[selected].Selected = true;
			return listSelectListItem;
		}

		/// <summary>
		/// Generate a list of SelectListItem using two attributes of the model as text to display it on the dropdown
		/// </summary>
		/// <typeparam name="T">The Model type for generate the list</typeparam>
		/// <param name="listModel">The list source of the model</param>
		/// <param name="key">A function to get the property of the model to use as a key of the dropdown</param>
		/// <param name="firstText">A function to get the property of the model to use as the first part of the text of the dropdown</param>
		/// <param name="secondText">A function to get the property of the model to use as the second part of the text of the dropdown</param>
		/// <param name="concatCharacter">A character to concat both text as one to display it on the dropdown</param>
		/// <param name="selected">Index of which element whatns to be selected of the begining, default 0</param>
		/// <returns>A list of SelectedListItem ready to use as a source of a dropdown with Razor</returns>
		public static List<SelectListItem> GetDropdown<T>(this List<T> listModel, Func<T, String> key, Func<T, String> firstText, Func<T, String> secondText, char concatCharacter, int selected = 0) {

			List<SelectListItem> listSelectListItem = new List<SelectListItem>();

			listModel.ForEach(x => {
				listSelectListItem.Add(new SelectListItem { Text = firstText(x) + concatCharacter + secondText(x), Value = key(x), Selected = false });
			});

			listSelectListItem[selected].Selected = true;
			return listSelectListItem;
		}

		/// <summary>
		/// Generate a list of SelectListItem using a normal list of String as key and value
		/// </summary>
		/// <param name="listdata">The source String list</param>
		/// <param name="selected">Index of which element whatns to be selected of the begining, default 0</param>
		/// <returns>A list of SelectedListItem ready to use as a source of a dropdown with Razor</returns>
		public static List<SelectListItem> GetDropdown(this List<String> listdata, int selected = 0) {
			List<SelectListItem> listSelectListItem = new List<SelectListItem>();

			listdata.ForEach(x => {
				listSelectListItem.Add(new SelectListItem { Text = x, Value = x, Selected = false });
			});

			listSelectListItem[selected].Selected = true;
			return listSelectListItem;
		}
	}
}
