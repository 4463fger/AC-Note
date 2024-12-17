/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode148.排序链表
 * │  类    名: SortList.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode;

public class SortListSolution
{
    public ListNode SortList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        // 计算链表长度
        int length = 0;
        ListNode cur = head;
        while (cur != null)
        {
            length++;
            cur = cur.next;
        }

        // 哨兵节点
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        
        // 归并排序
        for (int step = 1; step < length; step <<= 1)
        {
            // cur用于遍历链表
            // tail用于跟踪新链表的尾部。
            cur = dummy.next;
            ListNode tail = dummy;

            while (cur != null)
            {
                ListNode left = cur;
                ListNode right = Split(left, step);
                // cur提前指向下一组要排序的节点
                cur = Split(right, step);

                tail.next = Merge(left, right);
                while (tail.next != null)
                {
                    tail = tail.next;
                }
            }
        }
        return dummy.next;
    }

    /// <summary>
    /// 分割链表
    /// </summary>
    private ListNode Split(ListNode head, int step)
    {
        if (head == null)
            return null;

        for (int i = 1; i < step && head.next != null; i++)
        {
            head = head.next;
        }

        ListNode right = head.next;
        head.next = null;
        return right;
    }

    /// <summary>
    /// 合并链表
    /// </summary>
    private ListNode Merge(ListNode left, ListNode right)
    {
        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;

        while (left != null && right != null)
        {
            if (left.val < right.val)
            {
                tail.next = left;
                left = left.next;
            }
            else
            {
                tail.next = right;
                right = right.next;
            }
            tail = tail.next;
        }
        tail.next = left != null ? left : right;
        return dummy.next;
    }
}