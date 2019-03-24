
package org.feup.apm.ws;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the org.feup.apm.ws package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _GetRandArray_QNAME = new QName("http://ws.apm.feup.org/", "getRandArray");
    private final static QName _GetRandArrayResponse_QNAME = new QName("http://ws.apm.feup.org/", "getRandArrayResponse");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: org.feup.apm.ws
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link GetRandArrayResponse }
     * 
     */
    public GetRandArrayResponse createGetRandArrayResponse() {
        return new GetRandArrayResponse();
    }

    /**
     * Create an instance of {@link GetRandArray }
     * 
     */
    public GetRandArray createGetRandArray() {
        return new GetRandArray();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link GetRandArray }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://ws.apm.feup.org/", name = "getRandArray")
    public JAXBElement<GetRandArray> createGetRandArray(GetRandArray value) {
        return new JAXBElement<GetRandArray>(_GetRandArray_QNAME, GetRandArray.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link GetRandArrayResponse }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://ws.apm.feup.org/", name = "getRandArrayResponse")
    public JAXBElement<GetRandArrayResponse> createGetRandArrayResponse(GetRandArrayResponse value) {
        return new JAXBElement<GetRandArrayResponse>(_GetRandArrayResponse_QNAME, GetRandArrayResponse.class, null, value);
    }

}
