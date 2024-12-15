/*
 * ┌──────────────────────────────────┐
 * │  描    述:
 * │  类    名: a.cs
 * │  创 建 人:
 * └──────────────────────────────────┘
 */

using System.Text;

namespace LeetCode;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

class IsPalindromeSolution
{
    public bool IsPalindrome(ListNode head)
    {
        if (head == null || head.next == null)
            return true;
        
        // 使用快慢指针找到链表中点
        ListNode slow = head, fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        // 如果链表长度为奇数,快指针不会停在null上,需要跳过中间节点
        // slow此时指向后半部分 
        // 例如(1-2-3-2-1)，需要将slow指向2
        if (fast != null)
        {
            slow = slow.next;
        }

        // 反转链表后半部分
        ListNode secondHalfStart = ReverseList(slow);
        
        // 比较链表前半部分和后半部分是否相等
        ListNode p1 = head;
        ListNode p2 = secondHalfStart;
        bool isPalindrome = true;
        while (p2 != null)
        {
            if (p1.val != p2.val)
            {
                isPalindrome = false;
                break;
            }
            p1 = p1.next;
            p2 = p2.next;
        }
        return isPalindrome;
    }

    // 反转链表
    private ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;   // 新链表的头部
        ListNode cur = head;

        while (cur != null)
        {
            ListNode next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
        }
        return prev;
    }
}