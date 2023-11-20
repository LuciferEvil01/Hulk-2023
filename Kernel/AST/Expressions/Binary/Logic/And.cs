public class And: LogicSupport
{
    public And()
    {
      Priority= Priority.Priority4;
      
    }
    

    public override object? Value {get; set;}


    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {  
        Left!.Evaluate(globalServer,localServer,Bugs); 
        Right!.Evaluate(globalServer,localServer,Bugs); 
        Value= (bool)Left.Value!&& (bool)Right.Value!;
    }
}