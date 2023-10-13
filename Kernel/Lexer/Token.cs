
public class Token
{
    public string Value { get; private set; }
    public TokenType Type { get; private set; }
    

    public Token(TokenType type, string value)
    {
        this.Type = type;
        this.Value = value; 
    }

    public override string ToString()
        => string.Format("{0} [{1}]", Type, Value);
}
public enum TokenType
{
    Number,
    Text,
    logicSymbol,
    numericSymbol,
    Keyword,
    Variable,
    GeneralSymbol,
    Parameter,
}

public class TokenValues
{
    protected TokenValues() { }

    public const string Add = "+"; // +
    public const string Sub = "-"; // -
    public const string Mul = "*"; // *
    public const string Div = "/"; // /
    public const string Pow = "^"; // ^
    public const string sen = "sen"; // sen
    public const string cos = "cos"; // cos
    public const string log = "log"; // log
    public const string PI = "PI"; // PI (180°)


    public const string Greater = ">";
    public const string GorE = ">=";
    public const string SorE = "<=";
    public const string smaller = "<";
    public const string equal = "==";
    public const string or = "||";
    public const string and = "&&";


    public const string Assign = "="; // =
    public const string ValueSeparator = ","; // ,
    public const string StatementSeparator = ";"; // ;

    public const string OpenBracket = "("; // (
    public const string ClosedBracket = ")"; // )
    public const string OpenCurlyBraces = "{"; // {
    public const string ClosedCurlyBraces = "}"; // }

    public const string Print = "Print"; // Print
    public const string Function = "Function"; // Function
    public const string If = "if"; // If
    public const string Else = "else"; // else
    public const string id = ""; // variable
    public const string Let = "let"; // let
    public const string In = "in"; // in
    public const string Parameter = ""; // x

   

}
