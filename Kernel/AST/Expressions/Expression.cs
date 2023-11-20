

public class Expression : ASTNode
{
    public Expression( ) : base () { }

    public ExpressionType Type { get; set; }
    public double RayId =0;
    public override void Evaluate(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        throw new NotImplementedException();
    }
    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        throw new NotImplementedException();
    }
    public override object? Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Priority Priority {get; set;}
   
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

