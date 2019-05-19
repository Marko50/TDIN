using System;
using TestServiceClient.StockServiceReference;

namespace TestServiceClient {
  class Program {
    static void Main(string[] args) {
      string ticker = "IBM";

      Console.WriteLine("Asking for {0}", ticker);
      StockServiceClient proxy = new StockServiceClient();
      Console.ReadLine();
      do {
        Info info = proxy.GetStockPrice(ticker);
        Console.WriteLine("Response:  name = {0}  value = {1:F2}", info.name, info.value);
        Console.WriteLine("(A)gain ?");
      } while (Console.ReadKey(true).KeyChar == 'a');
      proxy.Close();
    }
  }
}
