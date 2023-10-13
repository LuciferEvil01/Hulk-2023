
public class Print : ASTNode
{
    public Print (ASTNode Argument ) : base ()
    {
        this.Argument= Argument;
    }

    public ASTNode Argument{get;set;}
    

    public override bool CheckSemantic(GlobalServer Globalserver, LocalServer Localserver, List<CompilingBugs> Bugs)
    {
     bool CheckArgument =  Argument.CheckSemantic(Globalserver,Localserver, Bugs);
     return CheckArgument;
    }

    
    // public  override void Evaluate() => Argument!.Evaluate();

    // public override string ToString() 
    //     => String.Format("Card {0} \n\t Power: {1} \n\t elements: {2}", Id, Power, Elements.Count);
}
