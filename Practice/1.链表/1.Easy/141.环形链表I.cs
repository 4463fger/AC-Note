/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode141.环形链表I
 * │  类    名: HasCycle.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode;

public class HasCycleSolution1
{
    /// <summary>
    /// 快慢指针解
    /// </summary>
    public bool HasCycle1(ListNode head) 
    {
        if (head == null || head.next == null)
            return false;
            
        ListNode fast = head;
        ListNode slow = head;
        
        while(fast != null && fast.next != null)
        {  
            slow = slow.next;
            fast = fast.next.next;
            if ((slow == fast))
                return true;
        }
        return false;
    }
    
    /// <summary>
    /// 暴力解
    /// </summary>
    public bool HasCycle2(ListNode head) 
    {
        int num = 0;
        while(head != null)
        {
            head = head.next;
            num++;
            if(num > 10000) 
                return true;
        }
        return false;
    }
}
