namespace Learn;

public class Code06_OneKindNumberLessMtimes
{
    // 数组中只有1种数出现次数少于m次，其他数都出现了m次
    // 返回出现次数小于m次的那种数
    // 测试链接 : https://leetcode.cn/problems/single-number-ii/
    // 注意 : 测试题目只是通用方法的一个特例，课上讲了更通用的情况
    
    public int SingleNumber(int[] nums)
    {
        return Find(nums, 3);
    }

    private int Find(int[] arr, int m)
    {
        // cnts[0]  : 0位上有多少个1
        // cnts[i]  : i位上有多少个1
        // cnts[31] : 31位上有多少个1
        int[] cnts = new int[32];
        // 遍历数组所有元素
        foreach (int num in arr)
        {
            for (int i = 0; i < 32; i++)
            {
                // 统计所有数字在第i位上1的总个数
                
                // num >> i 将数字右移i位，使得第i位移动到最低位。
                // &1 操作取出最低位的值（0或1），即原数字第i位的值。
                // 若num的二进制是101（即5)
                // 当i=2时，num >> 2得到001，&1后为1，表示第2位是1
                cnts[i] += (num >> i) & 1;
            }
        }
        
        int ans = 0;
        for (int i = 0; i < 32; i++)
        {
            if (cnts[i] % m != 0)
            {
                // 将特定二进制位设为1。
                // 如果第i位的总次数不能被m整除，说明只出现一次的数字在这一位是1。
                // 1 << i 生成一个只有第i位为1的数。
                // |= 将这个位合并到答案中。例如，若i=0，则设置最低位为1。
                ans |= (1 << i);
            }
        }
        return ans;
    }
}