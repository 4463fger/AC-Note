/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode912.排序数组
 * │  类    名: MergeSort.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

// 归并排序，填函数练习风格
// 测试链接 : https://leetcode.cn/problems/sort-an-array/

namespace Learn;

class MergeSortMethod
{
    public static int[] SortArray(int[] nums)
    {
        if (nums.Length > 1)
        {
            // mergeSort1为递归方法
            // mergeSort2为非递归方法
            // 用哪个都可以
            // MergeSort1(nums);
            MergeSort2(nums);
        }
        return nums;
    }

    public const int MAXN = 50001;
    public static int[] help = new int[MAXN];

    // 归并排序递归版
    public static void MergeSort1(int[] arr)
    {
        Sort(arr, 0, arr.Length - 1);
    }

    public static void Sort(int[] arr, int l, int r)
    {
        if (l == r)
            return;
        
        int m = (l + r) >> 1;
        Sort(arr, l, m);
        Sort(arr, m + 1, r);
        merge(arr, l, m, r);
    }

    // 归并排序非递归版
    public static void MergeSort2(int[] arr)
    {
        int n = arr.Length;
        for (int l, m, r, step = 1; step < n; step <<= 1)
        {
            l = 0;
            while (l < n)
            {
                m = l + step - 1;
                if (m + 1 >= n)
                {
                    break;
                }

                r = Math.Min(l + (step << 1) - 1, n - 1);
                merge(arr, l, m, r);
                l = r + 1;
            }
        }
    }

    private static void merge(int[] arr, int l, int m, int r)
    {
        int i = l;
        int a = l;
        int b = m + 1;
        while (a <= m && b <= r)
        {
            help[i++] = arr[a] <= arr[b] ? arr[a++] : arr[b++];
        }

        while (a <= m)
        {
            help[i++] = arr[a++];
        }

        while (b <= r)
        {
            help[i++] = arr[b++];
        }

        for (i = l; i <= r; i++)
        {
            arr[i] = help[i];
        }
    }
}