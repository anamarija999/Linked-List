public class DoublyLinkedList<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Prev { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Prev = null;
            Next = null;
        }
    }

    private Node head;
    private Node tail;

    public int Count { get; private set; }

    public void AddFirst(T value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
        Count++;
    }

    public void AddLast(T value)
    {
        Node newNode = new Node(value);
        if (tail == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Prev = tail;
            tail.Next = newNode;
            tail = newNode;
        }
        Count++;
    }

    public void RemoveFirst()
    {
        if (head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }
        else if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            head = head.Next;
            head.Prev = null;
        }
        Count--;
    }

    public void RemoveLast()
    {
        if (tail == null)
        {
            throw new InvalidOperationException("List is empty.");
        }
        else if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            tail = tail.Prev;
            tail.Next = null;
        }
        Count--;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        Count = 0;
    }

    public T[] ToArray()
    {
        T[] array = new T[Count];
        Node current = head;
        int i = 0;
        while (current != null)
        {
            array[i++] = current.Value;
            current = current.Next;
        }
        return array;
    }
}
