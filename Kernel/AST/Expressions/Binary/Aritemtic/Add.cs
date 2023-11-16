﻿
public class Add : Aritmetic
{
    public Add( ) : base()
    {
        Priority= Priority.Priority2;
       
    }

    public override ExpressionType Type {get; set;}


    public override object? Value {get; set;}

    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {
        Right!.Evaluate(globalServer,localServer,Bugs);
        Left!.Evaluate(globalServer,localServer,Bugs);
         
        if(ValidType(Right.Type) && ValidType(Left.Type)) 
        {
          Value = (double)Right.Value! + (double)Left.Value!;
          return;
        }
        Bugs.Add(new CompilingBugs(BugCode.semantico," a member of add operator is not a number"));
    }
    public override Priority Priority { get; set ; }

    public override string? ToString()
    {
        if (Value == null)
        {
            return String.Format("({0} + {1})", Left, Right);
        }
        return Value.ToString();
    }
}
