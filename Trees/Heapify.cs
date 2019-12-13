using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Heapify
    {
        public static void Heapy(int[] array)
        {
            Convert.ToDouble(9 / 2);

            var lastParentIndex = array.Length / 2 - 1;
            for (int i = lastParentIndex; i>=0; i--)
                Heapy(array, i);
        }
        private static void Heapy(int[] array, int index)
        {
            var largerIndex = index;
            var leftIndex = LeftChild(index);
            if (leftIndex < array.Length && array[leftIndex] > array[largerIndex])
                largerIndex = leftIndex;

            var rightIndex = RightChild(index);
            if (rightIndex < array.Length && array[rightIndex] > array[largerIndex])
                largerIndex = rightIndex;

            if (index == largerIndex)
                return;

            Swap(array, index, largerIndex);
            Heapy(array, largerIndex);
        }
        private static void Swap(int[] array, int first, int second)
        {
            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
        private static int LeftChild(int index) =>
            index * 2 + 1;
        private static int RightChild(int index) =>
            index * 2 + 2;

       
    }
}
