public class Or: LogicSupport
{
    public Or()
    {
     
    }
    public override ExpressionType Type {get; set;}

    public override object? Value {get; set;}

    public override void Evaluate()
    {
        Right!.Evaluate();
        Left!.Evaluate();
        
        Value= (bool)Right.Value! || (bool)Left.Value!;
    }
}