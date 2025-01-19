/*
 * ┌──────────────────────────────────┐
 * │  描    述: 堆结构和堆排序
 * │  类    名: HeapSort.cs
 * │  创    建: By 4463fger
 * └──────────────────────────────────┘
 */

// 堆结构和堆排序
// 测试链接 : https://leetcode.cn/problems/sort-an-array/
public class Code02_HeapSort
{
    public int[] SortArray(int[] nums)
    {
        if (nums.Length > 1)
        {
            // heapSort1为从顶到底建堆然后排序
            // heapSort2为从底到顶建堆然后排序
            //HeapSort1(nums);
            HeapSort2(nums);
        }
        return nums;
    }
    
    // 从顶到底建立大根堆，O(n * LogN)
    // 依次弹出堆内最大值并排好序，O(n * LogN)
    // 整体时间复杂度O(n * LogN)
    private void HeapSort1(int[] arr)
    {
        int n = arr.Length;
        // 构建大根堆
        for (int i = 0; i < n; i++)
        {
            HeapInsert(arr,i);
        }
        // 排序
        int size = n;
        while (size > 1)
        {
            // 将最大值，移到数组末尾 || size-1
            Swap(arr, 0, --size);
            // 0 位置数变了,重新维持大根堆
            Heapify(arr, 0, size);
        }
    }
    
    // 从底到顶建立大根堆，O(n)
    // 依次弹出堆内最大值并排好序，O(n * LogN)
    // 整体时间复杂度O(n * LogN)
    private void HeapSort2(int[] arr)
    {
        int n = arr.Length;
        // 从最后一个非叶子节点开始调整
        for (int i = n/2 - 1; i >= 0; i--)
        {
            Heapify(arr,i,n);
        }
        int size = n;
        while (size > 1)
        {
            Swap(arr, 0, --size);
            Heapify(arr, 0, size);
        }
    }
    
    // i位置的数,向上调整大根堆
    // arr[i] = x，x是新来的！往上看，直到不比父亲大，或者来到0 位置(顶)
    private void HeapInsert(int[] arr, int i)
    {
        while (arr[i] > arr[(i-1)/2])
        {
            Swap(arr, i, (i - 1) / 2);
            i = (i - 1) / 2;
        }
    }
    
    // 向下调整大根堆
    // i位置的数,变小了,又想维持大根堆结构
    // 堆的大小为size
    private void Heapify(int[] arr, int i, int size)
    {
        int l = i * 2 + 1;
        while (l < size)
        {
            // 左孩子=>l || 右孩子=>l+1
            // ReSharper disable once GrammarMistakeInComment
            // 找左右孩子中较大的一个
            // l+1<size检查右孩子是否存在 , 并且右比左大，那么选右
            int best = l + 1 < size && arr[l + 1] > arr[l] ? l + 1 : l;
            // 当前结点比右孩子大 break
            if(arr[best] <= arr[i])
                break;
            Swap(arr,best,i);
            i = best;
            l = i * 2 + 1;
        }
    }

    private void Swap(int[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}