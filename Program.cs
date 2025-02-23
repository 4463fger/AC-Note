using Learn;

class Program
{
    public static void Main(string[] args)
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
