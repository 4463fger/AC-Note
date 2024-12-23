/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode1290.二进制链表转整数
 * │  类    名: GetDecimalValue.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode;

public class GetDecimalValueSolution
{
    // (result << 1) 等价于 result * 2
    // (result << 1) | head.val 等价于 result * 2 + head.val
    public int GetDecimalValue(ListNode head)
    {
        var result = 0;
        while (head != null)
        {
            result = (result << 1) | head.val;
            head = head.next;
        }
        return result;
    }
}