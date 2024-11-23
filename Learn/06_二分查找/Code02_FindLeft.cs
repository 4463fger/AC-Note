/*
 * ┌──────────────────────────────────┐
 * │  描    述: 寻找>=num的最左位置
 * │  类    名: Code02_FindLeft.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */
namespace Learn;

// 有序数组中寻找>=num的最左位置
public class Code02_FindLeft
{
    public static int findLeft(int[] arr, int num)
    {
        int l = 0, r = arr.Length - 1, m = 0;
        int ans = -1;
        while (l <= r)
        {
            m = l + ((r - l) >> 1);
            if (arr[m] >= num)
            {
                // 如果中间位置的值大于等于num，更新答案并继续在左半边搜索
                ans = m;
                r = m - 1;
            }
            else
            {
                // 否则在右半边搜索
                l = m + 1;
            }
        }

        return ans;
    }

    public static int right(int[] arr, int num)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= num)
                return i;
        }

        return -1;
    }
}