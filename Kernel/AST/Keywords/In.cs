public class In :  Let
{
 public In(ASTNode Argument,Dictionary<string,object> Variables ) :base (Variables)
 {
   this.Argument=Argument;
 }  
 
 public ASTNode Argument {get; set;}

    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {   
        bool CheckArgument = Argument.CheckSemantic(GlobalServer,LocalServer,Bugs);
        return CheckArgument;

    }
    // public override void Evaluate( )=> Argument.Evaluate();  


}