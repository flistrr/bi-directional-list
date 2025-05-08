using System;

namespace List;

public class Node
{
    private Node? next;
    private Node? prev;
    private double data;

    public double Data {
        get => data;
        set => data = value;
    }
    public Node? Next {
        get => next;
        set => next = value;
    }
    public Node? Prev {
        get => prev;
        set => prev = value;
    }

    public Node(double data)
    {
        this.data = data;
        next = null;
        prev = null;
    }
}
