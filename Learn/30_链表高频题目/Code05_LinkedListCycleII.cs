namespace Learn;

// 返回链表的第一个入环节点
// 测试链接 : https://leetcode.cn/problems/linked-list-cycle-ii/

public class Code05_LinkedListCycleII
{
    public class ListNode 
    {
        public int val;
        public ListNode next;
    }
    
    public ListNode DetectCycle(ListNode head) 
    {
        if (head == null || head.next == null || head.next.next == null)
            return null;

        ListNode slow = head.next;
        ListNode fast = head.next.next;
        
        // 找到中点
        while (slow != fast)
        {
            if (fast.next == null || fast.next.next == null)
            {
                return null;
            }
            slow = slow.next;
            fast = fast.next.next;
        }
        
        // 找到中点后,快指针从头走，慢指针中点开始走，相遇点就是入环节点
        fast = head;
        while (slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }
        return slow;
    }
}