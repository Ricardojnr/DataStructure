using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Compiler
    {
        public bool CheckValue(string value)
        {
            Stack<char> stck = new Stack<char>();

            foreach (var item in value)
            {
                if (item == '(')
                    stck.Push(item);
                else
                if (item == ')')
                    stck.Pop();

            }

            if (stck.Count > 0)
                return false;

            return true;
        }
    }
}
