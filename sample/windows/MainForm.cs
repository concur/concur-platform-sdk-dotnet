using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Concur.Util;
using Concur.Authentication;
using Concur.Connect.V3.Serializable;

namespace Concur.Sample.ClientLibrary
{
    public partial class MainForm : Form
    {
		private void LoginButton_Click(object sender, EventArgs e)
		{
			LoginButton_ClickAsync();
		}

		/// <summary>
		/// Asynchronous handler activated when the user clicks the Login button.
		/// </summary>		
        private async void LoginButton_ClickAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

				//Get the user oauth token
				OAuthTokenDetail oauthTokenDetail = await ClientLibraryFacade.LoginAsync(
					LoginIdTextBox.Text,
					PasswordTextBox.Text,
					ClientIdTextBox.Text);

				//Get the user company expense configuration needed to submit expense reports.
				var groupConfig = await ClientLibraryFacade.GetGroupConfigurationAsync();
				
				//Determine the default expense policy out of the expense configuration, 
				//so that the default policy will be selected by default on the UI.
				var policies = groupConfig.Policies;
				int defaultPolicyIndex = -1;
				for(int i = 0; i < policies.Length; i++)
				{
					if (policies[i].IsDefault.Value)
					{
						defaultPolicyIndex = i;
						break;
					}
				}

				//Display the list of expense policies obtained from the company configuration
				//and select the default policy
				ExpensePolicyListBox.DisplayMember = "Name";
				ExpensePolicyListBox.Items.AddRange(groupConfig.Policies);
				if (defaultPolicyIndex != -1) ExpensePolicyListBox.SelectedIndex = defaultPolicyIndex;

				//Display the list of allowed payment types obtained from the company configuration.
				PaymentTypeComboBox.DisplayMember = "Name";
				PaymentTypeComboBox.Items.AddRange(groupConfig.PaymentTypes);
				if (groupConfig.PaymentTypes.Length > 0) PaymentTypeComboBox.SelectedIndex = 0;

				//Display the oauth token obtained from the user login.
				OAuthTokenTextBox.Text = oauthTokenDetail.AccessToken;
				CreateEverythingButton.Enabled = true;
            }
            catch (Exception except)
            {
                DisplayException(except);
            }
            finally {
                this.Cursor = Cursors.Default;
            }
        }

		/// <summary>
		/// Refresh the displayed list of Expense Types, which are allowed for the selected expense policy.
		/// </summary>
        private void ExpensePolicyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExpenseTypeComboBox.DisplayMember = "Name";
            ExpenseTypeComboBox.Items.AddRange(((Policy)(ExpensePolicyListBox.SelectedItem)).ExpenseTypes);
            ExpenseTypeComboBox.SelectedIndex = 0;
        }

		/// <summary>
		/// Open a dialog box to select the receipt image file.
		/// </summary>
		private void ExpenseEntryFileImageButton_Click(object sender, EventArgs e)
		{			
			openEntryImageFileDialog2.Filter = "Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png|Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
			DialogResult diaResult = openEntryImageFileDialog2.ShowDialog();
			if (diaResult != DialogResult.Cancel) ExpenseEntryFileImagePathTextBox.Text = openEntryImageFileDialog2.FileName;
		}

        private void CreateEverythingButton_Click(object sender, EventArgs e)
        {
            CreateReportAsync();
        }

		/// <summary>
		/// Asynchronous handler activated when the user clicks the Create Report button.
		/// </summary>
        private async void CreateReportAsync()
        {
            try
            {
				string filePath = ExpenseEntryFileImagePathTextBox.Text;
				ReceiptFileType fileType = ReceiptFileType.Jpeg;
				byte[] expenseImageData = null;

				//Read the byte array out of the selected image file, and figure out which image type it is.
				if (!string.IsNullOrWhiteSpace(filePath))
				{
					expenseImageData = System.IO.File.ReadAllBytes(filePath);
					string fileTypeString = Path.GetExtension(filePath);
					if (fileTypeString.StartsWith(".")) fileTypeString = fileTypeString.Substring(1);
					if (fileTypeString.ToUpper() == "JPG") fileTypeString = "JPEG";
					Enum.TryParse<ReceiptFileType>(fileTypeString, true, out fileType);
				}

                this.Cursor = Cursors.WaitCursor;

				//Create a report, with one expense entry, and with one receipt image attached to the entry.
                string reportId = await ClientLibraryFacade.CreateReportWithImageAsync(
                    ReportNameBox.Text,
                    VendorDescriptionTextBox.Text,
                    Convert.ToDecimal(TransactionAmountTextBox.Text),
                    TransactionCurrencyTextBox.Text,
                    ((ExpenseType)(ExpenseTypeComboBox.SelectedItem)).Code,
                    Convert.ToDateTime(TransactionDateTextBox.Text),
                    ((PaymentType)(PaymentTypeComboBox.SelectedItem)).ID,
                    expenseImageData,
					fileType);

                MessageBox.Show("Success creating report!!" + Environment.NewLine + "ReportID: " + reportId);
            }
            catch (Exception except)
            {
                DisplayException(except);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

		//Display details of the exception.
		public static void DisplayException(Exception e)
		{
			string msg = e.GetType().ToString() + " " + Environment.NewLine;
			msg += e.Message + " " + Environment.NewLine;

			var concurException = e as ConcurHttpException;
			if (concurException != null) msg += concurException.HttpStatusCode.ToString();

			MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			TransactionDateTextBox.Text = DateTime.Now.ToString();
			CreateEverythingButton.Enabled = false;
		}

		public MainForm()
		{
			InitializeComponent();
		}

    }
}


