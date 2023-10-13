
 public class LogicSupport : Bool
{
    public LogicSupport( ): base() {}

    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        if(Right!.Type== ExpressionType.Text)
        {
           Bugs.Add(new CompilingBugs(BugCode.semantico," I can't comparate text whit this operators "));
           Type= ExpressionType.Bug;
           return false;
        }
        Type= ExpressionType.logic;
        return true;
    }
}