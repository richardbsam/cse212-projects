using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A priority queue where items are enqueued to the back,
/// but dequeued based on highest priority (FIFO for ties).
/// </summary>
public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The node is always added to the back of the queue regardless of priority.
    /// </summary>
    /// <param name="value">The value to enqueue</param>
    /// <param name="priority">The priority of the value</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return the value of the item with the highest priority.
    /// If multiple items have the same highest priority, the one closest to
    /// the front is returned (FIFO order).
    /// </summary>
    /// <returns>The value of the dequeued item</returns>
    /// <exception cref="InvalidOperationException">Thrown if the queue is empty</exception>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the highest priority
        int highestPriority = _queue.Max(item => item.Priority);

        // Find the first item with that highest priority (FIFO)
        for (int i = 0; i < _queue.Count; i++)
        {
            if (_queue[i].Priority == highestPriority)
            {
                var value = _queue[i].Value;
                _queue.RemoveAt(i);
                return value;
            }
        }

        // This should not happen
        throw new InvalidOperationException("Unexpected error during Dequeue.");
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
