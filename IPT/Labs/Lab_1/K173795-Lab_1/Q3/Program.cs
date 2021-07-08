using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int sumLeftDiagonal = 0, size;
            
            Console.Write("Enter matrix size : ");
            size = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rnd.Next(1, 10);
                    Console.Write(matrix[i, j] + "  ");
                }
                Console.WriteLine();
            }
            
            for(int i = 0; i < size; i++)
            {
                sumLeftDiagonal = sumLeftDiagonal + matrix[i, size - i - 1];
            }
            Console.WriteLine("Left Diagonal Sum : " + sumLeftDiagonal);
            Console.WriteLine("Press Any Key to Exit...");
            Console.ReadKey();
        }

    }
}
