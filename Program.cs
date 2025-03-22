using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lab1Task2;
public class Program
{ 
    public static void Main()
    {

        Assembly assembly = Assembly.LoadFrom("Lab1Library.dll");

        Type[] types = assembly.GetTypes();
        foreach (Type t in types)
        {
            Console.WriteLine("class: " + t.Name);
            foreach(var temp in t.GetProperties())
            {
                Console.WriteLine("\t\tproperty:" + temp.Name);
            }
            foreach(var temp in t.GetMethods())
            {
                Console.WriteLine("\t\tmethod:" + temp.Name);
            }
        }        

        Console.ReadKey();
    }
}