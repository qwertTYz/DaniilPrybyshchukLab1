using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lab1Task1;
public class Task1
{
    public static void Main()
    {
        TryAgain:
        Console.Write("class: ");
        string className = Console.ReadLine();
        Console.Write("method: ");
        string methodName = Console.ReadLine();
        List<string> arguments = new();
        while (true)
        {
            Console.WriteLine("esc - exit\nf - add argument");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Escape) break;
            else if (cki.Key == ConsoleKey.F)
            {
                Console.Write("argument: ");
                string ar = Console.ReadLine();
                arguments.Add(ar);
            }
        }

        object[] prms = new object[arguments.Count];
        for (int i = 0; i < arguments.Count; i++)
        {
            prms[i] = arguments[i];
        }


        Type type = Type.GetType(className);
        try
        {
            object? classInstance = Activator.CreateInstance(type);

            MethodInfo minfo = type.GetMethod(methodName);
            ParameterInfo[] pinfo = minfo.GetParameters();

            for (int i = 0; i < pinfo.Length; i++)
            {
                if (i > prms.Length) break;

                prms[i] = Convert.ChangeType(prms[i], pinfo[i].ParameterType);
            }


            Console.Write("result: ");
            Console.Write(minfo.Invoke(classInstance, prms));
        }
        catch (Exception ex)
        {
            Console.WriteLine("encountered some problems");
            goto TryAgain;
        }
        Console.ReadKey();
    }
}