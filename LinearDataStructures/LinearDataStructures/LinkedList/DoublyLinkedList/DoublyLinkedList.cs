namespace LinearDataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public int Size { get; private set; }
        public DoublyLinkedNode<T> First { get; set; }
        public DoublyLinkedNode<T> Last { get; set; }

        public DoublyLinkedList()
        {
            this.First = null;
            this.Last = null;
            this.Size = 0;
        }

        //Adds an element to the front of the list
        public void AddToFront(T value)
        {
            if (First == null)
            {
                ++Size;
                this.First = Last = new DoublyLinkedNode<T>(value);
                return;
            }
            AddBefore(First, value);
        }

        //Adds an element to the back of the list
        public void AddToBack(T value)
        {
            if (Last == null)
            {
                ++Size;
                First = Last = new DoublyLinkedNode<T>(value);
                return;
            }
            AddAfter(Last, value);
        }

        //Adds a node before another node
        public void AddBefore(DoublyLinkedNode<T> node, T value)
        {
            ++Size;

            var newNode = new DoublyLinkedNode<T>(value);
            newNode.Prev = node.Prev;
            newNode.Next = node;

            newNode.Next.Prev = newNode;
            if (newNode.Prev != null)
            {
                newNode.Prev.Next = newNode;
            }
            else
            {
                First = newNode;
            }
        }

        //Adds a node after another node
        public void AddAfter(DoublyLinkedNode<T> node, T value)
        {
            ++Size;

            var newNode = new DoublyLinkedNode<T>(value);
            newNode.Prev = node;
            newNode.Next = node.Next;

            newNode.Prev.Next = newNode;
            if (newNode.Next != null)
            {
                newNode.Next.Prev = newNode;
            }
            else
            {
                Last = newNode;
            }
        }

        //Remove the item at the beginning
        public void RemoveFront()
        {
            Remove(First);
        }

        //Remove the last item
        public void RemoveLast()
        {
            Remove(Last);
        }

        //Removes an element from the list
        public void Remove(DoublyLinkedNode<T> node)
        {
            --Size;

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                First = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else
            {
                Last = node.Prev;
            }
        }
    }
}
