using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class MostRepeated
    {
        public int MostFrequent(int[] array)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int count = 0;
            foreach (var item in array)
            {
                if (dict.ContainsKey(item))
                    dict[item] = count += 1;
                else
                {
                    count = 1;
                    dict.Add(item, count);
                };
            }

            int maxValue = 0;
            foreach (var item in dict)
            {
                if (item.Value > maxValue)
                    maxValue = item.Value;
            }
            return maxValue;
        }

        public int CountPair(int[] array, int difference)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var number in array)
            {
                set.Add(number);
            }

            var count = 0;
            foreach (var number in array)
            {
                if (set.Contains(number + difference))
                    count++;
                if (set.Contains(number - difference))
                    count++;
                set.Remove(number);
            }

            return count;
        }


        public int[] TwoSum(int[] numbers, int target )
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int complement = target - numbers[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i  };
                }
                map.Add(numbers[i], i);
            }

            // Time complexity of this method is O(n) because we need to iterate
            // the array only once.

            return null;
        }
    }
}



