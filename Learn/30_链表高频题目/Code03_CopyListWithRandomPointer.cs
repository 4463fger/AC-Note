﻿namespace Learn;

// 复制带随机指针的链表
// 测试链接 : https://leetcode.cn/problems/copy-list-with-random-pointer/

public class Code03_CopyListWithRandomPointer
{
    // 不要提交这个类
    public class Node
    {
        public Node next;
        public Node random;
        public int val;

        public Node(int v)
        {
            val = v;
        }
    }
    
    public Node CopyRandomList(Node head) 
    {
        if (head == null)
            return null;

        Node cur = head;
        Node next = null;
        // 1 -> 2 -> 3 -> ...
        // 变成 : 1 -> 1' -> 2 -> 2' -> 3 -> 3' -> ...
        while (cur != null)
        {
            next = cur.next;
            // 复制自己
            cur.next = new Node(cur.val);
            cur.next.next = next;
            cur = next;
        }

        cur = head;
        Node copy = null;
        // 利用上面新老节点的结构关系，设置每一个新节点的random指针
        while (cur != null)
        {
            // 复制random节点
            next = cur.next.next;
            copy = cur.next;
            copy.random = cur.random != null ? cur.random.next : null;
            cur = next;
        }

        Node ans = head.next;
        cur = head;
        // 新老链表分离 : 老链表重新连在一起，新链表重新连在一起
        while (cur != null)
        {
            next = cur.next.next;
            copy = cur.next;
            cur.next = next;
            copy.next = next != null ? next.next : null;
            cur = next;
        }
        // 返回新链表的头结点
        return ans;
    }
}