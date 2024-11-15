public class Solution
{
    public void main(String[] args)
    {
    
    }

    public int solution(int[] diffs, int[] times, long limit)
    {
        int minLevel = 1;
        int maxLevel = diffs.Max();
        int result = maxLevel;

        while (minLevel <= maxLevel)
        {
            var levelAvg = (minLevel + maxLevel) / 2;

            if (CalTotalTime(levelAvg, diffs, times, limit) <= limit)
            {
                result = levelAvg;
                maxLevel = levelAvg - 1;
            }
            else
            {
                minLevel = levelAvg + 1;
            }
        }

        return result;
    }

    public static long CalTotalTime(int level, int[] diffs, int[] times, long limit)
    {
        long totalTime = 0;

        for (var i = 0; i < diffs.Length; ++i)
        {
            if (totalTime > limit)
            {
                return totalTime;
            }

            if (diffs[i] <= level)
            {
                totalTime += times[i];
                continue;
            }

            var count = diffs[i] - level;
            totalTime += (times[i] + times[i - 1]) * count + times[i];
        }

        return totalTime;
    }
}