public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Problem 1: Insert unique values only (ignore duplicates)
        if (value == Data)
        {
            return;  // Duplicate found = do nothing
        }

        if (value < Data)
        {
            // Go left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Go right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data) return true;
        if (value < Data)
            return Left?.Contains(value) ?? false;
        return Right?.Contains(value) ?? false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftH = Left?.GetHeight() ?? 0;
        int rightH = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftH, rightH);
    }
}