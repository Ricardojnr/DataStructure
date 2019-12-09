using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Structure_3
{
    public class BinarySearch
    {
        public int Search(int[] array, int value)
        {
            return Search(array, value, 0, array.Length - 1);
        }

        private int Search(int[] array, int value, int left, int right)
        {
            if (right < left)
                return -1;

            int middle = (left + right) / 2;

            if (array[middle] == value)
                return middle;

            if (array[middle] < value)
                return Search(array, value, left, middle - 1);

            return Search(array, value, middle + 1, right);
            
        }
    }
}
