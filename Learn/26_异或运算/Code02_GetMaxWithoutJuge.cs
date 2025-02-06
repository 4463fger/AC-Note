namespace Learn;

// 不用任何判断语句和比较操作，返回两个数的最大值
// 测试链接 : https://www.nowcoder.com/practice/d2707eaf98124f1e8f1d9c18ad487f76

class Code02_GetMaxWithoutJuge
{
    // 必须保证n一定是0或者1
    // 0变1，1变0
    private int Flip(int n)
    {
        return n ^ 1;
    }
    
    // 非负数返回1
    // 负数返回0
    private int Sign(int n)
    {
        // >>> 无符号右移 : 保持符号位不变，正数高位补0，负数高位补1
        // >>  有符号右移 : 无论正负数，高位始终补0，结果总是非负的
        // return Flip(n >>> 31);
        return Flip((n >> 31) & 1);
    }
    
    // 有溢出风险的实现
    public int GetMax1(int a, int b)
    {
        int c = a - b;
        // c非负，returnA -> 1
        // c非负，returnB -> 0
        // c负数，returnA -> 0
        // c负数，returnB -> 1
        int returnA = Sign(c);
        int returnB = Flip(returnA);
        return a * returnA + b * returnB;
    }
    
    // 没有任何问题的实现
    public int GetMax2(int a, int b)
    {
        // c可能是溢出的
        int c = a - b;
        // a的符号
        int sa = Sign(a);
        // b的符号
        int sb = Sign(b);
        // c的符号
        int sc = Sign(c);
        // 判断A和B，符号是不是不一样，如果不一样diffAB=1，如果一样diffAB=0
        int diffAB = sa ^ sb;
        // 判断A和B，符号是不是一样，如果一样sameAB=1，如果不一样sameAB=0
        int sameAB = Flip(diffAB);
        int returnA = diffAB * sa + sameAB * sc;
        int returnB = Flip(returnA);
        return a * returnA + b * returnB;
    }
}