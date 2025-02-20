
package org.feup.apm.ws;

import java.net.MalformedURLException;
import java.net.URL;
import javax.xml.namespace.QName;
import javax.xml.ws.Service;
import javax.xml.ws.WebEndpoint;
import javax.xml.ws.WebServiceClient;
import javax.xml.ws.WebServiceException;
import javax.xml.ws.WebServiceFeature;


/**
 * This class was generated by the JAX-WS RI.
 * JAX-WS RI 2.2.6-1b01 
 * Generated source version: 2.2
 * 
 */
@WebServiceClient(name = "Rand", targetNamespace = "http://ws.apm.feup.org/", wsdlLocation = "http://localhost:8080/WsRandom/Rand?wsdl")
public class Rand_Service
    extends Service
{

    private final static URL RAND_WSDL_LOCATION;
    private final static WebServiceException RAND_EXCEPTION;
    private final static QName RAND_QNAME = new QName("http://ws.apm.feup.org/", "Rand");

    static {
        URL url = null;
        WebServiceException e = null;
        try {
            url = new URL("http://localhost:8080/WsRandom/Rand?wsdl");
        } catch (MalformedURLException ex) {
            e = new WebServiceException(ex);
        }
        RAND_WSDL_LOCATION = url;
        RAND_EXCEPTION = e;
    }

    public Rand_Service() {
        super(__getWsdlLocation(), RAND_QNAME);
    }

    public Rand_Service(WebServiceFeature... features) {
        super(__getWsdlLocation(), RAND_QNAME, features);
    }

    public Rand_Service(URL wsdlLocation) {
        super(wsdlLocation, RAND_QNAME);
    }

    public Rand_Service(URL wsdlLocation, WebServiceFeature... features) {
        super(wsdlLocation, RAND_QNAME, features);
    }

    public Rand_Service(URL wsdlLocation, QName serviceName) {
        super(wsdlLocation, serviceName);
    }

    public Rand_Service(URL wsdlLocation, QName serviceName, WebServiceFeature... features) {
        super(wsdlLocation, serviceName, features);
    }

    /**
     * 
     * @return
     *     returns Rand
     */
    @WebEndpoint(name = "RandPort")
    public Rand getRandPort() {
        return super.getPort(new QName("http://ws.apm.feup.org/", "RandPort"), Rand.class);
    }

    /**
     * 
     * @param features
     *     A list of {@link javax.xml.ws.WebServiceFeature} to configure on the proxy.  Supported features not in the <code>features</code> parameter will have their default values.
     * @return
     *     returns Rand
     */
    @WebEndpoint(name = "RandPort")
    public Rand getRandPort(WebServiceFeature... features) {
        return super.getPort(new QName("http://ws.apm.feup.org/", "RandPort"), Rand.class, features);
    }

    private static URL __getWsdlLocation() {
        if (RAND_EXCEPTION!= null) {
            throw RAND_EXCEPTION;
        }
        return RAND_WSDL_LOCATION;
    }

}
