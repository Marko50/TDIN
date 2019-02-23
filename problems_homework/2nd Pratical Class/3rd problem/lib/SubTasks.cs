public class SubTasks{
    public SubTasks(Tasks tasks){
        for (int i = 0; i < tasks.tasks.Length; i++)
        {
            tasks.warnEvent += new Tasks.warnDelegate(tasks.warn);
        }
    }
}