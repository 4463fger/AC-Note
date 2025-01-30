/*
 * ┌──────────────────────────────────┐
 * │  描    述: 基数排序
 * │  类    名: RadixSort.cs
 * │  创    建: By 4463fger
 * └──────────────────────────────────┘
 */
 
namespace Learn;

// 基数排序，acm练习风格
// 测试链接 : https://www.luogu.com.cn/problem/P1177

class Code01_RadixSort 
{
    private const int BASE = 10;
    private static int[] arr;
    private static int[] help;
    private static int[] cnts;
    private static int n;
    
    public static void __Main__(string[] args)
    {
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
        using (StreamWriter writer = new StreamWriter(Console.OpenStandardOutput()))
        {
            n = int.Parse(reader.ReadLine().Trim());
            arr = new int[n];
            help = new int[n];
            cnts = new int[BASE];
            
            string[] input = reader.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            Sort();

            for (int i = 0; i < n - 1; i++)
            {
                writer.Write(arr[i] + " ");
            }
            writer.WriteLine(arr[n - 1]);
        }
    }

    private static void Sort()
    {
        int min = arr[0];
        for (int i = 1; i < n; i++)
        {
            min = Math.Min(min, arr[i]);
        }
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            arr[i] -= min;
            max = Math.Max(max, arr[i]);
        }
        RadixSort(Bits(max));
        for (int i = 0; i < n; i++)
        {
            arr[i] += min;
        }
    }

    private static int Bits(int number)
    {
        int ans = 0;
        while (number > 0)
        {
            ans++;
            number /= BASE;
        }
        return ans;
    }

    private static void RadixSort(int bits)
    {
        for (int offset = 1; bits > 0; offset *= BASE, bits--)
        {
            Array.Clear(cnts, 0, BASE);
            for (int i = 0; i < n; i++)
            {
                cnts[(arr[i] / offset) % BASE]++;
            }
            for (int i = 1; i < BASE; i++)
            {
                cnts[i] += cnts[i - 1];
            }
            for (int i = n - 1; i >= 0; i--)
            {
                help[--cnts[(arr[i] / offset) % BASE]] = arr[i];
            }
            for (int i = 0; i < n; i++)
            {
                arr[i] = help[i];
            }
        }
    }
}