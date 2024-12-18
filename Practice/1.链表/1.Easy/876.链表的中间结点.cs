/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode.876.middle-of-the-linked-list
 * │  类    名: MiddleNode.cs
 * │  创 建 人:
 * └──────────────────────────────────┘
 */

namespace LeetCode;


public class MiddleNodeSolution 
{
    public ListNode MiddleNode(ListNode head) 
    {
        ListNode slow = head;
        ListNode fast = head;
        
        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }
}