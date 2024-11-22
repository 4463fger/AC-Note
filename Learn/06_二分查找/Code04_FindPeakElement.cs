﻿/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode162寻找峰值
 * │  类    名: Code04_FindPeakElement.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;
// 题目:https://leetcode.cn/problems/find-peak-element/description/
class Solution
{
    public static int FindPeakElement(int[] arr)
    {
        int n = arr.Length;
        if (arr.Length == 1)
        {
            return 0;
        }

        if (arr[0] > arr[1])
        {
            return 0;
        }

        if (arr[n - 1] > arr[n - 2])
        {
            return n - 1;
        }

        int l = 1, r = n - 2, m = 0, ans = -1;
        while (l <= r)
        {
            m = (l + r) >> 1;
            if (arr[m - 1] > arr[m])
            {
                r = m - 1;
            }
            else if (arr[m] < arr[m + 1])
            {
                l = m + 1;
            }
            else
            {
                ans = m;
                break;
            }
        }
        return ans;
    }
}