using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class ClassQueue
    {
        List<int> list;
        int index = 0;
        public ClassQueue(int size)
        {

            list = new List<int>(size);
        }

        public void Enqueue(int item)
        {
            list.Add(item);
        }
        public int Dequeue()
        {
            int dequeue = list[index];
            list.RemoveAt(index);
            return dequeue;
            
        }
        public int Peek()
        {
            return list[index];
        }
        public int Size()
        {
            return list.Count;
        }
        public bool IsEmpty()
        {
            return list.Count > 0 ? false : true;
        }
    }
}
