namespace Learn;

// 位图的实现(必须是连续的范围)
public class Code01_Bitset
{
    private int[] set;

    public Code01_Bitset(int n)
    {
        // 需要多少个int来存储n位
        // (n + 31) / 32 向上取整
        set = new int[(n + 31) / 32];
    }

    // [num / 32]: 计算出放在第几个数中
    // num % 32  : 找出在这个数的第几位

    // 添加数字(将对应的位设为1)
    public void Add(int num)
    {
        // | : 有1则为1
        set[num / 32] |= 1 << (num % 32);
    }

    // 移除数字(将对应位置设为0)
    public void Remove(int num)
    {
        // & : 同1为1 , 否则为0
        set[num / 32] &= ~(1 << (num % 32));
    }

    // 反转数字位(1 => 0 && 0 => 1)
    public void Reverse(int num)
    {
        // ^ : 异或操作，相同为0，不同为1 (无进位相加)
        set[num / 32] ^= 1 << (num % 32);
    }

    // 检查数字是否存在
    public bool Contains(int num)
    {
        return ((set[num / 32] >> (num % 32)) & 1) == 1;
    }
}

/// <summary>
/// 对数器验证
/// </summary>
class Program
{
    public static void __Main__(string[] args)
    {
        int n = 1000;
        int testTimes = 10000;
        Console.WriteLine("测试开始");

        Code01_Bitset bitset = new Code01_Bitset(n);
        HashSet<int> hashSet = new HashSet<int>();

        Console.WriteLine("调用阶段开始");
        Random random = new Random();
        for (int i = 0; i < testTimes; i++)
        {
            double decide = random.NextDouble();
            int number = random.Next(n);

            if (decide < 0.33)
            {
                bitset.Add(number);
                hashSet.Add(number);
            }
            else if (decide < 0.666)
            {
                bitset.Remove(number);
                hashSet.Remove(number);
            }
            else
            {
                bitset.Reverse(number);
                if (hashSet.Contains(number))
                {
                    hashSet.Remove(number);
                }
                else
                {
                    hashSet.Add(number);
                }
            }
        }

        Console.WriteLine("调用阶段结束");

        Console.WriteLine("验证阶段开始");
        for (int i = 0; i < n; i++)
        {
            if (bitset.Contains(i) != hashSet.Contains(i))
            {
                Console.WriteLine("出错了");
            }
        }

        Console.WriteLine("验证阶段结束");
        Console.WriteLine("测试结束");
    }
}