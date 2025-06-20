/*
 * ┌──────────────────────────────────┐
 * │  描    述: 选择排序
 * │  类    名: Code01_SelectionSort.cs
 * │  创    建: By 4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;

public class Code01_Sort
{
    public void Swap(int[] arr ,int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
    
    /// <summary>
    /// 选择排序
    /// </summary>
    public void SelectionSort(int[] arr)
    {
        if (arr == null || arr.Length < 2)
            return;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[minIndex] > arr[j])
                {
                    minIndex = j;
                }
            }
            Swap(arr, i, minIndex);
        }
    }

    /// <summary>
    /// 冒泡排序
    /// </summary>
    public void BubbleSort(int[] arr)
    {      
        if (arr == null || arr.Length < 2)
            return;
        
        for (int i = arr.Length - 1; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (arr[j] < arr[j+1])
                {
                    Swap(arr, j, j+1);
                }
            }
        }
    }

    /// <summary>
    /// 插入排序
    /// </summary>
    /// <param name="arr"></param>
    public void InsertSort(int[] arr)
    {
        if (arr == null || arr.Length < 2)
            return;
        
        for (int i = 1; i < arr.Length; i++)
        {
            for (int j = i - 1; j >= 0 && arr[j] > arr[j+1] ; j--)
            {
                Swap(arr, j, j+1);
            }
        }
    }
}