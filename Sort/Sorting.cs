using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Structure3
{
    public class Sorting
    {
        public void BubbleSort(int[] array)
        {
            bool isSorted;
            for (int i = 0; i < array.Length; i++)
            {
                isSorted = true;
                for (int j = 1; j < array.Length - i; j++)
                {
                    if (array[j] < array[j - 1])
                    {
                        Swap(array, j, j - 1);
                        isSorted = false;
                    }
                }
                if (isSorted)
                    return;
            };

        }
        private void Swap(int[] array, int index, int indexer2)
        {
            int temp = array[indexer2];
            array[indexer2] = array[index];
            array[index] = temp;
        }
        public void SelectionSort(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i; j < array.Length; j++)
                    if (array[j] < array[minIndex])
                        minIndex = j;

                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }
        public void InsertSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int current = array[i];
                var j = i - 1;
                while (j >= 0 && array[j] > current)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = current;
            }
        }
        public void MergeSort(int[] array)
        {
            if (array.Length < 2)
                return;

            int middle = array.Length / 2;
            int[] left = new int[middle];

            for (int i = 0; i < middle; i++)
                left[i] = array[i];


            int[] right = new int[array.Length - middle];
            for (int i = middle; i < array.Length; i++)
                right[i - middle] = array[i];

            MergeSort(right);
            MergeSort(left);
            Merge(left, right, array);
        }
        private void Merge(int[] left, int[] right, int[] result)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];
            }

            while (i < left.Length)
                result[k++] = left[i++];
            while (j < right.Length)
                result[k++] = right[j++];
        }
        public void QuickSort(int[] array)
        {

            QuickSort(array, 0, array.Length - 1);

        }
        private void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            var boundary = Partition(array, start, end);
            QuickSort(array, start, boundary - 1);
            QuickSort(array, boundary + 1, end);
        }
        public int Partition(int[] array, int start, int end)
        {
            int boundary = start - 1;
            int pivot = array[end];

            for (int i = start; i <= end; i++)
            {
                if (array[i] <= pivot)
                {
                    boundary++;
                    Swap(array, i, boundary);
                }

            }
            return boundary;

        }
        public void CountingSort(int[] array)
        {
            int[] tempArray = new int[GetMaxSize(array)];
            foreach (var item in array)
                tempArray[item]++;

            int current = 0;
            for (int i = 0; i < tempArray.Length; i++)
            {
                for (int j = 0; j < tempArray[i]; j++)
                {
                    array[current++] = i;
                }
            }
        }
        public int GetMaxSize(int[] array)
        {
            int max = int.MinValue;
            foreach (var item in array)
                if (item > max)
                    max = item;

            return max + 1;
        }
        public int BinarySearch(int[] array, int indice)
        {
            return BinarySearch(array, 0, array.Length - 1, indice);
        }
        private int BinarySearch(int[] array, int left, int right, int target)
        {
            if (left > right)
                return -1;

            int middle = (left + right) / 2;

            if (array[middle] == target)
                return middle;

            if (target > array[middle])
                return BinarySearch(array, middle + 1, right, target);

                return BinarySearch(array, left, middle - 1, target);

        }
    }
}
