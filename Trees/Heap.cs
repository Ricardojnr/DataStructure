using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Heap
    {

        int[] items;
        int size = 0;
        public Heap(int max)
        {
            items = new int[max];
        }
        public void Insert(int value)
        {
            IsFull();
            
            items[size++] = value;
            BubbleUp();
        }
        public bool IsFull()
        {
            return size == items.Length;
        }
        private void BubbleUp()
        {
            var index = size - 1;
            while (index > 0 && items[index] > Parent(index))
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }
        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= size;
        }
        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= size;
        }
        private int Parent(int index)
        {
            return (index - 1) / 2;
        }
        private void Swap(int first, int second)
        {
            var temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }
        private bool IsEmpty()
        {
            return size == items.Length;
        }
        public int Remove()
        {
            
            if (IsEmpty())
                throw new Exception();

            var root = items[0];
            items[0] = items[--size];
            
            BubbleDown();
            
            return root;
        }
        private void BubbleDown()
        {
            
            var index = 0;
            while (index <= size && !IsValidParent(index))
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
            
            var isValid = items[index] >= LeftChild(index);

            if (HasRightChild(index))
                isValid &= items[index] >= RightChild(index);
            
            return  items[index] >= LeftChild(index) &&
                    items[index] >= RightChild(index);
        }
        private int LeftChild(int index)
        {
            return items[LeftChildIndex(index)];
        }
        private int RightChild(int index)
        {
            return items[LeftChildIndex(index)];
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
            var lastParentIndex = items.Length / 2 - 1;
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
