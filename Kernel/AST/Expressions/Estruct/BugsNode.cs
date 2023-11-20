 
public class BugsNode:Expression
{
    public BugsNode(): base()
    {

    }
    public override object? Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        throw new NotImplementedException();
    }
    public override void Evaluate(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        throw new NotImplementedException();
    }



}