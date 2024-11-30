/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode225. 用队列实现栈
 * │  类    名: StackByQueue.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

// 用队列实现栈

class StackByQueue
{
    public class MyStack
    {
        private Queue<int> _queue;
        private int size;
        public MyStack()
        {
            _queue = new Queue<int>();
        }

        // O(n)
        public void Push(int x)
        {
            size = _queue.Count;
            _queue.Enqueue(x);
            for (int i = 0; i < size; i++)
                _queue.Enqueue(_queue.Dequeue());
        }

        public int Pop()
        {
            return _queue.Dequeue();
        }

        public int Top()
        {
            return _queue.Peek();
        }

        public bool Empty()
        {
            return _queue.Count == 0;
        }
    }
}