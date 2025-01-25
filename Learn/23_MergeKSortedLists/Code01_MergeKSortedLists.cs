/*
 * ┌──────────────────────────────────┐
 * │  描    述: 合并K个有序链表
 * │  类    名: mergeKLists.cs
 * │  创    建: By 4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;

public class Code01_MergeKSortedLists
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode (int x)
        {
           val = x;
        }
    }

    // 合并K个有序链表
    // 测试链接：https://www.nowcoder.com/practice/65cfde9e5b9b4cf2b6bafa5f3ef33fa6

    class mergeKListsSolution
    {
        public ListNode mergeKLists(List<ListNode> arr)
        {
            // 小根堆
            var heap = new MinHeap();
            
            // [1]将所有链表的头结点加入优先队列
            foreach (var h in arr)
            {
                // 遍历所有的头！
                if (h != null)
                {
                    heap.Enqueue(h);
                }
            }
            // 如果队列还是空,证明链表就是空
            if (heap.Count == 0)
                return null;
            
            // [2]弹出最小结点作为合并链表的头结点
            ListNode head = heap.Dequeue();
            ListNode pre = head;
            if (pre.next != null)
            {
                heap.Enqueue(pre.next);
            }
            while (heap.Count > 0)
            {
                ListNode cur = heap.Dequeue();
                pre.next = cur;
                pre = cur;
                if (cur.next != null)
                {
                    heap.Enqueue(cur.next);
                }
            }
            return head;
        }

        private class MinHeap
        {
            private List<ListNode> heap;
            
            public MinHeap()
            {
                heap = new List<ListNode>();
            }
            public int Count => heap.Count;

            public void Enqueue(ListNode node)
            {
                heap.Add(node);
                int i = heap.Count - 1;
                while (i > 0)
                {
                    int parent = (i - 1) / 2;
                    if (heap[parent].val <= heap[i].val)
                        break;
                    Swap(parent, i);
                    i = parent;
                }
            }

            public ListNode Dequeue()
            {
                if (heap.Count == 0)
                    throw new InvalidOperationException("Heap is empty.");
                ListNode result = heap[0];
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                int i = 0;
                while (true)
                {
                    int left = 2 * i + 1;
                    int right = 2 * i + 2;
                    int smallest = i;
                    if (left < heap.Count && heap[left].val < heap[smallest].val)
                        smallest = left;
                    if (right < heap.Count && heap[right].val < heap[smallest].val)
                        smallest = right;
                    if (smallest == i)
                        break;
                    Swap(i, smallest);
                    i = smallest;
                }
                return result;
            }

            private void Swap(int i, int j)
            {
                ListNode temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }
        }
    }
}