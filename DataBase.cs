public class DataBase
{
   public DataBase(GlobalServer globalServer)
   {
     Data(globalServer);
   }
   void Data(GlobalServer globalServer)
   {
     List<Tuple<string,List<string>>>Function = Function1();
     List<Expression> expressions = Expressions();
     for (int i = 0; i < Function.Count; i++) {globalServer.Function.Add(Function[i],expressions[i]);}
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
      
      List<Expression> expressions= new List<Expression>();
      Expression expression = new Sen("x");
      Expression expression1= new Cos("x");
      Expression expression2= new Log("x","y");
      expressions.Add(expression);
      expressions.Add(expression1);
      expressions.Add(expression2);
      return expressions;
   }
    

}