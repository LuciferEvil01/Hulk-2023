
public class Function : ASTNode
{
    public Function (string id,ASTNode Argument, string parameter): base ()
    {
        this.Id = id;
        this.Argument= Argument;
        this.parametro=  parameter;
        Value= "";
    }

    public string Id { get; set; }
    public string parametro {get;set;}
    public ASTNode Argument {get; set;}
    public override object? Value { get ; set ; }
    public override void Evaluate(GlobalServer Globalserver, LocalServer Localserver, List<CompilingBugs> Bugs) {}


    public bool DeclarateFunction (GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
        var Tuple= new Tuple<string,string>(Id,parametro);
        if ( GlobalServer.Function.Keys.Contains(Tuple)|| GlobalServer.Function.Values.Contains(Argument))
        {
            Bugs.Add(new CompilingBugs(BugCode.semantico, " Function already defined"));
            return false;
        }
        else
        {
            
            GlobalServer.Function.Add(Tuple,Argument);
        }
        return true;
    }

    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
      bool CheckId = DeclarateFunction(GlobalServer,LocalServer,Bugs); 
      bool CheckArgument = Argument.CheckSemantic(GlobalServer,LocalServer,Bugs);
      return CheckId  && CheckArgument;
 
    }

    // public override string ToString()
    //     => String.Format("Element {0} \n\t {1} weaknesses \n\t {2} strengths", Id, Weak.Count, Strong.Count);
}
