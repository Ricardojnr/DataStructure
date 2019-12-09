using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{

    public class ClassArrayMin : Stack<int>
    {
        Stack<int> s2;
        public ClassArrayMin()
        {
            s2 = new Stack<int>();
        }
        public new void Push(int value)
        {
            if (value <= Min())
                s2.Push(value);

            base.Push(value);
        }

        public new int Pop()
        {
            int value = base.Pop();
            if (value == Min())
            {
                s2.Pop();
            }
            return value;
        }
        public int Min()
        {
            if (s2.Count == 0)
                return int.MaxValue;
            else
                return s2.Peek();
        }
    }

}
