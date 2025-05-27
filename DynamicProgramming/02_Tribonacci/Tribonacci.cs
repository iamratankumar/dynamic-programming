namespace DynamicProgramming;

public static class Tribonacci
{
    
    /// <summary>
    /// Any Possible integer as input
    /// </summary>
    /// <param name="n">5</param>
    /// <returns></returns>
    
    
    //Brute Force
    public static int Compute(int n)
    {
        if (n < 2) return 0;
        if (n is 2 or 3) return 1;
        
        return Compute(n-1)+Compute(n-2) + Compute(n - 3);
    }
    
    //Memoized Solution (~n time complexity) n space
    public static int ComputeMemoized(int n)
    {
        return ComputeMemoized(n, new Dictionary<int, int>());
    }

    private static int ComputeMemoized(int n, Dictionary<int, int> cache)
    {
        if (cache.TryGetValue(n, out var value)) return cache[n];
        if (n < 2) return 0;
        if (n is 2 or 3) return 1;
        var result = ComputeMemoized(n - 1, cache) + ComputeMemoized(n - 2, cache) + ComputeMemoized(n - 3, cache);
        cache[n] = result;
        return result;
    }
    
    //Bottom Up Approach
    public static int ComputeBottomUp(int n)
    {
        var tris = new int[n + 1];
        tris[2] = 1;

        for (var i = 3; i <= n; i++)
        {
            tris[i] = tris[i - 1] + tris[i - 2] + tris[i - 3];
        }

        return tris[n];
    }
}