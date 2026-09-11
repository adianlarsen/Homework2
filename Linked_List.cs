using System;

// Node class defined OUTSIDE the LinkedList class
public class Node
{
    public int value;
    public Node next;

    public Node(int value)
    {
        this.value = value;
    }
}

public class LinkedList
{
    private Node head;
    private Node tail;
    private int length;

    // Constructor
    public LinkedList(int value)
    {
        Node newNode = new Node(value);
        head = newNode;
        tail = newNode;
        length = 1;
    }

    public Node GetHead()
    {
        return head;
    }

    public Node GetTail()
    {
        return tail;
    }

    public int GetLength()
    {
        return length;
    }

    public void PrintList()
    {
        Node temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.value);
            temp = temp.next;
        }
    }

    //Problem 1: Removing Duplicates from a Sorted Linked List
    public void RemoveDuplicates()   
    {
        

    }

    public void PrintAll()
    {
        if (length == 0)
        {
            Console.WriteLine("Head: null");
            Console.WriteLine("Tail: null");
        }
        else
        {
            Console.WriteLine("Head: " + head.value);
            Console.WriteLine("Tail: " + tail.value);
        }
        Console.WriteLine("Length: " + length);
        Console.WriteLine("\nLinked List:");
        if (length == 0)
        {
            Console.WriteLine("empty");
        }
        else
        {
            PrintList();
        }
    }

    public void MakeEmpty()
    {
        head = null;
        tail = null;
        length = 0;
    }

    public void Append(int value)
    {
        Node newNode = new Node(value);
        if (length == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }
        length++;
    }

    public Node RemoveLast()
    {
        if (length == 0) return null;

        Node temp = head;
        Node pre = head;

        while (temp.next != null)
        {
            pre = temp;
            temp = temp.next;
        }

        tail = pre;
        tail.next = null;
        length--;

        if (length == 0)
        {
            head = null;
            tail = null;
        }
        return temp;
    }

    public void Prepend(int value)
    {
        Node newNode = new Node(value);
        if (length == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.next = head;
            head = newNode;
        }
        length++;
    }

    public Node RemoveFirst()
    {
        if (length == 0)
        {
            head = null;
            tail = null;
            return null;
        }

        Node temp = head;
        head = head.next;
        temp.next = null;
        length--;

        if (length == 0) tail = null;
        return temp;
    }

    public Node Get(int index)
    {
        if (index < 0 || index >= length) return null;

        Node temp = head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.next;
        }
        return temp;
    }

    public bool Set(int index, int value)
    {
        Node temp = Get(index);
        if (temp != null)
        {
            temp.value = value;
            return true;
        }
        return false;
    }

    public bool Insert(int index, int value)
    {
        if (index < 0 || index > length) return false;
        if (index == 0)
        {
            Prepend(value);
            return true;
        }
        if (index == length - 1 || index == length)
        {
            Append(value);
            return true;
        }

        Node newNode = new Node(value);
        Node temp = Get(index - 1);
        newNode.next = temp.next;
        temp.next = newNode;
        length++;
        return true;
    }

    public Node Remove(int index)
    {
        if (index < 0 || index >= length) return null;
        if (index == 0) return RemoveFirst();
        if (index == length - 1) return RemoveLast();

        Node temp = Get(index);
        Node prev = Get(index - 1);
        prev.next = temp.next;
        temp.next = null;
        length--;
        return temp;
    }

    public void Reverse()
    {
        Node temp = head;
        head = tail;
        tail = temp;

        Node before = null;
        Node after;

        for (int i = 0; i < length; i++)
        {
            after = temp.next;
            temp.next = before;
            before = temp;
            temp = after;
        }
    }

    // Floyd's Tortoise and Hare algorithm
    public Node FindMiddleNode()
    {
        if (head == null) return null;

        Node slow = head;
        Node fast = head;

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }
        return slow;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Constructor
        LinkedList list = new LinkedList(4);
        Console.WriteLine("Initial list:");
        list.PrintAll();

        // Append
        list.Append(7);
        list.Append(15);
        Console.WriteLine("\nAfter Append(7), Append(15):");
        list.PrintAll();

        // Prepend
        list.Prepend(1);
        Console.WriteLine("\nAfter Prepend(1):");
        list.PrintAll();

        // GetHead / GetTail / GetLength
        Console.WriteLine("\nHead value: " + list.GetHead().value);
        Console.WriteLine("Tail value: " + list.GetTail().value);
        Console.WriteLine("Length: " + list.GetLength());

        // Get
        Node node = list.Get(2);
        Console.WriteLine("\nGet(2) value: " + (node != null ? node.value.ToString() : "null"));

        // Set
        list.Set(2, 99);
        Console.WriteLine("\nAfter Set(2, 99):");
        list.PrintAll();

        // Insert
        list.Insert(2, 50);
        Console.WriteLine("\nAfter Insert(2, 50):");
        list.PrintAll();

        // Remove (middle)
        list.Remove(2);
        Console.WriteLine("\nAfter Remove(2):");
        list.PrintAll();

        // RemoveFirst
        list.RemoveFirst();
        Console.WriteLine("\nAfter RemoveFirst():");
        list.PrintAll();

        // RemoveLast
        list.RemoveLast();
        Console.WriteLine("\nAfter RemoveLast():");
        list.PrintAll();

        // Add a few more values for reverse/middle demo
        list.Append(20);
        list.Append(30);
        list.Append(40);
        Console.WriteLine("\nBefore Reverse():");
        list.PrintAll();

        // Reverse
        list.Reverse();
        Console.WriteLine("\nAfter Reverse():");
        list.PrintAll();

        // FindMiddleNode
        Node middle = list.FindMiddleNode();
        Console.WriteLine("\nMiddle node value: " + (middle != null ? middle.value.ToString() : "null"));

        // MakeEmpty
        list.MakeEmpty();
        Console.WriteLine("\nAfter MakeEmpty():");
        list.PrintAll();

        Console.WriteLine("\nDone. Press any key to exit.");
        Console.ReadKey();
    }
}
