using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4
{
    class Calculator
    {
        int Add(int a , int b){
            return a + b; 
        }
        int Subtract(int a, int b)
        {
            return a - b;
        }
        int Multiply(int a, int b)
        {
            return a * b;
        }
        int Divide(int a, int b)
        {
            return a / b;
        }
        int Add(int a, int b,int c)
        {
            return a + b + c;
        }
        int Subtract(int a, int b,int c)
        {
            return a - b - c;
        }
        int Multiply(int a, int b , int c)
        {
            return a * b * c;
        }
        int Divide(int a, int b , int c)
        {
            return (a / b)/c;
        }
        int Add(params int[] numbers)
        {
            int answer = 0;
            foreach(int i in numbers) {
                answer = answer + i;
            }
            return answer;
        }
        int Subtract(params int[] numbers)
        {
            int answer = 0;
            foreach (int i in numbers)
            {
                answer = answer - i;
            }
            return answer;
        }
        int Multiply(params int[] numbers)
        {
            int answer = 1;
            foreach (int i in numbers)
            {
                answer = answer * i;
            }
            return answer;
        }
        float Divide(params int[] numbers)
        {
            float answer = numbers[0];
            for(int i=0;i<numbers.Length;i++)
            {
                answer = answer / numbers[i];
            }
            return answer;
        }
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine("Add -> 1 + 2 + 3 + 4 : " + calc.Add(1, 3, 4));
            Console.WriteLine("Sub -> 1 - 2 - 3 - 4 : " + calc.Subtract(1, 2, 3, 4));
            Console.WriteLine("Mul -> 1 * 2 * 3 * 4 : " + calc.Multiply(1, 2, 3, 4));
            Console.WriteLine("Div -> 1 / 2 / 3 / 4 : " + calc.Divide(1, 2, 3, 4));
            Console.WriteLine("Press Any Key to Exit...");
            Console.ReadKey();
        }
    }
}
