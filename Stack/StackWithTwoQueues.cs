using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{

    public class StackWithTwoQueues
    {
        Queue<int> queue1;
        Queue<int> queue2;

        public StackWithTwoQueues(int size)
        {
            queue1 = new Queue<int>(size);
            queue2 = new Queue<int>(size);
        }

        public void Push(int item)
        {
            queue1.Enqueue(item);
        }

        public int Pop()
        {
            while (queue1.Count > 1)
                queue2.Enqueue(queue1.Dequeue());

            SwapQueues();

            return queue2.Dequeue();
        }

        private void SwapQueues()
        {
            var temp = queue1;
            queue1 = queue2;
            queue2 = temp;
        }

    }
}
