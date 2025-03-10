// setAll功能的哈希表
// 测试链接 : https://www.nowcoder.com/practice/7c4559f138e74ceb9ba57d76fd169967

// 使用时间戳
public class Code01_SetAllHashMap
{
        public static Dictionary<int,int[]> map = new Dictionary<int,int[]>();
        public static int setAllValue;
        public static int setAllTime;
        public static int cnt;

        public static void Put(int k ,int v)
        {
            if (map.ContainsKey(k))
            {
                int[] value = map[k];
                value[0] = v;
                value[1] = cnt++;
            }
            else
            {
                // map[k] = [v, cnt++];
                map[k] = new int[] { v, cnt++ };
            }
        }
        
        public static void SetAll(int v)
        {
            setAllValue = v;
            setAllTime = cnt++;
        }
        
        public static int Get(int k)
        {
            if (!map.TryGetValue(k, out var value))
            {
                return -1;
            }
            return value[1] > setAllTime ? value[0] : setAllValue;
        }
        
        /*
         输入描述：
        第一行一个整数N表示操作数。
        接下来N行，每行第一个数字opt代表操作类型
        若opt=1，接下来有两个整数x, y表示设置key=x对应的value=y
        若opt=2，接下来一个整数x，表示查询key=x对应的value，若key=x不存在输出-1
        若opt=3，接下来一个整数x，表示把加入过的所有的key对应的value都设置为x
         */
        public static void MAIN(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());

            // 读取所有输入并分割为 tokens
            string[] tokens = reader.ReadToEnd().Split(new[] { ' ', '\t', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);
          
            int index = 0;
            while (index < tokens.Length)
            {
                // 重置状态以处理新的测试用例
                map.Clear();
                setAllValue = -1;  // 初始化为无效值
                setAllTime = -1;
                cnt = 0;
                
                // 第一个数据为数据量
                int n = int.Parse(tokens[index++]);
                for (int i = 0; i < n; i++) 
                {
                    int op = int.Parse(tokens[index++]);
                    switch (op) {
                        case 1:
                            int a = int.Parse(tokens[index++]);
                            int b = int.Parse(tokens[index++]);
                            Put(a, b);
                            break;
                        case 2:
                            int c = int.Parse(tokens[index++]);
                            writer.WriteLine(Get(c));
                            break;
                        case 3:
                            int d = int.Parse(tokens[index++]);
                            SetAll(d);
                            break;
                    }
                }
            }

            writer.Flush();
            writer.Close();
            reader.Close();
        }
}