namespace DynamicProgramming;

public static class PossibleSum
{
    
    
    /// <summary>
    /// amount = 5  or 15
    /// nums = [1,2,3] or [6,5,10]
    /// </summary>
    /// <param name="amount">5</param>
    /// <param name="nums">[1,2,3]</param>
    /// <returns></returns>
    
    
    
    //Brute Force Solution
    // n^a time complexity where n = list of arrays and  a= int amount with space complexity of a
    public static bool Compute(int amount, List<int> nums)
    {
        if (amount == 0) return true;
        if (amount < 0) return false;

        foreach (var num in nums.Select(num => amount - num))
        {
            if (ComputeMemoized(num, nums))
            {
                return true;
            }
        }

        return false;
    }
    
    
    //Memoized Solution
    //a*n time complexity
    public static bool ComputeMemoized(int amount, List<int> nums)
    {
        return ComputeMemoized(amount, nums, new Dictionary<int, bool>());
    }

    private static bool ComputeMemoized(int amount, List<int> nums, Dictionary<int, bool> cache)
    {
        if (cache.TryGetValue(amount, out var value)) return cache[amount];
        if (amount == 0) return true;
        if (amount < 0) return false;

        foreach (var num in nums.Select(num=> amount-num))
        {
            if (ComputeMemoized(num, nums, cache))
            {
                cache[amount] = true;
                return true;
            }
        }

        cache[amount] = false;
        return false;
    }
    
    
    //BottomUp Approach
    public static bool ComputeBottomUp(int amount, List<int> nums)
    {
        var pSol = new bool[amount + 1];
        pSol[0] = true;

        for (var i = 0; i <= amount; i++)
        {
            if (pSol[i])
            {
                foreach (var pNext in nums.Select(n => i + n).Where(pNext => pNext<= amount))
                {
                    pSol[pNext] = true;
                }
            }
        }

        return pSol[amount];
    }

}