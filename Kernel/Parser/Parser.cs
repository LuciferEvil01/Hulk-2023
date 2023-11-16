using System.Collections;

public class Parse
{
    public ASTNode Code{get;} 
     public Parse(List<Token> tokens,List<CompilingBugs> bugs)
    {   
      Code=Parser(bugs,tokens);
    }
     ASTNode Parser(List<CompilingBugs> bugs,List<Token> tokens)
    {   TokenStream stream = new TokenStream(tokens);
         
         stream.MoveNext(1); 
        
         var words= end(stream,tokens);


            switch(stream.LookAhead(tokens).Value)
            {
                case "Print": 
                {
                  var tokens1= ListCreator(tokens,stream,words); 
                  return ParserPrint(bugs,tokens1);
                }
                case "if"   : 
                { 
                  var tokens1= ListCreator(tokens,stream,words); 
                  return ParserIf(bugs,tokens1);
                }
                case "let"  : 
                {
                  var tokens1= ListCreator(tokens,stream,words);  
                  return ParserLet(bugs,tokens1);
                }
                case "Function": 
                {
                  var tokens1= ListCreator(tokens,stream,words);
                  return ParserFunction(bugs,tokens1);
                }  
                default :        
                 stream.MoveBack(1);
                 return ParserExpression(bugs,tokens); 
            }   
        
    }
    public Function ParserFunction(List<CompilingBugs> bugs,List<Token> tokens)
    {
       TokenStream stream= new TokenStream(tokens);
      string variable;
      if(!stream.Next(TokenType.Variable,tokens))
      {
        variable="null variable";
        bugs.Add(new CompilingBugs(BugCode.Sintaxis,"This Token: "+stream.LookAhead(tokens).Value+" is not a valid id"));
        stream.MoveNext(1);
      }
      else {variable= stream.LookAhead(tokens).Value;}
      
      if(!stream.Next("(",tokens))
      {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis," the open bracket is missing after " + variable));
         stream.MoveNext(1);
      }
       string parameter;
      if(!stream.Next(TokenType.Variable,tokens))
      {
         parameter= "";
         bugs.Add(new CompilingBugs(BugCode.Sintaxis,"This token"+stream.LookAhead(tokens).Value +" is not a parameter"));
         stream.MoveNext(1);
      }
      else {parameter= stream.LookAhead(tokens).Value;}
      if(!stream.Next(")",tokens))
      {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis," the  closed bracket is missing after " + parameter));
         stream.MoveNext(1);
      }
      if(!stream.Next("=>",tokens))
      {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis,"The Landa symbol is no declarate "));
         stream.MoveNext(1);
      }
      if(stream.LookAhead(tokens,1).Value=="Function")
      {
        bugs.Add(new CompilingBugs(BugCode.semantico,"The function cant declarate into a function"));
      }
      
      List<Token> tokens1 = ListCreator(tokens,stream,";");
      ASTNode Argument= Parser(bugs,tokens1);
      Function function= new Function(variable,Argument,parameter);
      return function;
      
    }
    public ASTNode ParserIf(List<CompilingBugs> bugs,List<Token> tokens)
    {
      
        TokenStream stream = new TokenStream(tokens);
        if(!stream.Next("(",tokens))
        {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis,"the Open bracket is missing after the keyword if"));
         stream.MoveNext(1);
        }      
        List<Token> tokens1= ListCreator(tokens,stream,")");
        if(stream.LookAhead(tokens).Value!=")")
        {
          bugs.Add(new CompilingBugs(BugCode.Sintaxis,"the Closed bracket is missing after the condiconal of the Keyword if"));
          var BugsNode = new BugsNode();
          return BugsNode;
        }
        var Expression=ParserLogicExpression(bugs,tokens1);
        List<Token> tokens2= ListCreator(tokens,stream,"else");
        if(stream.LookAhead(tokens).Value!="else")
        {
          bugs.Add(new CompilingBugs(BugCode.Sintaxis,"The keyword else is missing"));
          var BugsNode = new BugsNode();
          return BugsNode;
        }
        var Argument1= Parser(bugs,tokens2);
        var Words = end(stream,tokens);
        List<Token> tokens3= ListCreator(tokens,stream,Words);
        var Argument2= Parser(bugs,tokens3);
        var IF =  new If(Expression,Argument1,Argument2);

        return IF;
    }
    ASTNode ParserPrint( List<CompilingBugs> bugs,List<Token> tokens)
    {
       TokenStream stream = new TokenStream(tokens);
       if(!stream.Next("(",tokens))
       {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis,"The open bracket is missing in the Print Instruccion "));
       }
       if(stream.LookAhead(tokens,1).Value== "Function")
       {
         bugs.Add(new CompilingBugs(BugCode.semantico,"cant declarate a function into a print"));
       }
       List<Token> tokens1= ListCreator(tokens,stream,")");
       
       if(stream.LookAhead(tokens).Value!=")")
       {
         bugs.Add(new CompilingBugs(BugCode.Sintaxis,"The closed bracket is missing in the Print Instruccion "));
         var BugsNode = new BugsNode();
         return BugsNode;
       }
       var Argument= Parser(bugs,tokens1);
       Print print= new Print(Argument);  
       return print;
    }
      ASTNode ParserLet( List<CompilingBugs> bugs,List<Token> tokens)
    {       
       TokenStream stream= new TokenStream(tokens);
       return Parameters();
       
      ASTNode Parameters()
      { 
         string parameter1;
         Tuple<string,Expression> Variable= new Tuple<string, Expression>(null!,null!);
         if(!stream.Next(TokenType.Variable,tokens))
          {
           parameter1="";
           bugs.Add(new CompilingBugs(BugCode.semantico,"the variable is missing in let "));  
           stream.MoveNext(1);  
          }
         else {parameter1= stream.LookAhead(tokens).Value;}
         if(!stream.Next("=",tokens))
         {
          bugs.Add(new CompilingBugs(BugCode.semantico,"the assing symbol is missin after variable "+parameter1+" "));
          stream.MoveNext(1);
         }
         if(!stream.Next(TokenType.Number,tokens))
          {
           if(!stream.Next(TokenType.Text,tokens))
           {
             if(!stream.Next("(",tokens))
             {
              Parameter(null!);
              bugs.Add(new CompilingBugs(BugCode.semantico,"the variable "+parameter1 +" cant save this value  "));
              stream.MoveNext(1);
             }
             else
             {
              List<Token> tokens1= ListCreator(tokens,stream,")");        
              if(stream.LookAhead(tokens).Value!=")")
              {
                bugs.Add(new CompilingBugs(BugCode.Sintaxis,"the closed bracket is missing in the argument of the variable "+ parameter1));
                var BugsNode= new BugsNode();
                return  BugsNode;     
              }
              var value= ParserExpression(bugs,tokens1);
              Parameter(value);
             }
           }
           else 
           {
              var value =  new Text(stream.LookAhead(tokens).Value);
              Parameter(value);
            }
          }
         else 
          {  
              var value =  new Number(double.Parse(stream.LookAhead(tokens).Value));
              Parameter(value);
          
          }         
         if(stream.Next("in",tokens)) 
          {
            var let= new Let(Variable,_In()); 
            return let;
          }
         else if(stream.Next(",",tokens))
          {
            var let= new Let(Variable,Parameters());
            return let;
          }
         else
         {
           bugs.Add( new CompilingBugs(BugCode.Sintaxis," this token "+ stream.LookAhead(tokens,1)+" is not a 'in' or ','"));
           var BugsNode = new BugsNode();
           return BugsNode;
         }
         void Parameter(Expression value)
          {
            Variable = new Tuple<string, Expression>(parameter1,value);
           
          }
       } 
       ASTNode _In ()
      {   
       var Words= end(stream,tokens);
       List<Token> tokens1= ListCreator(tokens,stream,Words);
       var Argument = Parser(bugs,tokens1);
       return Argument;
      }
   }
       Expression ParserExpression (List<CompilingBugs> bugs,List<Token> tokens)
      {    
        
        TokenStream stream = new TokenStream(tokens);
        Expression left;
        if(stream.Next(TokenType.Text,tokens)) 
        {
          var Text= new Text(stream.LookAhead(tokens).Value);
          return Text;
        }
          if(stream.Next("(",tokens)) 
          { 
           List<Token> tokens1= ListCreator(tokens,stream,")");
           if(stream.LookAhead(tokens).Value!=")")
           {
            bugs.Add(new CompilingBugs(BugCode.Sintaxis,"the closed bracket is missing"));
            left= new AtomBug();
            return left;
           }
           left =ParserExpression(bugs,tokens1);
          }
        else 
        { 
          if(!stream.Next(TokenType.Number,tokens))
          {
           if(!stream.Next(TokenType.Variable,tokens))
           {
            bugs.Add(new CompilingBugs(BugCode.semantico,"this token is not definite in a condicional "));
            stream.MoveNext(1);
           }
          }
          if(stream.LookAhead(tokens).Type== TokenType.Variable) 
            {
              left=GetVariableType(bugs,stream,tokens);
              if(stream.End)return left;
            }
          else if(stream.LookAhead(tokens).Type== TokenType.Number)
            {left= new Number(double.Parse(stream.LookAhead(tokens).Value));} 
          else left = null!;
        
         
        }
        stream.MoveNext(1);
        if(stream.End) return left;
        stream.MoveBack(1);

        BinaryExpression Operator;
        if(!stream.Next(TokenType.numericSymbol,tokens))
        {
         bugs.Add(new CompilingBugs(BugCode.semantico,"no found a valid operator after "+ left));
         stream.MoveNext(1);
         Operator= new OperatorBug();
        }
        else { Operator = GetOperator(bugs,stream,tokens);} 
        Operator.Left= left;
        return expression(Operator,bugs);
         BinaryExpression expression (BinaryExpression Operator,List<CompilingBugs> bugs)
          {
            Expression right;
            if(stream.Next("(",tokens)) 
            {
             List<Token> tokens1= ListCreator(tokens,stream,")");
            if(stream.LookAhead(tokens).Value!=")")
           {
            bugs.Add(new CompilingBugs(BugCode.Sintaxis,"the closed bracket is missing"));
             var operatorBug= new OperatorBug();
            return operatorBug;
           }
             right= ParserExpression(bugs,tokens1);
            }
            else 
            {
            right = getobject(bugs,stream,tokens); 
              if(stream.End)
              {
                var operatorBug= new OperatorBug();
                return operatorBug; 
              } 
            }
            stream.MoveNext(1);
            if(stream.End)
            {
             Operator.Right= right;
             return Operator;
            }
            stream.MoveBack(1);

            BinaryExpression Operator1;
            if(!stream.Next(TokenType.numericSymbol,tokens))
            {
            bugs.Add(new CompilingBugs(BugCode.semantico,"no found a valid symbol"));
            stream.MoveNext(1);
            Operator1= new OperatorBug();
            }
            else { Operator1 = GetOperator(bugs,stream,tokens);} 
            if(!Operator.ComparatePriority(Operator1.Priority)) 
            {
            Operator.Right= right;
            Operator1.Left= Operator;
            return expression(Operator1,bugs);
            }
            else 
            {
             Operator1.Left= right;
             Operator.Right= expression(Operator1,bugs);
             return Operator;
            }
           
          }
      }

      Expression ParserLogicExpression(List<CompilingBugs> bugs,List<Token> tokens)
      {
       TokenStream stream = new TokenStream(tokens);
       Expression left;
       BinaryExpression Operator;
       if(stream.Next("(",tokens))
       { 
        var tokens1 =  Expression_Into_Bracket();
        Operator    =  GetOperator(bugs,stream,tokens);
        if(Operator.Priority==Priority.Priority4) left= ParserLogicExpression(bugs,tokens1);
        else left= ParserExpression(bugs,tokens1);
       }
       else
       {       
        var tokens1= Expression_logic(1);
        left = ParserExpression(bugs,tokens1);
        Operator =  GetOperator(bugs,stream,tokens);
       } 
       if(Operator.Priority==Priority.Priority4 && stream.LookAhead(tokens,-1).Value!=")")
        {
          bugs.Add(new CompilingBugs(BugCode.Sintaxis,("Sintaxis error in  "+ Operator.Type)));
        }
        Operator.Left=left;
        return expression(Operator,bugs);

        BinaryExpression expression( BinaryExpression Operator, List<CompilingBugs> bugs)
         {
            Expression right;
            if(stream.Next("(",tokens)) 
            {
             var tokens1= Expression_Into_Bracket();       
             if(Operator.Priority==Priority.Priority4)right= ParserLogicExpression(bugs,tokens1);
             else right= ParserExpression(bugs,tokens1);
            }
            else
             {
               var tokens1 = Expression_logic(0);
               right = ParserExpression(bugs,tokens1); 
              }
            if(stream.End)
            {
              Operator.Right= right;
              return Operator;
            }
            BinaryExpression Operator1;
            if(stream.LookAhead(tokens).Type!=TokenType.logicSymbol)
            {
              bugs.Add(new CompilingBugs(BugCode.semantico,"no found a valid symbol"));
              Operator1= new OperatorBug();
            }
            else Operator1 = GetOperator(bugs,stream,tokens);
            if(!Operator.ComparatePriority(Operator1.Priority)) 
            {
            Operator.Right= right;
            Operator1.Left= Operator;
            return expression(Operator1,bugs);
            }
            else 
            {
             Operator1.Left= right;
             Operator.Right= expression(Operator1,bugs);
             return Operator;
            }

            
        }

        List<Token> Expression_logic(int y)
        {
          var pos = stream.Position;
          int x= searchOp(0)+y;
          var words = stream.LookAhead(tokens).Value;
          stream.MoveBack(x);
          if(pos!=stream.Position) stream.MoveBack(1);  
          List<Token> tokens1= ListCreator(tokens,stream,words);
   
          return tokens1;
        }
        List<Token> Expression_Into_Bracket()
        {
             var Tokens0= new List<Token>();
             Tokens0.Add(stream.LookAhead(tokens,-1));
             List<Token> tokens1= ListCreator(tokens,stream,")");
             stream.MoveNext(1);
             foreach (var item in tokens1)
             {
               Tokens0.Add(item);
             }
             Tokens0.Add(stream.LookAhead(tokens));    
             return tokens1;
        }

        int searchOp(int x)
        {
         
          while(!stream.Next(TokenType.logicSymbol,tokens))
          {

              if(stream.End){ break;}
              stream.MoveNext(1);
              x++;
          }
          return x;
        }
       
      }

    List<Token> ListCreator(List<Token> tokens,TokenStream stream,string end)
    {
       List<Token> tokens1= new List<Token>();
       int Count =0;
      //  Console.WriteLine("valor inicial : "+ stream.LookAhead(tokens)+"  valor final : "+ end);
      do
      { 
       while(stream.LookAhead(tokens).Value != end)
       {
         tokens1.Add(stream.LookAhead(tokens));  
         if(tokens1[0].Value=="(" && end==")")
         {
          if(stream.LookAhead(tokens).Value=="(") Count++;
         }
          if(stream.End) break;
        //  Console.Write(stream.LookAhead(tokens).Value+"  ");
         stream.MoveNext(1);
       }

       if(stream.LookAhead(tokens).Value==")" && Count!=0)
       {
        Count--;
        if(Count!=0)
        { 
         tokens1.Add(stream.LookAhead(tokens));
         if(stream.End) break;
        //  Console.Write(stream.LookAhead(tokens).Value+" ");
         stream.MoveNext(1);
        }
       }
       if(stream.End) break;
       } while (Count!=0); 

        tokens1.Add(stream.LookAhead(tokens));
        //  Console.Write(stream.LookAhead(tokens).Value);
        //  Console.WriteLine();


       return tokens1;
    }
    public string  end(TokenStream stream,List<Token> tokens)
    {
       var pos= stream.Count-stream.Position-1;
       var End= stream.LookAhead(tokens,pos).Value;
       return End;
    }
    
      BinaryExpression GetOperator(List<CompilingBugs> bugs,TokenStream stream,List<Token> tokens)
      {
        if(stream.LookAhead(tokens).Type== TokenType.GeneralSymbol)
        {
          bugs.Add(new CompilingBugs(BugCode.Sintaxis,"this operator cannot be used"));
          var Operator= new OperatorBug();
          return Operator;
        }
        switch (stream.LookAhead(tokens).Value)
        {
          case "<" : {var Operator = new Smaller(); return Operator;}
          case ">" : {var Operator = new Greater(); return Operator;}
          case "==": {var Operator = new Equal()  ; return Operator;}
          case "||": {var Operator = new Or()     ; return Operator;}
          case "&&": {var Operator = new And()    ; return Operator;}
          case "<=": {var Operator = new SmallorEqual(); return Operator;}
          case ">=": {var Operator = new GreatorEqual(); return Operator;}
          case "+" : {var Operator = new Add(); return Operator;}
          case "-" : {var Operator = new Sub(); return Operator;}
          case "/" : {var Operator = new Div(); return Operator;}
          case "*" : {var Operator = new Mul(); return Operator;}
          default  : {var Operator = new Pow(); return Operator;}
        }
        
      } 
       AtomExpression getobject(List<CompilingBugs> bugs,TokenStream stream,List<Token> tokens)
      {
           if(!stream.Next(TokenType.Number,tokens))    
           {     
            if(!stream.Next(TokenType.Variable,tokens))
            {   
             bugs.Add(new CompilingBugs(BugCode.semantico,"this token "+ stream.LookAhead(tokens).Value+" is not a number or variable "));
            }
           }
        if(stream.LookAhead(tokens).Type== TokenType.Variable) 
          {return GetVariableType(bugs,stream,tokens);}
        else if(stream.LookAhead(tokens).Type== TokenType.Number)
          {Number left= new Number(double.Parse(stream.LookAhead(tokens).Value));return left;} 
        else { var left = new AtomBug(); return left;}  
      }
      AtomExpression GetVariableType(List<CompilingBugs> bugs,TokenStream stream,List<Token> tokens)
      {
        var variable = stream.LookAhead(tokens).Value;
        if(stream.Next("(",tokens))
        {
          List<Token> tokens1= ListCreator(tokens,stream,")");
          Expression parameter;
          if(stream.LookAhead(tokens).Value!=")")
          {
            bugs.Add(new CompilingBugs(BugCode.Sintaxis,"the bracked is not closed after variable "+ variable));
            parameter= new AtomBug();
          }
          else  parameter= ParserExpression(bugs,tokens1);
          VFunction vFunction = new VFunction(variable,parameter); 
          return vFunction;
        }
        else 
        {
          Variable variable1= new Variable(variable); 

          return variable1;
        }       
      }
    //  public Expression ParserExpression(List<CompilingBugs> bugs,List<Token> tokens)
    //  {
      
    //   Stack<Expression> stack = new Stack<Expression>();
    //   Stack<Expression> Operator = new Stack<Expression>();
    //   TokenStream stream = new TokenStream(tokens);

    //   if(stream.Next(TokenType.Number,tokens) || stream.Next(TokenType.Variable,tokens))
    //   {
    //    Expression number = stream.LookAhead(tokens).Type==TokenType.Number ? new Number(double.Parse(stream.LookAhead(tokens).Value)) : new Variable(stream.LookAhead(tokens).Value);
    //    stack.Push(number);
    //   }
    //   else if(stream.Next(TokenType.numericSymbol,tokens) || stream.Next(TokenType.logicSymbol ,tokens))
    //   {
    //     Expression Oper = GetOperator(bugs,stream);
    //     stack.Push(Oper);
    //   }

    //   return;
    //  }


} 
