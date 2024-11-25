/*
 * ┌──────────────────────────────────┐
 * │  描    述: 寻找>=num的最右位置
 * │  类    名: Code02_FindLeft.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;

class Code03_FindRight
{
    // 保证arr有序，才能用这个方法
    // 有序数组中找<=num的最右位置
    static int FindRight(int[] arr, int num)
    {
        int l = 0, r = arr.Length - 1, m = 0;
        int ans = -1;
        while (l <= r)
        {
            m = l + ((r - l) >> 1);
            if (arr[m] <= num)
            {
                ans = m;
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }

        return ans;
    }

    // 保证arr有序，才能用这个方法
    static int Right(int[] arr, int num)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (arr[i] <= num)
            {
                return i;
            }
        }

        return -1;
    }
}