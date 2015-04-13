Concur Platform SDK for .NET and Xamarin
==================================================

This SDK contains the following:
* Source code for the ConcurPlatform library. This is a .NET Portable Class Library, which also works on Xamarin projects, and which abstracts details on how to call and consume Concur Platform web services.
* Source code for an Android sample app that uses the ConcurPlatform library to call Concur web services.
* Source code for an iOS sample app that uses the ConcurPlatform library to call Concur web services.
* Source code for a Windows sample app that uses the ConcurPlatform library to call Concur web services.


# Nuget Package

The ConcurPlatform library source code (included in this SDK) is already compiled and uploaded on [http://www.nuget.org/packages/ConcurPlatform](http://www.nuget.org/packages/ConcurPlatform) as a Nuget package named "*ConcurPlatform*". __NOTE: this package targets .NET Framework version 4.5 or later, so make sure your project properties targets this version of .NET Framework otherwise this package may not be listed in the results when you search for it from inside your development project.__


# Installation

## Referencing our Nuget Package from Visual Studio

To reference our Nuget package from any Visual Studio project, [follow the instructions described here](http://docs.nuget.org/consume/package-manager-dialog) and use "*ConcurPlatform*" as the package name to search for. Also make sure your development project targets .NET Framework version 4.5 or later otherwise the ConcurPlatform package may not be found when searched for. Anyway, for your information, __we have seen sometimes a buggy behavior in VS where the only way for it to successfully find and reference the package was by using Package Manager Console [as explained here](http://docs.nuget.org/consume/package-manager-console).__

## Referencing our Nuget Package from Xamarin

To reference our Nuget package from any Xamarin project, [follow the instructions described here](http://developer.xamarin.com/guides/cross-platform/application_fundamentals/nuget_walkthrough) and use "*ConcurPlatform*" as the package name to search for.


## Building our SDK Samples

The samples provided in this SDK reference our Nuget package. Depending on how you choose to compile the samples (Xamarin versus Visual Studio, IDE version, build versus rebuild, etc.) the compilation may fail because it may not succeed to resolve the reference to our Nuget package. If you get an error when trying to compile the samples, simply reference again the Nuget package as explained in the above sections.


# User Credentials

The ConcurPlatform library requires user credentials in order to make web services calls on the behalf of a user. If you want, you can obtain user credentials to a brand new sandbox company at Concur by [following the sandbox registration process described here](https://developer.concur.com/register).  


# Hello Expense Report

If you just want a quick and small sample showing how to start using the ConcurPlatform library then the following code snippet shows how to create an empty expense report named "Hello Expense Report".

    using Concur.Connect.V3;
    using Concur.Connect.V3.Serializable;
    . . .
    static async void HelloExpenseReportSample()
    {
        var concur = new ConnectService(accessToken: <b>ProvideHereYourOAuthAccessToken</b>);
        var report = await concur.CreateExpenseReportsAsync( new ReportPost() { Name = "Hello Expense Report" } );
        Console.WriteLine("Succefully created a report with ID = " + report.ID);
    }


## Web Services Abstracted by ConcurPlatform Library

The following REST web services are abstracted by our ConcurPlatform library:

1. Authentication Services. Specifically, the [Native Flow Token service](https://developer.concur.com/oauth-20/native-flow), the [Refresh Token service](https://developer.concur.com/oauth-20/refreshing-access-tokens), and the [Revoke Token service](https://developer.concur.com/oauth-20/working-access-tokens/revoking-access-tokens).

2. [Concur API version 3.0](https://www.concursolutions.com/api/docs/index.html).  

3. [Image Services version 1.0](https://developer.concur.com/imaging/image-resource/image-resource-post). Specifically the services for posting an image to a report, posting an image to a report entry, and posting an image to an invoice (also know as *payment request*).









## --------------------------- BEGIN Parking Lot Text ---------------------------------------

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

Otherwise, to install Concur Platform using the [Nuget command line tool](https://docs.nuget.org/consume/command-line-reference), run the following command:

    nuget install ConcurPlatform

NOTE: Navigate to http://www.nuget.org/packages/ConcurPlatform/ if you want to see further information about the ConcurPlatform package.

## --------------------------- END Parking Lot Text ---------------------------------------






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
