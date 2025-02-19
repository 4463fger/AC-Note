using System.Text;

namespace Learn;

// 位图的实现
// Bitset是一种能以紧凑形式存储位的数据结构
// Bitset(int n) : 初始化n个位，所有位都是0
// void fix(int i) : 将下标i的位上的值更新为1
// void unfix(int i) : 将下标i的位上的值更新为0
// void flip() : 翻转所有位的值
// boolean all() : 是否所有位都是1
// boolean one() : 是否至少有一位是1
// int count() : 返回所有位中1的数量
// String toString() : 返回所有位的状态
public class Code02_DesignBitsetTest
{
    // 测试链接 : https://leetcode-cn.com/problems/design-bitset/
    public class Bitset
    {
        private readonly int[] set; // 存储位的数组
        private readonly int size; // 位图的总大小
        private int ones; // 1的数量
        private bool reverse; // 是否翻转位的标志
        private int zeros; // 0的数量

        public Bitset(int n)
        {
            set = new int[(n + 31) / 32]; // 每个int存储32位，计算所需数组长度 
            size = n;
            zeros = n; // 初始所有位为0
            ones = 0;
            reverse = false; // 初始不翻转
        }

        // 把i这个数字加入到位图
        public void Fix(int i)
        {
            var index = i / 32;
            var bit = i % 32;
            if (!reverse)
            {
                // 位图所有位的状态，维持原始含义
                // 0 : 不存在
                // 1 : 存在
                if ((set[index] & (1 << bit)) == 0)
                {
                    zeros--;
                    ones++;
                    set[index] |= 1 << bit;
                }
            }
            else

            {
                // 位图所有位的状态，翻转了
                // 0 : 存在
                // 1 : 不存在
                if ((set[index] & (1 << bit)) != 0)
                {
                    zeros--;
                    ones++;
                    set[index] ^= 1 << bit;
                }
            }
        }

        // 把i这个数字从位图中移除
        public void Unfix(int i)
        {
            var index = i / 32;
            var bit = i % 32;
            if (!reverse)
            {
                if ((set[index] & (1 << bit)) != 0)
                {
                    ones--;
                    zeros++;
                    set[index] ^= 1 << bit;
                }
            }
            else
            {
                if ((set[index] & (1 << bit)) == 0)
                {
                    ones--;
                    zeros++;
                    set[index] |= 1 << bit;
                }
            }
        }

        public void Flip()
        {
            reverse = !reverse;
            var tmp = zeros;
            zeros = ones;
            ones = tmp;
        }

        public bool All()
        {
            return ones == size;
        }

        public bool One()
        {
            return ones > 0;
        }

        public int Count()
        {
            return ones;
        }
        
        // 转换为二进制字符串表示
        public string toString()
        {
            var builder = new StringBuilder();
            for (int i = 0, k = 0, number, status; i < size; k++)
            {
                number = set[k];
                for (var j = 0; j < 32 && i < size; j++, i++)
                {
                    status = (number >> j) & 1;
                    status ^= reverse ? 1 : 0;
                    builder.Append(status);
                }
            }

            return builder.ToString();
        }
    }
}