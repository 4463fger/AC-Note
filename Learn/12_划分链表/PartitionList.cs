/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode86.分隔链表
 * │  类    名: PartitionList.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

// 给你一个链表的头节点 head 和一个特定值 x
// 请你对链表进行分隔，使得所有 小于 x 的节点都出现在 大于或等于 x 的节点之前。
// 你应当 保留 两个分区中每个节点的初始相对位置
// 测试链接 : https://leetcode.cn/problems/partition-list/
public class PartitionList
{
    public class ListNode
    {
        public int val;
        public ListNode next;

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

    class PartitionSolution
    {

        public static ListNode partition(ListNode head, int x)
        {
            ListNode leftHead = null, leftTail = null;   // < x的区域
            ListNode rightHead = null, rightTail = null; // >=x的区域
            ListNode next = null;
            while (head != null)
            {
                next = head.next;   // head下一个节点
                head.next = null;   // 断链
                
                if (head.val < x)   // 放入<x区域
                {
                    if (leftHead == null) 
                    {
                        leftHead = head; 
                    }
                    else 
                    {
                        leftTail.next = head; 
                    }
                    leftTail = head;
                }
                else// 放入>=x区域
                {
                    if (rightHead == null)
                    {
                        rightHead = head;
                    }
                    else
                    {
                        rightTail.next = head;
                    }
                    rightTail = head;
                }
                head  = next; // 移动cur指针
            }
            if (leftHead == null)
            {
                return rightHead;
            }
            // <x的区域有内容
            leftTail.next = rightHead;
            return leftHead;
        }
    }
}