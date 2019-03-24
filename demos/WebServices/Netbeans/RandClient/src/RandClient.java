import org.feup.apm.ws.Rand_Service;
import org.feup.apm.ws.Rand;
import java.util.List;

public class RandClient {
  /**
   * @param args the command line arguments
   */
  public static void main(String[] args) {
    Rand_Service service = new Rand_Service();
    Rand port = service.getRandPort();

    System.out.println("Getting 10 random numbers from Java WS ...");
    List<Double> rnds = port.getRandArray(10);
    System.out.println("Here they are:");
    for (int k=0; k<10; k++)
      System.out.println(rnds.get(k));
  }
}
