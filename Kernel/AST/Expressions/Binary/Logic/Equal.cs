public class Equal :  Bool 
{
    public Equal( ) : base() 
    {
        Priority= Priority.Priority3;
     }

    public override ExpressionType Type {get; set;}

    public override object? Value {get; set;}

     public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {
         Right!.Evaluate(globalServer,localServer,Bugs);
        Left!.Evaluate(globalServer,localServer,Bugs);  
        
        Value = Right.Value! == Left.Value!;
    
    }
    public override Priority Priority { get ; set ; }

    // public override string? ToString()
    // {
    //     if (Value == null)
    //     {
    //         return String.Format("({0} - {1})", Left, Right);
    //     }
    //     return Value.ToString();
    // }
}
