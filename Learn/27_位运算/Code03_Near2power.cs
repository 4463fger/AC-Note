namespace Learn;

// 已知n是非负数
// 返回大于等于n的最小的2某次方
// 如果int范围内不存在这样的数，返回整数最小值
public class Code03_Near2power
{
    public int near2power(int n)
    {
        if (n < 0)
        {
            return 1;
        }

        n--;
        // n |= (int)((uint)n >> 1) 
        // 无符号右移： 使用 (uint)n 将n转换为无符号整数，再进行右移操作，确保高位补0
        n |= n >>> 1;
        n |= n >>> 2;
        n |= n >>> 4;
        n |= n >>> 8;
        n |= n >>> 16;

        return n + 1;
    }
}