using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniExam_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Read the input
            var number = Console.ReadLine().ToList();
            var positions = new int[10];
            
            //Call the recursion
            Calculate(number, positions);

            //Print the numbers
            for (int i = 0; i < positions.Length - 2; i++)
            {
                Console.Write("{0} ", positions[i]);
            }
            Console.Write(positions[positions.Length - 1]);
            Console.WriteLine();
        }

        //Recursively calculate the numbers 
        public static void Calculate(List<char> number, int[] positions)
        {
            if (number.Count() == 2)
            {
                var a = int.Parse(number[0].ToString());
                var b = int.Parse(number[1].ToString());

                var curr = (a + b) * (a ^ b) % 10;

                positions[curr]++;

                return;
            }

            for (int counter = 0; counter < number.Count - 1; counter++)
            {
                var newNumber = new List<char>(number);

                var a = int.Parse(newNumber[counter].ToString());
                var b = int.Parse(newNumber[counter + 1].ToString());

                var curr = ((a + b) * (a ^ b) % 10);

                newNumber.RemoveAt(counter + 1);
                newNumber.RemoveAt(counter);

                newNumber.Insert(counter, char.Parse(curr.ToString()));

                Calculate(newNumber, positions);
            }
        }
    }
}
