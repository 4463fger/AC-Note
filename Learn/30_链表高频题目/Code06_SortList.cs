﻿namespace Learn;

// 排序链表
// 要求时间复杂度O(N*LogN)，额外空间复杂度O(1)，还要求稳定性
// 数组排序做不到，链表排序可以
// 测试链接 : https://leetcode.cn/problems/sort-list/
public class Code06_SortList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
    }

    // 时间复杂度O(N*logN)，额外空间复杂度O(1)，有稳定性
    // 注意为了额外空间复杂度O(1)，所以不能使用递归
    // 因为mergeSort递归需要O(log n)的额外空间
    public ListNode SortList(ListNode head)
    {
        // [1]: 计算链表长度
        int n = 0;
        ListNode cur = head;
        while (cur != null)
        {
            n++;
            cur = cur.next;
        }
        
        // [2]: 归并排序开始
        // l1...r1 每组的左部分
        // l2...r2 每组的右部分
        // next 下一组的开头
        // lastTeamEnd 上一组的结尾
        ListNode l1, r1, l2, r2, next, lastTeamEnd;
        for (int step = 1; step < n; step <<= 1) 
        {
            // 第一组很特殊，因为要决定整个链表的头，所以单独处理
            l1 = head;
            r1 = FinEnd(l1, step);
            l2 = r1.next;
            r2 = FinEnd(l2, step);
            next = r2.next;
            r1.next = null;
            r2.next = null;
            Merge(l1, r1, l2, r2);
            head = start;
            lastTeamEnd = end;
            while (next != null) 
            {
                l1 = next;
                r1 = FinEnd(l1, step);
                l2 = r1.next;
                if (l2 == null) {
                    lastTeamEnd.next = l1;
                    break;
                }
                r2 = FinEnd(l2, step);
                next = r2.next;
                r1.next = null;
                r2.next = null;
                Merge(l1, r1, l2, r2);
                lastTeamEnd.next = start;
                lastTeamEnd = end;
            }
        }
        return head;
    }
    
    // 包括s在内，往下数k个节点返回
    // 如果不够，返回最后一个数到的非空节点
    private ListNode FinEnd(ListNode s, int k) 
    {
        while (s.next != null && --k != 0) 
        {
            s = s.next;
        }
        return s;
    }
    
    public ListNode start;
    public ListNode end;
    // l1...r1 -> null : 有序的左部分
    // l2...r2 -> null : 有序的右部分
    // 整体merge在一起，保证有序
    // 并且把全局变量start设置为整体的头，全局变量end设置为整体的尾
    public void Merge(ListNode l1, ListNode r1, ListNode l2, ListNode r2)
    {
        ListNode pre;
        // 确定合并后的头
        if (l1.val <= l2.val) 
        {
            start = l1;
            pre = l1;
            l1 = l1.next;
        } else 
        {
            start = l2;
            pre = l2;
            l2 = l2.next;
        }
        // 开始合并
        while (l1 != null && l2 != null) 
        {
            if (l1.val <= l2.val) 
            {
                pre.next = l1;
                pre = l1;
                l1 = l1.next;
            } else {
                pre.next = l2;
                pre = l2;
                l2 = l2.next;
            }
        }
        // 处理剩余部分
        if (l1 != null) 
        {
            pre.next = l1;
            end = r1;
        } 
        else 
        {
            pre.next = l2;
            end = r2;
        }
    }
}

