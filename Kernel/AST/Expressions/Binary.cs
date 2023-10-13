
public abstract class BinaryExpression : Expression
{
    public BinaryExpression( ) : base(){}

    public Expression? Left { get; set; }

    public Expression? Right { get; set; }

   
}
