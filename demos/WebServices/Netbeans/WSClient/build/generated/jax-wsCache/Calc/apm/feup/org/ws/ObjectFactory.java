
package apm.feup.org.ws;

import javax.xml.bind.annotation.XmlRegistry;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the apm.feup.org.ws package. 
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


    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: apm.feup.org.ws
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link Sqroot }
     * 
     */
    public Sqroot createSqroot() {
        return new Sqroot();
    }

    /**
     * Create an instance of {@link MaxminResponse }
     * 
     */
    public MaxminResponse createMaxminResponse() {
        return new MaxminResponse();
    }

    /**
     * Create an instance of {@link Maxmin }
     * 
     */
    public Maxmin createMaxmin() {
        return new Maxmin();
    }

    /**
     * Create an instance of {@link ArrayOfDouble }
     * 
     */
    public ArrayOfDouble createArrayOfDouble() {
        return new ArrayOfDouble();
    }

    /**
     * Create an instance of {@link SqrootResponse }
     * 
     */
    public SqrootResponse createSqrootResponse() {
        return new SqrootResponse();
    }

}
