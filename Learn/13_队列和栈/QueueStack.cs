/*
 * ┌──────────────────────────────────┐
 * │  描    述: 实现队列,栈
 * │  类    名: QueueStack.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

public class QueueStack
{
    // 使用C#实现
    // 实际上内部就是双向链表, 常数时间操作较慢
    public class Queue1
    {
        // .NET 中的双向链表 LinkedList
        // 单向链表就足够了
        private LinkedList<int> _queue = new LinkedList<int>();

        // 调用任何方法之前，先调用这个方法来判断队列内是否有东西
        public bool IsEmpty() => _queue.Count == 0;

        // 向队列中加入num，加到尾巴
        public void offer(int num) => _queue.AddLast(num);

        // 从队列头部拿
        public int Poll()
        {
            // 利用C# 9.0引入的模式匹配和属性模式的新特性
            if (_queue is { Count: > 0, First: not null }) 
            {
                int result = _queue.First.Value;
                _queue.RemoveFirst();
                return result;
            }
            throw new InvalidOperationException("队列为空");
        }
        
        // 查看队头元素
        public int Peek()
        {
            if (_queue is {Count: > 0, First: not null})
                return _queue.First.Value;
            throw new InvalidOperationException("队列为空");
        }
        
        // 返回目前队列有几个数
        public int Size() => _queue.Count;
    }
    
    // 实际刷题时更常见的写法，常数时间好
    // 如果可以确定加入操作的总次数不超过n，那么可以用
    // 一般笔试、面试都会有一个明确数据量，所以这是最常用的方式
    // 加入操作的总次数上限是多少,一定要明确
    // 主构造函数
    public class Queue2(int n)
    {
        private int[] _queue = new int[n];
        private int _l = 0, _r = 0;
        
        // 判断队列是否为空
        public bool IsEmpty() => _l == _r;

        public void offer(int num) => _queue[_r++] = num;

        public int Poll()
        {
            if (_l < _r)
                return _queue[_l++];
            throw new InvalidOperationException("队列为空");
        }
        
        public int Head() => _l < _r ? _queue[_l] : throw new InvalidOperationException("队列为空");
        public int Tail() => _l < _r ? _queue[_r - 1] : throw new InvalidOperationException("队列为空");
        public int Size() => _r - _l;
    }

    // 使用 .NET 内部实现
    // 其实就是动态数组，不过常数时间并不好
    public class Stack1
    {
        private readonly Stack<int> stack = new();

        // 调用任何方法之前，先调用这个方法来判断栈内是否有东西
        public bool IsEmpty() => stack.Count == 0;

        // 向栈中加入num
        public void Push(int num) => stack.Push(num);

        // 从栈顶移除并返回元素
        public int Pop()
        {
            if (stack.Count > 0)
                return stack.Pop();
            throw new InvalidOperationException("栈空");
        }

        // 返回栈顶元素但不移除
        public int Peek()
        {
            if (stack.Count > 0)
                return stack.Peek();
            throw new InvalidOperationException("栈空");
        }

        // 返回目前栈中有几个数
        public int Size() => stack.Count;
    }

    // 实际刷题时更常见的写法，常数时间好
    // 如果可以保证同时在栈里的元素个数不会超过n，那么可以用
    // 也就是发生弹出操作之后，空间可以复用
    // 一般笔试、面试都会有一个明确数据量，所以这是最常用的方式
    // 同时在栈里的元素个数不会超过n
    public class Stack2(int n)
    {
        private int[] stack = new int[n];
        private int _size = 0;
        
        // 调用任何方法之前，先调用这个方法来判断栈内是否有东西
        public bool IsEmpty() => _size == 0;

        public void Push(int num) => stack[_size++] = num;

        public int Pop()
        {
            if (_size > 0)
                return stack[--_size];
            throw new InvalidOperationException("栈空");
        }

        public int Peek()
        {
            if (_size > 0)
                return stack[_size - 1];
            throw new InvalidOperationException("栈空");
        }

        public int Size() => _size;
    }
}