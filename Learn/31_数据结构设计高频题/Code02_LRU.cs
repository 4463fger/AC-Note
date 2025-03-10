namespace Learn;

// 测试链接 : https://leetcode.cn/problems/lru-cache/
// 实现LRU结构 => (字典 + 双向链表)
public class Code02_LRU
{
    public class LRUCache
    {
        private DoubleList _doubleList;
        private Dictionary<int, DoubleNode> keyNodeDic;
        private readonly int capacity;

        public LRUCache(int capacity)
        {
            _doubleList = new DoubleList();
            keyNodeDic = new Dictionary<int, DoubleNode>();
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (keyNodeDic.TryGetValue(key,out var node))
            {
                _doubleList.MoveNodeToTail(node);
                return node.val;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (keyNodeDic.TryGetValue(key, out var node))
            {
                node.val = value;
                _doubleList.MoveNodeToTail(node);
            }
            // 向链表中放入节点
            else
            {
                // 如果已经超过容量,那么删除头
                if (keyNodeDic.Count == capacity)
                {
                    keyNodeDic.Remove(_doubleList.RemoveHead().key);
                }
                DoubleNode newNode = new DoubleNode(key, value);
                keyNodeDic.Add(key, newNode);
                _doubleList.AddNode(newNode);
            }
        }

        public class DoubleNode
        {
            public int key;

            public DoubleNode last;
            public DoubleNode next;
            public int val;

            public DoubleNode(int k, int v)
            {
                key = k;
                val = v;
            }
        }

        public class DoubleList
        {
            public DoubleNode head;
            public DoubleNode tail;

            public DoubleList()
            {
                head = null;
                tail = null;
            }

            // 添加到尾部
            public void AddNode(DoubleNode newNode)
            {
                // 如果新节点为空，直接返回
                if (newNode == null)
                    return;

                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.next = newNode;
                    newNode.last = tail;
                    tail = newNode;
                }
            }

            public void MoveNodeToTail(DoubleNode node)
            {
                // 本身就在尾巴,直接return
                if (tail == node)
                    return;

                // 将相邻俩节点断开
                if (node == head)
                {
                    head = node.next;
                    head.last = null;
                }
                else
                {
                    node.last.next = node.next;
                    node.next.last = node.last;
                }

                // 移至末尾
                node.last = tail;
                node.next = null;
                tail.next = node;
                tail = node;
            }

            public DoubleNode RemoveHead()
            {
                if (head == null)
                    return null;

                var res = head;
                if (head == tail)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = res.next;
                    res.next = null;
                    head.last = null;
                }

                return res;
            }
        }
    }
}