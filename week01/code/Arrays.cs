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

        // Step 1: Create an array of doubles with the specified length.
        // Step 2: Use a loop to fill the array with multiples of the given number.
        //         For example, if number = 3 and length = 5, then array should be:
        //         index 0: 3 (3 * 1)
        //         index 1: 6 (3 * 2)
        //         index 2: 9 (3 * 3)
        //         index 3: 12 (3 * 4)
        //         index 4: 15 (3 * 5)
        // Step 3: Return the filled array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples; // replace this return statement with your own
        
        // Calling MultiplesOf(3, 5) would return: {3, 6, 9, 12, 15}

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

        // Step 1: Determine the number of elements in the list using data.Count.
        // Step 2: Calculate the starting point of the rotation. We want to move the last 'amount' elements to the front.
        //         For example: if amount = 3 and list = {1,2,3,4,5,6,7,8,9}
        //         then we move {7,8,9} to the front and shift the rest.
        // Step 3: Use GetRange to extract the last 'amount' elements.
        // Step 4: Use GetRange to extract the remaining elements from the beginning to the new split point.
        // Step 5: Clear the original list and then add the two parts back in order: rotatedPart + remainingPart.

        int count = data.Count;

        // Extract the last 'amount' elements (the part to move to front)
        List<int> rotatedPart = data.GetRange(count - amount, amount);

        // Extract the first part (the part to move to the back)
        List<int> remainingPart = data.GetRange(0, count - amount);

        // Clear the original list and rebuild it in rotated order
        data.Clear();
        data.AddRange(rotatedPart);
        data.AddRange(remainingPart);

        // Result: numbers = {7, 8, 9, 1, 2, 3, 4, 5, 6}
    }
}
