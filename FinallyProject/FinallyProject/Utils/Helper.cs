using System;
using System.Collections.Generic;
using System.Text;

namespace FinallyProject.Utils
{

    public static class Helper
    {
        public static void Color(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}

