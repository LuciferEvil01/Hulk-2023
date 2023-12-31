
public abstract class AtomExpression : Expression
{
    public AtomExpression( ) : base(){}
    
    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer table, List<CompilingBugs> Bugs) => true;

    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs) 
    {}

    public override string ToString() => String.Format("{0}",Value);
}
