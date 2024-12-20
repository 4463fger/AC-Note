/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode142.环形链表II
 * │  类    名: DetectCycle.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode;

public class HasCycleSolution2
{
    public ListNode DetectCycle(ListNode head)
    {
        if (head == null || head.next == null)
            return null;

        var slow = head;
        var fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            // 有环
            if (slow == fast)
            {
                slow = head;
                while (slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                }

                return slow;
            }
        }

        return null;
    }
}