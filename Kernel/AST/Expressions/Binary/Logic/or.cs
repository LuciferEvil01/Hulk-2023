public class Or: LogicSupport
{
    public Or()
    {
      Priority= Priority.Priority4; 
     
      
    }
    
    public override ExpressionType Type {get; set;}
  

    public override object? Value {get; set;}
    public override Priority Priority { get ; set ; }

    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {
         Right!.Evaluate(globalServer,localServer,Bugs);
        Left!.Evaluate(globalServer,localServer,Bugs);  
        
        Value= (bool)Right.Value! || (bool)Left.Value!;
    }
}