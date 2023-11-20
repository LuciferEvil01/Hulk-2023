public class Aritmetic : BinaryExpression
{
    public Aritmetic( ): base ()
    {
     
    }
 
    public override object? Value {get; set;}
    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        bool right = Right!.CheckSemantic(GlobalServer, LocalServer, Bugs);
        bool left = Left!.CheckSemantic(GlobalServer, LocalServer, Bugs);
        bool ValidType(ExpressionType  type) 
        {
          return type == ExpressionType.Number || type == ExpressionType.variable;
        }
        if (!ValidType(Right.Type) || !ValidType(Left.Type))
        {
            Bugs.Add(new CompilingBugs( BugCode.Sintaxis, "We don't do that here... "));
            Type = ExpressionType.Bug;
            return false;
        }

        Type = ExpressionType.Number;
        return right && left;
    }
    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    { }
}