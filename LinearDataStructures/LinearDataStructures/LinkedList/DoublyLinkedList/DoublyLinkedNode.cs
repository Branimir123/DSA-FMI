namespace LinearDataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedNode<T>
    {
        public DoublyLinkedNode(T value)
        {
            this.Value = value;
            this.Prev = null;
            this.Next = null;
        }

        public T Value { get; set; }
        public DoublyLinkedNode<T> Prev { get; internal set; }
        public DoublyLinkedNode<T> Next { get; internal set; }
    }
}
