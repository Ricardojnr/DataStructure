using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class MinHeap
    {
        private Node[] nodes = new Node[10];
        private int size;
        public class Node
        {
            public int key;
            public string value;

            public Node(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public void Add(int priority, string value)
        {
            if (IsFull())
                throw new ArgumentNullException();

            nodes[size++] = new Node(priority, value);

            BubbleUp();
        }
        public int Remove()
        {
            if (IsEmpty())
                throw new Exception();
            var root = nodes[0].key;
            
            nodes[0] = nodes[--size];
            BubbleDown();

            return root;
        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= size && !IsValidParent(index))
            {
                var smallerChildIndex = SmallerChildIndex(index);
                Swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }
        private int SmallerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;
            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return (LeftChild(index).key < RightChild(index).key) ?
                LeftChildIndex(index) :
                RightChildIndex(index);

        }
        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = nodes[index].key <= LeftChild(index).key;

            if (HasRightChild(index))
                isValid &= nodes[index].key <= RightChild(index).key;

            return isValid;
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= size;
        }
        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= size;
        }

        private void BubbleUp()
        {
            var index = size - 1;
            
            while (index > 0 && nodes[index].key < nodes[Parent(index)].key)
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }
        private void Swap(int first, int second)
        {
            var temp = nodes[first];
            nodes[first] = nodes[second];
            nodes[second] = temp;
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }
        private Node LeftChild(int index)
        {
            return nodes[LeftChildIndex(index)];
        }
        private Node RightChild(int index)
        {
            return nodes[RightChildIndex(index)];
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }
        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
        private bool IsFull()
        {
            return size == nodes.Length;
        }
    }
}
