using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class OneToOneCaracter
    {
        HashSet<char> hash = new HashSet<char>();
        HashSet<char> hash2 = new HashSet<char>();
        public bool CheckCaracter(string s1, string s2)
        {
            foreach (var item in s1)
            {
                if (!hash.Contains(item))
                    hash.Add(item);
            }

            foreach (var item in s2)
            {
                if (!hash2.Contains(item))
                    hash2.Add(item);
            }

            if (hash.Count != hash2.Count)
                return false;

            return true;
        }
    }
}
