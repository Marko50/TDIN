import java.io.Console;
import java.io.IOException;
import java.io.Reader;
import java.util.BitSet;
import java.util.concurrent.CompletableFuture;

public class JavaASieve {
  
  void AsyncCall(int maxval) {
    CompletableFuture<Integer> result = CompletableFuture.supplyAsync(() -> CountPrimes(maxval));
    result.thenAccept((count) -> PrintCount(count));
  }
  
  void PrintCount(Integer count) {
    System.out.printf("\nNr. of primes = %d\n", count);
  }
  
  int CountPrimes(int maxval) {
    if (maxval < 2)
      return 0;

    BitSet bits = new BitSet(maxval+1);
    bits.set(2, maxval+1);
    int limit = (int) Math.ceil(Math.sqrt(maxval));
    for (int k=2; k<=limit; k++)
      if (bits.get(k))
        for (int i=2*k; i<=maxval; i+=k)
          bits.set(i, false);
	  int count = 0;	  
    for (int k=2; k<=maxval; k++)
	  if (bits.get(k))
		  count++;
    return count;
  }  
  
  public static void main(String[] args) {
    Console console;
    String line;
    int maxval, t = 1;
    
    console = System.console();
    console.printf("Number of primes from 2 to ");
    line = console.readLine();
    maxval = Integer.parseInt(line);
    JavaASieve sv = new JavaASieve();
    sv.AsyncCall(maxval);
    console.printf("Press return to exit ...\n");
    Reader conReader = console.reader();
    try {
      while (!conReader.ready()) {
        Thread.sleep(1000);
        console.printf("..%d", t++);
      }
      conReader.read();
    } catch (IOException | InterruptedException ex) {
        console.printf(ex.getMessage());
    }
  }
}
