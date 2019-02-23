public class Task{
    private string description;
    private System.DateTime dueDate;

    public Task(string desc, System.DateTime dt){
        this.description = desc;
        this.dueDate = dt;
    }

    public string Description{
        get{
            return this.description;
        }
    }

    public System.DateTime DueDate{
        get{
            return this.dueDate;
        }
    }    
}