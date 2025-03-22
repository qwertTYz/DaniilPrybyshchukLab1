using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lab1Task3;
public class Task3
{
    public static void Main()
    {
        Assembly assembly = Assembly.LoadFrom("Lab1Library.dll");

        try
        {
            Type type = assembly.GetType("Lab1Library.Service");
            MethodInfo minfo = type.GetMethod("Create");
            object typeInstance = Activator.CreateInstance(type);
            object[] parameters = new object[minfo.GetParameters().Length];
            parameters[0] = "servis";
            parameters[1] = "street";
            parameters[2] = false;


            var temp = minfo.Invoke(typeInstance, parameters);

            minfo = type.GetMethod("PrintObject");
            minfo.Invoke(temp, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        Console.ReadKey();
    }
}