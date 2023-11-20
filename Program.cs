class Program
{
  static string[,] TextInitial = { { "###","   ","###","  ","###","   ","###","  ","###","   ","   ","  ","###","   ","###"},
                                   { "###","   ","###","  ","###","   ","###","  ","###","   ","   ","  ","###","   ","##" },
                                   { "###","   ","###","  ","###","   ","###","  ","###","   ","   ","  ","###","  ","##"},
                                   { "###","###","###","  ","###","   ","###","  ","###","   ","   ","  ","###","#","##"},
                                   { "###","###","###","  ","###","   ","###","  ","###","   ","   ","  ","###","#","##"},
                                   { "###","   ","###","  ","###","   ","###","  ","###","   ","   ","  ","###","  ","##"},
                                   { "###","   ","###","  ","###","###","###","  ","###","###","###","  ","###","   ","##"},
                                   { "###","   ","###","  "," ##","###","## ","  ","###","###","###","  ","###","   ","###"}};
  static void printArrayString(string[,] array)
  {
    for(int i = 0; i < array.GetLength(0);i++)
    {
      string row = "\t\t\t\t\t\t";
      for(int j = 0; j < array.GetLength(1); j++)
      {
        row += array[i,j];
      }
      Console.WriteLine(row);
    }
  }
  static void Start()
  {
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    System.Console.WriteLine("#######################################################################################################################################");
    printArrayString(TextInitial);
    System.Console.WriteLine("#######################################################################################################################################");
    Console.ForegroundColor = ConsoleColor.White;
  }
  static void Main()
  {
    Console.Clear();
    Start();
    GlobalServer globalServer = new GlobalServer();
    DataBase dataBase = new DataBase(globalServer);
 
    while (true)
    {
      LocalServer localServer = new LocalServer();
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.Write("> ");
      Console.ForegroundColor = ConsoleColor.White;
    
       
      string code = Console.ReadLine()!;
      if (code == "exit") break;
      if (code == "clear")
      
      {
        Console.Clear();
        continue;
      }
      if (code.Length != 0)
      {
        Lexer Lexer = new Lexer(code);

        var tokens = CollectList(Lexer.GetTokens);
        var Bugs = Lexer.Bugs;
        if (CompilingErrors(Bugs) && inicialBugs(tokens))
        {
          Parse Parser = new Parse(tokens, Bugs);
          if (CompilingErrors(Bugs))
          {
            ASTNode ParserCode = Parser.Code;
            ParserCode.CheckSemantic(globalServer, localServer, Bugs);
            if (CompilingErrors(Bugs))
            {
              ParserCode.Evaluate(globalServer, localServer, Bugs);
              if (CompilingErrors(Bugs))
              {
                Console.WriteLine(ParserCode.Value);
              }
            }
          }
        }

      }
      else Console.WriteLine("This code is empety write again");
    }
    Console.Clear();
  }
  static bool inicialBugs(List<Token> tokens)
  {
    var lastPos = tokens.Count - 1;
    if (tokens[lastPos].Value != ";")
    {
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("The code is not closed:  the symbol ';' is missing");
      Console.ForegroundColor = ConsoleColor.White;
      return false;
    }
    return true;
  }
  static List<Token> CollectList(IEnumerable<Token> tokens)
  {
    var Tokens = new List<Token>();
    Tokens.Add(new Token(TokenType.GeneralSymbol, ">"));
    foreach (var token in tokens) Tokens.Add(token);
    return Tokens;
  }
  static bool CompilingErrors(List<CompilingBugs> bugs)
  {
    if (bugs.Count != 0)
    {
      Console.ForegroundColor = ConsoleColor.DarkRed;
      foreach (var item in bugs) { Console.WriteLine("! " + item.Code + " Bug " + item.Argument); }
      Console.ForegroundColor = ConsoleColor.White;
      return false;
    }
    return true;
  }
}
