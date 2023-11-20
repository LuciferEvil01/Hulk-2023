
public class Add : Aritmetic
{

    public Add( ) : base()
    {
        Priority= Priority.Priority2;
       
    }

    


    public override object? Value {get; set;}

    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {
       
        Left!.Evaluate(globalServer,localServer,Bugs);

        Right!.Evaluate(globalServer,localServer,Bugs);
   
        
      
         
        if(ValidType(Right.Type) && ValidType(Left.Type)) 
        {
          if(EqualValue(localServer,Left)&& EqualValue(localServer,Right))
          {Value =  (double)Left.Value!+(double)Right.Value! ;}
          else  { Value= localServer.value[Left.RayId] + (double)Right.Value!;}
    
          return;
        }
        
        Bugs.Add(new CompilingBugs(BugCode.semantico," a member of add operator is not a number"));
    }


    public override string? ToString()
    {
        if (Value == null)
        {
            return String.Format("({0} + {1})", Left, Right);
        }
        return Value.ToString();
    }
}
