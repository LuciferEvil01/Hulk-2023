 public class LocalServer
{
     public LocalServer()
    {
     Variable= new Tuple<string,Expression>(null!,null!);
     Node= 0;
    }

    public  Tuple<string,Expression> Variable; 
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