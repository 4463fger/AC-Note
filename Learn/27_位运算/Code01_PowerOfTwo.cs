namespace Learn;

// Brian Kernighan算法
// 提取出二进制里最右侧的1
// 判断一个整数是不是2的幂
// 测试链接 : https://leetcode.cn/problems/power-of-two/

class Code01_PowerOfTwo
{
    public bool IsPowerOfTwo(int n)
    {
        // n & -n 提取出二进制里最右侧的1
        // 当一个数是2的幂时，是满足 n & -n = n 的
        // 8 & -8 = 8
        // 8 为 1000
        return n > 0 && n == (n & - n);
    }
}