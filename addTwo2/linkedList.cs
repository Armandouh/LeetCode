namespace addTwo2;

public class linkedList
{
    private Node head;
    private int count;

    public linkedList()
    {
        this.head = null;
        this.count = 0;
    }

    public bool Empty
    {
        get { return this.count == 0; }
    }

    public int Size
    {
        get { return this.count; }
    }

    public object Add(int index, object o)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException("Index: " + index);


        if (index > count)
            index = count;

        Node current = this.head;

        if (this.Empty || index == 0)
        {
            this.head = new Node(o, this.head);
        }
        else
        {
            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
            }

            current.next = new Node(o, current.next);
        }

        count++;
        return o;
    }

    public object Add(object o)
    {
        return this.Add(count, o);
    }

    public void PrintList()
    {
        Node current = this.head;

        while (current != null)
        {
            Console.Write(current.data + " -> ");
            current = current.next;
        }

        Console.Write("null");
        Console.WriteLine();
    }

    public object Remove(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException("index: " + index);

        if (this.Empty)
            return null;
        if (index > this.count)
            index = count - 1;

        Node current = this.head;
        object result = null;

        if (index == 0)
        {
            result = current.data;
            this.head = current.next;
        }
        else
        {
            for (int i = 0; i < index - 1; i++)
                current = current.next;

            result = current.next.data;

            current.next = current.next.next;
        }

        count--;

        return result;
    }

    public void Clear()
    {
        this.head = null;
    }

    public int indexOf(object o)
    {
        Node current = this.head;

        for (int i = 0; i < this.Size; i++)
        {
            if (current.data.Equals(o))
                return i;
            current = current.next;
        }

        return -1;
    }

    public bool Contains(object o)
    {
        return this.indexOf(o) >= 0;
    }

    public object get(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException("index: " + index);

        if (this.Empty)
            return null;

        if (index > this.count)
            index = this.count - 1;

        Node current = this.head;

        for (int i = 0; i < index; i++)
            current = current.next;

        return current.data;
    }

    public object this[int index]
    {
        get { return this.get(index); }
    }
}