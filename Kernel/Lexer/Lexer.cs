public class Lexer 
{
    List<string> GeneralOperator{get;set;}
    List<string> LogicOperator{get;set;}
    List<string> NumericOperator{get;set;}
    List<string> Keywords{get;set;}
    TokenReader reader{get;}
    List<CompilingBugs> Bugs{get;set;}
    
    public Lexer(string code)
    {
     reader          = new TokenReader(code);  
     GeneralOperator = new List<string>();
     GeneralOperator = GetGeneralOperator(GeneralOperator);
     LogicOperator   = new List<string>();
     LogicOperator   = GetLogicOperator(LogicOperator);
     NumericOperator = new List<string>();
     NumericOperator = GetNumericOperator(NumericOperator);
     Keywords        = new List<string>();
     Keywords        = GetKeyWords(Keywords);
     Bugs            = new List<CompilingBugs>();
  

    }
    public IEnumerable<Token> GetTokens
    {
        get
        {
            List<Token> tokens= new List<Token>();
            while (!reader.EOF)
            {
                string value;

                if (reader.ReadWhiteSpace())
                    continue;

                if (reader.Readvariable(out value))
                {
                    if (Keywords.Contains(value))
                        tokens.Add(new Token(TokenType.Keyword, value));
                    else if(reader.ContinuesWith("(")|| reader.ContinuesWith("=") || reader.ContinuesWith(" "))
                        tokens.Add(new Token(TokenType.Variable, value));
                    
                    else tokens.Add(new Token(TokenType.Parameter,value));
                    continue;
                }

                if (reader.ReadNumber(out value))
                {
                    double d;
                    if (!double.TryParse(value, out d))
                        Bugs.Add(new CompilingBugs(BugCode.lexico, "This a error"));
                    tokens.Add(new Token(TokenType.Number, value));
                    continue;
                }

                if (MatchText(reader, tokens, Bugs))
                    continue;

                if (MatchSymbol(reader, tokens))
                    continue;

                var unkOp = reader.ReadAny();
                Bugs.Add(new CompilingBugs( BugCode.lexico, unkOp.ToString()));
            }

            foreach (var Token in tokens)
            {
            yield return Token; 
            }
        }

    }
     private bool MatchSymbol(TokenReader reader, List<Token> tokens)
    {
        foreach (var op in GeneralOperator)
        {
            if (reader.Match(op))
            {
                tokens.Add(new Token(TokenType.GeneralSymbol, op));
                return true;
            }
        }
        foreach (var op in LogicOperator)
        {
            if (reader.Match(op))
            {
                tokens.Add(new Token(TokenType.logicSymbol, op));
                return true;
            }
        }
        foreach (var op in NumericOperator)
        {
            if (reader.Match(op))
            {
            tokens.Add(new Token(TokenType.numericSymbol, op));
                return true;
            }
        }
        return false;
    }

    private bool MatchText(TokenReader reader, List<Token> tokens, List<CompilingBugs> Bugs)
    {
       
            string text;
            if (reader.Match("\""))
            {
                if (!reader.ReadUntil("\"", out text))
                    Bugs.Add(new CompilingBugs(BugCode.Sintaxis, "\""));
                tokens.Add(new Token(TokenType.Text, text));
                return true;
            }
        return false;
    }
                
     List<string> GetGeneralOperator(List<string> Operator)
    {           
      string[] Operators= {"=",";",",","{","}","(",")"};
      foreach (var Op in Operators) Operator.Add(Op);  
      return Operator;      
    }
     List<string> GetLogicOperator(List<string> Operator)
    {           
      string[] Operators= {"==","<",">",">=","<=","||","&&"};
      foreach (var Op in Operators) Operator.Add(Op);  
      return Operator;      
    }
     List<string> GetNumericOperator(List<string> Operator)
    {           
      string[] Operators= {"+","*","-","/","^","cos","sen","log","PI"};
      foreach (var Op in Operators) Operator.Add(Op);  
      return Operator;      
    }

    List<string> GetKeyWords(List<string> KeyWord)
    {
        string[] KeyWords={"Print","Function","Let","in","if","else"};
        foreach (var key in KeyWords) KeyWord.Add(key); 
        return KeyWord;
    }          
         
               
               



}