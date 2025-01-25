using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedQueue<T>
{
    private Queue<T> queue = new Queue<T>();
    private readonly int maxSize = 3;

    public FixedQueue(int size)
    {
        maxSize = size;
    }
    
    public void Enqueue(T item)
    {
        if (queue.Count >= maxSize)
        {
            queue.Dequeue(); // Remove oldest item if we're at capacity
        }
        queue.Enqueue(item);
    }

    public T Dequeue()
    {
        return queue.Dequeue();
    }

    public T Peek()
    {
        return queue.Peek();
    }

    public int Count
    {
        get { return queue.Count; }
    }

    public bool Contains(T item)
    {
        return queue.Contains(item);
    }
}