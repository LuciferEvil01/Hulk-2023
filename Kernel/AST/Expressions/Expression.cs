
public abstract class Expression : ASTNode
{
    public Expression( ) : base () { }

    public abstract ExpressionType Type { get; set; }
    public abstract void Evaluate();

    public abstract object? Value { get; set; }
}
