/*
 * ┌──────────────────────────────────┐
 * │  描    述: LeetCode3232. 判断是否可以赢得数字游戏
 * │  类    名: CanAliceWin.cs
 * │  创 建 人:  4463fger
 * └──────────────────────────────────┘
 */

public class SolutionCanAliceWin 
{
    public bool CanAliceWin(int[] nums) 
    {
        int ans = 0;

        foreach (var item in nums) {
            if (item < 10) 
            {
                ans += item;
            } 
            else 
            {
                ans -= item;
            }
        }
        // 单位数和两位数和不相等
        return ans != 0;
    }
}