public class VFunction: AtomExpression

{
    public VFunction(string id ,object parameter) : base()
    {
        this.id= id;
       this.parameter= parameter;
    }
    public override ExpressionType Type 
    {
     get {return ExpressionType.variable;}
     set {} 
    }
    public override object? Value { get ; set;}
    public string id{get;set;}
    public object parameter {get; set;}
    

}
