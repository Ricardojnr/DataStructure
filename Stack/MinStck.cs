using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class MinStck
    {
        public int min;
        public int value;
        public MinStck(int min, int value)
        {
            this.value = value;
            this.min = min;
        }
    }

    public class Stck: Stack<MinStck>
    {
        public void Push(int item)
        {
            int newValue = Math.Min(item, Min());
            base.Push(new MinStck(newValue, item));
        }

        public int Min()
        {
            if (this.Count == 0)
                return int.MaxValue;
            else
               return Peek().min;

        }
    }
}
