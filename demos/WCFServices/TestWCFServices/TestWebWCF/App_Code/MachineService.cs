using System;
using System.ServiceModel;

public class MachineService : IMachineService {
  public string getMachineNameAndOS() {
    string answer = Environment.MachineName;
    answer += (" - " + Environment.OSVersion.ToString());
    return answer;
  }
}
