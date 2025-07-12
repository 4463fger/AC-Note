/*
 * ┌──────────────────────────────────┐
 * │  描    述: 二叉树及其三种序的递归实现
 * │  类    名: BinaryTreeTraversalRecursion.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

// 递归序的解释
// 时间复杂度 O(N)
// 空间复杂度 O(H) H:树的高度
// 用递归实现二叉树的三序遍历

namespace Learn;

class BinaryTreeTraversalRecursion
{
    public class TreeNode
    {
        public int Val;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int v)
        {
            Val = v;
        }
        
        // 递归基本样子，用来理解递归序
        public void F(TreeNode head)
        {
            if (head == null)
            {
                return;
            }
            // 1
            F(head.Left);
            // 2
            F(head.Right);
            // 3
        }
        
        // 先序打印所有节点，递归版
        public void PreOrder(TreeNode head)
        {
            if (head == null)
            {
                return;
            }
            Console.WriteLine(head.Val + " ");
            PreOrder(head.Left);
            PreOrder(head.Right);
        }
        
        // 中序打印所有节点，递归版
        public void InOrder(TreeNode head)
        {
            if (head == null)
            {
                return;
            }
            InOrder(head.Left);
            Console.Write(head.Val + " ");
            InOrder(head.Right);
        }
        
        // 后序打印所有节点，递归版
        public void PostOrder(TreeNode head)
        {
            if (head == null)
            {
                return;
            }
            PostOrder(head.Left);
            PostOrder(head.Right);
            Console.WriteLine(head.Val + " ");
        }
    }
}