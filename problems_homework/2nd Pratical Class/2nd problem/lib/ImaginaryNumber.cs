public class ImaginaryNumber
{
    private delegate void Printer();
    private event Printer printerEvent;
    private double realPart;
    private double imaginaryPart;
    public ImaginaryNumber(double real, double imaginary){
        this.realPart = real;
        this.imaginaryPart = imaginary; 
        this.printerEvent += new Printer(this.print);
    }

    public double R {
        get{
            return this.realPart;
        }
        set{
            this.realPart = value;
        }
    }

    public double I{
        get{
            return this.imaginaryPart;
        }
        set{
            this.imaginaryPart = value;
        }
    }


    public ImaginaryNumber conjugate(){
        ImaginaryNumber ret = new ImaginaryNumber(this.R, - this.I);
        ret.printerEvent(); 
        return ret;
    }
    public ImaginaryNumber copy(){
        ImaginaryNumber ret = new ImaginaryNumber(this.R, this.I); 
        ret.printerEvent();
        return ret;
    }

    public static implicit operator ImaginaryNumber(double i){
        ImaginaryNumber ret = new ImaginaryNumber(i,0);
        ret.printerEvent();
        return ret;
    }

    public static ImaginaryNumber operator+(ImaginaryNumber imFirst, ImaginaryNumber imSecond){
        ImaginaryNumber ret =  new ImaginaryNumber(imFirst.R + imSecond.R, imFirst.I + imSecond.I);
        ret.printerEvent();
        return ret;
    }

    public static ImaginaryNumber operator-(ImaginaryNumber imFirst, ImaginaryNumber imSecond){
        ImaginaryNumber ret = new ImaginaryNumber(imFirst.R - imSecond.R, imFirst.I - imSecond.I);
        ret.printerEvent();
        return ret;
    }
    
    public static ImaginaryNumber operator*(ImaginaryNumber imFirst, ImaginaryNumber imSecond){
        ImaginaryNumber ret = new ImaginaryNumber((imFirst.R * imSecond.R) - (imFirst.I * imSecond.I), (imFirst.R * imSecond.I) - (imFirst.I * imSecond.R));
        ret.printerEvent();
        return ret;
    }

    public static ImaginaryNumber operator/(ImaginaryNumber imFirst, ImaginaryNumber imSecond){
        ImaginaryNumber ret = new ImaginaryNumber((imFirst.R * imSecond.R + imFirst.I * imSecond.I) / (System.Math.Pow(imFirst.R,2) + System.Math.Pow(imSecond.R,2)), (imFirst.R * imSecond.I - imFirst.I * imSecond.R)/ (System.Math.Pow(imFirst.R,2) + System.Math.Pow(imSecond.R,2)));
        ret.printerEvent();
        return ret;
    }

    public static bool operator== (ImaginaryNumber imFirst, ImaginaryNumber imSecond){
        return imFirst.R == imSecond.R && imFirst.I == imSecond.I;
    }
    public static bool operator!= (ImaginaryNumber imFirst, ImaginaryNumber imSecond){
        return imFirst.R != imSecond.R || imFirst.I != imSecond.I;
    }

    public override string ToString() {
        return this.R.ToString() + '+' + this.I.ToString() + 'i';
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()){
            return false;
        }
        return ((ImaginaryNumber) obj).I == this.I && ((ImaginaryNumber) obj).R == this.R;
    }
    
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    private void print(){
        System.Console.WriteLine(System.Math.Round(this.R,2).ToString() + " + " + System.Math.Round(this.I,2).ToString() + "i");
    }    
}