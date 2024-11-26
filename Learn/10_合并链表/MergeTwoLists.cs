/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode21.合并链表
 * │  类    名: MergeTwoLists.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode;

public class MergeTwoLists
{
    // 将两个升序链表合并为一个新的 升序 链表并返回
    // 新链表是通过拼接给定的两个链表的所有节点组成的
    // 测试链接 : https://leetcode.cn/problems/merge-two-sorted-lists/
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class MergeTwoListsSolution {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
            if (list1 == null || list2 == null)
            {
                return list1 ?? list2;
            }
            
            // 谁小谁是头节点(相等则默认第一个为头节点)
            ListNode head = list1.val <= list2.val ? list1 : list2;
            ListNode cur1 = head.next;
            ListNode cur2 = head == list1 ? list2 : list1;
            ListNode pre = head;

            while (cur1 != null && cur2 != null)
            {
                if (cur1.val <= cur2.val)
                {
                    pre.next = cur1;
                    cur1 = cur1.next;
                }
                else
                {
                    pre.next = cur2;
                    cur2 = cur2.next;
                }
                pre = pre.next;
            }

            // cur1不是空,则指向cur1
            // 否则指向cur2
            pre.next = cur1 ?? cur2;
            return head;
        }
    }
}