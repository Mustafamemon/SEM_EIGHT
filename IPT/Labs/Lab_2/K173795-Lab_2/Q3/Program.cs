using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Q3
{
    class Program
    {
        private
             int[] random_array = new int[1000000];
         int start_index;
         int end_index;
         int search_value;


         static void Main(string[] args)
         {
             Random randNum = new Random();
             int[] random_array = Enumerable
                 .Repeat(0, 1000000)
                 .Select(i => randNum.Next(0, 1000))
                 .ToArray();

             Stopwatch stopwatch = new Stopwatch();



             Console.Write("Enter the number you want to search : ");
             int number = int.Parse(Console.ReadLine());


             ParameterizedThreadStart param1 = new ParameterizedThreadStart(searchIndexes);

             Thread th1 = new Thread(param1);
             Thread th2 = new Thread(param1);
             Thread th3 = new Thread(param1);
             Thread th4 = new Thread(param1);
             Thread th5 = new Thread(param1);

             Program wThread1 = new Program(random_array, 0, 200000, number);
             Program wThread2 = new Program(random_array, 200000, 400000, number);
             Program wThread3 = new Program(random_array, 400000, 600000, number);
             Program wThread4 = new Program(random_array, 600000, 800000, number);
             Program wThread5 = new Program(random_array, 800000, 1000000, number);

             Console.WriteLine("\n\t\tOutput With Thread : ");
             stopwatch.Reset();

             stopwatch.Start(); // timmer start
             th1.Start(wThread1);
             stopwatch.Stop(); // timmer stop

             stopwatch.Start(); // timmer start
             th2.Start(wThread2);
             stopwatch.Stop(); // timmer stop

             stopwatch.Start(); // timmer start
             th3.Start(wThread3);
             stopwatch.Stop(); // timmer stop

             stopwatch.Start(); // timmer start
             th4.Start(wThread4);
             stopwatch.Stop(); // timmer stop

             stopwatch.Start(); // timmer start
             th5.Start(wThread5);
             stopwatch.Stop(); // timmer stop

             th1.Join();
             th2.Join();
             th3.Join();
             th4.Join();
             th5.Join();


             TimeSpan ts_with_thread = stopwatch.Elapsed;

             Console.WriteLine("\nElapsed Time is {0} ms", ts_with_thread.Milliseconds);

             Console.WriteLine("Press any key to continue...");
             Console.ReadKey();

         }
         public Program(int[] random_array, int start_index, int end_index, int search_value)
         {
             this.random_array = random_array;
             this.start_index = start_index;
             this.end_index = end_index;
             this.search_value = search_value;
         }
         public void setSearchValue(int value)
         {
             this.search_value = value;
         }
         public void setStartIndex(int value)
         {
             this.start_index = value;
         }
         public void setEndIndex(int value)
         {
             this.end_index = value;
         }
         public int getSearchValue()
         {
             return this.search_value;
         }
         public int getStartIndex()
         {
             return this.start_index;
         }
         public int getEndIndex()
         {
             return this.end_index;
         }
         public int getValueAtIndex(int i)
         {
             return this.random_array[i];
         }

         [MethodImpl(MethodImplOptions.Synchronized)]
         public static void searchIndexes(object obje)
         {
             Program obj = (Program)obje;
             for (int i = obj.getStartIndex(); i < obj.getEndIndex(); i++)
             {
                 if (obj.getSearchValue() == obj.getValueAtIndex(i))
                 {
                    Console.Write(i.ToString() + " ");
                 }
             }

         }
    }
}
