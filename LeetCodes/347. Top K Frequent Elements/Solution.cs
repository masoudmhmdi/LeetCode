namespace LeetCodes._347._Top_K_Frequent_Elements;

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        int[] ints = new int[10_000 * 2 + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            ints[nums[i] + 10_000] += 1;
        }

        int[] result = new int[k];
        for (int i = 0; i < k; i++)
        {
            int max = int.MinValue;
            int maxIndex = 0;
            for (int j = 0; j < ints.Length; j++)
            {
                if (ints[j] > max)
                {
                    maxIndex = j;
                    max = ints[j];
                }
            }

            ints[maxIndex] = int.MinValue;
            result[i] = maxIndex - 10_000;
        }

        return result;
    }
}
