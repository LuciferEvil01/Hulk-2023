
public class Number : AtomExpression
{
    public Number(double value) : base()
    {
        this.value = value;
        Type = ExpressionType.Number;
        
    }
     double value ;
    
    public override object? Value { get{ return value;}  }

    public bool IsInt
    {
        get
        {
            int a;
            return int.TryParse(Value!.ToString(), out a);
        }
    }
}
