
public class Text : AtomExpression
{
    public Text(string value ) : base()
    {
        Value = value;
        Type = ExpressionType.Text;
        
    }
  
   

    public override object? Value { get; set; }
}
