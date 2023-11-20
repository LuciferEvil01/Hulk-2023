public class Merge : Aritmetic
{

    public Merge( ) : base()
    {
        Priority= Priority.Priority1;
        Type= ExpressionType.Text;
       
    }

    
    

    public override object? Value {get; set;}

    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {
       
        Left!.Evaluate(globalServer,localServer,Bugs);

        Right!.Evaluate(globalServer,localServer,Bugs);

          if(EqualValue(localServer,Left)&& EqualValue(localServer,Right))
          {Value =  Left.Value!+" "+ Right.Value! ;}
          else  { Value= localServer.value[Left.RayId] +" " + Right.Value!;}
    
          return;
        
    
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
