/*
 * ┌──────────────────────────────────┐
 * │  描    述: 二叉树三种序的非递归实现(栈)
 * │  类    名: BinaryTreeTraversalIteration.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

// 不用递归，用迭代的方式实现二叉树的三序遍历
// 时间复杂度 O(N)
// 空间复杂度 O(H) H:树的高度
class BinaryTreeTraversalIteration 
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val)
        {
            this.val = val;
        }
    }
    
    #region 前中后序遍历
    
  

    // 先序打印所有节点，
    // 先序遍历(中—>左—>右)
    // 所以栈中应该是(右->左->中)存放节点
    public void PreOrder(TreeNode head)
    {
        if (head != null)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(head);
            while (stack.Count > 0)
            {
                head = stack.Pop();
                Console.WriteLine(head.val + " ");
                if (head.right != null)
                {
                    stack.Push(head.right);
                }
                if (head.left != null)
                {
                    stack.Push(head.left);
                }
            }
            Console.WriteLine();
        }
    }
    
    // 中序打印所有节点，非递归版
    public void InOrder(TreeNode head)
    {
        if (head != null)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Count > 0 || head != null)
            {
                if (head != null)
                {
                    stack.Push(head);
                    head = head.left;
                }
                else
                {
                    head = stack.Pop();
                    Console.WriteLine(head.val + " ");
                    head = head.right;
                }
            }
            Console.WriteLine();
        }
    }
    
    // 后序打印所有节点，非递归版
    // 这是用两个栈的方法
    public void posOrderTwoStacks(TreeNode head)
    {
        if (head != null)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<TreeNode> collect = new Stack<TreeNode>();
            stack.Push(head);
            while(stack.Any())
            {
                head = stack.Pop();
                collect.Push(head);
                if (head.left != null)
                {
                    stack.Push(head.left);
                }
                if (head.right != null)
                {
                    stack.Push(head.right);
                }
            }
            while (collect.Any())
            {
                Console.WriteLine(collect.Pop().val + " ");
            }
            Console.WriteLine();
        }
    }
    
    // 后序打印所有节点，非递归版
    // 这是用一个栈的方法
    public static void PosOrderOneStack(TreeNode h)
    {
        if (h != null)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(h);
            // 如果始终没有打印过节点，h就一直是头节点
            // 一旦打印过节点，h就变成打印节点
            // 之后h的含义 : 上一次打印的节点
            while (stack.Any())
            {
                TreeNode cur = stack.Peek();
                if (cur.left != null
                    && h != cur.left
                    && h != cur.right)
                { // 有左树且左树没处理
                    stack.Push(cur.left);
                }
                else if(cur.right != null
                        && h != cur.right)
                { // 有右数且右数没处理
                    stack.Push(cur.right);
                }
                else
                { // 左数,右数都没有 或者 都处理过
                    Console.WriteLine(cur.val + " ");
                    h = stack.Pop();
                }
            }
        }
    }
    
    #endregion

    #region 测试

    // 用一个栈完成先序遍历
    // 测试链接 : https://leetcode.cn/problems/binary-tree-preorder-traversal/
    public IList<int> PreorderTraversal(TreeNode head)
    {
        List<int> ans = new List<int>();
        if (head != null)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(head);
            while (stack.Any())
            {
                head = stack.Pop();
                ans.Add(head.val);
                if (head.right != null)
                    stack.Push(head.right);
                if (head.left != null)
                    stack.Push(head.left);   
            }
        }
        return ans;
    }
    
    // 用一个栈完成中序遍历
    // 测试链接 : https://leetcode.cn/problems/binary-tree-inorder-traversal/
    public IList<int> InorderTraversal(TreeNode head)
    {
        List<int> ans = new List<int>();
        if (head != null)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Any() || head != null)
            {
                if (head != null)
                {
                    stack.Push(head);
                    head = head.left;
                }
                else
                {
                    head = stack.Pop();
                    ans.Add(head.val);
                    head = head.right;
                }
            }
        }
        return ans;
    }

    // 用两个栈完成后序遍历
    // 提交时函数名改为postorderTraversal
    // 测试链接 : https://leetcode.cn/problems/binary-tree-postorder-traversal/
    public IList<int> postorderTraversalTwoStacks(TreeNode root)
    {
        List<int> ans = new List<int>();
        if (root != null)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<TreeNode> collect = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Any())
            {
                root = stack.Pop();
                collect.Push(root);
                if (root.left != null)
                {
                    stack.Push(root.left);
                }
                if (root.right != null)
                {
                    stack.Push(root.right);
                }
            }
            while (collect.Any())
            {
                ans.Add(collect.Pop().val);
            }
        }
        return ans;
    }
    
    // 用一个栈完成后序遍历
    // 提交时函数名改为postorderTraversal
    // 测试链接 : https://leetcode.cn/problems/binary-tree-postorder-traversal/
    public IList<int> postorderTraversalOneStack(TreeNode h)
    {
        List<int> ans = new List<int>();
        if (h is not null)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(h);
            while (stack.Any())
            {
                TreeNode cur = stack.Peek();
                if (cur.left != null 
                    && h != cur.left
                    && h != cur.right)
                {
                    stack.Push(cur.left);
                }
                else if (cur.right != null
                    && h!=cur.right)
                {
                    stack.Push(cur.right);
                }
                else
                {
                    ans.Add(cur.val);
                    h = stack.Pop();
                }
            }
        }
        return ans;
    }
    
    #endregion
}