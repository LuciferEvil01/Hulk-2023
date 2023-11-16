public class VFunction: AtomExpression

{
    // variable Funcional 
    public VFunction(string id ,Expression parameter) : base()
    {
       this.id= id;
       this.parameter= parameter;
       Type= ExpressionType.variable;
    }

    public override ExpressionType Type { get ; set ; } // tipo de expression
    public override object? Value { get ; set;}// valor de la variable 
    public string id{get;set;} // nombre de la variable
    public Expression parameter {get; set;} // valor del parametro 
    public override void Evaluate(GlobalServer globalServer,LocalServer localServer, List<CompilingBugs> Bugs) 
    { 
        // metodo que se encarga de definirle un valor a la variable 
        if(localServer!=null!)
        {
            foreach (var item in globalServer.Function)// revisa todas las funciones declaradas anteriormente
          {
            if(item.Key.Item1==id)// ejecuta una accion solo si la variable esta declarada
            {   
              var variable= new Tuple<string,Expression>(item.Key.Item2,parameter); // crea una nueva variable
              localServer.Variable= variable;// define el id como el parametro de la funcion y su expression 
              var Argument= item.Value; // como el argumento de la funcion y despues lo evalua.
              Argument.Evaluate(globalServer,localServer.CreateChild(),Bugs);
              Value= Argument.Value; // toma el valor de la expression como propia
              Type= ExpressionType.Number;// define esta variable de tipo numero
              return;
            }
          }
        }
        Bugs.Add( new CompilingBugs(BugCode.semantico," this variable "+ id+" is not declarate"));
        Type= ExpressionType.Bug;
        // en caso de nunca encontrar una coinciencia dentro del ciclo adiciona un nuevo error a la lista de 
        // errores 
        
    }
    

}
