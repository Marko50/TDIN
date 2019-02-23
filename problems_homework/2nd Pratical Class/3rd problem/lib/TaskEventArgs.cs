public class TaskEventArgs{
    public System.TimeSpan interval;
    public string description;

    public TaskEventArgs(string desc , System.TimeSpan intval){
        this.interval = intval;
        this.description = desc;
    }
}