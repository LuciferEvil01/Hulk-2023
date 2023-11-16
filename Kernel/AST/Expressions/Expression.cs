
public abstract class Expression : ASTNode
{
    public Expression( ) : base () { }

    public abstract ExpressionType Type { get; set; }
 
    
    public abstract Priority Priority {get; set;}
   
     public bool ComparatePriority(Priority priority)
    {
       int x = Value(this.Priority);
       int y = Value(priority);
       return  x>y;
       int Value (Priority priority)
       {
        switch (priority)
        {
          case Priority.Priority1: return 1;
          case Priority.Priority2: return 2;
          case Priority.Priority3: return 3;
          case Priority.Priority4: return 4;
          default: return 5;
        }
       }
    } 
}
 public enum Priority
{
  Priority1,
  Priority2,   
  Priority3,
  Priority4,
  Priority5,
}

