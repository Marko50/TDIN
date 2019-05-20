using System;
using System.ServiceModel;

[ServiceContract]
public interface IHostService{
    [OperationContract(IsOneWay = true)]
    void ServiceMethodCall(string param);
}