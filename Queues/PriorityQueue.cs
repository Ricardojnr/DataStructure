using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class PriorityQueue
    {
        int[] array;
        int index =-1;
        public PriorityQueue(int value)
        {
            array = new int[value];
        }

        public void Insert(int item)
        {
            if (index == array.Length)
                throw new Exception();

            int i;
            for (i = index; i >= 0; i--)
            {
                if (array[i] > item)
                    array[i + 1] = array[i];
                else
                    break;
            }
            array[i + 1] = item;
            index++;
        }
    }
}

