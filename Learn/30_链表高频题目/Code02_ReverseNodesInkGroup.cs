namespace Learn
{
// 每k个节点一组翻转链表
// 测试链接：https://leetcode.cn/problems/reverse-nodes-in-k-group/

    public class Code02_ReverseNodesInkGroup
    {
        // 不要提交这个类
        public class ListNode
        {
            public int val;
            public ListNode next;
        }
        
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode start = head;
            ListNode end = TeamEnd(start, k);
            if (end == null) 
            {
                return head;
            }
            
            // 第一组
            head = end;
            Reverse(start,end);
            // 翻转后start变成了上一组的结尾节点
            // lastTeamEnd用于下一组操作完后，将上一组和下一组进行相连
            ListNode lastTeamEnd = start; 
            while (lastTeamEnd.next != null)
            {
                // 开始进入下一组
                start = lastTeamEnd.next;
                end = TeamEnd(start, k);
                if (end == null)
                {
                    return head;
                }
                Reverse(start,end);
                lastTeamEnd.next = end;
                lastTeamEnd = start;
            }
            return head;
        }

        // 当前组的开始节点是s,往下数k个找到当前组的结束节点
        private ListNode TeamEnd(ListNode s, int k)
        {
            // --k 是为了让s指向结束节点
            // 例如k:2
            // --k==1,s移动一次，下一次--k == 0,不成立直接跳出，s刚好找到结束节点
            while (--k != 0 && s != null)
            {
                s = s.next;
            }
            return s;
        }

        // s -> a -> b -> c -> e -> 下一组的开始节点
        // 通过如下的reverse方法调整成: 
        // e -> c -> b -> a -> s -> 下一组的开始节点
        private void Reverse(ListNode s , ListNode e)
        {
            e = e.next;
            ListNode pre = null;
            ListNode cur = s;
            ListNode next = null;

            // 这篇反转链表博文写的很好
            // https://blog.csdn.net/weixin_45031801/article/details/139496847
            while (cur != e)
            {
                next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            s.next = e;
        }
    }
}
