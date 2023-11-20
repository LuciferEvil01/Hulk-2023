public class Sen: AtomExpression

{
    public Sen(string id) : base()
    {
        this.id= id;
        Type= ExpressionType.Number;        

    }
     
     
    public override object? Value { get ; set;}
    public string id{get;set;}
    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {    
        var expression= searchVariable(localServer.Parent!);
        if(expression!= null)
        {
          
          expression.Evaluate(globalServer,localServer.Parent!,Bugs);
          Value =  Math.Sin((double)expression.Value!);
        
        } 
        
        Expression searchVariable(LocalServer localServer)
        {
          if(localServer!= null!)
          {
            if(localServer.Node>0)
            { 
              foreach (var item in localServer.Variable) {if(item.Key==id) return item.Value; }
              return searchVariable(localServer.Parent!);
            }
             foreach (var item in localServer.Variable) {if(item.Key==id) return item.Value; }
          }
          Bugs.Add(new CompilingBugs(BugCode.semantico," this variable "+id+" is not declarate in the scope"));    
          Type= ExpressionType.Bug;
          return null!;
        } 
        
  }
}
