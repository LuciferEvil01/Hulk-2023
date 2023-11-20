
 public abstract class BinaryExpression : Expression
{
    public BinaryExpression( ) : base()
    {
    }

    public Expression? Left { get; set; }

    public Expression? Right { get; set; }
    public bool ValidType (ExpressionType type)
    {
        return type== ExpressionType.Number;
    }
    public bool EqualValue (LocalServer localServer,Expression expression)
    {
       if(localServer.value.Count==0) return true;
       if((double)expression.Value! == localServer.value[expression.RayId]  )  return true;
       else return false ;
    }
   
   
}
