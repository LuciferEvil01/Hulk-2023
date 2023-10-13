public class Parse
{
    public List<Token> tokens {get; private set;}
    public TokenStream stream {get; private set;}
    
     public Parse(IEnumerable<Token> tokens,List<CompilingBugs> bugs)
    {
      this.tokens= new List<Token>();
      CollectList(tokens);
      stream= new TokenStream(this.tokens);
    }
    
    public ASTNode Parser(List<CompilingBugs> bugs)
    {
        
            switch(stream.LookAhead(tokens).Value)
            {
                case "Print":    return ParserPrint(bugs);
                case "if"   :    return ParserIf(bugs);
                case "let"  :    return ParserLet(bugs);
                case "Function": return ParserFunction(bugs);
                default : return ParserExpression(bugs); 
            }   
        
    }
    public Function ParserFunction(List<CompilingBugs> bugs)
    {

      if(!stream.Next(TokenType.Variable,tokens))
      {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis,"The function don't have variable declarated"));
      }
      var variable= stream.LookAhead(tokens).Value;
      if(!stream.Next("(",tokens))
      {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis," the bracket is not open "));
      }
      if(!stream.Next(TokenType.Parameter,tokens))
      {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis,"This is not a parameter"));
      }
      var parameter= stream.LookAhead(tokens).Value;
      if(!stream.Next(")",tokens))
      {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis," the bracket is not closed "));
      }
      if(!stream.Next("=",tokens))
      {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis," The assignment symbol is no declarate "));
      }
      if(stream.Next("Function",tokens))
      {
        bugs.Add(new CompilingBugs(BugCode.semantico,"The function cant declarate into a function"));
      }
      ASTNode Argument= Parser(bugs);
      Function function= new Function(variable,Argument,parameter);
      return function;
      
    }
    public void ParserElse(List<CompilingBugs> bugs)
    {
       
    }
    public If ParserIf(List<CompilingBugs> bugs)
    {
      
        
        var Expression= ParserExpression(bugs);
        if(Expression.Type != ExpressionType.logic ) 
        {
         bugs.Add(new CompilingBugs(BugCode.semantico,"this expression cannot be used like a condicional"));
        }
        var If = new If(Expression);
        
        return If;
    }
    In ParserIn( List<CompilingBugs> bugs,Dictionary<string,object> parameter)
    {
      var Argument = Parser(bugs);
      In Let_in= new In(Argument,parameter);
      return  Let_in;
    }
    Print ParserPrint( List<CompilingBugs> bugs)
    {
       if(!stream.Next("(",tokens))
       {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis,"the bracket is not open"));
       }
       if(stream.Next("Function",tokens))
       {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis,"cant declarate a function into a print"));
       }
       var Argument= Parser(bugs);
       Print print= new Print(Argument);
        
       return print;
    }
      Let ParserLet( List<CompilingBugs> bugs)
    {
       Dictionary<string,object> Parameter = new Dictionary<string, object>();
       Parameters();
      return ParserIn(bugs,Parameter);
      void Parameters()
      { 
         if(!stream.Next(TokenType.Variable,tokens))
          {
          bugs.Add(new CompilingBugs(BugCode.semantico,"this token is not parameter and is no definite in a let "));
          }
         var parameter1= stream.LookAhead(tokens).Value;
         if(!stream.Next("=",tokens))
         {
          bugs.Add(new CompilingBugs(BugCode.semantico,"not found the assign symbol"));
         }
         if(!stream.Next(TokenType.Number,tokens) || !stream.Next(TokenType.Text,tokens))
          {
          bugs.Add(new CompilingBugs(BugCode.semantico,"the token cant save this value  "));
          }
          var value = stream.LookAhead(tokens).Value;
          Parameter.Add(parameter1,value);
          if(stream.Next("in",tokens)) return;
          if(stream.Next(",",tokens)) Parameters();
       } 

   }
    void CollectList(IEnumerable<Token> tokens)
    {
      foreach (var token in tokens) this.tokens.Add(token);
    }
      BinaryExpression ParserExpression (List<CompilingBugs> bugs)
      {    
        if(stream.Next("(",tokens)) ParserExpression(bugs);
        var left = getobject(bugs);
        if(!stream.Next(TokenType.logicSymbol,tokens)|| !stream.Next(TokenType.numericSymbol,tokens))
        {
         bugs.Add(new CompilingBugs(BugCode.semantico,"no found a valid symbol"));
        }
        var Operator = GetOperator(bugs); 
        Operator.Left= left;
        return expression(Operator,bugs);
         BinaryExpression expression (BinaryExpression Operator,List<CompilingBugs> bugs)
          {
            if(stream.Next("(",tokens)) ParserExpression(bugs);
            var right = getobject(bugs); 
            Operator.Right=right;
            if(stream.Next(")",tokens)) return Operator;
            if(stream.Next(";",tokens)) return Operator;
            if(!stream.Next(TokenType.logicSymbol,tokens)|| !stream.Next(TokenType.numericSymbol,tokens))
            {
              bugs.Add(new CompilingBugs(BugCode.semantico,"no found a valid symbol"));
            }   
            var Operator1 = GetOperator(bugs);
            Operator1.Left= Operator;
            return expression(Operator1,bugs);
          }
      }
      BinaryExpression GetOperator(List<CompilingBugs> bugs)
      {
        if(stream.LookAhead(tokens).Type== TokenType.GeneralSymbol)
        {
          bugs.Add(new CompilingBugs(BugCode.Sintaxis,"this operator cannot be used"));
        }
        switch (stream.LookAhead(tokens).Value)
        {
          case "<" : {var Operator = new Smaller(); return Operator;}
          case ">" : {var Operator = new Greater(); return Operator;}
          case "==": {var Operator = new Equal()  ; return Operator;}
          case "<=": {var Operator = new SmallorEqual(); return Operator;}
          case ">=": {var Operator = new GreatorEqual(); return Operator;}
          case "+" : {var Operator = new Add(); return Operator;}
          case "-" : {var Operator = new Sub(); return Operator;}
          case "/" : {var Operator = new Div(); return Operator;}
          case "*" : {var Operator = new Mul(); return Operator;}
          default  : {var Operator = new Pow(); return Operator;}
        }
        
      } 
       AtomExpression getobject(List<CompilingBugs> bugs)
      {
        if(!stream.Next(TokenType.Number,tokens) || !stream.Next(TokenType.Variable,tokens))
          {
          bugs.Add(new CompilingBugs(BugCode.semantico,"this token is not definite in a condicional "));
          }
        if(stream.LookAhead(tokens).Type== TokenType.Variable) 
          {return GetVariableType(bugs);}
        else 
          {Number left= new Number(double.Parse(stream.LookAhead(tokens).Value));return left;} 
      }
      
      AtomExpression GetVariableType(List<CompilingBugs> bugs)
      {
        var variable = stream.LookAhead(tokens).Value;
        if(stream.Next("(",tokens))
        {
          if(!stream.Next(TokenType.Parameter,tokens))
          {
            bugs.Add(new CompilingBugs(BugCode.Sintaxis,"parameter is not found"));
          }
          
          var parameter= stream.LookAhead(tokens).Value;
          if(!stream.Next(")",tokens))
          {
            bugs.Add(new CompilingBugs(BugCode.Sintaxis,"the bracked is not closed"));
          }

          VFunction vFunction = new VFunction(variable,parameter); return vFunction;
        }
        else 
        {
          Variable variable1= new Variable(variable); return variable1;
        }       
      }
     


} 
