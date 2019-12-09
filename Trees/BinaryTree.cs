using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class BinaryTree
    {
        private Node root = null;
        private class Node
        {
            public int value = 0;
            public Node leftChild = null;
            public Node rightChild = null;

            public Node(int value)
            {
                this.value = value;
            }
        }

        public BinaryTree()
        {

        }
        public void Insert(int value)
        {

            Node node = new Node(value);
            if (root == null)
                root = node;
            else
            {
                var current = root;

                while (true)
                {
                    if (value < current.value)
                    {
                        if (current.leftChild == null)
                        {
                            current.leftChild = node;
                            break;
                        }
                        current = current.leftChild;
                    }
                    else
                    {
                        if (current.rightChild == null)
                        {
                            current.rightChild = node;
                            break;
                        }
                        current = current.rightChild;
                    }
                }
            }
        }

        public bool Find(int value)
        {
            var current = root;
            while (current != null)
            {
                if (value < current.value)
                    current = current.leftChild;
                else
                if (value > current.value)
                    current = current.rightChild;
                else
                    return true;
            }
            return false;
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(root);
        }
        public void TraverseInOrder()
        {
            TraverseInOrder(root);
        }
        public void TraversePostOrder()
        {
            TraversePostOrder(root);
        }
        public int Min()
        {
            return Min(root);
        }
        public int Height()
        {
            return Height(root);
        }
        public int MinLeftMost()
        {
            if (root == null)
                throw new Exception();

            var current = root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.leftChild;

            }
            return last.value;
        }
        public bool equalsX(BinaryTree Tree)
        {
            return CheckEquals(Tree.root, root);
        }
        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(root, int.MinValue, int.MaxValue);
        }
        public void DistanceTree(int Distance)
        {
            DistanceTree(Distance, root);
        }
       
        private void DistanceTree(int Distance, Node Node)
        {
            if (Node == null)
                return;

            if (Distance == 0)
                Console.WriteLine(Node.value);

            DistanceTree(Distance - 1, Node.leftChild);
            DistanceTree(Distance - 1, Node.rightChild);

        }

        private bool IsBinarySearchTree(Node Node, int Min, int Max)
        {
            if (Node == null)
                return true;

            if (Node.value < Min || Node.value > Max)
                return false;

            return IsBinarySearchTree(Node.leftChild, Min, Node.value - 1)
                && IsBinarySearchTree(Node.rightChild, Node.value + 1, Max);
        }
        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.value);
            TraversePreOrder(root.leftChild);
            TraversePreOrder(root.rightChild);
        }
        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            TraverseInOrder(root.leftChild);
            Console.WriteLine(root.value);
            TraverseInOrder(root.rightChild);
        }
        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;

            TraversePostOrder(root.leftChild);
            TraversePostOrder(root.rightChild);
            Console.WriteLine(root.value);
        }

        public int CountLeaves()
        {
            return CountLeaves(root);
        }
        private int CountLeaves(Node Node)
        {
            if (Node == null)
                return 0;

            if (IsLeaf(Node))
                return 1;

            return CountLeaves(Node.leftChild) + CountLeaves(Node.rightChild);

        }
        public int Max()
        {
            return Max(root);
        }
        private int Max(Node Node)
        {
            if (Node == null)
                return 0;

            var left = Max(Node.leftChild);
            var right = Max(Node.rightChild);

            return Math.Max(Math.Max(left, right), Node.value);
        }

        public bool Contains(int value)
        {
            return Contains(root, value);
        }
        private bool Contains(Node Node, int value)
        {
            if (Node == null)
                return false;

            if (Node.value == value)
                return true;

            if (value > Node.value)
                return Contains(Node.rightChild, value);
            else if (value < Node.value)
                return Contains(Node.leftChild, value);

            return false;
        }
        public bool AreSibling(int first, int second)
        {
            return AreSibling(root, first, second);
        }
        private bool AreSibling(Node root, int first, int second)
        {
            if (root == null)
                return false;

            var areSibling = false;
            
            if(root.leftChild != null && root.rightChild != null)
            {
                areSibling = (root.leftChild.value == first && root.rightChild.value == second) ||
                    (root.rightChild.value == first && root.leftChild.value == second);
            }

            return areSibling || AreSibling(root.leftChild, first, second) || AreSibling(root.rightChild, first, second);
        }
        public List<int> getAncestors(int value)
        {
            var list = new List<int>();
            getAncestors(root, list,  value);
            return list;
        }
        private bool getAncestors(Node root, List<int> list, int value)
        {
            if (root == null)
                return false;

            if (root.value == value)
                return true;

            if (getAncestors(root.leftChild, list, value) || getAncestors(root.rightChild, list, value))
            {
                list.Add(root.value);
                return true;
            }

            return false;
        }

        public int Size()
        {
            return Size(root);
        }


        private int Size(Node Node)
        {
            if (Node == null)
                return 0;
            if (IsLeaf(Node))
                return 1;

            return 1 + Size(Node.leftChild) + Size(Node.rightChild);
        }
        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(Height(root.leftChild), Height(root.rightChild));
        }
        private bool IsLeaf(Node node)
        {
            return node.leftChild == null && node.rightChild == null;
        }
        private int Min(Node root)
        {
            if (IsLeaf(root))
                return root.value;

            var left = Min(root.leftChild);
            var right = Min(root.rightChild);

            return Math.Min(Math.Min(left, right), root.value);
        }
        private bool CheckEquals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return first.value == second.value
                    && CheckEquals(first.leftChild, second.leftChild)
                    && CheckEquals(first.rightChild, second.rightChild);

            return false;
        }



    }
}