
public class If: Expression
{
    public If (Expression Condicional, Expression LeftOption,Expression  RightOption ): base()
    {
      this.Condicional=Condicional; 
      this.LeftOption= LeftOption;
      this.RightOption= RightOption;
     
    }
    public Expression Condicional{get;set;}
      public Expression LeftOption {get; set;}
      public Expression RightOption {get; set;}
    public override object? Value { get ; set ; }
    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
       bool checkCondional= Condicional.CheckSemantic(GlobalServer,LocalServer,Bugs);
       bool checkLeftOption= LeftOption.CheckSemantic(GlobalServer,LocalServer,Bugs);
       bool checkRightOption= RightOption.CheckSemantic(GlobalServer,LocalServer,Bugs); 
       return checkLeftOption && checkRightOption && checkCondional;
    }
    public override void Evaluate(GlobalServer Globalserver, LocalServer Localserver, List<CompilingBugs> Bugs)
    {
  
      Condicional.Evaluate(Globalserver,Localserver,Bugs);
      if((bool)Condicional.Value!) 
      {
     
       LeftOption.Evaluate(Globalserver,Localserver,Bugs);
       Value= LeftOption.Value;
      }
      else 
       {
       
        RightOption.Evaluate(Globalserver,Localserver,Bugs);
        Value= RightOption.Value;
       }
    }

}