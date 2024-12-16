/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode61.旋转链表
 * │  类    名: RotateRight.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode;


public class RotateRightSolution 
{
    /// <summary>
    /// 构建环形
    /// </summary>
    public ListNode RotateRight1(ListNode head, int k) 
    {
        if(head == null || head.next == null || k == 0)
            return head;
        
        // 计算链表长度并找到尾节点
        int length = 1;
        ListNode tail = head;
        while(tail.next != null)
        {
            tail = tail.next;
            length++;
        }

        // 组成环形列表
        tail.next = head;

        // 计算新的尾部节点位置
        k = k % length;
        int stepsToNewTail = length - k; 
        ListNode newTail = head;
        for(int i = 0 ; i < stepsToNewTail - 1; i++)
        {
            newTail = newTail.next;
        }

        // 断开环
        ListNode newHead = newTail.next;
        newTail.next = null;

        // 返回新的头节点
        return newHead;
    }
    
    /// <summary>
    /// 快慢指针
    /// </summary>
    public ListNode RotateRight2(ListNode head, int k) 
    {
        if(head == null || head.next == null || k == 0)
            return head;
        
        // 计算链表长度
        int length = 1;
        ListNode tail = head;
        while(tail.next != null)
        {
            tail = tail.next;
            length++;
        }

        k = k % length;
        if(k == 0)
            return head;
        
        ListNode fast = head,slow = head;
        for(int i = 0; i< k; i++)
        {
            fast = fast.next;
        }

        while(fast.next != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        ListNode newHead = slow.next;
        slow.next = null;
        fast.next = head;

        return newHead;
    }
}