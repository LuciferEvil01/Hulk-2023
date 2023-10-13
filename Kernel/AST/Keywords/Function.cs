
public class Function : ASTNode
{
    public Function (string id,ASTNode Argument, Object parameter): base ()
    {
        this.Id = id;
        this.Argument= Argument;
        this.parametro=  parameter;
    }

    public string Id { get; set; }
    public object parametro {get;set;}
    public ASTNode Argument {get; set;}

    // public void Evaluate() => Argument.Evaluate();


    public bool DeclarateFunction (GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        if ( GlobalServer.Function.Keys.Contains(Id)|| GlobalServer.Function.Values.Contains(Argument))
        {
            Bugs.Add(new CompilingBugs(BugCode.semantico, " Function already defined"));
            return false;
        }
        else
        {
            GlobalServer.Function.Add(Id,Argument);
        }
        return true;
    }

    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
      bool CheckArgument = Argument.CheckSemantic(GlobalServer,LocalServer,Bugs);
      return CheckArgument;
 
    }

    // public override string ToString()
    //     => String.Format("Element {0} \n\t {1} weaknesses \n\t {2} strengths", Id, Weak.Count, Strong.Count);
}
