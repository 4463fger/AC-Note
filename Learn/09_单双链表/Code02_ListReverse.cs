/*
 * ┌──────────────────────────────────┐
 * │  描    述: 反转链表
 * │  类    名: ParameterPassingTest.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode;

// 单链表节点
public class ListNode
{
    public ListNode next;
    public int val;

    public ListNode(int val)
    {
        this.val = val;
    }

    public ListNode(int val, ListNode next)
    {
        this.val = val;
        this.next = next;
    }
}

/// <summary>
/// 反转链表
/// 测试链接 : https://leetcode.cn/problems/reverse-linked-list/
/// </summary>
class ReverseListSolution
{
    public static ListNode reverseList(ListNode head)
    {
        ListNode pre = null; // 初始化前一个节点为 null
        ListNode next = null; // 初始化下一个节点为 null
        
        // head == null , 已经完全反转
        while (head != null)
        {
            next = head.next; //保存当前节点的下一个节点
            head.next = pre; // 将当前节点的next指向前一个节点
            pre = head; // 更新前一个节点为当前节点
            head = next; // 移动到下一个节点
        }
        //在循环结束后，pre 指向了原链表的最后一个节点，即反转后链表的第一个节点
        //因此return pre 返回的就是反转后链表的新头指针。
        return pre;
    }
}

//双链表
public class DoubleListNode
{
    public int Value { get; set; }
    public DoubleListNode Last { get; set; }
    public DoubleListNode Next { get; set; }

    public DoubleListNode(int value)
    {
        Value = value;
        Last = null;
        Next = null;
    } 
}

/// <summary>
/// 反转双链表
/// </summary>
public class ReverseDoubleListSolution
{
    public static DoubleListNode ReverseDoubleList(DoubleListNode head)
    {
        DoubleListNode pre = null;
        DoubleListNode next = null;
        while (head != null)
        {
            next = head.Next;
            head.Next = pre;
            head.Last = next;
            pre = head;
            head = next;
        }
        return pre;
    }
}