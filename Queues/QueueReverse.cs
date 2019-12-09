using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class QueueReverse
    {
        Stack<int> stck;
        public void Reverse(Queue<int> queue, int k)
        {
            stck = new Stack<int>();

            for (int i = 0; i < k; i++)
                stck.Push(queue.Dequeue());
            
            while ( stck.Count != 0 )
                queue.Enqueue(stck.Pop());
                                
            for (int i = k- queue.Count; i < queue.Count; i++)
                queue.Enqueue(queue.Dequeue());
        }        
    }
}
