using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class MinHeap
    {
        private Node[] _nodes = new Node[10];
        private int _size;
        public class Node
        {
            public int Key;
            public string Value;

            public Node(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        public void Add(int priority, string value)
        {
            if (IsFull())
                throw new ArgumentNullException();

            _nodes[_size++] = new Node(priority, value);

            BubbleUp();
        }
        public int Remove()
        {
            if (IsEmpty())
                throw new Exception();
            var root = _nodes[0].Key;
            
            _nodes[0] = _nodes[--_size];
            BubbleDown();

            return root;
        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= _size && !IsValidParent(index))
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

            return (LeftChild(index).Key < RightChild(index).Key) ?
                LeftChildIndex(index) :
                RightChildIndex(index);

        }
        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = _nodes[index].Key <= LeftChild(index).Key;

            if (HasRightChild(index))
                isValid &= _nodes[index].Key <= RightChild(index).Key;

            return isValid;
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= _size;
        }
        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= _size;
        }

        private void BubbleUp()
        {
            var index = _size - 1;
            
            while (index > 0 && _nodes[index].Key < _nodes[Parent(index)].Key)
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }
        private void Swap(int first, int second)
        {
            var temp = _nodes[first];
            _nodes[first] = _nodes[second];
            _nodes[second] = temp;
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }
        private Node LeftChild(int index)
        {
            return _nodes[LeftChildIndex(index)];
        }
        private Node RightChild(int index)
        {
            return _nodes[RightChildIndex(index)];
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
            return _size == 0;
        }
        private bool IsFull()
        {
            return _size == _nodes.Length;
        }
    }
}
