using ChordMan.Models;

namespace ChordMan.ExtensionMethods;

public static class DataExtensions
{
    public static int GetWrappedIndex(this int[] array, int position)
    {
        if (array.Length == 0) throw new ArgumentException("Array cannot be empty");

        int wrappedIndex = position % array.Length;
        if (wrappedIndex < 0) wrappedIndex += array.Length; // Handle negative indexes
        
        return wrappedIndex;
    }
    
    
    public static int GetSteps(this int stepsToMove)
    {
        if (stepsToMove <= 0)
            return 0;
        
        var steps = 0; 
        for (int i = 0; i < stepsToMove; i++)
        {
            steps += Orders.StepOrder[
                Orders.StepOrder.GetWrappedIndex(i)];
        }
        return steps;
    }
}
