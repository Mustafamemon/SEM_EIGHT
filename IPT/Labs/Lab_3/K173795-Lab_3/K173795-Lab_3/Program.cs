using System;
using System.Reflection;
namespace K173795_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string dll_path = AppDomain.CurrentDomain.BaseDirectory + "EntityFramework.dll";

            Assembly ef = Assembly.LoadFile(dll_path);
            Type myType = ef.GetType();

            MethodInfo[] MethodsInfoPublic = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Console.WriteLine("\n\t\tTotal Number of Public Mehtods is {0}.", MethodsInfoPublic.Length);

            DisplayMethodsInfo(MethodsInfoPublic);

            MethodInfo[] MethodsInfoProtected = myType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Console.WriteLine("\n\t\tTotal Number of Protected Mehtods is {0}.", MethodsInfoProtected.Length);

            DisplayMethodsInfo(MethodsInfoProtected);

            Console.ReadKey();
        }
        public static void DisplayMethodsInfo(MethodInfo[] MethodsInfo)
        {
            for (int i = 0; i < MethodsInfo.Length; i++)
            {
                MethodInfo MethodInfo = (MethodInfo)MethodsInfo[i];
                Console.WriteLine("\nMethod Name : {0}.", MethodInfo.Name);
            }
        }
    }
}
