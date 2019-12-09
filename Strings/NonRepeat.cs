using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataStructure
{
    public class NonRepeat
    {
        public void FindNonRepeat(string value)
        {   
            int count = 1;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (var item in value)
            {
                if (dict.ContainsKey(item))
                {
                    count = dict[item];
                    dict[item] = count + 1;
                }
                else
                {
                    count = 1;
                    dict.Add(item, count);
                }
            }
        }
        public char FindRepeat(string value)
        {
            HashSet<char> dict = new HashSet<char>();

            foreach (var item in value)
            {
                if (dict.Contains(item))
                    return item;  
                
                dict.Add(item);
            }

            return char.MinValue;
        }
    }
}
