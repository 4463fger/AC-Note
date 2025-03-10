namespace Learn;


// 最大频率栈
public class Code06_MaximumFrequencyStack
{
    // 测试链接 : https://leetcode.cn/problems/maximum-frequency-stack/
    public class FreqStack 
    {
        // 出现的最大次数
        private int topTimes;
        // 每层的链表节点
        private Dictionary<int, List<int>> cntValues;
        // 每个数出现了几次(次频表)
        private Dictionary<int, int> valuesTimes;
        
        public FreqStack()
        {
            cntValues = new();
            valuesTimes = new();
        }
    
        public void Push(int val) 
        {
            // (key : val || value : val已出现的次数，如果不存在那么为0)
            valuesTimes[val] = valuesTimes.GetValueOrDefault(val, 0) + 1;
            int curTopTimes = valuesTimes[val];
            
            // 准备对应层级的列表
            if (!cntValues.ContainsKey(curTopTimes))
                cntValues.Add(curTopTimes,new List<int>());

            cntValues[curTopTimes].Add(val);
            // 更新最大词频
            topTimes = Math.Max(topTimes, curTopTimes);
        }
    
        public int Pop()
        {
            // 最大层的链表
            List<int> topTimeValues = cntValues[topTimes];

            int ans = topTimeValues[^1];
            topTimeValues.RemoveAt(topTimeValues.Count - 1);
            
            // 如果该层链表为空,那么清楚
            if (cntValues[topTimes].Count == 0)
            {
                cntValues.Remove(topTimes--);
            }

            int times = valuesTimes[ans];
            if (times == 1)
            {
                valuesTimes.Remove(ans);
            }
            else
            {
                valuesTimes[ans] = times - 1;
            }
            return ans;
        }
    }
}