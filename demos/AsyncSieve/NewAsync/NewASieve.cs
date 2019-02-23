using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

class Sieve {
  async void AsyncCall(int maxval) {
    int count;

    count = await Task.Run<int>(() => CountPrimes(maxval));
    Console.WriteLine();
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
    int maxval, t=1;

    Console.Write("Number of primes from 2 to ");
    line = Console.ReadLine();
    maxval = Convert.ToInt32(line);
    Sieve sv = new Sieve();
    sv.AsyncCall(maxval);
    Console.WriteLine("Press return to exit ...");
    while (!Console.KeyAvailable) {
      Thread.Sleep(1000);
      Console.Write("..{0}", t++);
    }
    Console.ReadKey(true);
  }
}
