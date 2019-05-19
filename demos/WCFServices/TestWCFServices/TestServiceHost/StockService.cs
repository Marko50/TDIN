using System;

namespace TestServiceHost {
  public class StockService : IStockService {
    public Info GetStockPrice(string ticker) {
      Info stock = new Info();
      Random rgen = new Random();
      stock.name = ticker;
      stock.value = 9.50 + 10.0 * (rgen.NextDouble() - 0.5);
      return stock;
    }
  }
}
