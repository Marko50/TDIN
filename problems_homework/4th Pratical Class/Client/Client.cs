using System;
public class Client{
    public static void Main(){
        Console.Write("Input the Range number: ");
        string input = Console.ReadLine();
        int range = Int32.Parse(input);
        PrimeNumberWebService primeNumberWebService = new PrimeNumberWebService();
        int num = primeNumberWebService.numberOfPrimeNumbersInRange(range);
        Console.WriteLine("Number: " + num);
    }
}