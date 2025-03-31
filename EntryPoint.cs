using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Lab1EntryPoint;

public class EntryPoint
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1 - first task\n2 - second task\n3 - third task\n4 - exit");
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    FirstTask();
                    break;
                case ConsoleKey.D2:
                    SecondTask();
                    break;
                case ConsoleKey.D3:
                    ThirdTask();
                    break;
                case ConsoleKey.D4:
                    return;
                default:
                    break;
            }
        }
    }

    public static void FirstTask()
    {
        while (true)
        {
            string className = EnterClassName();
            if (className == "ErrorOccured") break;
            string methodName = EnterMethodName(className);

            Type type = Type.GetType(className);
            MethodInfo methodInfoCheck = type.GetMethod(methodName);
            if (methodInfoCheck == null)
            {
                Console.WriteLine($"such method doesnt exist");
                break;
            }

            List<string> arguments = EnterArguments();

            object[] parameters = new object[arguments.Count];
            for (int i = 0; i < arguments.Count; i++)
            {
                parameters[i] = arguments[i];
            }

           


            object? classInstance = Activator.CreateInstance(type);

            MethodInfo methodInfo = type.GetMethod(methodName);
            ParameterInfo[] parameterInfos = methodInfo.GetParameters();

            if (parameterInfos.Length != parameters.Length)
            {
                Console.WriteLine("parameter count doesnt match");
                break;
            }

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                if (i > parameters.Length) break;

                parameters[i] = Convert.ChangeType(parameters[i], parameterInfos[i].ParameterType);
            }

            Console.Write("result: ");
            Console.Write(methodInfo.Invoke(classInstance, parameters));
            return;
        }
    }

    public static string EnterClassName()
    {
        Console.Write("class: ");
        string className = Console.ReadLine();
        if (Type.GetType(className) == null)
        {
            Console.WriteLine($"cannot create {className}");
            return "ErrorOccured";
        }
        return className;
    }

    public static string EnterMethodName(string className)
    {
        Console.Write("method: ");
        string methodName = Console.ReadLine();
        //if (Type.GetType(className).GetMethod(methodName) )
        //{
        //    Console.WriteLine($"cannot create {className}");
        //    return "ErrorOccured";
        //}
        return methodName;
    }

    public static List<string> EnterArguments()
    {
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

        return arguments;
    }

    public static void SecondTask()
    {
        Assembly assembly = Assembly.LoadFrom("Lab1Library.dll");

        Type[] types = assembly.GetTypes();
        foreach (Type t in types)
        {
            Console.WriteLine("class: " + t.Name);
            foreach (var temp in t.GetProperties())
            {
                Console.WriteLine("\t\tproperty:" + temp.Name);
            }
            foreach (var temp in t.GetMethods())
            {
                Console.WriteLine("\t\tmethod:" + temp.Name);
            }
        }
    }

    public static void ThirdTask()
    {
        Assembly assembly = Assembly.LoadFrom("Lab1Library.dll");

        Type type = assembly.GetType("Lab1Library.Service");
        MethodInfo methodInfo = type.GetMethod("Create");
        object typeInstance = Activator.CreateInstance(type);
        object[] parameters = new object[methodInfo.GetParameters().Length];
        parameters[0] = "servis";
        parameters[1] = "street";
        parameters[2] = false;


        var temp = methodInfo.Invoke(typeInstance, parameters);

        methodInfo = type.GetMethod("PrintObject");
        methodInfo.Invoke(temp, null);
    }
}