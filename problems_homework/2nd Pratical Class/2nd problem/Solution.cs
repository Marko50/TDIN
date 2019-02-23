public class Solution{
    public static void Main(){
        ImaginaryNumber im1 = new ImaginaryNumber(2,-1);
        ImaginaryNumber im2 = im1.conjugate();
        ImaginaryNumber im3 = im1 + im2;
        ImaginaryNumber im4 = new ImaginaryNumber(3,8);
        ImaginaryNumber im5 = new ImaginaryNumber(-3,-4);
        ImaginaryNumber im6 = im4 * im3;
        ImaginaryNumber im7 = im5/im1;
        ImaginaryNumber im8 = new ImaginaryNumber(2,-1);
        if(im8 == im1){
            System.Console.WriteLine("IM8 == IM1");
        }
        if(im8 != im3){
            System.Console.WriteLine("IM8 != IM3");
        }
    }
}