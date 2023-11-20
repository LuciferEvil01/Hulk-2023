
public class Print : Expression
{
    public Print (Expression Argument ) : base ()
    {
        this.Argument= Argument;
      
    }

    public Expression Argument{get;set;}
    public override object? Value { get ; set ; }


    public override bool CheckSemantic(GlobalServer Globalserver, LocalServer Localserver, List<CompilingBugs> Bugs)
    {
     bool CheckArgument =  Argument.CheckSemantic(Globalserver,Localserver, Bugs);
     return CheckArgument;
    } 
    public override void Evaluate(GlobalServer Globalserver, LocalServer Localserver, List<CompilingBugs> Bugs) 
    { 
      Argument!.Evaluate(Globalserver, Localserver,Bugs);
      Value= Argument.Value;
    } 
    // public override string ToString() 
    //     => String.Format("Card {0} \n\t Power: {1} \n\t elements: {2}", Id, Power, Elements.Count);
}
