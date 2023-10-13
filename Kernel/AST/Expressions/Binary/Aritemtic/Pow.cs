public class Pow: Aritmetic
{
    public Pow( ) : base(){}

    public override ExpressionType Type {get; set;}

    public override object? Value {get; set;}

    public override void Evaluate()
    {
        Right!.Evaluate();
        Left!.Evaluate();
        Math.Pow((double)Left.Value!,(double)Right.Value!);
    }

    // public override string? ToString()
    // {
    //     if (Value == null)
    //     {
    //         return String.Format("({0} + {1})", Left, Right);
    //     }
    //     return Value.ToString();
    // }
}
