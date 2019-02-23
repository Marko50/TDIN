public class Tasks{
    public static int MIN_TIME = 1;
    public delegate void warnDelegate(TaskEventArgs taskEventArgs);
    public event warnDelegate warnEvent;
    public Task[] tasks = new Task[3];

    public Tasks(Task t1, Task t2, Task t3){
        this.tasks[0] = t1;
        this.tasks[1] = t2;
        this.tasks[2] = t3;
    }

    public void warn(TaskEventArgs taskEventArgs){
       if(taskEventArgs.interval.Seconds <= MIN_TIME){
            System.Console.WriteLine("WARNING: TASK " + taskEventArgs.description + " is running out of time. Time Left: " + taskEventArgs.interval.Seconds);
        }   
    }
}