public class Pow: Aritmetic
{
    public Pow( ) : base(){}

    public override ExpressionType Type {get; set;}

    public override object? Value {get; set;}

    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {
        Right!.Evaluate(globalServer,localServer,Bugs);
        Left!.Evaluate(globalServer,localServer,Bugs); 
        if(ValidType(Right.Type) && ValidType(Left.Type))
        {
         Value =  Math.Pow((double)Left.Value!,(double)Right.Value!);
         return;
        }
        Bugs.Add(new CompilingBugs(BugCode.semantico," a member of pow operator is not a number")); 
       
    }

    // public override string? ToString()
    // {
    //     if (Value == null)
    //     {
    //         return String.Format("({0} + {1})", Left, Right);
    //     }
    //     return Value.ToString();
    // }
}
