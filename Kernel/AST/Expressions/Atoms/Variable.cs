public class Variable: AtomExpression

{
    public Variable(string id) : base()
    {
        this.id= id;
        Type= ExpressionType.variable;        

    }
     
     public override ExpressionType Type 
    {
     get ;
     set ; 
    }
    public override object? Value { get ; set;}
    public string id{get;set;}
    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {    
        var expression= searchVariable(localServer.Parent!);
        if(expression!= null)
        {
          
          expression.Evaluate(globalServer,localServer.Parent!,Bugs);
          Value = expression.Value;
          Console.WriteLine(Value);
          Type  = expression.Type;
        } 
        
        Expression searchVariable(LocalServer localServer)
        {
          if(localServer!= null!)
          {
            if(localServer.Node>0)
            { 
              
              if(localServer.Variable.Item1==id) return localServer.Variable.Item2;
              return searchVariable(localServer.Parent!);
            }
            if(localServer.Variable.Item1==id) return localServer.Variable.Item2;
          }
          Bugs.Add(new CompilingBugs(BugCode.semantico," this variable "+id+" is not declarate in the scope"));    
          Type= ExpressionType.Bug;
          return null!;
        } 
        
  }
}
