/*
 * ┌──────────────────────────────────┐
 * │  描    述: 将数组和减半的最少操作次数
 * │  类    名: HalveArray.cs
 * │  创    建: By 4463fger
 * └──────────────────────────────────┘
 */
namespace Learn
{
    // 将数组和减半的最少操作次数
    // 测试链接 : https://leetcode.cn/problems/minimum-operations-to-halve-array-sum/
    public class Code03_MinimumOperationsToHalveArraySum
    {
        public int HalveArray1(int[] nums)
        {
            // 大根堆
            var heap = new PriorityQueue<double, double>(Comparer<double>.Create(
                (a, b) => b.CompareTo(a)));

            // 将数组元素加入堆中
            double sum = 0;
            foreach (var num in nums)
            {
                heap.Enqueue((double)num, (double)num);
                sum += num;
            }
            
            // sum 整体累加和 -> 要减少的目标
            sum /= 2;
            int ans = 0;

            for (double minus = 0 , cur = 0; minus < sum; ans++,minus += cur)
            {
                // 最大元素
                cur = heap.Dequeue() / 2;
                heap.Enqueue(cur,cur);
            }
            return ans;
        }

        // [1]自己手写堆, 从底到顶建堆
        // [2]把每个数都乘2的20次方
        public static int MAXN = 100001;
        public  long[] heap = new long[MAXN];
        public  int size;
        
        // 提交时把HalveArray2
        public int HalveArray2(int[] nums)
        {
            size = nums.Length;
            long sum = 0;
            for (int i = size - 1; i >= 0; i--)
            {
                // 左移20位,相当于乘以2的20次方
                heap[i] = (long)nums[i] << 20;
                sum += heap[i];
                Heapify(i);
            }

            sum /= 2;
            int ans = 0;
            for (long minus = 0; minus < sum; ans++)
            {
                heap[0] /= 2;
                minus += heap[0];
                Heapify(0);
            }
            return ans;
        }

        // 建堆
        private  void Heapify(int i)
        {
            int l = i * 2 + 1;
            while (l < size)
            {
                int best = l + 1 < size && heap[l + 1] > heap[l] ? l + 1 : l;
                best = heap[best] > heap[i] ? best : i;
                if (best == i)
                {
                    break;
                }
                Swap(best, i);
                i = best;
                l = i * 2 + 1;
            }
        }

        private void Swap(int i, int j)
        {
            (heap[i], heap[j]) = (heap[j], heap[i]);
        }
    }
}