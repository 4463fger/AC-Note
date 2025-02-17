namespace Learn;
    
// 逆序二进制的状态
// 测试链接 : https://leetcode.cn/problems/reverse-bits/
public class Code05_ReverseBits
{
    // [1]: 位运算解法
    //      逆序二进制的状态
    public uint reverseBits(uint n) 
    {
        n = ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);
        n = ((n & 0xcccccccc) >> 2) | ((n & 0x33333333) << 2);
        n = ((n & 0xf0f0f0f0) >> 4) | ((n & 0x0f0f0f0f) << 4);
        n = ((n & 0xff00ff00) >> 8) | ((n & 0x00ff00ff) << 8);
        n = (n >> 16) | (n << 16);
        return n; 
    }
    
    // [2]:
    public uint ReverseBits(uint n)
    {
        // 32位无符号整数
        uint res = 0;

        for (int _ = 0; _ < 32; _++)
        {
            var last = n & 1;
            res = (res << 1) + last;
            n >>= 1;
        }
        return res;
    }
}