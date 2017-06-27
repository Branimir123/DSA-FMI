namespace LinearDataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedNode<T>
    {
        public SinglyLinkedNode(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value { get; set; }
        public SinglyLinkedNode<T> Next { get; set; }
    }
}
