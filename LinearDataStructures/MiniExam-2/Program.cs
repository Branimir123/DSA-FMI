using System;
using System.Linq;

namespace MiniExam_2
{
    public class Node
    {
        public Node(Node left, int value)
        {
            this.Value = value;
            this.Left = left;
            this.Right = null;

            if (left != null)
            {
                left.Right = this;
            }
        }

        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public static void Remove(Node node)
        {
            if (node.Left != null)
            {
                node.Left.Right = null;
            }

            if (node.Right != null)
            {
                node.Right.Left = null;
            }

            node.Left = null;
            node.Right = null;
        }

        public static void Add(Node left, Node right)
        {
            if (left == right)
            {
                return;
            }

            left.Right = right;
            right.Left = left;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var allSwaps = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var nodes = new Node[n + 1];
            for (int i = 1; i <= n; i++)
            {
                nodes[i] = new Node(nodes[i - 1], i);
            }

            var start = nodes[1];
            var end = nodes[n];

            // For every number which has to be swaped: 
            foreach (var swap in allSwaps)
            {
                //Find the number 
                var middle = nodes[swap];

                //Make it's right left
                var newRight = middle.Left;

                //Make it's left right
                var newLeft = middle.Right;

                //Remove the number
                Node.Remove(middle);

                //Attach the new in opposite order
                Node.Add(end, middle);
                Node.Add(middle, start);

                //Change the old start and end
                start = newLeft ?? middle;
                end = newRight ?? middle;
            }

            var results = new int[n];
            for (int i = 0; i < n; i++)
            {
                results[i] = start.Value;
                start = start.Right;
            }

            Console.WriteLine(string.Join(" ", results));
        }
    }
}
