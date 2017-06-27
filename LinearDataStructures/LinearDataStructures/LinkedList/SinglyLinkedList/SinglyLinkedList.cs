using System;

namespace LinearDataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedList()
        {
            this.First = null;
            this.Last = null;
            this.Size = 0;
        }

        public int Size { get; private set; }
        public SinglyLinkedNode<T> First { get; set; }
        public SinglyLinkedNode<T> Last { get; set; }

        //Add an element to front
        public void AddToFront(T value)
        {
            var newNode = new SinglyLinkedNode<T>(value);
            if (First == null)
            {
                ++Size;
                this.First = Last = newNode;
                return;
            }

            newNode.Next = First;
            this.First = newNode;
        }

        //Add an element to back 
        public void AddToBack(T value)
        {
            var newNode = new SinglyLinkedNode<T>(value);
            if (First == null)
            {
                First = Last = newNode;
                return;
            }

            AddAfter(Last, value);
        }

        //Add after node
        public void AddAfter(SinglyLinkedNode<T> node, T value)
        {
            var newNode = new SinglyLinkedNode<T>(value);

            newNode.Next = node.Next;
            node.Next = newNode;
        }

        //Remove the element at the beginning
        public void RemoveFront()
        {
            this.First = First.Next;
        }

        //Remove the last element
        public void RemoveLast()
        {
            if (Last == null)
            {
                throw new ArgumentNullException("List is empty");
            }
            var currNode = this.First;
            while (currNode.Next != null)
            {
                currNode = currNode.Next;
            }

            currNode.Next = null;
            this.Last = currNode;
        }

        //Remove a node from anywhere
        public void Remove(SinglyLinkedNode<T> node)
        {
            --Size;

            var currNode = this.First;
            while (currNode.Next != node)
            {
                currNode = currNode.Next;
            }

            currNode.Next = node.Next;
        }
    }
}
