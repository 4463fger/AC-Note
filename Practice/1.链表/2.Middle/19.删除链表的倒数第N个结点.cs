/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode19.删除链表的倒数第N个结点
 * │  类    名: RemoveNthFromEnd.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode;

// 思路，先将first指针指向删除结点,然后开始一起移动second和first，当first指向null时，second指向的就是要删除的结点
// 测试链接: https://leetcode.cn/problems/remove-nth-node-from-end-of-list/description/
public class RemoveNthFromEndSolution 
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (head == null || n <= 0) return head;

        ListNode first = head;
        ListNode second = head;

        for (int i = 0; i < n; i++)
        {
            if (first == null) 
                return head; 
            first = first.next;
        }

        if (first == null)
        {
            return head.next;
        }

        while (first.next != null)
        {
            first = first.next;
            second = second.next;
        }

        second.next = second.next.next;

        return head;
    }
}