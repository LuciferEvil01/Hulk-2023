public class DataBase
{
   public DataBase(GlobalServer globalServer)
   {
     Data(globalServer);
   }
   void Data(GlobalServer globalServer)
   {
     List<Tuple<string,List<string>>>Function = Function1();
     List<Expression> Argument= Expressions();
     for (int i = 0; i < Function.Count; i++) {globalServer.Function.Add(Function[i],Argument[i]);}
     
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
   List<Expression> Expressions ()
   {
      List<Expression> expressionss = new List<Expression>();
      double x = 0;
      Variable variable = new Variable("x");
      variable.Value=x;
      Variable variable1 = new Variable("y");
      variable1.Value=x;
      Expression expression = new Number( Math.Sin((double)variable.Value!));
      Expression expression1= new Number( Math.Cos((double)variable.Value!));
      Expression expression2= new Number (Math.Log((double)variable.Value!,(double)variable1.Value!));
      expressionss.Add(expression);
      expressionss.Add(expression1);
      expressionss.Add(expression2);
      return expressionss;
   }
    

}