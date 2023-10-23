class Program
{
    static void Main(string[] args)
    {
        // Generate some sample data
        var random = new Random();
        var data = Enumerable.Range(0, 100).Select(i => random.NextDouble() * 100).ToArray();

        // Calculate descriptive statistics
        var mean = Statistics.Mean(data); // sample mean
        var variance = Statistics.Variance(data); // sample variance
        var stdDev = Statistics.StandardDeviation(data); // sample standard deviation
        var median = Statistics.Median(data); // sample median
        var mode = Statistics.Mode(data); // sample mode
        var max = Statistics.Maximum(data); // sample maximum
        var min = Statistics.Minimum(data); // sample minimum
        var range = Statistics.Range(data); // sample range
        var q10 = Statistics.Quantile(data, 0.1); // 10th percentile
        var q25 = Statistics.Quantile(data, 0.25); // 25th percentile
        var q50 = Statistics.Quantile(data, 0.5); // 50th percentile (same as median)
        var q75 = Statistics.Quantile(data, 0.75); // 75th percentile

        // Print the results
        Console.WriteLine("Descriptive statistics for the sample data:");
        Console.WriteLine($"Mean: {mean:F2}");
        Console.WriteLine($"Variance: {variance:F2}");
        Console.WriteLine($"Standard deviation: {stdDev:F2}");
        Console.WriteLine($"Median: {median:F2}");
        Console.WriteLine($"Mode: {mode:F2}");
        Console.WriteLine($"Maximum: {max:F2}");
        Console.WriteLine($"Minimum: {min:F2}");
        Console.WriteLine($"Range: {range:F2}");
        Console.WriteLine($"10th percentile: {q10:F2}");
        Console.WriteLine($"25th percentile: {q25:F2}");
        Console.WriteLine($"50th percentile: {q50:F2}");
        Console.WriteLine($"75th percentile: {q75:F2}");
    }
}

