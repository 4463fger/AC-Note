/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode641.设计循环双端队列
 * │  类    名: CircularDeque.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

// 设计循环双端队列
// 测试链接 : https://leetcode.cn/problems/design-circular-deque/

class CircularDeque
{
    // 使用数组实现的循环双端队列
    class MyCircularDeque2
    {
        private int[] deque;
        private int l, r, size, limit;
        
        public MyCircularDeque2(int k)
        {
            deque = new int[k];
            l = r = size = 0;
            limit = k;
        }
        
        public bool InsertFront(int value)
        {
            if (IsFull())
                return false;
            if (IsEmpty())
            {
                l = r = 0;
                deque[0] = value;
            }
            else
            {
                l = l == 0 ? limit - 1 : l - 1;
                deque[l] = value;
            }
            size++;
            return true;
        }
    
        public bool InsertLast(int value) 
        {
            if (IsFull())
                return false;
            if (IsEmpty())
            {
                l = r = 0;
                deque[0] = value;
            }
            else
            {
                r = r == limit - 1 ? 0 : r + 1;
                deque[r] = value;
            }
            size++;
            return true;
        }
    
        public bool DeleteFront()
        {
            if (IsEmpty())
            {
                return false;
            }
            // l = (l + 1) % limit;
            l = l == limit - 1 ? 0 : l + 1;
            size--;
            return true;
        }
    
        public bool DeleteLast() 
        {
            if (IsEmpty())
            {
                return false;
            }
            //  r = (r - 1 + limit) % limit;
            r = r == 0 ? limit - 1 : r - 1;
            size--;
            return true;
        }
    
        public int GetFront()
        {
            if (IsEmpty())
                return -1;
            return deque[l];
        }
    
        public int GetRear() 
        {
            if (IsEmpty())
                return -1;
            return deque[r];
        }
    
        public bool IsEmpty()
        {
            return size == 0;
        }
    
        public bool IsFull()
        {
            return size == limit;
        }
    }
    // 内部就是双向链表
    // 常数操作慢，但是leetcode数据量太小了，所以看不出劣势
    class MyCircularDeque1
    {
        public LinkedList<int> deque = new();
        private int size;
        private int limit;

        public MyCircularDeque1(int k)
        {
            size = 0;
            limit = k;
        }

        public bool InsertFront(int value)
        {
            if (IsFull())
                return false;
            deque.AddFirst(value);
            size++;
            return true;
        }

        public bool InsertLast(int value)
        {
            if (IsFull())
                return false;
            deque.AddLast(value);
            size++;
            return true;
        }
        
        public bool DeleteFront() 
        {
            if (IsEmpty())
                return false;
            deque.RemoveFirst();
            size--;
            return true;
        }
    
        public bool DeleteLast() 
        {
            if (IsEmpty())
                return false;
            deque.RemoveLast();
            size--;
            return true;
        }
    
        public int GetFront() 
        {
            if (IsEmpty())
                return -1;
            return deque.First.Value;
        }
    
        public int GetRear()
        {
            if (IsEmpty())
                return -1;
            return deque.Last.Value;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == limit;
        }
    }
}