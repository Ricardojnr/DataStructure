using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class ClassArray
    {
        public int[] itens;
        int count;
        
        public ClassArray(int length)
        {
            itens  = new int[length];
        }

        public void Insert(int item)
        {
            if(count == itens.Length-1)
            {
                int[] newItens = new int[count * 2];

                for (int i = 0; i < itens.Length; i++)
                {
                    newItens[i] = itens[i];
                }
                itens = newItens;
            }

            itens[count++] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                return;

            for (int i = index; i < count; i++)
            {
                itens[i] = itens[i + 1];
            }

            count--;
        }

        public int IndexOf(int index)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == index)
                    return i;
            }
            return -1;
        }
    }
}
