public class TokenStream  
{
    int position;
    public int Position { get { return position; } }

    public bool End{get{return Position == Count-1;}}
    public int Count;

    public TokenStream(List<Token> tokens)
    {  
    
        position = 0;
        Count = tokens.Count;

    }

   

    public void MoveNext(int k)
    {
        position += k;
    }

    public void MoveBack(int k)
    {
        position -= k;
       
    }

    public bool Next()
    {
        if (Position < Count - 1)
        {
            position++;
        }

        return Position < Count;
    }

    public bool Next( TokenType type , List<Token> tokens)
    {
       
        if (Position < Count-1 && LookAhead(tokens,1).Type == type)
        {
            position++;
            return true;
        }

        return false;
    }

    public bool Next(string value, List<Token> tokens)
    {            
        if (Position < Count-1 && LookAhead(tokens,1).Value == value)
        {
            position++;
            return true;
        }

        return false;
    }

    public bool CanLookAhead(int k = 0)
    {
        return Count - Position > k;
    }

    public Token LookAhead(List<Token> tokens,int k=0)
    {
        return tokens[Position+k];
    }
}