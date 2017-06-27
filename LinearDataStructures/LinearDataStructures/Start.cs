using LinearDataStructures.LinkedList.DoublyLinkedList;
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

            //Measure add of structures
            Console.WriteLine(Measure.Action(() =>
            {
                for (int i = 0; i < 1000000; ++i)
                {
                    list.Add(i);
                }
            }));

            var doublyLinkedList = new DoublyLinkedList<int>();

            Console.WriteLine(Measure.Action(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    doublyLinkedList.AddToBack(i);
                }
            }));
        }
    }
}
