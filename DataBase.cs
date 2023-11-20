public class DataBase
{
   public DataBase(GlobalServer globalServer)
   {
     Data(globalServer);
   }
   void Data(GlobalServer globalServer)
   {
     List<Tuple<string,List<string>>>Function = Function1();
     for (int i = 0; i < Function.Count; i++) {globalServer.Function.Add(Function[i],null!);}
   }
   List<Tuple<string,List<string>>> Function1()
   {
      
      List<Tuple<string,List<string>>> tuples = new List<Tuple<string, List<string>>>();
      Tuple<string,List<string>> tuple = new Tuple<string, List<string>> ("sen", new List<string>(){"x"});
      Tuple<string,List<string>> tuple1 = new Tuple<string, List<string>> ("cos", new List<string>(){"x"});
      Tuple<string,List<string>> tuple2 = new Tuple<string, List<string>> ("log", new List<string>(){"x","y"});
      tuples.Add(tuple);
      tuples.Add(tuple1);
      tuples.Add(tuple2);
      return tuples; 
   }
   public void completeFunction(GlobalServer globalServer)
   {
      List<Tuple<string,List<string>>>Function = Function1();
     List<Expression> Argument= Expressions();
     for (int i = 0; i < Function.Count; i++) {globalServer.Function[Function[i]]= Argument[i];}
   
   }
   List<Expression> Expressions ()
   {
      List<Expression> expressionss = new List<Expression>();
     
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("Define el angulo del seno");
      Console.ForegroundColor = ConsoleColor.White;
      double x= double.Parse(Console.ReadLine()!);
    
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("Define el angulo del coseno");
      Console.ForegroundColor = ConsoleColor.White;
      double y=double.Parse(Console.ReadLine()!);
      
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("Define el Argumento del Logaritmo");
      Console.ForegroundColor = ConsoleColor.White;
      double z=double.Parse(Console.ReadLine()!);
      
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("Define la Base del logaritmo");
      Console.ForegroundColor = ConsoleColor.White;
      double w= double.Parse(Console.ReadLine()!);

      Expression expression = new Number( Math.Sin(x));
      Expression expression1= new Number( Math.Cos(y));
      Expression expression2= new Number (Math.Log(z,w));
      expressionss.Add(expression);
      expressionss.Add(expression1);
      expressionss.Add(expression2);
      return expressionss;
   }
    

}