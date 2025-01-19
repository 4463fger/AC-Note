/*
 * ┌──────────────────────────────────┐
 * │  描    述: 堆结构和堆排序
 * │  类    名: HeapSort.cs
 * │  创    建: By 4463fger
 * └──────────────────────────────────┘
 */
 
// 堆结构和堆排序，acm练习风格
// 测试链接 : https://www.luogu.com.cn/problem/P1177

public class Code01_HeapSort
{
    private const int MAXN = 100001;
    private static int[] arr = new int[MAXN];
    private static int n;

    public static void _Main_(string[] args)
    {
        // Luogu();
        // 从标准输入读取数据
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            // 向标准输出写入数据
        using (StreamWriter writer = new StreamWriter(Console.OpenStandardOutput()))
        {
            // 读取第一行输入, 包含一个整数n(数组大小)
            string[] input = reader.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            // 读取第二行输入，包含n个整数(数据)
            input = reader.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            HeapSort2();
            for (int i = 0; i < n - 1; i++)
            {
                writer.Write(arr[i] + " ");
            }

            writer.WriteLine(arr[n - 1]);
        }
    }

    // i位置的数，向上调整大根堆
    private static void HeapInsert(int i)
    {
        while (arr[i] > arr[(i - 1) / 2])
        {
            swap(i, (i - 1) / 2);
            i = (i - 1) / 2;
        }
    }

    // i位置的数，向下调整大根堆
    // 当前堆的大小为size
    private static void Heapify(int i, int size)
    {
        int l = i * 2 + 1;
        while (l < size)
        {
            int best = l + 1 < size && arr[l + 1] > arr[l] ? l + 1 : l;
            best = arr[best] > arr[i] ? best : i;
            if (best == i)
                break;
            swap(best, i);
            i = best;
            l = i * 2 + 1;
        }
    }


    // 从顶到底建立大根堆，O(n * LogN)
    // 依次弹出堆内最大值并排好序，O(n * LogN)
    // 整体时间复杂度O(n * LogN)
    public static void HeapSort1()
    {
        for (int i = 0; i < n; i++)
        {
            HeapInsert(i);
        }
        int size = n;
        while (size > 1)
        {
            swap(0, --size);
            Heapify(0, size);
        }
    }

    // 从底到顶建立大根堆，O(n)
    // 依次弹出堆内最大值并排好序，O(n * LogN)
    // 整体时间复杂度O(n * LogN)
    private static void HeapSort2()
    {
        for (int i = n/2 - 1; i >= 0; i--) 
        {
            Heapify(i, n);
        }
        int size = n;
        while (size > 1)
        {
            swap(0, --size);
            Heapify(0, size);
        }
    }
    
    private static void swap(int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}