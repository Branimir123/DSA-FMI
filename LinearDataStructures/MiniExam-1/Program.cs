using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniExam_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var jedi = Console.ReadLine().Split(' ');
            string titles = "MKP";

            var jediSorted = new Dictionary<char, Queue<string>>();

            foreach (var title in titles)
            {
                jediSorted[title] = new Queue<string>();
            }

            var jediUnsorted = jedi.ToList();
            jediUnsorted.ForEach(j => jediSorted[j[0]].Enqueue(j));

            var strBld = new StringBuilder();
            foreach (var title in titles)
            {
                var queue = jediSorted[title];
                while (queue.Count > 0)
                {
                    strBld.AppendFormat("{0} ", queue.Dequeue());
                }
            }

            Console.WriteLine(strBld.ToString().Trim());
        }
    }
}
