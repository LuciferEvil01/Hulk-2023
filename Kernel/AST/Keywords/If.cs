
public class If: ASTNode
{
    public If (BinaryExpression Condicional): base()
    {
      this.Condicional=Condicional; 
    }
    public BinaryExpression Condicional{get;set;}
    
    

    public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
    {
       bool checkCondional= Condicional.CheckSemantic(GlobalServer,LocalServer,Bugs);
       return checkCondional;
    }
    public void Evaluate()
    {
      Condicional.Evaluate();
    }
}