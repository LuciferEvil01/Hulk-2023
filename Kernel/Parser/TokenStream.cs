public class TokenStream  
{
    int position;
    public int Position { get { return position; } }

    public bool End;
    public int Count;

    public TokenStream(List<Token> tokens)
    {  
        End=  position == tokens.Count-1;
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
        if (position < Count - 1)
        {
            position++;
        }

        return position < Count;
    }

    public bool Next( TokenType type , List<Token> tokens)
    {
        if (position < Count-1 && LookAhead(tokens,1).Type == type)
        {
            position++;
            return true;
        }

        return false;
    }

    public bool Next(string value, List<Token> tokens)
    {            
        if (position < Count-1 && LookAhead(tokens,1).Value == value)
        {
            position++;
            return true;
        }

        return false;
    }

    public bool CanLookAhead(int k = 0)
    {
        return Count - position > k;
    }

    public Token LookAhead(List<Token> tokens,int k=0)
    {
        return tokens[position+k];
    }
}