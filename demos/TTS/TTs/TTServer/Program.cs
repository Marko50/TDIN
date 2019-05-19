using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TTServer {
    class Program {
        static void Main() {
            WebServiceHost host = new WebServiceHost(typeof(TTService.TTService));
            host.Open();
            Console.WriteLine("TT service running");
            Console.WriteLine("Press ENTER to stop the service");
            Console.ReadLine();
            host.Close();
        }
    }
}
