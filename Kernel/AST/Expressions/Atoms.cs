
public abstract class AtomExpression : Expression
{
    public AtomExpression( ) : base(){}

    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer table, List<CompilingBugs> Bugs) => true;

    public override void Evaluate() { }

    public override string ToString() => String.Format("{0}",Value);
}
