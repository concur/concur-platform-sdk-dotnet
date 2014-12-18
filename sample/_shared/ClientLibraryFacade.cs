using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concur.Connect.V3.Serializable;
using Concur.Authentication;
using Concur.Connect;
using Concur.Util;
using System;

namespace ConcurPlatformSdkSample
{
	/// <summary>
	/// In the sample app, all code that accesses the SDK library is isolated in this class.
	/// So if you just want to see which SDK classes and methods we use in order to implement this sample you
	/// can simply focus on reading the code below. Any other code in this sample is simply dealing with
	/// reading and writing from/to UI controls or file system.
	/// </summary>
	class ClientLibraryFacade
	{
		// All the Concur Platform version 3.0 API can be accessed via the serviceV3 variable below.
		// Unfortunately we still have some legacy functionality in Concur Platform version 1.0 which wasn't fully
		// incorporated in version 3.0, so that's the reason why we need the serviceV1 variable below to access
		// the old API.
		static Concur.Connect.V3.ConnectService serviceV3;
		static Concur.Connect.V1.ConnectService serviceV1;

		/// <summary>
		/// This facade method shows how to use the SDK to obtain an oauth token (with some extra details) out of given LoginID/Password/ClientID parameters.
		/// It also shows how you can instantiate service objects for versions 1.0 and 3.0 of Concur Platform API.
		/// </summary>
		/// <param name="loginId">This is the Email/UserName entered by the user when he/she signin at https://developer.concur.com/ </param>
		/// <param name="password">This is the Password used by the user when he/she signin at https://developer.concur.com/ </param>
		/// <param name="clientId">This is the oauth client id (required to identify the application) and needed to generate an oauth token </param>
		/// <returns>OAuthTokenDetail object, which encapsulates details of the oauth token obtained for the current user</returns>
		public static async Task<OAuthTokenDetail> LoginAsync(string loginId, string password, string clientId)
		{
			var authService = new AuthenticationService();
			OAuthTokenDetail oauthDetail =  await authService.GetOAuthTokenAsync(loginId, password, clientId);

			serviceV3 = new Concur.Connect.V3.ConnectService(oauthDetail.AccessToken, oauthDetail.InstanceUrl);
			serviceV1 = new Concur.Connect.V1.ConnectService(oauthDetail.AccessToken, oauthDetail.InstanceUrl);
			return oauthDetail;
		}
		
		/// <summary>
		/// This facade method shows how to use the SDK to get the expense group configurartion object for the current user.
		/// The returned object encapsulates the user's company configuration, needed to submit a report. 
		/// Notice that the oauth credential of the current user was provided when the service object was instantiated,
		/// so the service object always makes calls on the behalf of that user.
		/// </summary>
		/// <returns>ExpenseGroupConfiguration object</returns>
		public static async Task<ExpenseGroupConfiguration> GetGroupConfigurationAsync()
		{
			return (await serviceV3.GetExpenseGroupConfigurationsAsync()).Items[0];
		}
			
		/// <summary>
		/// This facade method shows how to use the SDK to: 
		/// * Create an expense report
		/// * Create an expense entry in the report
		/// * Create/attach an image to the expense entry
		/// </summary>
		/// <param name="reportName">Name chosen for the report. E.g. "Concur DevCon Expenses".</param>
		/// <param name="vendorDescription">Name/Description of the expense entry vendor. E.g. "Starbucks".</param>
		/// <param name="transactionAmount">Transaction amount for the expense entry. E.g. "12.44". </param>
		/// <param name="transactionCurrencyCode">Transaction currency code for the expense entry. E.g. "USD". </param>
		/// <param name="expenseTypeCode">Expense type code for the expense entry. The list of possible codes is obtained from the ExpenseGroupConfiguration object. E.g. "BRKFT". </param>
		/// <param name="transactionDate">Transaction date for the expense entry.</param>
		/// <param name="paymentTypeId">Payment type ID for the expense entry. The list of possible IDs is obtained from the ExpenseGroupConfiguration object, e.g. "nF0xyzYB6fmn2rKfJN8JMXbeF2QA". </param>
		/// <param name="expenseImageData">Byte array containing the expense receipt image data. This is usually obtained by reading the contents of an image file.</param>
		/// <param name="imageType">Type of the image whose bytes were provided by the above parameter.</param>
		/// <returns>The ID of the created report</returns>
		public static async Task<string> CreateReportWithImageAsync(
			string reportName,
			string vendorDescription,
			decimal? transactionAmount,
			string transactionCurrencyCode,
			string expenseTypeCode,
			DateTime? transactionDate,
			string paymentTypeId,
			byte[] expenseImageData,
			ReceiptFileType imageType)
		{
			var report = await serviceV3.CreateExpenseReportsAsync(new ReportPost() { Name = reportName });
			var reportEntry = await serviceV3.CreateExpenseEntriesAsync(new EntryPost()
				{
					VendorDescription = vendorDescription,
					TransactionAmount = transactionAmount,
					TransactionCurrencyCode = transactionCurrencyCode,  //e/g "USD",
					ExpenseTypeCode = expenseTypeCode,     //e.g. "BRKFT", "BUSML",
					TransactionDate = transactionDate,
					PaymentTypeID = paymentTypeId,     //e.g. "nF0xyzYB6fmn2rKfJN8JMXbeF2QA"
					ReportID = report.ID
				});
			if (expenseImageData != null) await serviceV1.CreateExpenseEntryReceiptImagesAsync(expenseImageData, imageType, reportEntry.ID);
			return report.ID;
		}
	}		
}