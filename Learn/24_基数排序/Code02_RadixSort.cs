/*
 * ┌──────────────────────────────────┐
 * │  描    述: 基数排序
 * │  类    名: RadixSort.cs
 * │  创    建: By 4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;

// 基数排序
// 测试链接 : https://leetcode.cn/problems/sort-an-array/

public class Code02_RadixSort
{
    // 可以设置进制，不一定10进制，随你设置
    // BASE：基数排序的基数，这里设置为10，表示十进制。
    // MAXN：数组的最大长度。
    // help：辅助数组，用于在排序过程中存储中间结果。
    // cnts：计数数组，用于记录每个基数位上的数字出现的次数。
    public static int Base = 10;
    public static int MAXN = 50001;
    public static int[] help = new int[MAXN];
    public static int[] cnts = new int[Base];
    
    
    public  int[] SortArray(int[] arr)
    {
        if (arr.Length > 1)
        {
            // 如果会溢出，那么要改用long类型数组来排序
            int n = arr.Length;
            
            // [1]找到数组中的最小值 => (用于把arr转成非负数组)
            int min = arr[0];
            for (int i = 1; i < n; i++)
            {
                min = Math.Min(min, arr[i]);
            }

            // [2]寻找数组中的最大值
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                // 数组中的每个数字，减去数组中的最小值，就把arr转成了非负数组
                arr[i] -= min;
                // 记录数组中的最大值
                max = Math.Max(max, arr[i]);
            }
            
            // 根据最大值在BASE进制下的位数，决定基数排序做多少轮 
            // [3]: 计算最大值的位数
            int bits = Bits(max);
            
            // [4]: 基数排序
            RadixSort(arr, n, bits);
            
            // [5]: 还原数组
            for (int i = 0; i < n; i++)
            {
                arr[i] += min;
            }
        }
        return arr;
    }

    /// <summary>
    /// 计算数字的位数
    /// 返回number在BASE进制下有几位
    /// </summary>
    private int Bits(int number)
    {
        if (number == 0) 
            return 1;
        int ans = 0;
        while (number > 0)
        {
            ans ++;
            number /= Base;
        }
        return ans;
    }
    
    // 基数排序核心代码
    // arr内要保证没有负数
    // n是arr的长度
    // bits是arr中最大值在BASE进制下有几位
    private void RadixSort(int[] arr, int n, int bits)
    {
        // 循环遍历每一位数字，从最低位到最高位
        for (int offset = 1; bits > 0; offset *= Base,bits--)
        {
            // [1]：清空计数数组
            Array.Fill(cnts,0);
            
            // [2]：统计每个数字在当前位出现的次数
            // 把每个数字的offset位的元素依次填入桶中
            foreach (int num in arr)
            {
                int digit = (num / offset) % Base;
                cnts[digit]++;
            }
            
            // [3]：计算前缀和
            // <= 0 : x个
            // <= 1 : x+y 个
            // <= 2 : x+y+z 个
            for (int i = 1; i < Base; i++)
            {
                cnts[i] += cnts[i - 1];
            }
            
            // [4]反向填充辅助数组
            for (int i = n - 1; i >= 0; i--)
            {
                // digit 是当前数字在当前位上的值
                // 比如123 在第十位上的值是2
                int digit = (arr[i] / offset) % Base;
                help[--cnts[digit]] = arr[i];
            }
            
            // [5]数据写回原数组
            Array.Copy(help,arr,n);
        }   
    }
}
