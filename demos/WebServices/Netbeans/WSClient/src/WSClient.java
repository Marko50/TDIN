import apm.feup.org.ws.ArrayOfDouble;
import apm.feup.org.ws.CalculatorX0020WebX0020Service;
import apm.feup.org.ws.CalculatorX0020WebX0020ServiceSoap;
import org.feup.apm.ws.Rand;
import org.feup.apm.ws.Rand_Service;
import java.util.List;
import javax.xml.ws.Holder;

public class WSClient {
  /**
   * @param args the command line arguments
   */
  public static void main(String[] args) {
    double val;
    int k;
    List<Double> list;
    ArrayOfDouble vals = new ArrayOfDouble();
    Holder<Double> mx = new Holder<>();
    Holder<Double> mn = new Holder<>();
    Holder<Integer> nr = new Holder<>();
    
    CalculatorX0020WebX0020Service serviceNET = new CalculatorX0020WebX0020Service();
    CalculatorX0020WebX0020ServiceSoap portNET = serviceNET.getCalculatorX0020WebX0020ServiceSoap();
    Rand_Service serviceJava = new Rand_Service();
    Rand portJava = serviceJava.getRandPort();
    
    System.out.println("Calling sqroot(3.0) in .NET WS");
    val = portNET.sqroot(3.0);
    System.out.println("sqroot(3.0) = " + val + "\n");
    list = portJava.getRandArray(100);
    System.out.println("Generated " + list.size() + " random doubles using a Java WS");
    for (k=0; k<100; k++)
      vals.getDouble().add(list.get(k));
    portNET.maxmin(vals, mx, mn, nr);
    System.out.println("Found (.NET WS) the max and min of the " + nr.value + " doubles: mx = " + mx.value + " mn = " + mn.value);
  }
}