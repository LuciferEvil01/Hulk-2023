public class Log: AtomExpression

{
    public Log(string id,string Base) : base()
    {
        this.id= id;
        this.Base= Base;

        Type= ExpressionType.Number;        

    }
     
     
    public override object? Value { get ; set;}
    public string id{get;set;}
    public string Base{get;set;}
    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs)
    {    
        Expression expression = null!;
        Expression expression1= null! ;
        searchVariable(localServer.Parent!);
        if(expression!= null)
        {
          
          expression.Evaluate(globalServer,localServer.Parent!,Bugs);
          expression1.Evaluate(globalServer,localServer.Parent!,Bugs);

          Value =  Math.Log((double)expression!.Value!,(double)expression1.Value!);
        
        } 
        
        void searchVariable(LocalServer localServer)
        {
          if(localServer!= null!)
          {
            if(localServer.Node>0)
            { 
              
              if(localServer.Variable.ContainsKey(id) && localServer.Variable.ContainsKey(Base))
              { 
                expression= localServer.Variable[id];
                expression1= localServer.Variable[Base]; 
                return; 
              }
              searchVariable(localServer.Parent!);
              return;
            }
            if(localServer.Variable.ContainsKey(id) && localServer.Variable.ContainsKey(Base))
            { 
              expression= localServer.Variable[id];
              expression1= localServer.Variable[Base]; 
              return; 
            }
          }
          Bugs.Add(new CompilingBugs(BugCode.semantico," this variable "+id+" is not declarate in the scope"));    
          Type= ExpressionType.Bug;
           return;
        } 
        
  }
}
