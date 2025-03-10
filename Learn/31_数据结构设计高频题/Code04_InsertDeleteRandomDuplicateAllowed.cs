namespace Learn;

// 插入、删除和获取随机元素O(1)时间且允许有重复数字的结构
// https://leetcode.cn/problems/insert-delete-getrandom-o1-duplicates-allowed/

internal class Code04_InsertDeleteRandomDuplicateAllowed
{
    public class RandomizedCollection
    {
        private Dictionary<int, List<int>> map;
        private List<int> arr;
        private Random random;


        public RandomizedCollection()
        {
            map = new Dictionary<int, List<int>>();
            arr = new List<int>();
            random = new Random();
        }
        
        public bool Insert(int val)
        {
            arr.Add(val);
            if (!map.TryGetValue(val,out var list))
            {
                list = new List<int>();
                map[val] = list;
            }
            list.Add(arr.Count - 1);
            return list.Count == 1;
        }

        public bool Remove(int val)
        {
            if (!map.ContainsKey(val))
            {
                return false;
            }

            List<int> valList = map[val];
            int valAnyIndex = valList.First();
            int endValue = arr[arr.Count - 1];

            // 要删除的就是最后一个元素,那么就直接删除索引
            if (val == endValue)
            {
                valList.Remove(arr.Count - 1);
            }
            else
            {
                List<int> endValueList = map[endValue];
                
                // 交换元素
                endValueList.Add(valAnyIndex);
                arr[valAnyIndex] = endValue;
                
                // 移除对应列表元素
                endValueList.Remove(arr.Count - 1);
                valList.Remove(valAnyIndex);
            }
            
            // 移除末尾元素
            arr.RemoveAt(arr.Count -1);

            if (valList.Count == 0)
            {
                map.Remove(val);
            }
            return true;
        }

        public int GetRandom()
        {
            return arr[random.Next(arr.Count)];
        }
    }
}