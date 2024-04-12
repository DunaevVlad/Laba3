using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        NodeList list = new NodeList();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(6);

        Console.WriteLine("Список элементов:");
        list.Print();

        // Удаляем элементы 3 и 5
        list.Remove(3);
        list.Remove(5);

        Console.WriteLine("Список после удаления:");
        list.Print();

        list.OrganizeQueueAndStack();
    }
}

class Node
{
    public int data;
    public Node next;

    public Node(int d)
    {
        data = d;
        next = null;
    }
}

class NodeList
{
    private Node head;

    public NodeList()
    {
        head = null;
    }

    public void Add(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            return;
        }

        Node current = head;
        while (current.next != null)
        {
            current = current.next;
        }
        current.next = newNode;
    }

    public void Remove(int data)
    {
        if (head == null)
            return;

        if (head.data == data)
        {
            head = head.next;
            return;
        }

        Node current = head;
        while (current.next != null)
        {
            if (current.next.data == data)
            {
                current.next = current.next.next;
                return;
            }
            current = current.next;
        }
    }

    public void Print()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.data + " ");
            current = current.next;
        }
        Console.WriteLine();
    }

    public void OrganizeQueueAndStack()
    {
        Queue queue = new Queue();
        Stack stack = new Stack();
        Node current = head;
        int index = 0;
        while (current != null)
        {
            if (index % 2 == 0)
                queue.Enqueue(current.data); // Элементы с четными индексами добавляем в очередь
            else
                stack.Push(current.data); // Элементы с нечетными индексами добавляем в стек
            current = current.next;
            index++;
        }

        Console.WriteLine("Queue (Элементы с четными индексами):");
        while (queue.Count > 0)
        {
            Console.Write(queue.Dequeue() + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Stack (Элементы с нечетными индексами):");
        while (stack.Count > 0)
        {
            Console.Write(stack.Pop() + " ");
        }
        Console.WriteLine();
    }
}
