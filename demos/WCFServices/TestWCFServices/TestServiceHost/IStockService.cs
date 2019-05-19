using System.Runtime.Serialization;
using System.ServiceModel;

namespace TestServiceHost {
  [ServiceContract]
  public interface IStockService {
    [OperationContract]
    Info GetStockPrice(string ticker);
  }

  [DataContract]
  public class Info {
    [DataMember]
    public string name;
    [DataMember]
    public double value;
  }
}
