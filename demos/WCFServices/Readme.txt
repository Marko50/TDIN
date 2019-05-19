This demo contains 1 VS solution with 4 projects, but two of them are independent of the other two.
One of the projects is a web site (TestWebWCF).

First pair
==========

- TestServiceHost

This is a project containing a Windows GUI application hosting a WCF service.
The service has a contract (IStockService.cs) and an implementation (StockService.cs).
It also contains the configuration file app.config (installed automatically as
SotckService.exe.config).
The service was added to the project after the creation of a Windows Form application
using "Add New Item ..." and selecting "WCF Service".
This creates the service contract and implementation files with some skeleton code.
The app.config file is also filled with a default configuration with the basicHttpBinding.
The main endpoint binding was changed using the service configuration editor available
in the VS Tools menu (WCF Service Configuration Editor) or by right clicking in app.config.
With this editor the default binding was changed to the also predefined netTcpBinding.
This binding uses the tcp protocol and needs a base TCP address.
In the host section the following address was added:
  net.tcp://localhost:9000/TestServiceHost/StockService/  (the netTcpBinding does not
specify any additional segment).
The service metadata (needed for building the proxies in the client) is made available
in the configuration file through the definition of a specific http (mex) endpoint (already
put in the app.config when the service was added with "Add New Item...").

- TestServiceClient

This is a project consuming the service in a console application.
The proxy and configuration file were generated through the "Add Service Reference..."
option in the context menu of the project. We must supply the address of the Endpoint
that returns the description of the service:
(http://localhost:8733/Design_Time_Addresses/TestServiceHost/StockService).
The service host must be running and open to generate the proxy and configuration file.

Note: Windows now restricts the creation of http ports and addresses to administrators
(applications that serve on http ports must run in administrator mode or on a pre-registered port).
Nevertheless there is a port and URL allowed for tests: for the recent versions of windows it
is htpp://localhost:8733/Design_Time_Addresses/

Second pair
===========

- TestWebWCF 

This is a web site hosting a wcf service. First we created an empty web site (not a web
application) and then we added with "Add New Item..." a "WCF Service" to the site.
This creates the App_Code directory and the service contract and implementation files inside.
It also creates the <Service>.svc file that indicates that this site is a WCF server.
The Web.config file is also filled with the default service configuration parameters.
(by default the service uses the basicHttpProtocol, compatible with XML web services).
In this case the service (called MachineService) has a method to retrieve the machine
name and OS name.

- WebWCFClient

This is a simple console application calling the service.
But instead of using a WCF proxy we included a XML web service proxy to show the compatibility.
The included proxy is then a XML WS proxy built by using the option:
"Add Service Reference... / Advanced... / Add Web Reference ..." from the project context
menu.
The address of the service, when running on the IIS Express server, from VS, was:
"http://localhost:52934/MachineService.svc"

                         