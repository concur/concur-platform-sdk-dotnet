Concur Platform SDK for .NET Framework and Xamarin
==================================================

This SDK contains the following:
* Source code for the __ConcurPlatform library__. This is a __.NET Portable Class Library__, which also works on __Xamarin__ projects, and which abstracts details on how to call and consume Concur Platform web services.
* Source code for an __Android__ sample app that uses the ConcurPlatform library.
* Source code for an __iOS__ sample app that uses the ConcurPlatform library.
* Source code for a __Windows__ sample app that uses the ConcurPlatform library.


## NuGet Package

The ConcurPlatform library source code (included in this SDK) is already compiled and uploaded on [http://www.nuget.org/packages/ConcurPlatform](http://www.nuget.org/packages/ConcurPlatform) as a NuGet package named "*ConcurPlatform*". __NOTE: this package targets .NET Framework version 4.5 or later, so make sure your project properties targets this version of .NET Framework otherwise this package may not be listed in the results when you search for it from inside your development project.__


## Installation

#### Referencing our NuGet Package from Visual Studio

To reference our NuGet package from any Visual Studio project, [follow the instructions described here](http://docs.nuget.org/consume/package-manager-dialog) and use "*ConcurPlatform*" as the package name to search for. Also make sure your development project targets .NET Framework version 4.5 or later otherwise the ConcurPlatform package may not be found when searched for. Anyway, for your information, __we have seen sometimes a buggy behavior in VS where the only way for it to successfully find and reference a package is by using Package Manager Console [as explained here](http://docs.nuget.org/consume/package-manager-console).__

#### Referencing our NuGet Package from Xamarin

To reference our NuGet package from any Xamarin project, [follow the instructions described here](http://developer.xamarin.com/guides/cross-platform/application_fundamentals/nuget_walkthrough) and use "*ConcurPlatform*" as the package name to search for.


#### Building our SDK Samples

The samples provided in this SDK reference our NuGet package. Depending on how you choose to compile the samples (Xamarin versus Visual Studio, IDE version, build versus rebuild, etc.) the compilation may fail because it may not succeed to resolve the reference to our NuGet package. If you get an error when trying to compile the samples, simply reference again the NuGet package as explained in the above sections.


## User Credentials and Sandbox Company

The ConcurPlatform library requires user credentials (e.g. OAuth access token) in order to make web services calls on the behalf of a user. If you want, you can obtain user credentials to a brand new sandbox company at Concur by [following the sandbox registration process described here](https://developer.concur.com/register).  


## Hello Expense Report Sample

If you just want to see a small C# sample of how to use the ConcurPlatform library then the following code sample shows how to create an empty expense report named "Hello Expense Report".

```C#
using Concur.Util;
using Concur.Connect.V3;
using Concur.Connect.V3.Serializable;
. . .
static async void HelloExpenseReportSample()
{
    var serviceV3 = new Concur.Connect.V3.ConnectService( __ProvideHereYourOAuthAccessToken__ );
    var report = await serviceV3.CreateExpenseReportsAsync(
        new ReportPost() { Name = "Hello Expense Report" }
    );
    Console.WriteLine("Successfully created a report with ID = " + report.ID);

    /*** Paste here the code to submit a receipt to the report header ***/
}
```

If you want to enrich the above sample and make it submit a receipt image to the report header then copy and paste the code snippet displayed below to the bottom of the above sample. 

```C#
    var serviceV1 = new Concur.Connect.V1.ConnectService( __ProvideHereYourOAuthAccessToken__ );
    byte[] expenseImageData = new System.Net.WebClient().DownloadData("https://raw.githubusercontent.com/concur/concur-platform-sdk-dotnet/master/sample/_shared/TestReceipt.jpg");
    var receiptImage = await serviceV1.CreateExpenseReportReceiptImagesAsync(expenseImageData, ReceiptFileType.Jpeg, report.ID);
    if (receiptImage != null) Console.WriteLine("Successfully submitted a receipt to the report header");
```

If you want to see how to create expense entries for a report, how to submit receipt images to expense entries, how to access company configuration, how to determine allowed expense policies, how to determine allowed payment types, or how to determine allowed expense types, please browse our Windows, Android, or iOS [samples](https://github.com/concur/concur-platform-sdk-dotnet/tree/master/sample).

# ConcurPlatform Library in Details

### Classes

All classes in ConcurPlatform library have detailed intellisense documentation. Intellisense makes it trivial to know which class instance is expected as parameter or returned by a method. Therefore, the only 3 class names that you need to know in advance are the "service classes". They aren't referenced by any other class and they represent the Concur web services. They are:

* Concur.Connect.__V3.ConnectService__ - This service class should suffice for virtually everything you need to do. It simply abstracts calls to [Concur API version 3.0](https://www.concursolutions.com/api/docs/index.html) which is where the large majority of our web services reside. 
* Concur.Connect.__V1.ConnectService__ - This service class is only useful if you need to submit receipts to an expense report, to an expense entry, or to an invoice (A.K.A. payment request). This service class was only incorporated to the ConcurPlatform library because we wanted to isolate in this class any functionality related to the old version 1.0 of Concur web services which were not available yet in version 3.0.
* Concur.Authentication.__AuthenticationService__ - This service class is only useful if you need to manage OAuth tokens. It abstracts calls to the [Native Flow Token service](https://developer.concur.com/oauth-20/native-flow), the [Refresh Token service](https://developer.concur.com/oauth-20/refreshing-access-tokens), and the [Revoke Token service](https://developer.concur.com/oauth-20/working-access-tokens/revoking-access-tokens). You shouldn't need to use this service class in scenarios where you already have an OAuth token and you aren't planning to revoke or refresh it.

The [SDK samples](https://github.com/concur/concur-platform-sdk-dotnet/tree/master/sample) exemplifies the usage of the above classes. [Click here](https://github.com/concur/concur-platform-sdk-dotnet/blob/master/sample/_shared/ClientLibraryFacade.cs) to jump directly to a C# file shared by all samples and where all 3 classes above are instantiated and used. Otherwise, see the [Hello Expense Report Sample](# hello-expense).

#### Method Name Pattern

All methods in ConcurPlatform libary follow a naming pattern and they all have detailed intellisense documentation. Once you see a couple of samples, you should be able to intuitively discover the method or parameter you need to use just by letting auto complete-word and intellisense drive you. 

All methods in our library follow this naming formation pattern: **CRUD operation name** + **resource name** + **optional parameter name differentiator** + **optional async keyword**. For example: 
* Get ExpenseEntries Async 
* Create ExpenseEntries Async 
* Update ExpenseEntries ById Async
* Delete ExpenseEntries ById Async

The *CRUD operation names* are the well known __Get__, __Create__, __Update__, and __Delete__. So if you need to get a resource you type __Get__ and intellisense will show you all resources available for that operation. The same applies if you need to Create, Update or Delete, simply type the operation name and let intellisense tell you which resources supports that operation. Unfortunately not all resources support already all 4 operations. NOTE: AuthenticationService also supports __Revoke__ as an exceptional operation name and that can also be noticed using intellisense. 

The *resource names* are based on usual names for Expense and Travel business. They are the following:

* CommonConnectionRequests
* CommonListItems
* CommonLists
* CommonLocations
* CommonSuppliers
* ExpenseAllocations
* ExpenseAttendees
* ExpenseeAttendeeTypes
* ExpenseDigitalTaxInvoices
* ExpenseEntries
* ExpenseEntriesAttendeeAssociations
* ExpenseExchangeRate
* ExpenseGroupConfiguration
* ExpenseItemizations
* ExpenseReceiptImage
* ExpenseReportDigests
* ExpenseReports
* InsightsLateBookings
* InsightsOpportunities
* InvoicePurchaseOrder
* InvoiceSalesTaxValidationRequest
* InvoiceVendors
* QuickExpenses
* TravelRequests
* --------------------------
* ExpenseEntryReceiptImages
* ExpenseInvoiceReceiptImages
* ExpenseReportReceiptImages
* --------------------------
* OAuthAccessTokens
* OAuthTokens
* RefreshedOAuthTokens

To avoid future issues with languages that might not support overloading we include parameter names in some method names, for example:
* GetExpenseReports**ById**Async(string **id**, ...)
* DeleteCommonListItems**ByIdByListId**Async(string **id**, string **listId**, ...)
* DeleteInvoiceVendors**ByVendorCodeByAddressCode**Async(string **addressCode**, string **vendorCode**)

And finally, all asynchronous methods end with the **Async** word. Whereas the synchronous methods omit that suffix. NOTE: we intend to deprecate the synchronous methods in the near future as they promote bad practices. The asynchronous methods yield better performance and better energy efficiency (specially in battery powered devices.)


#### Pagination Pattern

TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO








## License

Copyright 2014 [Concur](http://www.concur.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.







## --------------------------- BEGIN Parking Lot Text ---------------------------------------



#### Services Abstracted by the ConcurPlatform Library
The following REST web services are abstracted by our ConcurPlatform library:

1. Authentication Services. Specifically, the [Native Flow Token service](https://developer.concur.com/oauth-20/native-flow), the [Refresh Token service](https://developer.concur.com/oauth-20/refreshing-access-tokens), and the [Revoke Token service](https://developer.concur.com/oauth-20/working-access-tokens/revoking-access-tokens).

2. [Concur API version 3.0](https://www.concursolutions.com/api/docs/index.html).  

3. [Image Services version 1.0](https://developer.concur.com/imaging/image-resource/image-resource-post). Specifically the services for posting an image to a report, posting an image to a report entry, and posting an image to an invoice (also know as *payment request*).




http://xamarin.com/faq
Xamarin faq about not being able to work with non-express edition.
 
The Client Library comprises:
API Version 3.0   https://www.concursolutions.com/api/docs/index.html#!/DigitalTaxInvoices
Authentication services https://developer.concur.com/oauth-20/working-access-tokens
Some API from Version 1.0 regarding imaging https://developer.concur.com/api-documentation/web-services/imaging/image-resource/image-resource-post
 
Async pattern support in the latest .NET 4.5.*(C# 5.0).
 
We recommend the use of Async methods for everything. We intend to remove the synchronous method in the future. Async saves energy (battery) and it is the recommended way for all Mobile or Server-scalable applications.
 
This share has the whole solution \\990-02785\SheldonShare
 
 
Client Library at GitHub:  https://github.com/concur/concur-platform-sdk-dotnet
 
NuGet package:  http://www.nuget.org/packages/ConcurPlatform/ 
 
-----------------------------------------------------------------------------------------------------------------------------------

abstracting calls for the following web services in the concur platform:

SDK for the [Concur Platform](http://developer.concur.com). For more information on the set of platform services, see the [Web services overview](https://developer.concur.com/get-started/webservices-overview) document on the developer portal.
Register for a [developer Sandbox here](https://developer.concur.com/register).


To reference the 

The source code contained in this repository is self-contained and it doesn't have external references.

## User Credentials

The portable library requires user credentials in order to make web services calls on the behalf of a user. If you want, you can obtain user credentials to a brand new sandbox company at Concur by [following the sandbox registration process described here](https://developer.concur.com/register).  

You need user credentials in order to call 

To install Concur Platform from inside the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console), run the following command:

    Install-Package ConcurPlatform

Otherwise, to install Concur Platform using the [NuGet command line tool](https://docs.nuget.org/consume/command-line-reference), run the following command:

    nuget install ConcurPlatform

NOTE: Navigate to http://www.nuget.org/packages/ConcurPlatform/ if you want to see further information about the ConcurPlatform package.


## Web Services Abstracted by ConcurPlatform Library


## --------------------------- END Parking Lot Text ---------------------------------------





