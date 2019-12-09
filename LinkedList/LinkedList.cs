using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class LinkedList
    {
        private Node First{ get; set; }
        private Node Last { get; set; }
        int _size = 0; 

        private class Node
        {
            public int value;
            public Node next { get; set; }
            

            public Node(int item)
            {
                value = item;
            }
            public Node()
            {

            }
        }

        public void AddFirst(int item)
        {
            Node node = new Node(item);
            if (First == null)
                First = Last = node;
            else
                node.next = First;

            First = node;

            _size++;
        }
        public void AddLast(int item)
        {
            Node node = new Node(item);

            if (First == null)
                First = Last = node;
            else
            {
                Last.next = node;
                Last = node;
            }
            _size++;
        }

        public void DeleteFirst()
        {
            if (First == null)
                return;

            First = First.next;

            _size--;
        }

        public void DeleteLast()
        {
            if (Last == null)
                return;

            Node node = First;
            while (node != null)
            {
                if (node.next == Last)
                {
                    Last = node;
                    node.next = null;
                }
                node = node.next;
                
            }

            _size--;
        }
        public bool Contains(int value)
        {
            Node node = First;
            while (node != null)
            {
                if (node.value == value)
                    return true;

                node = node.next;
            }

            return false;
        }

        public int IndexOf(int value)
        {
            Node node = First;

            int i = 0;
            while (node != null)
            {
                if (node.value == value)
                    return i;
                i++;
                node = node.next;
            }
            return -1;
        }

        public int Size()
        {
            return _size;
        }
        public int[] ToArray()
        {
            Node node = First;
            int[] array = new int[_size];

            int i = -1;
            while (node != null)
            {
                i++;
                array[i] = node.value;
                node = node.next;
            }

            return array;
        }

        public int PrintMiddle()
        {
            Node MiddleNode = First;
            Node Node = First;

            while (Node != Last && Node.next != Last)
            {
                Node = Node.next.next;
                MiddleNode = MiddleNode.next;
            }


            if (Node == Last)
                    return MiddleNode.value;
                else
                   return  MiddleNode.next.value;

        }
        
        public bool HasLoop()
        {
            Last.next = First;
            Node FastNode = First;
            Node SlowNode = First;

            while (SlowNode != null && FastNode.next.next != null)
            {
                FastNode = FastNode.next.next;
                SlowNode = SlowNode.next;
                if (SlowNode == FastNode)
                    return true;
            }
            return false;
        }
      

    }
}
