/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode155.最小栈
 * │  类    名: GetMinStack.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;

// 最小栈
// 测试链接 : https://leetcode.cn/problems/min-stack/
public class GetMinStack
{
    // 方法一
    // 自己实现数组栈
    class MinStack1
    {
        // leetcode的数据在测试时，同时在栈里的数据不超过这个值
        // 如果leetcode补测试数据了，超过这个量导致出错，就调大
        public const int MAXN = 8001;
        public int[] data;
        public int[] min;
        public int size;

        public MinStack1()
        {
            data = new int[MAXN];
            min = new int[MAXN];
            size = 0;
        }
        
        public void Push(int val)
        {
            data[size] = val;
            if (size == 0 || val <= min[size - 1])
                min[size] = val;
            else
                min[size] = min[size - 1];
            size++;
        }
    
        public void Pop()
        {
            size--;
        }
    
        public int Top()
        {
            return data[size - 1];
        }
    
        public int GetMin()
        {
            return min[size - 1];
        }
    }
    // 方法二
    // 使用C#内置栈实现
    class MinStack2
    {
        public Stack<int> data;
        public Stack<int> min;

        public MinStack2()
        {
            data = new Stack<int>();
            min = new Stack<int>();
        }
        
        public void Push(int val) 
        {
            data.Push(val);
            if (min.Count == 0 || val <= min.Peek())
                min.Push(val);
            else
                min.Push(min.Peek());
        }
    
        public void Pop()
        {
            data.Pop();
            min.Pop();
        }
    
        public int Top()
        {
            return data.Peek();
        }
    
        public int GetMin()
        {
            return min.Peek();
        }
    }
}
