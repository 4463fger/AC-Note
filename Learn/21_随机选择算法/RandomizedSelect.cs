/*
 * ┌──────────────────────────────────┐
 * │  描    述: 无序数组中第K大的元素
 * │  类    名: RandomizedSelect.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;

// 无序数组中第K大的元素
// 测试链接 : https://leetcode.cn/problems/kth-largest-element-in-an-array/

public class Code_RandomizedSelect  
{
    // 随机选择算法，时间复杂度O(n) 
    public  int FindKthLargest(int[] nums, int k)
    {
        return RandomizedSelect(nums, nums.Length - k);
    }
    
    // 如果arr排序的话，在i位置的数字是什么
    private  int RandomizedSelect(int[] arr, int i)
    {
        int ans = 0;
        for (int l = 0, r = arr.Length - 1; l <= r;)
        {
            // 随机这一下，常数时间比较大
            // 但只有这一下随机，才能在概率上把时间复杂度收敛到O(n)
            Partition(arr, l, r, arr[l + (int)(new Random().NextDouble() * (r - l + 1))]);
            // 因为左右两侧只需要走一侧
            // 所以不需要临时变量记录全局的first、last
            // 直接用即可
            if (i  < first)
            {
                r = first - 1;
            }
            else if( i > last)
            {
                l = last + 1;
            }
            else
            {
                ans = arr[i];
                break;
            }
        }
        return ans;
    }
    
    // 荷兰国旗问题
    private  int first, last;
    // (查找数组,左边界,右边界,基准值)
    private  void Partition(int[] arr, int l, int r, int x)
    {
        first = l;
        last = r;
        int i = l;
        while (i <= last)
        {
            if (arr[i] == x)
            {
                i++;
            }
            else if (arr[i] < x)
            {
                Swap(arr, first++, i++);
            }
            else
            {
                Swap(arr, i, last--);
            }
        }
    }

    private  void Swap(int[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}