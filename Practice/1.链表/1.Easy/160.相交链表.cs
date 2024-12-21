/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode160.相交链表
 * │  类    名: GetIntersectionNode.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

namespace LeetCode;

public class ListNodeSolution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null)
            return null;

        ListNode fastA = headA;
        ListNode fastB = headB;
        int countA = 0;
        int countB = 0;
        while (fastA != null)
        {
            fastA = fastA.next;
            countA++;
        }
        while (fastB != null)
        {
            fastB = fastB.next;
            countB++;
        }

        fastA = headA;
        fastB = headB;
        
        int diff = countA - countB;
        if (diff > 0)
        {
            while (diff > 0)
            {
                fastA = fastA.next;
                diff--;
            }
        }
        else
        {
            while (diff < 0)
            {
                fastB = fastB.next;
                diff++;
            }
        }
        
        while (fastA != null && fastB != null)
        {
            if (fastA == fastB)
                return fastA;
                
            fastA = fastA.next;
            fastB = fastB.next;
        }

        return null;
    }
}