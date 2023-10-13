public abstract class ASTNode
{
    public ASTNode( ) {}

    public abstract bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs);    
}
