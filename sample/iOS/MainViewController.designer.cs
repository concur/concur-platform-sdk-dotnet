// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace ConcurPlatformSdkSample
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField AmountTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField ClientIdTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CreateReportButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField CurrencyTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField DateTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ExpenseTypeCollapseButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ExpenseTypeExpandButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIPickerView ExpenseTypePicker { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ImageButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton LoginButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField LoginIdTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView MyMainView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField PasswordTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton PaymentTypeCollapseButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton PaymentTypeExpandButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIPickerView PaymentTypePicker { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField ReceiptImageTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ReportNameLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField ReportNameTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel StatusLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel VendorLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField VendorTextField { get; set; }

		[Action ("CreateReportButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void CreateReportButton_TouchUpInside (UIButton sender);

		[Action ("ExpenseTypeCollapseButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ExpenseTypeCollapseButton_TouchUpInside (UIButton sender);

		[Action ("ExpenseTypeExpandButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ExpenseTypeExpandButton_TouchUpInside (UIButton sender);

		[Action ("ImageButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ImageButton_TouchUpInside (UIButton sender);

		[Action ("LoginButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void LoginButton_TouchUpInside (UIButton sender);

		[Action ("PaymentTypeCollapseButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PaymentTypeCollapseButton_TouchUpInside (UIButton sender);

		[Action ("PaymentTypeExpandButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PaymentTypeExpandButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (AmountTextField != null) {
				AmountTextField.Dispose ();
				AmountTextField = null;
			}
			if (ClientIdTextField != null) {
				ClientIdTextField.Dispose ();
				ClientIdTextField = null;
			}
			if (CreateReportButton != null) {
				CreateReportButton.Dispose ();
				CreateReportButton = null;
			}
			if (CurrencyTextField != null) {
				CurrencyTextField.Dispose ();
				CurrencyTextField = null;
			}
			if (DateTextField != null) {
				DateTextField.Dispose ();
				DateTextField = null;
			}
			if (ExpenseTypeCollapseButton != null) {
				ExpenseTypeCollapseButton.Dispose ();
				ExpenseTypeCollapseButton = null;
			}
			if (ExpenseTypeExpandButton != null) {
				ExpenseTypeExpandButton.Dispose ();
				ExpenseTypeExpandButton = null;
			}
			if (ExpenseTypePicker != null) {
				ExpenseTypePicker.Dispose ();
				ExpenseTypePicker = null;
			}
			if (ImageButton != null) {
				ImageButton.Dispose ();
				ImageButton = null;
			}
			if (LoginButton != null) {
				LoginButton.Dispose ();
				LoginButton = null;
			}
			if (LoginIdTextField != null) {
				LoginIdTextField.Dispose ();
				LoginIdTextField = null;
			}
			if (MyMainView != null) {
				MyMainView.Dispose ();
				MyMainView = null;
			}
			if (PasswordTextField != null) {
				PasswordTextField.Dispose ();
				PasswordTextField = null;
			}
			if (PaymentTypeCollapseButton != null) {
				PaymentTypeCollapseButton.Dispose ();
				PaymentTypeCollapseButton = null;
			}
			if (PaymentTypeExpandButton != null) {
				PaymentTypeExpandButton.Dispose ();
				PaymentTypeExpandButton = null;
			}
			if (PaymentTypePicker != null) {
				PaymentTypePicker.Dispose ();
				PaymentTypePicker = null;
			}
			if (ReceiptImageTextField != null) {
				ReceiptImageTextField.Dispose ();
				ReceiptImageTextField = null;
			}
			if (ReportNameLabel != null) {
				ReportNameLabel.Dispose ();
				ReportNameLabel = null;
			}
			if (ReportNameTextField != null) {
				ReportNameTextField.Dispose ();
				ReportNameTextField = null;
			}
			if (StatusLabel != null) {
				StatusLabel.Dispose ();
				StatusLabel = null;
			}
			if (VendorLabel != null) {
				VendorLabel.Dispose ();
				VendorLabel = null;
			}
			if (VendorTextField != null) {
				VendorTextField.Dispose ();
				VendorTextField = null;
			}
		}
	}
}
