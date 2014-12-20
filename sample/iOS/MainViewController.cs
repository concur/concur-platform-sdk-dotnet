using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections;
using System.Collections.Generic;
using Concur.Connect.V3.Serializable;
using ConcurPlatformSdkSample;
using Concur.Authentication;
using Concur.Connect.V1;
using Concur.Connect.V3;
using Concur.Util;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using MonoTouch.AssetsLibrary;
using System.IO;


namespace ConcurPlatformSdkSample
{
	public partial class MainViewController : UIViewController
	{
		ExpenseType[] ExpenseTypes{ get; set; }  /* Array of Expense Types as displayed */
		PaymentType[] PaymentTypes{ get; set; }  /* Array of Payment Types as displayed */
		byte[] ExpenseImageData{ get; set; }  /* Image content to be attached to the report entry */
		UIImagePickerController ImagePicker { get; set; } /* Image picker control used when selecting a receipt image */

		public MainViewController (IntPtr handle) : base (handle)
		{
		}
			
		/// <summary>
		/// Standard boilerplate code for Xamarin-iOS
		/// </summary>
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		/// <summary>
		/// Populated the pickers with empty lists and disable the CreateReport button because the user didn't login yet.
		/// </summary>
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			ExpenseTypePicker.Model = new MyPickerModel(new List<string>());
			PaymentTypePicker.Model = new MyPickerModel(new List<string>());

			CreateReportButton.Enabled = false;
		}
			
