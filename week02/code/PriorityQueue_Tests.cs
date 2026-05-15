using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities (A=1, B=5, C=3) and dequeue once.
    // Expected Result: B (highest priority should be removed first).
    // Defect(s) Found: If a lower priority item is removed instead, the dequeue logic is not correctly selecting the highest priority item.
    public void TestPriorityQueue_HighestPriorityRemovedFirst()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Add three items with the same priority (A=5, B=5, C=5) and dequeue once.
    // Expected Result: A (first inserted item should be removed when priorities are equal).
    // Defect(s) Found: If B or C is removed instead, the queue is not maintaining FIFO order for equal priorities.
    public void TestPriorityQueue_TieBreakFIFO()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);

        var result = pq.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: If no exception is thrown or the message is incorrect, the empty-queue handling is not implemented properly.
    public void TestPriorityQueue_EmptyThrowsException()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with mixed priorities and dequeue until empty.
    // Expected Result: B, D, C, A (items should be removed in order of highest priority, with FIFO used for ties).
    // Defect(s) Found: If ordering is incorrect, either priority comparison or tie-breaking logic is not implemented correctly.
    public void TestPriorityQueue_MultipleDequeueOrder()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("A", 2);
        pq.Enqueue("B", 9);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 9);

        Assert.AreEqual("B", pq.Dequeue()); // first 9, should be B since it was added before D
        Assert.AreEqual("D", pq.Dequeue()); // second 9, should be D
        Assert.AreEqual("C", pq.Dequeue()); // next highest should be C with 5
        Assert.AreEqual("A", pq.Dequeue()); // last should be A with 2
    }
}