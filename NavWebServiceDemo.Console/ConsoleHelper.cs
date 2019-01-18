using System;

namespace NavWebServiceDemo.Console
{
    public static class ConsoleHelper
    {
        public static void WriteHeadLine(string value)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(new String('-',40));
            System.Console.WriteLine("---"+value+"---");
            System.Console.WriteLine(new String('-', 40));
        }
    }
}
