public abstract class ASTNode
{
    public ASTNode( ) { }
    // clase Abstracta principal del arbol posse las dos funciones principales el Evaluate y 
    //  el check Semantic
    public abstract void Evaluate(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs);
    public abstract object? Value { get; set; }

    public abstract bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs);    
}
