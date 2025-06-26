/*
 * ┌──────────────────────────────────┐
 * │  描    述: 二进制和位运算
 * │  类    名: Code01_BinarySystem.cs
 * │  创    建: By 4463fger
 * └──────────────────────────────────┘
 */

namespace Learn;

public class Code01_BinarySystem
{
    /// <summary>
    /// 打印一个int类型数字的32位进制的状态
    /// </summary>
    public static void printBinary(int num)
    {
        for (int i = 31; i >= 0; i--)
        {
            Console.Write((num & (1<<i)) == 0 ? "0" : "1");
        }
    }
}