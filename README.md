Concur Platform SDK for .NET Framework and Xamarin
==================================================

This SDK contains the following:
* .NET Portable Class Library (which also works on Xamarin) for abstracting details on how to call and consume Concur web services. The portable library contains intellisense in its classes, methods, and parameters; making it very easy to discover how to use the library. 
* Sample of a working app in Android that uses the portable library to call Concur web services.
* Sample of a working app in iOS that uses the portable library to call Concur web services.
* Sample of a working app in Windows that uses the portable library to call Concur web services.

To try this library, you may want to create a sandbox company at Concur. [Follow the registration process described here](https://developer.concur.com/register) to create a sandbox company. The user credentials obtained via the registration process can be used with the portable library to access data in the sandbox company.

## Installation

To install Concur Platform from the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console), run the following command:
    Install-Package ConcurPlatform
Otherwise, to install Concur Platform using the [Nuget command line tool](https://docs.nuget.org/consume/command-line-reference), run the following command:
    nuget install ConcurPlatform

NOTE: Navigate to http://www.nuget.org/packages/ConcurPlatform/ if you want to see further information about the ConcurPlatform package.




 


 abstracting calls for the following web services in the concur platform:


SDK for the [Concur Platform](http://developer.concur.com). For more information on the set of platform services, see the [Web services overview](https://developer.concur.com/get-started/webservices-overview) document on the developer portal.
Register for a [developer Sandbox here](https://developer.concur.com/register).








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
