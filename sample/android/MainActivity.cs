using System;
using System.IO;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Content;
using Android.Widget;
using Android.Provider;
using Android.Database;
using Android.Graphics;
using Concur.Connect.V3.Serializable;

namespace Concur.Sample.ClientLibrary
{
    [Activity(Label = "Concur Platform SDK Sample", MainLauncher = true, Icon = "@drawable/ConcurIcon")]
    public class MainActivity : Activity
    {
		private const int REQ_CODE_PICK_IMAGE = 1;  /* Android constant for image picking processing */
        ExpenseType[] expenseTypes; /* Array of Expense Types displayed in the UI */ 
		PaymentType[] paymentTypes; /* Array of Payment Types displayed in the UI */ 
        byte[] expenseImageBytes; /* Receipt image content to be sent via Concur API */

		/// <summary>
		/// On view creation
		/// </summary>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			// Set the expense transaction date to today's date
            var dateView = FindViewById<EditText>(Resource.Id.dateEditText);
            dateView.Text = DateTime.Now.ToString();            
            
			// Hook the handle for the Login button click
            Button loginButton = FindViewById<Button>(Resource.Id.loginButton);
            loginButton.Click += delegate { LoginButton_Click(); };  /*button.Text = string.Format("{0} clicks!", count++);*/

			// Hook the handle for the Create Report button click
            Button createReportButton = FindViewById<Button>(Resource.Id.CreateReportButton);
            createReportButton.Click += delegate { CreateReportButton_Click(); };

			// Hook the handle for the Image button click
            Button imageButton = FindViewById<Button>(Resource.Id.imageButton);
            imageButton.Click += delegate { ImageButton_Click(); };
        }

