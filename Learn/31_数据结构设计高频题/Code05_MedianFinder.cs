namespace Learn;

public class Code05_MedianFinder
{
    // 快速获得数据流的中位数的结构
    // 测试链接 : https://leetcode.cn/problems/find-median-from-data-stream/
    class MedianFinder
    {
        private PriorityQueue<int, int> small; // 小根堆
        private PriorityQueue<int, int> large; // 大根堆
        
        public MedianFinder() 
        {
            small = new PriorityQueue<int, int>();
            large = new PriorityQueue<int, int>();
        }
    
        public void AddNum(int num) 
        {
            // 加入大根堆
            if (large.Count == 0 || num <= large.Peek())
            {
                large.Enqueue(num,-num);
            }
            else
            {
                small.Enqueue(num,num);
            }
            
            balance();
        }
    
        public double FindMedian()
        {
            if (small.Count != large.Count) 
                return small.Count > large.Count ? small.Peek() : large.Peek();
            
            return (double)(small.Peek() + large.Peek())/2;
        }

        // 两个堆数据的平衡
        void balance()
        {
            if (MathF.Abs(small.Count - large.Count) != 2) return;
            
            if (small.Count > large.Count)
            {
                int num = small.Dequeue();
                large.Enqueue(num,-num);
            }
            else if (large.Count > small.Count)
            {
                int num = large.Dequeue();
                small.Enqueue(num,num);
            }
        }
    }
}
