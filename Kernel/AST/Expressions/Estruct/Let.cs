  public class Let : Expression
  {
    public Let(Tuple<string,Expression> Variables,Expression Argument): base()
    {
      this.Variables= Variables;
      this.Argument= Argument;
     
    }  
     
     public Tuple<string,Expression> Variables{get;set;} 
     public Expression Argument {get; set;}
    public override object? Value { get ; set; }

    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {     
       bool CheckArgument = Argument.CheckSemantic(GlobalServer,LocalServer,Bugs);
       return CheckArgument;
    }
    public override void Evaluate(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs) 
    {   
       LocalServer.Variable.Add(Variables.Item1,Variables.Item2); 
       Argument.Evaluate(GlobalServer,LocalServer.CreateChild(),Bugs);
       Value= Argument.Value;
    }


}