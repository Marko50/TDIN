Contents of this demo
=====================

The demo contains 4 Visual Studio .NET projects grouped in a single solution and 3 NetBeans projects.

.NET projects
=============
One of the projects (CalcWS) is a Web Site containing a WebService. When deployed (IIS Express) its address should be "http://<machine>:<port>/Calc.asmx"
You should put this project under a WebSites directory inside the user directory where VS stores solution and projects information.
The other 3 projects are under the solution directory (WSServiceAndClient) in the Projects subdirectory.

The Calc project contains the WebService code (Calc.cs), produces a .dll and is referenced by the WebSite CalcWS (the .dll is automatically copied to its Bin directory).

The CalcClient contains a Console client to this WebService. It has a Web Reference to the WebService, automatically building a proxy to it.

The project WSClient is a console client using both the CalcWS WebService and a Java WebService running in a Glassfish server. It contains Web References to both services in order to build automatically their proxies.

Java projects (NetBeans projects)
=================================
The Java projects contain a WebService (generates random doubles) (WSRandom). This WebService is a resource of a Web Application running in the web container of the Glassfish Application Server.
The Web Application should have at least a page (index.jsp). The address of this page, after deployment, should be "http://<machine>:<port>/WSRandom/index.jsp". The WebService acts as a resource with address: "http://<machine>:<port>/WSRandom/Rand".

Another Java project is RandClient a Java console application which calls the Java WebService.

The third and last project is another Java console application (WSClient) which calls the .NET WebService and the Java WebService in a similar way of the .NET project with the same name.