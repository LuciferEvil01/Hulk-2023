
public class OperatorBug:BinaryExpression
{
    public OperatorBug(): base()
    {

    }
    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        throw new NotImplementedException();
    }
    public override void Evaluate(GlobalServer globalServer, LocalServer localServer, List<CompilingBugs> Bugs)
    {
        
    }
    public override Priority Priority { get => 0; set => throw new NotImplementedException(); }

    public override ExpressionType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override object? Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

}

