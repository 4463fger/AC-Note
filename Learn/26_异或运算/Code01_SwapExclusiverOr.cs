namespace Learn;

public class Code01_SwapExclusiverOr
{
    public static void main(string[] args) 
    {
        int a = -2323;
        int b = 10;
        Console.WriteLine("现在我们要开始用异或来交换a和b的值啦~喵");
        a = a ^ b;
        b = a ^ b;
        a = a ^ b;
        Console.WriteLine($"交换后a的值是：{a} 喵~");
        Console.WriteLine($"交换后b的值是：{b} 喵~");

        int[] arr = { 3, 5 };
        swap(arr, 0, 1);
        Console.WriteLine($"数组第一个元素现在是：{arr[0]} 喵~");
        Console.WriteLine($"数组第二个元素现在是：{arr[1]} 喵~");
        swap(arr, 0, 0);
        Console.WriteLine($"尝试对自己进行交换后的数组第一个元素还是：{arr[0]} 主人要注意这种写法有时候会出错呢喵！");
    }

    // 当i!=j，没问题，会完成交换功能
    // 当i==j，会出错
    // 所以知道这种写法即可，并不推荐
    public static void swap(int[] arr, int i, int j) 
    {
        if(i == j)
        {
            Console.WriteLine("这里如果i和j相等的话，就不" + 
                              "要尝试交换它们啦，不然可能会有小问题喵~");
        }
        arr[i] = arr[i] ^ arr[j];
        arr[j] = arr[i] ^ arr[j];
        arr[i] = arr[i] ^ arr[j];
    }
}