/*
 * ┌──────────────────────────────────┐
 * │  描    述: 二分查找
 * │  类    名: Code01_FindNumber.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;

public class Code01_FindNumber
{
    // public static void Main(string[] args)
    // {
    //     //对数器
    //     int N = 100;    // 随机数组的最大长度
    //     int V = 1000;   // 随机数组中元素的最大值（不包括）
    //     int testTime = 500000;
    //     Console.WriteLine("测试开始");
    //     for (int i = 0; i < testTime; i++)
    //     {
    //         // 生成随机数组长度
    //         int n = (int)(new Random().NextDouble() * N);
    //         int[] arr = randomArray(n, V);
    //         Array.Sort(arr);
    //         // 生成随机查找的元素
    //         int num = (int)(new Random().NextDouble() * V);
    //         if (right(arr,num) != exist(arr,num))
    //         {
    //             Console.WriteLine("出错了");
    //         }
    //     }
    //     Console.WriteLine("测试结束");
    // }

    /// <summary>
    /// 二分查找法
    /// 时间复杂度：O(logN)
    /// </summary>
    /// <param name="arr">有序数组</param>
    /// <param name="num">查找的元素</param>
    /// <returns></returns>
    public static bool exist(int[]? arr, int num)
    {
        if (arr == null || arr.Length == 0)
            return false;

        int l = 0, r = arr.Length - 1, m = 0;
        while (l <= r)
        {
            // m = (l + r) / 2
            // >>1等价于/2，运行效率更高
            m = l + ((r - l) >> 1);
            if (arr[m] == num)
                return true;
            else if (arr[m] > num)
                r = m - 1;
            else
                l = m + 1;
        }

        return false;
    }

    // 唯一暴力解
    public static bool right(int[] sortedArr, int num)
    {
        foreach (var cur in sortedArr)
        {
            if (cur == num)
            {
                return true;
            }
        }

        return false;
    }

    // 生成一个长度为n,随机数的最大值是V的随机数组
    private static int[] randomArray(int n, int v)
    {
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = (int)(new Random().NextDouble() * v) + 1;
        }

        return arr;
    }
}