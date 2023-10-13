  
  class Else: ASTNode
  {
    public Else(ASTNode LeftOption,ASTNode RightOption )
    {
      this.LeftOption= LeftOption;
      this.RightOption= RightOption;
    }
    
      public ASTNode LeftOption {get; set;}
      public ASTNode RightOption {get; set;}
      public override bool CheckSemantic(GlobalServer GlobalServer, LocalServer LocalServer, List<CompilingBugs> Bugs)
      {
       bool checkLeftOption= LeftOption.CheckSemantic(GlobalServer,LocalServer,Bugs);
       bool checkRightOption= RightOption.CheckSemantic(GlobalServer,LocalServer,Bugs); 
       return checkLeftOption && checkRightOption;
      }

  }
 