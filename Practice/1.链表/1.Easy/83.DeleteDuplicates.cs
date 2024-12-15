/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode83.删除排序链表中的重复元素
 * │  类    名: GetMinStack.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode
{
 public class DeleteDuplicatesSolution
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

  public ListNode DeleteDuplicates(ListNode head)
  {
   ListNode cur = head;
   while (cur != null && cur.next != null)
   {
    if (cur.val == cur.next.val)
    {
     cur.next = cur.next.next;
    }
    else
    {
     cur = cur.next;
    }
   }
   return head;
  }
 }

}
