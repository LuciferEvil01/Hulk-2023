
public class Bool : BinaryExpression
{
    public Bool( ): base() {}
    public override ExpressionType Type {get; set;}

    public override Priority Priority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override object? Value {get; set;}
    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        bool left= Left!.CheckSemantic(GlobalServer,LocalServer,Bugs);
        bool right= Right!.CheckSemantic(GlobalServer,LocalServer,Bugs);
        if( Right.Type != Left.Type!)
        {
            Bugs.Add(new CompilingBugs(BugCode.semantico,"We don't do that here... "));
            Type= ExpressionType.Bug;
            return false;
        }
        Type= ExpressionType.logic;
        return left && right;
    }
    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs){}

}