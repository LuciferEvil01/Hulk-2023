public class Equal :  Bool 
{
    public Equal( ) : base() 
    {
        Priority= Priority.Priority3;
     }

    

    public override object? Value {get; set;}

     public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {    
        Left!.Evaluate(globalServer,localServer,Bugs);  
        Right!.Evaluate(globalServer,localServer,Bugs); 
        Value =  Left.Value! == Right.Value! ;
    
    }
  

    // public override string? ToString()
    // {
    //     if (Value == null)
    //     {
    //         return String.Format("({0} - {1})", Left, Right);
    //     }
    //     return Value.ToString();
    // }
}
