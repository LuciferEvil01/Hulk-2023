 public class AtomBug: AtomExpression
{
   public AtomBug(): base()
  {

  }
    public override object? Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
}