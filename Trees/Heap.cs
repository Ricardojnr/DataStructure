using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Heap
    {

        int[] _items;
        int _size = 0;
        public Heap(int max)
        {
            _items = new int[max];
        }
        public void Insert(int value)
        {
            IsFull();
            
            _items[_size++] = value;
            BubbleUp();
        }
        public bool IsFull()
        {
            return _size == _items.Length;
        }
        private void BubbleUp()
        {
            var index = _size - 1;
            while (index > 0 && _items[index] > Parent(index))
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }
        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= _size;
        }
        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= _size;
        }
        private int Parent(int index)
        {
            return (index - 1) / 2;
        }
        private void Swap(int first, int second)
        {
            var temp = _items[first];
            _items[first] = _items[second];
            _items[second] = temp;
        }
        private bool IsEmpty()
        {
            return _size == _items.Length;
        }
        public int Remove()
        {
            
            if (IsEmpty())
                throw new Exception();

            var root = _items[0];
            _items[0] = _items[--_size];
            
            BubbleDown();
            
            return root;
        }
        private void BubbleDown()
        {
            
            var index = 0;
            while (index <= _size && !IsValidParent(index))
            {
                var largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);

                index = largerChildIndex;
            }
        }
        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;

            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return (LeftChild(index) > RightChild(index)) ?
                    LeftChildIndex(index) : RightChildIndex(index);
        }
        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;
            
            var isValid = _items[index] >= LeftChild(index);

            if (HasRightChild(index))
                isValid &= _items[index] >= RightChild(index);
            
            return  _items[index] >= LeftChild(index) &&
                    _items[index] >= RightChild(index);
        }
        private int LeftChild(int index)
        {
            return _items[LeftChildIndex(index)];
        }
        private int RightChild(int index)
        {
            return _items[LeftChildIndex(index)];
        }
        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }
        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }
        public bool IsMaxHeap(int[] array)
        {
            return IsMaxHeap(array, 0);
        }
        private bool IsMaxHeap(int [] array, int index)
        {
            var lastParentIndex = _items.Length / 2 - 1;
            if (index > lastParentIndex)
                return true;

            var leftChild = index * 2 + 1;
            var rightChild = index * 2 + 2;

            var isValidParent = 
                array[index] >= array[leftChild] &&
                array[index] >= array[rightChild];

            return isValidParent &&
                IsMaxHeap(array, leftChild) &&
                IsMaxHeap(array, rightChild);

        }
    }
}
