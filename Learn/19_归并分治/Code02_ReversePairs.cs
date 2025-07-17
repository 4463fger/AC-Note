/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode493.反转对
 * │  类    名: SmallSum.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;

// 翻转对数量
// 测试链接 : https://leetcode.cn/problems/reverse-pairs/
public class Code02_ReversePairs
{
    public static int MAXN = 50001;
    public static int[] help = new int[MAXN];

    public  int ReversePairs(int[] arr)
    {
        return Counts(arr, 0, arr.Length - 1);
    }

    // 统计l....r范围上,翻转对的数量,同事l....r范围统计完后要有序
    // 时间复杂度O(N * logN)
    private  int Counts(int[] arr, int l, int r)
    {
        if (l == r)
            return 0;

        int m = (l + r) >> 1;
        return Counts(arr, l, m) + Counts(arr, m + 1, r) + Merge(arr, l, m, r);
    }

    private  int Merge(int[] arr, int l, int m, int r)
    {
        // 统计部分
        int ans = 0;
        for (int i = l , j = m + 1; i <= m; i++)
        {
            while (j <= r && ((long)arr[i] > (long)arr[j] * 2))
            {
                j++;
            }
            ans += j - m - 1;
        }
        
        // 归并排序
        int index = l;
        int a = l;
        int b = m + 1;
        while (a <= m && b<= r)
        {
            help[index++] = arr[a] <= arr[b] ? arr[a++] : arr[b++];
        }
        while (a <= m)
        {
            help[index++] = arr[a++];
        }
        while (b <= r)
        {
            help[index++] = arr[b++];
        }
        // 复制l-r
        for (int i = l; i <= r; i++)
        {
            arr[i] = help[i];
        }
        return ans;
    }
}