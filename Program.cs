class Program
{
    public static void Main(string[] args)
    {
        int[] testArray = [1, 3, 5, 2, 4, 6];
        int n = testArray.Length;
        
        Array.Copy(testArray, Code01_SmallSum.arr, n);
        
        long result = Code01_SmallSum.SmallSum(0, n - 1);
        Console.WriteLine(result);
    }
}
