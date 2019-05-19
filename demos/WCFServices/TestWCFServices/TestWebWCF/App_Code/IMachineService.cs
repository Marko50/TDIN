using System;
using System.ServiceModel;

[ServiceContract]
public interface IMachineService {
  [OperationContract]
  string getMachineNameAndOS();
}