		/// <summary>
		/// Handle the Image button click
		/// </summary>
        protected void ImageButton_Click()
        {
            try
            {
				// Display view to allow selecting the chosen image.
                Intent intent = new Intent();
                intent.SetType("image/*");
                intent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), REQ_CODE_PICK_IMAGE);
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }
			
		/// <summary>
		/// Handle view activity.
		/// </summary>
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent imageReturnedIntent)
        {
            base.OnActivityResult(requestCode, resultCode, imageReturnedIntent);

			// Determine which image file was picked and then capture its content and display its file name.
            if (REQ_CODE_PICK_IMAGE == requestCode && resultCode == Result.Ok)
            {
                Android.Net.Uri selectedImageUri = imageReturnedIntent.Data;
                String[] filePathColumn = { MediaStore.Images.Media.InterfaceConsts.Data };

                ICursor cursor = ContentResolver.Query(selectedImageUri, filePathColumn, null, null, null);
                cursor.MoveToFirst();

                int columnIndex = cursor.GetColumnIndex(filePathColumn[0]);
                String filePath = cursor.GetString(columnIndex);
                cursor.Close();

                Bitmap selectedImageBitmap = BitmapFactory.DecodeFile(filePath);          
                using (var imageStream = new MemoryStream())
                {
                    selectedImageBitmap.Compress(Bitmap.CompressFormat.Jpeg, 20, imageStream);
                    expenseImageBytes = imageStream.ToArray();
                }
                var pathNames = filePath.Split(@"/\".ToCharArray());
                var receiptImageView = FindViewById<EditText>(Resource.Id.receiptImageEditText);
                receiptImageView.Text = pathNames[pathNames.Length - 1].Split('.')[0];
            }
        }

		/// <summary>
		/// Handle Create Report click
		/// </summary>
        protected void CreateReportButton_Click()
        {
            CreateReportAsync();
        }

		/// <summary>
		/// Process Create Report asynchronously
		/// </summary>
        protected async void CreateReportAsync()
        {
            try
            {
				// Clear status
				TextView statusView = FindViewById<TextView>(Resource.Id.statusTextView);
				statusView.Text = "";

                // Get the object for each view.
                var reportNameView = FindViewById<EditText>(Resource.Id.reportNameEditText);
                var vendorView = FindViewById<EditText>(Resource.Id.vendorEditText);
                var amountView = FindViewById<EditText>(Resource.Id.amountEditText);
                var currencyView = FindViewById<EditText>(Resource.Id.currencyEditText);
                var dateView = FindViewById<EditText>(Resource.Id.dateEditText);
                var expenseTypeView = FindViewById<Spinner>(Resource.Id.expenseTypeSpinner);
                var paymentTypeView = FindViewById<Spinner>(Resource.Id.paymentTypeSpinner);

				// Verify if both Expense Type and Payment Type were selected.
                string selectedExpenseTypeName = (expenseTypeView.SelectedItem ?? "").ToString();
                string selectedPaymentTypeName = (paymentTypeView.SelectedItem ?? "").ToString();
                if (String.IsNullOrEmpty(selectedExpenseTypeName) || String.IsNullOrEmpty(selectedPaymentTypeName)) throw new Exception("You forgot to select either an EXPENSE TYPE or a PAYMENT TYPE !!!");

				// Determine the selected Expense Type code and the selected Payment Type ID
                string expenseTypeCode = Array.Find<ExpenseType>(expenseTypes, x => x.Name.Equals(selectedExpenseTypeName)).Code;
                string paymentTypeId = Array.Find<PaymentType>(paymentTypes, x => x.Name.Equals(selectedPaymentTypeName)).ID;

				// The Facade calls Concur APIs to create an expense report, with an expense entry and an expense image.
                string reportId = await ClientLibraryFacade.CreateReportWithImageAsync(
                    reportNameView.Text,
                    vendorView.Text,
                    decimal.Parse(amountView.Text),
                    currencyView.Text,
                    expenseTypeCode,
                    DateTime.Parse(dateView.Text),
                    paymentTypeId,
                    expenseImageBytes,
					Concur.Util.ReceiptFileType.Jpeg);

				// Set ReportID in the status
				statusView.Text = "Success!!!  Report ID: " + reportId;
            }
            catch (Exception except)
            {
                DisplayException(except);
            }
        }

		/// <summary>
		/// Handle Login button click.
		/// </summary>
        protected void LoginButton_Click()
        {
            LoginAsync();
        }

		/// <summary>
		/// Process asynchronously the Login button click.
		/// </summary>
        protected async void LoginAsync()
        {
            try
            {
				// Clear status
				TextView statusView = FindViewById<TextView>(Resource.Id.statusTextView);
				statusView.Text = "";

				// Find the objects for Login view, Password view, and Client ID view
				var clientIdView = FindViewById<EditText>(Resource.Id.clientIdEditText);
				var loginIdView = FindViewById<EditText>(Resource.Id.loginIdEditText);
                var passwordView = FindViewById<EditText>(Resource.Id.passwordEditText);

				// Facade calls Concur API to Login using the user provided LoginID, Password, and ClientID
				await ClientLibraryFacade.LoginAsync(loginIdView.Text, passwordView.Text, clientIdView.Text);

				// Facade calls Concur API to get the expense configuration needed by this use in order to create expense reports.
				ExpenseGroupConfiguration defaultGroupConfig = await ClientLibraryFacade.GetGroupConfigurationAsync();

				// Determine which expense policy is the default one.
				Policy defaultExpensePolicy = null;
                foreach (Policy policy in defaultGroupConfig.Policies) if (policy.IsDefault == true) defaultExpensePolicy = policy;

				// Determine, out of the expense configuration object, the allowed Expense Types and allowed Payment Types for this user
                expenseTypes = defaultExpensePolicy.ExpenseTypes;
                paymentTypes = defaultGroupConfig.PaymentTypes;
                var expenseTypeNames = new List<string>(); foreach(var type in expenseTypes) expenseTypeNames.Add(type.Name);
                var paymentTypeNames = new List<string>(); foreach(var type in paymentTypes) paymentTypeNames.Add(type.Name);

				// Populate the appropriate UI views for Payment Types and Expense Types
                PopulateSpinner(expenseTypeNames, Resource.Id.expenseTypeSpinner);
                PopulateSpinner(paymentTypeNames, Resource.Id.paymentTypeSpinner);
            }
            catch (Exception except)
            {
                DisplayException(except);
            }
        }

		/// <summary>
		/// Helper to populate a spinner view
		/// </summary>
        protected void PopulateSpinner(List<string> elementNames, int spinnerId)
        {
            var spinner = FindViewById<Spinner>(spinnerId);
            var adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerItem, elementNames); //Android.Resource.Layout.SimpleSpinnerDropDownItem
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
        }

		/// <summary>
		/// Helper to display an exception on the UI
		/// </summary>
        protected void DisplayException(Exception except)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Ooops!!!");
            builder.SetMessage(except.Message);
            builder.SetNeutralButton("Get out of my face", DoNothing);

            AlertDialog dialog = builder.Create();
            dialog.Show();
        }

		/// <summary>
		/// Do Nothing handler for when the OK button is clicked in the Exception message.
		/// </summary>
        protected virtual void DoNothing(Object sender, DialogClickEventArgs e)
        {
        
        }
    }
}

