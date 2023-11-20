 public class LocalServer
{
     public LocalServer()
    {
     Variable= new Dictionary<string, Expression>();
     Node= 0;
     value= new Dictionary<double, double>();
    }

    public  Dictionary<string,Expression> Variable;
    public Dictionary<double,double> value;
   
    public LocalServer? Parent { get; set; }
    public int Node{get; set;}

    public LocalServer CreateChild()
    {
        LocalServer child = new LocalServer();
        child.Parent = this;
        child.Node= this.Node+1;       
        return child;
    }
}