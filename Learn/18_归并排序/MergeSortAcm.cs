/*
 * ┌──────────────────────────────────┐
 * │  描    述: ACM风格归并排序
 * │  类    名: MergeSort.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;

class MergeSortAcm
{
    // 归并排序，acm练习风格
    // 测试链接 : https://www.luogu.com.cn/problem/P1177
    // 输入输出处理效率很高的写法
    // 提交以下的code，提交时请把类名改成"Main"，可以直接通过

    public const int MAXN = 100001;
    // 是用于存储输入整数序列的数组
    public static int[] arr = new int[MAXN];
    public static int[] help = new int[MAXN];
    public static int n;
    public static void main(string[] args)
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
            
            // 接下来是对数组arr进行排序和输出结果的代码
            // meregeSort1(0,n-1);
            mergeSort2();
            for (int i = 0; i < n - 1; i++)
            {
                writer.Write(arr[i] + " ");
            }
            writer.WriteLine(arr[n-1]);
        }
    }

    // 归并排序递归版
    // 参数 l: 排序数组的起始索引
    // 参数 r: 排序数组的结束索引
    public static void mergeSort1(int l, int r)
    {
        // 当起始索引等于结束索引时，说明数组只有一个元素，无需排序，直接返回
        if (l == r)
        {
            return;
        }
        // 计算数组的中间索引，使用位运算符>>实现除以2的效果，提高计算效率
        // (l + r) / 2
        int m = (l + r) >> 1;
        mergeSort1(l,m);
        mergeSort1(m+1,r);
        merge(l,m,r);
    }

    // 归并排序非递归版
    public static void mergeSort2()
    {
        // step <<= 1 == step = step * 2
        // 每次步长翻倍
        // step < n 步长不会超过数组长度。
        for (int step = 1; step < n; step <<= 1)
        {
            // 表示当前处理的子数组对的起始位置
            // 每次移动两个步长的位置
            for (int l = 0; l < n; l += step << 1)
            {
                // 左子树组的结束位置
                int m = Math.Min(l + step - 1, n - 1);
                // 右子数组的结束位置
                int r = Math.Min(l + (step << 1) - 1, n - 1);
                if (m>=r)
                    break;
                merge(l,m,r);
            }
        }
    }
    
    /// <summary>
    /// 合并两个有序数组
    /// </summary>
    /// <param name="l">左边子数组的起始索引。</param>
    /// <param name="m">左边子数组的结束索引 || 右边子数组的前一个位置</param>
    /// <param name="r">右边子数组的结束索引</param>
    private static void merge(int l, int m, int r)
    {
        int i = l;      // 辅助数组 help 中下一个要填充的位置
        int a = l;      // 左边子数组 [l...m] 的当前处理位置
        int b = m + 1;  // 右边子数组 [m+1...r] 的当前处理位置
        while (a <= m && b <= r)
        {
            help[i++] = arr[a] <= arr[b] ? arr[a++] : arr[b++];
        }
        while (a <= m)
        {
            help[i++] = arr[a++];
        }
        while (b<=r)
        {
            help[i++] = arr[b++];
        }
        // 拷贝回原数组arr
        for (i = l; i <= r; i++)
        {
            arr[i] = help[i];
        }
    }

    private static void Luogu()
    {
        // luogu
        n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(input[i]);
        }
        
        // 调用非递归归并排序
        mergeSort2();

        for (int i = 0; i < n - 1; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine(arr[n - 1]);
    }
}