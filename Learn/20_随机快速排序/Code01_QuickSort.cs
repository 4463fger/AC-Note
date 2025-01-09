/*
 * ┌──────────────────────────────────┐
 * │  描    述: 快速排序
 * │  类    名: QuickSort1.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */
 
// 随机快速排序，acm练习风格
// 测试链接 : https://www.luogu.com.cn/problem/P1177
// 请同学们务必参考如下代码中关于输入、输出的处理
// 这是输入输出处理效率很高的写法
// 提交以下的code，提交时请把类名改成"Main"，可以直接通过

public class Code01_QuickSort
{
    public const int MAXN = 100001;
    public static int[] arr = new int[MAXN];

    public static void __Main__(string[] args)
    {
        // 读取输入
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(input[i]);
        }

        // 调用快速排序
        QuickSort2(arr, 0, n - 1);

        // 输出结果
        for (int i = 0; i < n - 1; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine(arr[n - 1]);
    }

    // 随机快速排序改进版(推荐)
    private static void QuickSort2(int[] arr, int l, int r)
    {
        if (l >= r)
        {
            return;
        }
        // 随机选择基准值
        int x = arr[l + new Random().Next(r - l + 1)];
        // 分区并获取 ==x 区域的边界
        (int left, int right) = Partition2(arr, l, r, x);
        // 递归排序左边和右边
        QuickSort2(arr, l, left - 1);
        QuickSort2(arr, right + 1, r);
    }

    // 荷兰国旗问题分区
    private static (int, int) Partition2(int[] arr, int l, int r, int x)
    {
        int first = l; // <x 区域的右边界
        int last = r;  // >x 区域的左边界
        int i = l;     // 当前遍历的位置

        while (i <= last)
        {
            if (arr[i] == x)
            {
                i++; // 如果等于 x，直接跳过
            }
            else if (arr[i] < x)
            {
                // 如果小于 x，交换到 <x 区域
                Swap(arr, first, i);
                first++;
                i++;
            }
            else
            {
                // 如果大于 x，交换到 >x 区域
                Swap(arr, i, last);
                last--;
            }
        }
        // 返回 ==x 区域的左右 边界
        return (first, last);
    }

    // 交换数组中的两个元素
    private static void Swap(int[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}