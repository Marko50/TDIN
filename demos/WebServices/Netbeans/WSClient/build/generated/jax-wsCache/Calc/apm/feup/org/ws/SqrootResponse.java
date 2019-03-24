
package apm.feup.org.ws;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="SqrootResult" type="{http://www.w3.org/2001/XMLSchema}double"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "sqrootResult"
})
@XmlRootElement(name = "SqrootResponse")
public class SqrootResponse {

    @XmlElement(name = "SqrootResult")
    protected double sqrootResult;

    /**
     * Gets the value of the sqrootResult property.
     * 
     */
    public double getSqrootResult() {
        return sqrootResult;
    }

    /**
     * Sets the value of the sqrootResult property.
     * 
     */
    public void setSqrootResult(double value) {
        this.sqrootResult = value;
    }

}