		/// <summary>
		/// Show today's date as the default expense transaction date.
		/// </summary>
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			DateTextField.Text = DateTime.Now.ToString();
		}

		/// <summary>
		/// Standard boilerplate code for Xamarin-iOS
		/// </summary>
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		/// <summary>
		/// Standard boilerplate code for Xamarin-iOS
		/// </summary>
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		/// <summary>
		/// Standard boilerplate code for Xamarin-iOS
		/// </summary>
		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		/// <summary>
		/// Handle click on the Login button.
		/// </summary>
		partial void LoginButton_TouchUpInside (UIButton sender)
		{
			LoginButton_TouchUpInsideAsync();
		}
		 
		/// <summary>
		/// Asynchronous processing of the login button click.
		/// </summary>
	 	async Task LoginButton_TouchUpInsideAsync ()
		{
			try
			{
				// Clear the last displayed status.
				StatusLabel.Text = ""; 

				// The facade calls Concur API to login using the ClientID, LoginID, and Password entered by the user in the UI.
				await ClientLibraryFacade.LoginAsync (
					LoginIdTextField.Text, 
					PasswordTextField.Text,
					ClientIdTextField.Text);    

				// The facade calls Concur API to get the configuration this user should use when creating expense reports.
				// Then get the list of allowed Payment Types and allowed Expense Types for this user for creating expense reports.
				var groupConfig = await ClientLibraryFacade.GetGroupConfigurationAsync ();
				PaymentTypes = groupConfig.PaymentTypes;
				ExpenseTypes = groupConfig.Policies.First(p => p.IsDefault.Value == true).ExpenseTypes;

				// Display the Payment Types and the Expense Types
				(ExpenseTypePicker.Model as MyPickerModel).MyItems = ExpenseTypes.Select(t => t.Name).ToList();
				(PaymentTypePicker.Model as MyPickerModel).MyItems = PaymentTypes.Select(t => t.Name).ToList();

				// Refresh controls used for displaying and selecting Payment Type and Expense Type.
				ExpenseTypePicker.ReloadAllComponents();
				PaymentTypePicker.ReloadAllComponents();
				SetButtonTitleAsPickerSelection(ExpenseTypeExpandButton, ExpenseTypePicker);
				SetButtonTitleAsPickerSelection(PaymentTypeExpandButton, PaymentTypePicker);

				CreateReportButton.Enabled = true;
			}
			catch(Exception e) 
			{
				DisplayException (e);
			}
		}


		/// <summary>
		/// Asynchronous processing of the Image button click (used for selecting a receipt image out of the ones in the device).
		/// </summary>
		partial void ImageButton_TouchUpInside (UIButton sender)
		{
			this.ImagePicker = new UIImagePickerController();
			var photoLibraryType = UIImagePickerControllerSourceType.SavedPhotosAlbum; //.PhotoLibrary;
			this.ImagePicker.SourceType = photoLibraryType;
			this.ImagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(photoLibraryType);
			this.ImagePicker.FinishedPickingMedia += ImagePicker_FinishedPickingMedia;
			this.ImagePicker.Canceled += ImagePicker_Cancelled;
			this.PresentViewController(this.ImagePicker, true, null);
		}

		void ImagePicker_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			ImagePicker_FinishedPickingMediaAsync(e);
		}

		/// <summary>
		/// Asynchronous processing of the image selection event.
		/// The below is standard iOS code (via Xamarin classes) needed to extract the file name and the content of the selected image file
		/// </summary>
		async Task ImagePicker_FinishedPickingMediaAsync(UIImagePickerMediaPickedEventArgs e)
		{
			try
			{
				string mediaTypeName = e.Info [UIImagePickerController.MediaType].ToString();
				if (string.Compare(mediaTypeName,"public.image", true) != 0)
				{
					Console.WriteLine("No image was selected.");
					CloseAndDisposeImagePicker();
					return;
				}

				using (NSUrl nsUrl = e.Info[UIImagePickerController.ReferenceUrl] as NSUrl)
				{
					if (nsUrl == null)
					{
						Console.WriteLine("Could not get URL for the selected image.");
						CloseAndDisposeImagePicker();
						return;
					}

					using (var assetsLib = new ALAssetsLibrary())
					{
						assetsLib.AssetForUrl(
							nsUrl,
							(ALAsset asset) => 
							{ 
								using (ALAssetRepresentation assetRep = asset.DefaultRepresentation)
								{
									UIImage originalImage;
									using(var assetStream = new AssetLibraryReadStream(assetRep)) originalImage = UIImage.LoadFromData(NSData.FromStream(assetStream));
									this.ExpenseImageData = originalImage.AsJPEG(0.1f).ToArray();
									ReceiptImageTextField.Text = assetRep.Filename;
									CloseAndDisposeImagePicker();
								}
							},
							(NSError error) => { throw new IOException("Error when getting asset for URL."); } 
						);
					}
				}
			}
			catch(Exception ex)
			{
				CloseAndDisposeImagePicker();
				DisplayException (ex);
			}
		}
			
		/// <summary>
		/// Closes the and dispose the image picker in order to release resources.
		/// </summary>
		void CloseAndDisposeImagePicker()
		{
			this.ImagePicker.DismissViewController(true, null);
			this.ImagePicker.Dispose ();
			this.ImagePicker = null;
		}

		void ImagePicker_Cancelled(object sender, EventArgs e)
		{
			CloseAndDisposeImagePicker ();
		}

		/// <summary>
		/// If the user selects a picker item then display the same item on the hovering button. 
		/// The hovering button shows the picker selection even after the picker is hidden.
		/// </summary>
		void SetButtonTitleAsPickerSelection(UIButton button, UIPickerView picker)
		{
			List<string> pickerItems = (picker.Model as MyPickerModel).MyItems;
			int selectedRow = picker.SelectedRowInComponent(0);
			string selectedName = pickerItems.Count == 0 ? "" : pickerItems[selectedRow];
			button.SetTitle(selectedName, UIControlState.Normal);
		}

		/// <summary>
		/// The expand button for the Expense Type picker was clicked. This button hovers the Expense Type picker.
		/// </summary>
		partial void ExpenseTypeExpandButton_TouchUpInside (UIButton sender)
		{
			ExpandButton_TouchUpInside (ExpenseTypeExpandButton, ExpenseTypeCollapseButton, "Expense Type =>", ExpenseTypePicker);
		}

		/// <summary>
		/// The expand button for the Payment Type picker was clicked. This button hovers the Payment Type picker.
		/// </summary>
		partial void PaymentTypeExpandButton_TouchUpInside (UIButton sender)
		{
			ExpandButton_TouchUpInside (PaymentTypeExpandButton, PaymentTypeCollapseButton, "Payment Type =>", PaymentTypePicker);
		}

		/// <summary>
		/// An associated picker expand button was clicked. Therefore perform the following: 
		/// 1. Set the proper title and background for the collapse because it will be displayed.
		/// 2. Hide the expand button and display the collapse button.
		/// 3. Display the picker.
		/// </summary>
		void ExpandButton_TouchUpInside (UIButton expandButton, UIButton collapseButton, string collapseButtonTitle, UIPickerView picker)
		{
			collapseButton.BackgroundColor = UIColor.Cyan;
			collapseButton.SetTitle(collapseButtonTitle, UIControlState.Normal);  //" Done!            =>"
			collapseButton.Enabled = true;
			expandButton.Hidden = true;

			picker.Hidden = false;
		}

		/// <summary>
		/// The collapse button for the Expense Type picker was clicked. This button is displayed beside the Expense Type picker.
		/// </summary>
		partial void ExpenseTypeCollapseButton_TouchUpInside (UIButton sender)
		{
			CollapseButton_TouchUpInside(ExpenseTypeExpandButton, ExpenseTypeCollapseButton, "Expense Type:", ExpenseTypePicker);
		}

		/// <summary>
		/// The collapse button for the Payment Type picker was clicked. This button is displayed beside the Payment Type picker.
		/// </summary>
		partial void PaymentTypeCollapseButton_TouchUpInside (UIButton sender)
		{
			CollapseButton_TouchUpInside(PaymentTypeExpandButton, PaymentTypeCollapseButton, "Payment Type:", PaymentTypePicker);
		}

		/// <summary>
		/// An associated picker collapse button was clicked. Therefore perform the following: 
		/// 1. Set the proper title and background for the collapse button because it will be disabled (but it will still be displayed).
		/// 2. Display the expand button.
		/// 3. Display on the expand button the same title found in the picker selected item.
		/// 4. Hide the picker.
		/// </summary>
		void CollapseButton_TouchUpInside (UIButton expandButton, UIButton collapseButton, string collapseButtonTitle, UIPickerView picker)
		{
			collapseButton.BackgroundColor = UIColor.Clear;
			collapseButton.SetTitle(collapseButtonTitle, UIControlState.Normal);
			collapseButton.Enabled = false;
			expandButton.Hidden = false;

			int selectedRow = picker.SelectedRowInComponent(0);
			List<string> pickerItems = (picker.Model as MyPickerModel).MyItems;
			string selectedName = pickerItems.Count == 0 ? "" : pickerItems[selectedRow];
			expandButton.SetTitle(selectedName, UIControlState.Normal);

			picker.Hidden = true;
		}
	
		/// <summary>
		/// Handle the Create Report button click.
		/// </summary>
		partial void CreateReportButton_TouchUpInside(UIButton sender)
		{
			CreateReportButton_TouchUpInsideAsync();
		}

		/// <summary>
		/// Process asynchronously the Create Report click.
		/// </summary>
		async Task CreateReportButton_TouchUpInsideAsync()
		{
			try
			{
				// Clear the last displayed report creation status.
				StatusLabel.Text = ""; 

				// Get the expense code for the Expense Type selected in the UI.
				int selectedExpenseTypeIndex = ExpenseTypePicker.SelectedRowInComponent(0);
				string expenseTypeCode = ExpenseTypes[selectedExpenseTypeIndex].Code;

				// Get the ID for the Payment Type selected in the UI.
				int selectedPaymentTypeIndex = PaymentTypePicker.SelectedRowInComponent(0);
				string paymentTypeId = PaymentTypes[selectedPaymentTypeIndex].ID;

				// The facade will call Concur APIs to create an expense report with an expense entry and an expense image.
				string reportId = await ClientLibraryFacade.CreateReportWithImageAsync(
					ReportNameTextField.Text,
					VendorTextField.Text,
					decimal.Parse(AmountTextField.Text),
					CurrencyTextField.Text,
					expenseTypeCode,
					DateTime.Parse(DateTextField.Text),
					paymentTypeId,
					ExpenseImageData,
					ReceiptFileType.Jpeg);

				// Show report creation success as the lastest status.
				StatusLabel.Text = "Success!!!  Report ID: " + reportId; 
			}
			catch(Exception e)
			{
				DisplayException(e);
			}
		}

		/// <summary>
		/// Display the exception in case something goes wrong. 
		/// </summary>
		void DisplayException(Exception e)
		{
			var alertController = UIAlertController.Create (
				"Unexpected Exception",
				e.GetType ().Name + Environment.NewLine + e.Message,
				UIAlertControllerStyle.Alert); 
			alertController.AddAction (UIAlertAction.Create ("OK", UIAlertActionStyle.Default, null));
			this.PresentViewController (alertController, true, null);
		}
		#endregion
	}
}

