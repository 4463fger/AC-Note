namespace  Learn;

// 全O(1)的数据结构
// 测试链接 : https://leetcode.cn/problems/all-oone-data-structure/
public class Code01_AllO1
{
    public class AllOne 
    {
        // 内部桶结构
        class Bucket
        {
            public int cnt; // 次序
            public HashSet<string> set;
            public Bucket last;
            public Bucket next;

            // 默认创建时传入一个字符
            public Bucket(string s , int c)
            {
                set = new HashSet<string>();
                set.Add(s);
                cnt = c;
            }
        }

        private Bucket head;
        private Bucket tail;

        // key   : 字符
        // value : 字符所在的桶
        private Dictionary<string, Bucket> map;
        
        public AllOne()
        {
            head = new Bucket("", 0);
            tail = new Bucket("", int.MaxValue);
            head.next = tail;
            tail.last = head;
            map = new Dictionary<string, Bucket>();
        }
    
        public void Inc(string key)
        {
            if (!map.ContainsKey(key))
            {
                // 如果头桶的下一个桶的计数为1号桶
                if (head.next.cnt == 1)
                {
                    map.Add(key, head.next);
                    head.next.set.Add(key);
                }
                else
                {
                    // 创建计数为1 的桶
                    Bucket newBucket = new Bucket(key, 1);
                    map.Add(key, newBucket);
                    Insert(head,newBucket);
                }
            }
            else // 如果键已经存在于表中
            {
                Bucket bucket = map[key];
                if (bucket.next.cnt == bucket.cnt + 1) // 如果下一个桶的计数为当前桶的计数加1
                {
                    map[key] = bucket.next;
                    bucket.next.set.Add(key);
                }
                else
                {
                    Bucket newBucket = new Bucket(key, bucket.cnt + 1);
                    map[key] = newBucket;
                    Insert(bucket, newBucket);
                }
                bucket.set.Remove(key);
                if (bucket.set.Count == 0)
                {
                    Remove(bucket);
                }
            }
        }
    
        public void Dec(string key)
        {
            if (!map.ContainsKey(key))
                return;

            Bucket bucket = map[key];
            if (bucket.cnt == 1)
            {
                map.Remove(key);
            }
            else
            {
                // 如果前一个桶的计数等于当前桶的计数-1
                if (bucket.last.cnt == bucket.cnt - 1)
                {
                    map[key] = bucket.last;
                    bucket.last.set.Add(key);
                }
                else
                {
                    Bucket newBucket = new Bucket(key, bucket.cnt - 1);
                    map[key] = newBucket;
                    Insert(bucket.last, newBucket);
                }
            }

            bucket.set.Remove(key);
            if (bucket.set.Count == 0)
            {
                Remove(bucket);
            }
        }
    
        public string GetMaxKey() 
        {
            // 如果尾桶的前一个桶的集合不为空
            if (tail.last.set.Count > 0)
            {
                var enumerator = tail.last.set.GetEnumerator();
                enumerator.MoveNext();
                return enumerator.Current;
            }
            return ""; // 如果集合为空，返回空字符串
        }
    
        public string GetMinKey() 
        {
            if (head.next.set.Count > 0) // 如果头桶的下一个桶的集合不为空
            {
                // 返回该集合中的任意一个键
                var enumerator = head.next.set.GetEnumerator();
                enumerator.MoveNext();
                return enumerator.Current; 
            }
            return ""; // 如果集合为空，返回空字符串
        }

        // cur : 插入到哪个桶后
        // pos : 需要插入桶
        private void Insert(Bucket cur , Bucket pos)
        {
            cur.next.last = pos;
            pos.next = cur.next;
            cur.next = pos;
            pos.last = cur;
        }

        // cur : 需要删除桶
        private void Remove(Bucket cur)
        {
            cur.last.next = cur.next;
            cur.next.last = cur.last;
        }
    }
}

