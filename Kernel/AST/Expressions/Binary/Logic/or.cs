public class Or: LogicSupport
{
    public Or()
    {
      Priority= Priority.Priority4; 
     
      
    }
    
    
  

    public override object? Value {get; set;}
  

    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {
        Left!.Evaluate(globalServer,localServer,Bugs);  
        Right!.Evaluate(globalServer,localServer,Bugs); 
        
        Value= (bool)Right.Value! || (bool)Left.Value!;
    }
}