public class Solution{
    private double function(double x){
        return 4.0/(1+x*x);  
    }

    private async System.Threading.Tasks.Task<double> loop(){
        double pi = 0.0;
        long NRECS = 1000000000;
        double w = 1/NRECS;
        await System.Threading.Tasks.Task.Run(() => {
            for (int k=0; k < NRECS; k++) 
            {
                pi += function((k+0.5)*w)*w;
            }
        });
        return pi;
    }

    private async System.Threading.Tasks.Task pi(){
        System.Threading.Tasks.Task<double> task = loop();
        System.Console.WriteLine("Asynchronous PI function called.");
        System.Console.WriteLine("Line 1.");
        System.Console.WriteLine("Line 2.");
        System.Console.WriteLine("Line 3.");
        System.Console.WriteLine("Line 4.");
        System.Console.WriteLine("Line 5.");
        System.Console.WriteLine("Line 6.");
        System.Console.WriteLine("Lines were printed while task loop() was running.");
        System.Console.WriteLine("Now we can wait for loop() to end.");
        double pi = await task;
        System.Console.WriteLine("Asynchronous loop function returns. PI: " + pi.ToString());
    }
    public static void Main(){
        Solution solution = new Solution();
        System.Threading.Tasks.Task x = solution.pi();
        x.Wait();
    }
}