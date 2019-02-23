public class Solution{
    public static void Main(){
        Task t1 = new Task("Wash the dishes", System.DateTime.Today);
        Task t2 = new Task("Do my homework", System.DateTime.Today);
        Task t3 = new Task("Clean my bedroom", System.DateTime.Today);

        Tasks tasks = new Tasks(t1,t2,t3);

        SubTasks subTasts = new SubTasks(tasks);

        System.Threading.Tasks.Task task1 = System.Threading.Tasks.Task.Run(() => tasks.warn(new TaskEventArgs(t1.Description, t1.DueDate - System.DateTime.Today)));
        System.Threading.Tasks.Task task2 = System.Threading.Tasks.Task.Run(() => tasks.warn(new TaskEventArgs(t2.Description, t2.DueDate - System.DateTime.Today)));
        System.Threading.Tasks.Task task3 = System.Threading.Tasks.Task.Run(() => tasks.warn(new TaskEventArgs(t3.Description, t3.DueDate - System.DateTime.Today)));
        
        //task1.Wait(1000);
        task2.Wait(1000);
        task3.Wait(1000);
    }
}