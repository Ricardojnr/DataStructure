using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class ArrayQueue
    {

        int[] Queue;
        int Rear = -1;
        int Front = -1;
        int count = 0;
        int max = 0;
        public ArrayQueue(int total )
        {
            max = total;
            Queue = new int[total];
        }
        public void Enqueue(int item)
        {
            Rear = (Rear + 1) % Queue.Length;
            count++;
            Queue[Rear] = item;

        }
        public int Dequeue()
        {
            Front = (Front + 1) % Queue.Length;
            count--;
            var item = Queue[Front];
            Queue[Front] = 0;
            return item;
        }
        public override string ToString()
        {
            return string.Join(",", Queue);
        }
        public int Peek()
        {
            return Queue[Front];
        }

        public bool IsEmpty()
        {
            if (count == 0)
                return false;
            return true;
        }
        public bool IsFull()
        {
            if (count == max)
                return true;

            return false;
        }

    }
}
