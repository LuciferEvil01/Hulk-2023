 public class TokenReader
    {
      
        readonly string code;
        int pos;

        public TokenReader(string code)
        {
            this.code = code;
            this.pos = 0;
        }

        public bool EOF => (pos >= code.Length);

        public char Peek()
        {
            if (pos < 0 || pos >= code.Length) throw new InvalidOperationException();

            return code[pos];
        }

        public bool ContinuesWith(string prefix)
        {
            if (pos + prefix.Length > code.Length)
                return false;
            for (int i = 0; i < prefix.Length; i++)
                if (code[pos + i] != prefix[i])
                    return false;
            return true;
        }

        public bool Match(string prefix)
        {
            if (ContinuesWith(prefix))
            {
                pos += prefix.Length;
                return true;
            }

            return false;
        }

        public bool ValidIdCharacter(char c, bool begining)
        {
            return c == '_' || (begining ? char.IsLetter(c) : char.IsLetterOrDigit(c));
        }

        public bool Readvariable(out string variable)
        {
            variable = "";
            while (!EOF && ValidIdCharacter(Peek(), variable.Length == 0))
                variable += ReadAny();
            return variable.Length > 0;
        }

        public bool ReadNumber(out string number)
        {
            number = "";
            while (!EOF && char.IsDigit(Peek())) number += ReadAny();
            
            if (!EOF && Match("."))
            {
                number += '.';
                while (!EOF && char.IsDigit(Peek()))
                    number += ReadAny();
            }

            if (number.Length == 0)  return false;

            while (!EOF && char.IsLetterOrDigit(Peek())) number += ReadAny();

            return number.Length > 0;
        }

        public bool ReadUntil(string end, out string text)
        {
            text = "";
            while (!Match(end))
            {
                if (EOF)
                    return false;
                text += ReadAny();
            }
            return true;
        }

        public bool ReadWhiteSpace()
        {
            if (char.IsWhiteSpace(Peek()))
            {
                ReadAny();
                return true;
            }
            return false;
        }

        public char ReadAny()
        {
            if (EOF)
                throw new InvalidOperationException();

            return code[pos++];
        }
    }