using LinearDataStructures.List;
using System;
using Utils.Time;

namespace LinearDataStructures
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            Console.WriteLine(Measure.Action(() =>
            {
                for (int i = 0; i < 100; ++i)
                {
                    list.Add(i);
                }
            }));
        }
    }
}
