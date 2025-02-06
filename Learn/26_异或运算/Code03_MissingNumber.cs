namespace Learn;

// 找到缺失的数字
// 测试链接 : https://leetcode.cn/problems/missing-number/

public class Code03_MissingNumber
{
    public int MissingNumber(int[] nums)
    {
        int eorAll = 0; // 所有元素的异或和
        int eorHas = 0; // 现在有的元素的异或和

        for (int i = 0; i < nums.Length; i++)
        {
            eorAll ^= i;       // 收集0到n-1的异或
            eorHas ^= nums[i]; // 收集数组现有数字
        }

        eorAll ^= nums.Length; // 补上最后一个数字n
        return eorAll ^ eorHas;
    }
}
/* 异或是无进位相加
    [1]准备阶段
        eorAll:所有数的异或和
        eorHas:现有的数字异或和
    
    [2]第一次循环遍历数组
        i 从0到 n-1（比如数组长度3，i就是0,1,2）
        eorAll ^= i → 相当于计算 0^1^2
        eorHas ^= nums[i] → 假设nums是[0,1,3]，这里计算 0^1^3
        
    [3]补全完整序列
    eorAll ^= nums.Length → 把n（数组长度3）异或进去
    此时eorAll变成 0^1^2^3
    
    [4]最终碰撞
    eorAll是完整序列的异或值（0^1^2^3）
    eorHas是当前数组的异或值（0^1^3）
    
    二者异或时：
    (0^0)会消失
    (1^1)会消失
    剩下2^3^3 → 3^3消失 → 最终剩2
*/
    
    
    