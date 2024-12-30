/*
 * ┌──────────────────────────────────┐
 * │  描    述: 归并分治求小和
 * │  类    名: SmallSum.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */

// 小和问题
// 测试链接 : https://www.nowcoder.com/practice/edfe05a1d45c4ea89101d936cac32469
// 请同学们务必参考如下代码中关于输入、输出的处理
// 这是输入输出处理效率很高的写法
// 提交以下的code，提交时请把类名改成"Main"，可以直接通过

using System.IO;
using System;

public class Code01_SmallSum
{
    private const int MAXN = 100001;
    public static int[] arr = new int[MAXN];
    public static int[] help = new int[MAXN];
    public static int n;

    public static void _Main_(string[] args)
    {
        // 使用Reader 和 Writer来进行输入输出操作
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput())) 
        {
            string line;
            if ((line = reader.ReadLine()) != null) 
            {
                // 读取第一行数据
                n = int.Parse(line);
                //读取第二行
                if ((line = reader.ReadLine()) != null) 
                {
                    string[] nums = line.Split(' ');
                    for (int i = 0; i < n; i++) 
                    {
                        arr[i] = int.Parse(nums[i]);
                    }
                    Console.WriteLine(SmallSum(0, n - 1));
                }
            }
        }
    }
    
    public static void __Main__(string[] args)  
    {
        string line;
        int count = 0;
        while (count++ < 2) {
            line = Console.ReadLine();
            if (line == null) {
                return;
            }
            string[] tokens = line.Split();
            if (count == 1) {
                n = int.Parse(tokens[0]);
            } else {
                for (int i = 0; i < n; i++) {
                    arr[i] = int.Parse(tokens[i]);
                }
                long sum = SmallSum(0, n - 1);
                Console.WriteLine(sum);
            }
        }
    }
    
    // 返回arr[l...r]上所有数字的小和
    // 时间复杂度O(n * logn)
    public static long SmallSum(int l, int r)
    {
        // 区间只有一个数字，小和==0
        if (l == r) 
            return 0;

        int m = (l + r) >> 1;
        
        // 左侧部分的小和 + 右侧部分的小和 + 跨左右的小和
        return SmallSum(l,m) + SmallSum(m+1,r) + Merge(l,m,r);
    }
    
    // 求小和,并数组变有序
    public static long Merge(int l, int m, int r)
    {
        // 统计部分
        long ans = 0;
        
        for (int j = m + 1, i = l,sum = 0; j <= r; j++)
        {
            // 左侧部分小于右侧
            while ( i <= m && arr[i] <= arr[j])
            {
                sum += arr[i++];
            }
            ans += sum;
        }
        
        // Merge
        int a = l;      //  左指针
        int b = m + 1;  // 右指针
        int index = l;  // 辅助数组指针
        
        // 合并两个有序子数组
        while (a <= m && b <= r)
        {
            help[index++] = arr[a] <= arr[b] ? arr[a++] : arr[b++];
        }
        // 处理左右部分剩余
        while (a <= m)
        {
            help[index++] = arr[a++];
        }
        while (b <= r)
        {
            help[index++] = arr[b++];
        }

        Array.Copy(help, l, arr, l, r - l + 1);
        return ans;
    }
}