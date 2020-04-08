using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Compiler_functions
    {
        private string line;


        public Compiler_functions(string line1)
        {
            line = line1;
            for (int i = 0; i < line.Length; i++)
            {

                if (line[i].Equals(' ')) continue;
                else if (('a' <= line[i] && line[0] <= 'z') || ('A' <= line[i] && line[i] <= 'Z'))
                    i+=handle_reserved_and_id(line,i);
                else if ('0' <= line[i] && line[i] <= '9')
                    i+=handle_numbers(line, i);
                else i+=handle_symbols(line, i);
                    
                    
                    
            }
        }

        public int handle_reserved_and_id(string s,int start)
        {
            bool flag = false;
            string x="";
            
            for (int i = start; i < s.Length; i++)
            {
                char z = s[i];

                if(('a'<=s[i]&&z<='z')||('A'<=z&& z<='Z')||('0'<=z&&z<='9'&&i!=0))
                {
                     x+=s[i];
                }
                else break;
            }
            foreach (KeyValuePair<string, tiny_scanner.TokenType> item in tiny_scanner.Token.RESERVED_WORDS)
            {
                if (x.Equals(item.Key))
                {
                    Console.WriteLine(x + "  T_" + item.Value  );
                    flag = true;
                }
            }
            if(!flag)       Console.WriteLine(x+"  ID_"+x);


            return x.Length-1;

        }

        public int handle_numbers(string s, int start)
        {
            bool flag = false;
            string x = "";

            for (int i = start; i < s.Length; i++)
            {
                char z = s[i];

                if (('0' <= z && z <= '9' )||z.Equals('.'))
                {
                    x += s[i];
                    if (z.Equals('.')) flag=true;
                }
                else break;
            }

           

            if (!flag) Console.WriteLine(x + "  T_NUM" );
            else Console.WriteLine(x + "  T_FLOAT"  );


            return x.Length - 1;
        }


        public int handle_symbols(string s, int start)
        {
            bool flag = false;
            string x = "";
            x += line[start];
            if (line[start].Equals(':') && line[start + 1].Equals('='))
            {
                x += '=';
                Console.WriteLine(x + "  T_Assignment" );
            }
            else
            {
                x=(start<x.Length-1)?x+= line[start+1]:x;
                foreach (KeyValuePair<string, tiny_scanner.TokenType> item in tiny_scanner.Token.SPECIAL_SYMBOLS)
                {
                    if (x.Equals(item.Key))
                    {
                        Console.WriteLine(x + "  T_" + item.Value );
                        flag = true;
                    }

                }

                if (!flag)
                {
                    x.Remove(x.Length - 1);
                    foreach (KeyValuePair<string, tiny_scanner.TokenType> item in tiny_scanner.Token.SPECIAL_SYMBOLS)
                    {
                        if (x.Equals(item.Key))
                        {
                            Console.WriteLine(x + "  T_" + item.Value );
                        }

                    }
                }
            }



            return x.Length-1;

        }
    }
    
}