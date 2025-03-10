namespace Learn;

// 插入、删除和获取随机元素O(1)时间的结构
// 测试链接 : https://leetcode.cn/problems/insert-delete-getrandom-o1/
public class Code03_InsertDeleteRandom
{
    public class RandomizedSet
    {
        // key  : 值
        // value: 在列表中的下标
        private Dictionary<int, int> _dic;
        public List<int> arr;
        private Random random;
        
        public RandomizedSet()
        {
            _dic = new Dictionary<int, int>();
            arr = new List<int>();
            random = new Random();
        }
    
        // 插入元素：O(1)
        public bool Insert(int val) 
        {
            if (_dic.ContainsKey(val))
            {
                return false;
            }
            _dic.Add(val, arr.Count);
            arr.Add(val);
            return true;
        }
    
        public bool Remove(int val) 
        {
            if (!_dic.TryGetValue(val, out var valIndex))
            {
                return false;
            }

            int endValue = arr[arr.Count - 1];
            
            // 将最后一个元素放到要删除的元素位置上
            _dic[endValue] = valIndex;
            arr[valIndex] = endValue;
            
            // 清理被删除的元素
            _dic.Remove(val);
            arr.RemoveAt(arr.Count - 1);
            return true;
        }
    
        // 获取随机元素：O(1)
        public int GetRandom()
        {
            return arr[random.Next(arr.Count)];
        }
    }
}