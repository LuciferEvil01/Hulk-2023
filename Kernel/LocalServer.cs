 public class LocalServer
{
     public LocalServer()
    {
     Variable= new Dictionary<string,Variable>();
    }

    Dictionary<string,Variable> Variable; 
    public LocalServer? Parent { get; set; }

    public LocalServer CreateChild()
    {
        LocalServer child = new LocalServer();
        child.Parent = this;
            
        return child;
    }
}