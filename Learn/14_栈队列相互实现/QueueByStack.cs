/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode232. 用栈实现队列
 * │  类    名: QueueByStack.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

// 用栈实现队列
class QueueByStack
{
    public class MyQueue 
    {
        Stack<int> inStack = new();
        Stack<int> outStack = new();
        public MyQueue() {   
        }
    
        // 倒数据
        // 从in栈，把数据倒入out栈
        // 1) out空了，才能倒数据
        // 2) 如果倒数据，in必须倒完
        private void InToOut()
        {
            if(outStack.Count == 0)
                while(inStack.Count != 0)
                    outStack.Push(inStack.Pop());
        }

        public void Push(int x) 
        {
            inStack.Push(x);
            InToOut();
        }
    
        public int Pop() {
            InToOut();
            return outStack.Pop();
        }
    
        public int Peek() {
            InToOut();
            return outStack.Peek();
        }
    
        public bool Empty() {
            return inStack.Count== 0 && outStack.Count== 0;
        }
    }
}