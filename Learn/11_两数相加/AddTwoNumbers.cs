/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode2.两数相加
 * │  类    名: AddTwoNumbers.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

// 给你两个 非空 的链表，表示两个非负的整数
// 它们每位数字都是按照 逆序 的方式存储的，并且每个节点只能存储 一位 数字
// 请你将两个数相加，并以相同形式返回一个表示和的链表。
// 你可以假设除了数字 0 之外，这两个数都不会以 0 开头
// 测试链接：https://leetcode.cn/problems/add-two-numbers/

public class AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    
    public class AddTwoNumbersSolution {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode ans = null;
            ListNode cur = null;  
            int carry = 0;  // 进位
            for (int sum,val = 0;   // 声明变量
                 l1 != null || l2 != null; // 终止条件
                 l1 = l1?.next, // l1跳转
                 l2 = l2?.next) // l2跳转
            {
                sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;

                val = sum % 10;
                carry = sum / 10;

                if (ans == null)
                {
                    ans = new ListNode(val);
                    cur = ans;
                }else
                {
                    cur.next = new ListNode(val);
                    cur = cur.next;
                }
            }
            if (carry == 1)
            {
                cur.next = new ListNode(1);
            }
            return ans;
        }
    }
}