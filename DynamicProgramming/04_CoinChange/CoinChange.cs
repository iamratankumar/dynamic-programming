namespace DynamicProgramming;

public class CoinChange
{
    
    /// <summary>
    /// Brute Force Solution
    /// Time complexity O(c^a) where a= amount and c = coins
    /// Space Complexity O(a) 
    /// </summary>
    /// <param name="amount">5</param>
    /// <param name="coins">[1,2,3]</param>
    /// <returns></returns>
    public static int Compute(int amount, List<int> coins)
    {
        if (amount == 0) return 0;
        if (amount < 0) return -1;

        var minCoins = -1;

        foreach (var c in coins.Select(c => amount - c))
        {
            var subCoins = Compute(c, coins);
            if (subCoins != -1)
            {
                var nCoins = subCoins + 1;
                if (nCoins < minCoins || minCoins == -1) minCoins = nCoins;
            }
        }

        return minCoins;
    }
    
    /// <summary>
    /// Memoized/Tabulation Approach
    /// Time Complexity O(a*c)
    /// Space Complexity O(a)
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="coins"></param>
    /// <returns></returns>
    public static int ComputeMemoized(int amount, List<int> coins)
    {
        return ComputeMemoized(amount, coins, new Dictionary<int, int>());
    }

    private static int ComputeMemoized(int amount, List<int> coins, Dictionary<int, int> cache)
    {
        if (amount == 0) return 0;
        if (amount < 0) return -1;
        if (cache.TryGetValue(amount, out var memoized)) return memoized;

        var minCoins = -1;

        foreach (var c in coins.Select(n=> amount-n))
        {
            var subCoins = ComputeMemoized(c, coins, cache);

            if (subCoins != -1)
            {
                var nCoins = subCoins + 1;
                if (nCoins < minCoins || minCoins == -1) minCoins = nCoins;
            }
        }

        cache[amount] = minCoins;
        return minCoins;
    }


    public static int ComputeBottomUp(int amount, List<int> coins)
    {
        
        Span<int> dp = stackalloc int[amount + 1];

        for (int i = 1; i < amount + 1; i++)
        {
            int curr = amount + 1;

            foreach (var c in coins)
            {
                if (i - c>= 0)
                {
                    if (curr > dp[i - c] + 1)
                    {
                        curr = dp[i - c] + 1;
                    }
                }
            }

            dp[i] = curr;
        }

        return dp[amount] == amount + 1 ? -1 : dp[amount];
    }
    
    
}