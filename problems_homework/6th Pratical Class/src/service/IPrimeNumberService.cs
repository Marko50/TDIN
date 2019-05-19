using System.ServiceModel;

namespace PrimeNumberService{
    public class IPrimeNumberService : PrimeNumberInterface{
        public int getNumberOfPrimeNumbers(int range){
            int numPrimes = 0;
            for (int x = 2; x < range; x++){
                int isPrime = 0;
                for (int y = 1; y < x; y++){
                    if (x % y == 0)
                        isPrime++;
                    if(isPrime == 2) break;
                }
                if(isPrime != 2)
                    numPrimes++;
                isPrime = 0;
            }
            return numPrimes;
        }
    }
}