public class Variable: AtomExpression

{
    public Variable(string id) : base()
    {
        this.id= id;

    }
    public override ExpressionType Type 
    {
     get {return ExpressionType.variable;}
     set {} 
    }
    public override object? Value { get ; set;}
    public string id{get;set;}
    

}
