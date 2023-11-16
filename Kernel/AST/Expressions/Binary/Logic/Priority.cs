 public class Prioritytype: LogicSupport
{
    public Prioritytype(): base() {  }
    public Priority Valor = Priority.Priority3;
    public override Priority Priority { get {return Valor;}}
}