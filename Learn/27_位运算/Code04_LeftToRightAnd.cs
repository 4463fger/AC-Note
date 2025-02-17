namespace Learn;

// 给你两个整数 left 和 right ，表示区间 [left, right]
// 返回此区间内所有数字 & 的结果
// 包含 left 、right 端点
// 测试链接 : https://leetcode.cn/problems/bitwise-and-of-numbers-range/
public class Code04_LeftToRightAnd
{
    public int RangeBitwiseAnd(int left , int right)
    {
        while (left < right)
        {
            // 这里 right & -right 得到 right 二进制表示中最低位的1（即最低的1对应的值）
            // 将 right 减去这个值，就相当于把 right 中最低位的1消除掉
            right -= right & -right;
        }
        return right;
    }
}