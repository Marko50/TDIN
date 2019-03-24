/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.feup.apm.ws;

import java.util.Random;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

/**
 *
 * @author apm
 */
@WebService(serviceName = "Rand")
public class Rand {

  /**
   * Web service operation
   */
  @WebMethod(operationName = "getRandArray")
  public double[] getRandArray(@WebParam(name = "nr") int nr) {
    double[] res = new double[nr];
    Random rnd = new Random(System.nanoTime());

    for (int k=0; k<nr; k++)
      res[k] = rnd.nextDouble();
    return res;
  }
}
