using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Concur.Sample.ClientLibrary
{
	/// <summary>
	/// MVC model for a custom Picker control we used when displaying Expense Types and Payment Types.
	/// </summary>
	public class MyPickerModel: UIPickerViewModel
	{
		public List<string> MyItems;

		/// <summary>
		/// Initializes a new instance and hold the items we want to display.
		/// </summary>
		public MyPickerModel(List<string> items)
		{
			this.MyItems = items;
		}
			
		/// <summary>
		/// Informs how many components are comprised in the picker.
		/// </summary>
		public override int GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		/// <summary>
		/// Informs how rows a given picker component has.
		/// </summary>
		public override int GetRowsInComponent(UIPickerView picker, int component)
		{
			return MyItems.Count;
		}

		/// <summary>
		/// Informs the string to be displayed in a given component row.
		/// </summary>
		public override string GetTitle(UIPickerView picker, int row, int component)
		{
			return MyItems[row];
		}
	}
}

