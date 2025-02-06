namespace Learn;

// 数组中1种数出现了奇数次，其他的数都出现了偶数次
// 返回出现了奇数次的数
// 测试链接 : https://leetcode.cn/problems/single-number/

public class Code04_SingleNumber
{
    public  int SingleNumber(int[] nums)
    {
        int eor = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            eor ^= nums[i];
        }
        return eor;
    }
}