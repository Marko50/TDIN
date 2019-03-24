
package org.feup.apm.ws;

import java.util.List;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;
import javax.xml.bind.annotation.XmlSeeAlso;
import javax.xml.ws.Action;
import javax.xml.ws.RequestWrapper;
import javax.xml.ws.ResponseWrapper;


/**
 * This class was generated by the JAX-WS RI.
 * JAX-WS RI 2.2.6-1b01 
 * Generated source version: 2.2
 * 
 */
@WebService(name = "Rand", targetNamespace = "http://ws.apm.feup.org/")
@XmlSeeAlso({
    ObjectFactory.class
})
public interface Rand {


    /**
     * 
     * @param nr
     * @return
     *     returns java.util.List<java.lang.Double>
     */
    @WebMethod
    @WebResult(targetNamespace = "")
    @RequestWrapper(localName = "getRandArray", targetNamespace = "http://ws.apm.feup.org/", className = "org.feup.apm.ws.GetRandArray")
    @ResponseWrapper(localName = "getRandArrayResponse", targetNamespace = "http://ws.apm.feup.org/", className = "org.feup.apm.ws.GetRandArrayResponse")
    @Action(input = "http://ws.apm.feup.org/Rand/getRandArrayRequest", output = "http://ws.apm.feup.org/Rand/getRandArrayResponse")
    public List<Double> getRandArray(
        @WebParam(name = "nr", targetNamespace = "")
        int nr);

}
