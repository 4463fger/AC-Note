/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode203.移除链表元素
 * │  类    名: RemoveElements.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode
{
    public class RemoveElementsSolution
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            // 哨兵节点
            ListNode sentinel = new ListNode(0);
            sentinel.next = head;

            ListNode cur = sentinel;
            while (cur.next != null)
            {
                if (cur.next.val == val)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next;
                }
            }

            return sentinel.next;
        }
    }
}