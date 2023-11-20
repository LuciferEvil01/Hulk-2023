using System.Runtime.CompilerServices;

public class VFunction: AtomExpression

{
    // variable Funcional 
    public VFunction(string id ,List<Expression> parameter) : base()
    {
       this.id= id;
       this.parameter= parameter;
       Type= ExpressionType.variable;
          
    }
    public override object? Value { get ; set;}// valor de la variable 
    public string id{get;set;} // nombre de la variable
    
    public List<Expression> parameter {get; set;} // valor del parametro 
    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs) 
    { 
        // metodo que se encarga de definirle un valor a la variable 
        if(localServer.Node>1000) Bugs.Add( new CompilingBugs(BugCode.compilacion,"stackOverFlow "));
        
        if(localServer!=null! && globalServer!= null && Bugs.Count==0 )
        {
            foreach (var item in globalServer.Function)// revisa todas las funciones declaradas anteriormente
          {
            if(item.Key.Item1==id && item.Key.Item2.Count== parameter.Count)// ejecuta una accion solo si la variable esta declarada
            {   
             for (int i = 0; i < item.Key.Item2.Count; i++)
              { 
                if(localServer.Variable.ContainsKey(item.Key.Item2[i])) 
                localServer.Variable[item.Key.Item2[i]]= parameter[i];
                else localServer.Variable.Add(item.Key.Item2[i],parameter[i]);
              }     
           
               var Argument = item.Value;
               Argument.Evaluate(globalServer,localServer.CreateChild(),Bugs);
               Value=Argument.Value; // toma el valor de la expression como propia
               
               if(localServer.value.ContainsKey(RayId)) RayId++;
               if(Bugs.Count==0)localServer.value.Add(RayId,(double)Value!);
            
            Type= ExpressionType.Number;// define esta variable de tipo numero
              return;
            }
          }
        }
        Bugs.Add( new CompilingBugs(BugCode.semantico," this variable "+ id+" is not  valid "));
        Type= ExpressionType.Bug;
        // en caso de nunca encontrar una coinciencia dentro del ciclo adiciona un nuevo error a la lista de 
        // errores 
        
    }
    

}
