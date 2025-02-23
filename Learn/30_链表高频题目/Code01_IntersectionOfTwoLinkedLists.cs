namespace Learn;

// 返回两个无环链表相交的第一个节点
// 测试链接 : https://leetcode.cn/problems/intersection-of-two-linked-lists/
public class Code01_IntersectionOfTwoLinkedLists
{
    public class ListNode
    {
        public ListNode next;
        public int val;
    }
    
    // [1]: 计算链表长度差值
    // [2]: 先让长的走diff步,那么两个指针一起走，一定会相遇
    // [3]: 返回相遇节点
    public ListNode GetIntersectionNode(ListNode h1, ListNode h2)
    {
        if (h1 == null || h2 == null) return null;

        ListNode a = h1, b = h2;
        
        // [1]: 计算链表长度差值
        int diff = 0;
        while (a.next != null)
        {
            a = a.next;
            diff++;
        }
        while (b.next != null)
        {
            b = b.next;
            diff--;
        }
        if (a != b)
        {
            //走到最后都不相交,那么null
            return null;
        }

        // [2]: 先让长的走diff步
        if (diff >= 0)
        {
            a = h1;
            b = h2;
        }
        else
        {
            a = h2;
            b = h1;
        }

        diff = Math.Abs(diff);
        while (diff-- != 0)
        {
            a = a.next;
        }
        
        // [3]: 那么两个指针一起走，一定会相遇
        while ( a != b)
        {
            a = a.next;
            b = b.next;
        }
        return a;
    }
}