﻿using DefaultNamespace;

namespace tiny_scanner
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Compiler_functions test=new Compiler_functions("{return a||b}; int a+b ; int z=\"2\" ");
        }
    }
}