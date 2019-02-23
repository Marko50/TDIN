using System;
using System.Collections;

class Sieve {
  void SyncCall(int maxval) {
    int count;

    count = CountPrimes(maxval);
    Console.WriteLine("Nr. of primes = {0}", count);
  }
  
  int CountPrimes(int maxval) {
    if (maxval < 2)
      return 0;
    
    BitArray bits = new BitArray(maxval+1, true);

    int limit = (int) Math.Ceiling(Math.Sqrt(maxval));
    for (int k=2; k<=limit; k++)
      if (bits[k])
        for (int i=2*k; i<=maxval; i+=k)
          bits[i] = false;
    int count = 0;
    for (int k=2; k<=maxval; k++)
      if (bits[k])
        count++;
    return count;
  }

  static void Main() {
    string line;
    int maxval;

    Console.Write("Number of primes from 2 to ");
    line = Console.ReadLine();
    maxval = Convert.ToInt32(line);
    Sieve sv = new Sieve();
    sv.SyncCall(maxval);
    Console.WriteLine("Press return to exit ...");
    Console.ReadLine();
  }
}
