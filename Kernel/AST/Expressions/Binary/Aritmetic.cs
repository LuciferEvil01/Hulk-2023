public class Aritmetic : BinaryExpression
{
    public Aritmetic( ): base ()
    {
     
    }
    public override ExpressionType Type {get; set;}
    public override object? Value {get; set;}

    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        bool right = Right!.CheckSemantic(GlobalServer, LocalServer, Bugs);
        bool left = Left!.CheckSemantic(GlobalServer, LocalServer, Bugs);

        if (Right.Type != ExpressionType.Number || Left.Type != ExpressionType.Number)
        {
            Bugs.Add(new CompilingBugs(, BugCode.Invalid, "We don't do that here... "));
            Type = ExpressionType.Bug;
            return false;
        }

        Type = ExpressionType.Number;
        return right && left;
    }
    public override void Evaluate()
    {
        throw new NotImplementedException();
    }
}