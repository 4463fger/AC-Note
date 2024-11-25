/*
 * ┌──────────────────────────────────┐
 * │  描    述: 测试参数传递行为
 * │  类    名: ParameterPassingTest.cs
 * │  创 建 人: 4463fger
 * └──────────────────────────────────┘
 */
namespace Learn;

class ParameterPassingTest
{
    
    // public static void Main(string[] args)
    // {
    //     // 基本数据类型（int、long、byte、short）
    //     // 都是按值传递
    //     int a = 10;
    //     F(a);
    //     Console.WriteLine(a); // 输出:10
    //     
    //     // 引用类型(类)
    //     Number b = new Number(5);
    //     G1(b);
    //     Console.WriteLine(b == null ? "null" : b.Val.ToString());// 输出: 5，因为G1只是将局部变量b设为null，不影响传入的对象
    //     G2(b);
    //     Console.WriteLine(b == null ? "null" : b.Val.ToString()); // 输出: 6，因为G2修改了对象的内容
    //     
    //     // 引用类型(string) 虽然按引用传递
    //     // 是一种不可变（immutable）类型,看起来像按值传递
    //     string s = "hello";
    //     G5(s);
    //     Console.WriteLine(s); // 输出: hello，因为G5不能修改原始字符串
    //     
    //     // 数组类型（int[]）按引用传递
    //     int[] c = { 1, 2, 3, 4, 5 };
    //     G3(c);
    //     Console.WriteLine(c[0]); //输出: 1。
    //     G4(c);
    //     Console.WriteLine(c[0]); //输出: 100。因为G4修改了数组的第一个元素
    // }
    
    public static void F(int a)
    {
        a = 0; // 局部变量a被修改,不影响Main中的a
    }
    public class Number(int v)
    {
        public int Val = v;
    }

    public static void G1(Number b)
    {
        b = null; // 将局部变量b设为null，不影响传入的对象
    }

    public static void G2(Number b)
    {
        if (b != null) b.Val = 6; // 修改传入对象的内容
    }
    
    public static void G3(int[] c)
    {
        c = null; //递的是引用的副本。这意味着方法内部有一个新的引用，但它指向的是同一个对象。这里将新对象指向null，不影响原对象
    }
    
    public static void G4(int[] c)
    {
        if (c != null && c.Length > 0) c[0] = 100; // 修改数组的第一个元素
    }
    
    public static void G5(string s)
    {
        s = "world"; // 创建新的字符串对象，不影响传入的字符串
    }
}