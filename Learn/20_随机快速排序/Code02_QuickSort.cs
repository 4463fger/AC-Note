/*
 * ┌──────────────────────────────────┐
 * │  描    述: 快速排序
 * │  类    名: QuickSort2.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

// 随机快速排序，填函数练习风格
// 测试链接 : https://leetcode.cn/problems/sort-an-array/

public class Code02_QuickSort
{
    public int[] SortArray(int[] nums)
    {
        if (nums.Length > 1)
            QuickSort2(nums, 0, nums.Length - 1);
        return nums;
    }

    // 随机快速排序改进版(推荐)
    private void QuickSort2(int[] arr, int l, int r)
    {
        if (l >= r)
        {
            return;
        }
        // 随机选择基准值
        int x = arr[l + (int)(new Random().NextDouble() * (r - l + 1))];
        // 分区并获取 == x 区域的边界
        (int left, int right) = Partition2(arr, l, r, x);
        // 递归排序左边和右边
        QuickSort2(arr, l, left - 1);
        QuickSort2(arr, right + 1, r);
    }

    // 荷兰国旗问题分区
    private (int, int) Partition2(int[] arr, int l, int r, int x)
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
                (arr[first], arr[i]) = (arr[i], arr[first]);
                first++;
                i++;
            }
            else
            {
                // 如果大于 x，交换到 >x 区域
                (arr[last], arr[i]) = (arr[i], arr[last]);
                last--;
            }
        }
        // 返回 ==x 区域的左右 边界
        return (first, last);
    }


    // 随机快速排序经典版(不推荐)
    private static void QuickSort1(int[] arr, int l, int r)
    {
        if (l >= r)
            return;
        
        // 随机这一下,常数时间比较大
        // 但只有这一下随机，才能在概率上把快速排序的时间复杂度收敛到O(n * logn)
        int x = arr[l + (int)(new Random().NextDouble() * (r - l + 1))];
        int mid = Partition1(arr, l, r, x);
        QuickSort1(arr, l, mid - 1);
        QuickSort1(arr, mid + 1, r);
    }

    // 已知arr[l....r]范围上一定有x这个值
    // 划分数组 <=x放左边，>x放右边，并且确保划分完成后<=x区域的最后一个数字是x
    private static int Partition1(int[] arr, int l, int r, int x)
    {
        // a : arr[l....a-1]范围是<=x的区域
        // xi : 记录在<=x的区域上任何一个x的位置，哪一个都可以
        int a =  l , xi = 0;
        for (int i = l; i <= r; i++)
        {
            if (arr[i] <= x)
            {
                // 交换
                (arr[i],arr[a]) = (arr[a],arr[i]);
                if (arr[a] == x)
                    xi = a;
            }
            a++;
        }
        (arr[xi], arr[a - 1]) = (arr[a - 1], arr[xi]);
        return a - 1;
    }
}