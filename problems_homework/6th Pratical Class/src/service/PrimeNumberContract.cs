using System.ServiceModel;

namespace PrimeNumberService{
    [ServiceContract]
    public interface PrimeNumberInterface{
        [OperationContract]
        int getNumberOfPrimeNumbers(int range);
    }
}