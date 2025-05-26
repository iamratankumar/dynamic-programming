namespace DynamicProgramming;

public static class Fibonacci
{
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="n">10</param>
    /// <returns></returns>
    
    //Exponential time complexity and n space time
    // Not suitable for larger numbers
    public static int ComputeBruteForce(int n)
    {
        if (n < 2) return n;

        return ComputeBruteForce(n - 1) + ComputeBruteForce(n -2);
    }
    
    
    //~n time complexity and n space
    //better performance
    //top bottom with cache

    public static int ComputeMemoized(int n)
    {
        return ComputeMemoized(n, new Dictionary<int, int>());
    }

    private static int ComputeMemoized(int n, Dictionary<int, int> cache)
    {
        if (cache.TryGetValue(n,out var value)) return cache[n];
        if (n < 2) return n;

        var fib = ComputeMemoized(n - 1, cache) + ComputeMemoized(n - 2, cache);
        cache[n] = fib;
        return fib;
    }
    
    
    //n time complexity and space
    //Bottom up approch
    //efficient

    public static int ComputeBottomUp(int n)
    {
        var fibs = new int[n + 1];
        fibs[1] = 1;

        for (var i = 2; i <= n; i++)
        {
            fibs[i] = fibs[i - 1] + fibs[i - 2];
        }

        return fibs[n];
    }


}