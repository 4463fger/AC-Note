/*
 * ┌──────────────────────────────────┐
 * │  描    述: 最多线段重合问题
 * │  类    名: maxCover.cs
 * │  创    建: By 4463fger
 * └──────────────────────────────────┘
 */

// 最多线段重合问题
// 测试链接 : https://www.nowcoder.com/practice/1ae8d0b6bb4e4bcdbf64ec491f63fc37
// 测试链接 : https://leetcode.cn/problems/meeting-rooms-ii/

namespace Learn;

public class Code02_MaxCover
{
    public static int MAXN = 10001;
    // 10001个数据,每个都是2个值,0表示开始,1表示结束
    public static int[][] line = new int[MAXN][];
    public static int n;

    public static void __Main__() {
        // 初始化二维数组
        for (int i = 0; i < MAXN; i++) {
            line[i] = new int[2];
        }

        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++) {
            string[] tokens = Console.ReadLine().Split();
            line[i][0] = int.Parse(tokens[0]);
            line[i][1] = int.Parse(tokens[1]);
        }
        size = 0;
        Array.Clear(heap,0,heap.Length);
        Console.WriteLine(Compute());
    }

    // 找重合方法
    private static int Compute() {
        // 线段一共有n条, 左闭右闭
        // 所有线段，根据开始位置排序，结束位置无所谓
        // 比较器的用法
        // line [0...n) 排序 : 所有小数组，开始位置谁小谁在前
        Array.Sort(line, 0, n,
                   Comparer<int[]>.Create(
                       (a, b) => a[0].CompareTo(b[0])));

        int ans = 0;
        for (int i = 0; i < n; i++) {
            while (size > 0 && heap[0] <= line[i][0]) {
                Pop();
            }
            Add(line[i][1]);
            ans = Math.Max(ans, size);
        }
        return ans;
    }

    // 小根堆
    private static int[] heap = new int[MAXN];
    // 小根堆大小
    private static int size;

    public static void Add(int x) {
        heap[size] = x;
        int i = size++;
        while (heap[i] < heap[(i - 1) / 2]) {
            Swap(i, (i - 1) / 2);
            i = (i - 1) / 2;
        }
    }

    public static void Pop() {
        Swap(0, --size);
        int i = 0, l = 1;
        while (l < size) {
            int best = l + 1 < size && heap[l + 1] < heap[l] ? l + 1 : l;
            best = heap[best] < heap[i] ? best : i;
            if (best == i) {
                break;
            }
            Swap(i, best);
            i = best;
            l = i * 2 + 1;
        }
    }

    // 牛客不支持元祖交换,这里无需简写
     public static void Swap(int i, int j) {
        int tmp = heap[i];
        heap[i] = heap[j];
        heap[j] = tmp;
    }
     
     
    // LeetCode 测试链接: https://leetcode.cn/problems/meeting-rooms-ii/
    // 提交以下代码可以直接通过
    public  int MainMeetingRooms(int[][] meeting)
    {
        int n = meeting.Length;
        // 按会议开始时间排序
        Array.Sort(meeting, (a, b) => a[0] - b[0]);
        // 最小堆，存储会议的结束时间
        var heap = new PriorityQueue<int, int>();
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            // 如果堆顶的会议已经结束，弹出堆顶
            while (heap.Count > 0 && heap.Peek() <= meeting[i][0])
            {
                heap.Dequeue();
            }
            // 将当前会议的结束时间加入堆
            heap.Enqueue(meeting[i][1], meeting[i][1]);
            // 更新最大会议室数量
            ans = Math.Max(ans, heap.Count);
        }
        return ans;
    }
    
    // 上面的leetcode题目是会员题，需要付费
    // 如果不想开通leetcode会员，还有一个类似的题，但是注意题意，和课上讲的有细微差别
    // 课上讲的题目，认为[1,4]、[4、5]可以严丝合缝接在一起，不算有重合
    // 但是如下链接的题目，认为[1,4]、[4、5]有重合部分，也就是4
    // 除此之外再无差别
    // 测试链接 : https://leetcode.cn/problems/divide-intervals-into-minimum-number-of-groups/
    // 提交如下代码可以直接通过
    public  int MinGroups(int[][] meeting)
    {
        int n = meeting.Length;
        // 按会议开始时间排序
        Array.Sort(meeting, (a, b) => a[0] - b[0]);
        // 最小堆，存储会议的结束时间
        var heap = new PriorityQueue<int, int>();
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            // 注意这里的判断：堆顶的会议结束时间必须小于当前会议的开始时间
            while (heap.Count > 0 && heap.Peek() < meeting[i][0])
            {
                heap.Dequeue();
            }
            // 将当前会议的结束时间加入堆
            heap.Enqueue(meeting[i][1], meeting[i][1]);
            // 更新最大会议室数量
            ans = Math.Max(ans, heap.Count);
        }
        return ans;
    }
}
