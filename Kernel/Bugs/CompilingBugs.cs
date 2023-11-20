
public class CompilingBugs
{
    public CompilingBugs (BugCode code, string argument)
    {
        this.Code = code;
        this.Argument = argument;
    }

    public BugCode Code { get; }

    public string Argument { get; }
}

public enum BugCode
{
    lexico,
    Sintaxis,
    semantico,
    compilacion,
}
