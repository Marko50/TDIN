/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package PrimeNumberWebService;

import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import java.util.List;
import java.util.ArrayList;

/**
 *
 * @author root
 */
@WebService(serviceName = "PrimeNumberWebService")
public class PrimeNumberWebService {

    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "hello")
    public String hello(@WebParam(name = "name") String txt) {
        return "Hello " + txt + " !";
    }
    
    @WebMethod(operationName = "numberOfPrimeNumbersInRange")
    public int numberOfPrimeNumbersInRange(@WebParam(name = "range") int range){
        // loop through the numbers one by one
        List<Integer> primes = new ArrayList<>();
        for (int i = 2; i < range; i++) {
            boolean isPrimeNumber = true;
            // check to see if the number is prime
            for (int j = 2; j < i; j++) {
                if (i % j == 0) {
                    isPrimeNumber = false;
                    break; // exit the inner for loop
                }
            }
            // print the number if prime
            if (isPrimeNumber) {
                primes.add(i);
            }
        }
        return primes.size();
    }
}
