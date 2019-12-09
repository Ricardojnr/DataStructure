using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class QueueStack
    {
        Stack<int> Stack1;
        Stack<int> Stack2;

        public QueueStack(int Value)
        {
            Stack1 = new Stack<int>(Value);
            Stack2 = new Stack<int>(Value);
        }

        public void Enqueue(int item)
        {
            Stack1.Push(item);
        }

        public int Dequeue()
        {
            if (Stack2.Count == 0)
                while (Stack1.Count !=0)
                    Stack2.Push(Stack1.Pop());

            return Stack2.Pop();

        }
    }
}
