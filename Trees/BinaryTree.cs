using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class BinaryTree
    {
        private Node _root = null;
        private class Node
        {
            public int Value { get; private set; }
            public Node LeftChild { get; set; } = null;
            public Node RightChild { get; set; } = null;

            public Node(int value)
            {
                Value = value;
            }
        }
        public void Insert(int value)
        {
            _root = Insert(_root, value);
        }
        private Node Insert(Node root, int Value)
        {
            if (root == null)
                return new Node(Value);

            if (Value > root.Value)
                root.RightChild = Insert(root.RightChild, Value);
            else
                root.LeftChild = Insert(root.LeftChild, Value);

            return root;

        }
        public bool Find(int value)
        {
            var current = _root;
            while (current != null)
            {
                if (value < current.Value)
                    current = current.LeftChild;
                else
                if (value > current.Value)
                    current = current.RightChild;
                else
                    return true;
            }
            return false;
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(_root);
        }
        public void TraverseInOrder()
        {
            TraverseInOrder(_root);
        }
        public void TraversePostOrder()
        {
            TraversePostOrder(_root);
        }
        public int Min()
        {
            return Min(_root);
        }
        public int Height()
        {
            return Height(_root);
        }
        public int MinLeftMost()
        {
            if (_root == null)
                throw new Exception();

            var current = _root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.LeftChild;

            }
            return last.Value;
        }
        public bool Equals(BinaryTree Tree)
        {
            return CheckEquals(Tree._root, _root);
        }
        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(_root, int.MinValue, int.MaxValue);
        }
        public void DistanceTree(int Distance)
        {
            DistanceTree(Distance, _root);
        }

        private void DistanceTree(int Distance, Node Node)
        {
            if (Node == null)
                return;

            if (Distance == 0)
                Console.WriteLine(Node.Value);

            DistanceTree(Distance - 1, Node.LeftChild);
            DistanceTree(Distance - 1, Node.RightChild);

        }

        private bool IsBinarySearchTree(Node Node, int Min, int Max)
        {
            if (Node == null)
                return true;

            if (Node.Value < Min || Node.Value > Max)
                return false;

            return IsBinarySearchTree(Node.LeftChild, Min, Node.Value - 1)
                && IsBinarySearchTree(Node.RightChild, Node.Value + 1, Max);
        }
        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.Value);
            TraversePreOrder(root.LeftChild);
            TraversePreOrder(root.RightChild);
        }

        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            TraverseInOrder(root.LeftChild);
            Console.WriteLine(root.Value);
            TraverseInOrder(root.RightChild);
        }
        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;

            TraversePostOrder(root.LeftChild);
            TraversePostOrder(root.RightChild);
            Console.WriteLine(root.Value);
        }
        public void TraverseLevelOrder()
        {
            for (int i = 0; i < Height(); i++)
            {
                foreach (var value in GetNodesAtDistance(i))
                    Console.WriteLine(value);
            }
        }
        
        public List<int> GetNodesAtDistance(int distance)
        {
            var list = new List<int>();
            GetNodesAtDistance(_root, distance, list);
            return list;
        }
        private void GetNodesAtDistance(Node root, int distance, List<int> list)
        {
            if (root == null)
                return;
            if (distance == 0)
                list.Add(root.Value);

            GetNodesAtDistance(root.LeftChild, distance - 1, list);
            GetNodesAtDistance(root.RightChild, distance - 1, list);
        }

        public int CountLeaves()
        {
            return CountLeaves(_root);
        }
        private int CountLeaves(Node Node)
        {
            if (Node == null)
                return 0;

            if (IsLeaf(Node))
                return 1;

            return CountLeaves(Node.LeftChild) + CountLeaves(Node.RightChild);

        }
        public int Max()
        {
            return Max(_root);
        }
        private int Max(Node Node)
        {
            if (Node == null)
                return 0;

            var left = Max(Node.LeftChild);
            var right = Max(Node.RightChild);

            return Math.Max(Math.Max(left, right), Node.Value);
        }

        public bool Contains(int value)
        {
            return Contains(_root, value);
        }
        private bool Contains(Node Node, int value)
        {
            if (Node == null)
                return false;

            if (Node.Value == value)
                return true;

            if (value > Node.Value)
                return Contains(Node.RightChild, value);
            else if (value < Node.Value)
                return Contains(Node.LeftChild, value);

            return false;
        }
        public bool AreSibling(int first, int second)
        {
            return AreSibling(_root, first, second);
        }
        private bool AreSibling(Node root, int first, int second)
        {
            if (root == null)
                return false;

            var areSibling = false;

            if (root.LeftChild != null && root.RightChild != null)
            {
                areSibling = (root.LeftChild.Value == first && root.RightChild.Value == second) ||
                    (root.RightChild.Value == first && root.LeftChild.Value == second);
            }

            return areSibling || AreSibling(root.LeftChild, first, second) || AreSibling(root.RightChild, first, second);
        }
        public List<int> GetAncestors(int value)
        {
            var list = new List<int>();
            GetAncestors(_root, list, value);
            return list;
        }
        private bool GetAncestors(Node root, List<int> list, int value)
        {
            if (root == null)
                return false;

            if (root.Value == value)
                return true;

            if (GetAncestors(root.LeftChild, list, value) || GetAncestors(root.RightChild, list, value))
            {
                list.Add(root.Value);
                return true;
            }

            return false;
        }

        public int Size()
        {
            return Size(_root);
        }


        private int Size(Node Node)
        {
            if (Node == null)
                return 0;
            if (IsLeaf(Node))
                return 1;

            return 1 + Size(Node.LeftChild) + Size(Node.RightChild);
        }
        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(Height(root.LeftChild), Height(root.RightChild));
        }
        private bool IsLeaf(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }
        private int Min(Node root)
        {
            if (IsLeaf(root))
                return root.Value;

            var left = Min(root.LeftChild);
            var right = Min(root.RightChild);

            return Math.Min(Math.Min(left, right), root.Value);
        }
        private bool CheckEquals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return first.Value == second.Value
                    && CheckEquals(first.LeftChild, second.LeftChild)
                    && CheckEquals(first.RightChild, second.RightChild);

            return false;
        }



    }
}