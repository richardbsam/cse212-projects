using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities
    // Expected Result: Dequeue returns values in descending priority order
    // Defect(s) Found: None
    public void Dequeue_Returns_Highest_Priority_Item_First()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 5);
        pq.Enqueue("Mid", 3);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Mid", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with same highest priority
    // Expected Result: First-in of those with highest priority is removed (FIFO respected)
    // Defect(s) Found: None
    public void Dequeue_Preserves_FIFO_For_Same_Priority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 4);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 2);

        Assert.AreEqual("B", pq.Dequeue()); // First of the two 5s
        Assert.AreEqual("C", pq.Dequeue()); // Second of the two 5s
        Assert.AreEqual("A", pq.Dequeue()); // Next priority
        Assert.AreEqual("D", pq.Dequeue()); // Lowest
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from empty queue
    // Expected Result: InvalidOperationException thrown
    // Defect(s) Found: None
    public void Dequeue_Throws_Exception_When_Empty()
    {
        var pq = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: ToString returns proper string representation
    // Expected Result: Items listed with correct format and order
    // Defect(s) Found: None
    public void ToString_Formats_Correctly()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 1);
        pq.Enqueue("Y", 2);
        var expected = "[X (Pri:1), Y (Pri:2)]";

        Assert.AreEqual(expected, pq.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue same value with different priorities
    // Expected Result: Each item treated independently
    // Defect(s) Found: None
    public void Enqueue_Same_Value_Different_Priorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Task", 2);
        pq.Enqueue("Task", 5);

        Assert.AreEqual("Task", pq.Dequeue()); // The one with priority 5
        Assert.AreEqual("Task", pq.Dequeue()); // Then the one with priority 2
    }
}
