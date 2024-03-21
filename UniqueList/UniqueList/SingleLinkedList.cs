using System.Text;

namespace UniqueListSpace;
public class SingleLinkedList<T>
{
    public int Size { get; private set; }
    protected Node? head = null;

    protected class Node(T value)
    {
        public T value = value;
        public Node next;
    }

    public void Add(T element)
    {
        var newNode = new Node(element);
        if (head != null)
        {
            newNode.next = head;
        }

        head = newNode;
        Size++;
    }

    public void RemoveAt(int index)
    {
        if (0 > index || index >= Size)
        {
            throw new IndexOutOfRangeException("Index out of range.");
        }

        Node? previous = null;
        Node current = head;
        for (int i = 0; i < index; ++i)
        {
            previous = current;
            current = current.next;
        }

        if (previous == null)
        {
            head = current.next;
        }
        else
        {
            previous.next = current.next;
        }

        Size--;
    }

    public T this[int index]
    {
        get { return GetNode(index).value; }
        set { GetNode(index).value = value; }
    }

    protected Node GetNode(int index)
    {
        if (0 > index || index >= Size)
        {
            throw new IndexOutOfRangeException("Index out of range.");
        }

        Node current = head;
        for (int i = 0; i < index; ++i)
        {
            current = current.next;
        }

        return current;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        Node current = head;
        while (current != null)
        {
            sb.Append(current.value.ToString());
            current = current.next;
        }

        return sb.ToString();
    }
}