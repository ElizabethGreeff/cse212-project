public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1:
        // Create a new array with the required length.
        // This array will store all the multiples.

        double[] result = new double[length];

        // Step 2:
        // Use a loop to go through each position in the array.

        for (int i = 0; i < length; i++)
        {
            // Step 3:
            // Calculate the multiple for the current position.

            result[i] = number * (i + 1);
        }

        // Step 4:
        // Return the completed array.

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1:
        // Find where the list should be split.

        int splitIndex = data.Count - amount;

        // Step 2:
        // Get the part from the split index to the end.

        List<int> endPart = data.GetRange(splitIndex, amount);

        // Step 3:
        // Get the beginning part of the list.

        List<int> beginningPart = data.GetRange(0, splitIndex);

        // Step 4:
        // Clear the original list so we can rebuild it.

        data.Clear();

        // Step 5:
        // Add the end part first.

        data.AddRange(endPart);

        // Step 6:
        // Add the beginning part after it.

        data.AddRange(beginningPart);
    }
}
