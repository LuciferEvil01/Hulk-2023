public class Let : ASTNode
{
 public Let(Dictionary<string,object> Variables): base()
 {
   this.Variables= Variables;
 }  
 public Dictionary<string,object> Variables{get;set;} 

    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        
        bool Checkvariables= true;
       foreach( KeyValuePair<string,object> variable in this.Variables)
       {
        if(LocalServer.Variables.Contains(variable.Key))
        {
          Bugs.Add(new CompilingBugs(BugCode.semantico,"This variable is in use"));
          Checkvariables=false;
        }
        else 
        {
          LocalServer.Variables.Add(variable.Key);
        }
       }
        return  Checkvariables ;

    }
    // public override void Evaluate( )=> Argument.Evaluate();  


}