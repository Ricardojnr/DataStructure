using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class AVLTree
    {
        AVLNode root = null;
        private class AVLNode
        {
            public int value = 0;
            public AVLNode RightChild = null;
            public AVLNode LeftChild = null;
            public int height = 0;
            public AVLNode(int value)
            {
                this.value = value;
            }
        }

        public void Insert(int value)
        {
            root = Insert(root, value);
        }
        private AVLNode Insert(AVLNode root, int Value)
        {
            if (root == null)
                return new AVLNode(Value);

            if (Value > root.value)
                root.RightChild = Insert(root.RightChild, Value);
            else
                root.LeftChild = Insert(root.LeftChild, Value);

            SetHeight(root);

            return Balance(root);

        }
        private AVLNode Balance(AVLNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (BalanceFactor(root.LeftChild) < 0)
                    root.LeftChild =  RotateLeft(root.LeftChild);

                return RotateRight(root);
            }
            else if (IsRightHeavy(root))
            {
                if (BalanceFactor(root.RightChild) > 0)
                    root.RightChild = RotateRight(root.RightChild);

                return  RotateLeft(root);
            }
            return root;
        }

        private AVLNode RotateRight(AVLNode node)
        {
            var newRoot = node.LeftChild;
            node.LeftChild = newRoot.RightChild;
            newRoot.RightChild = node;
            
            SetHeight(node);
            SetHeight(newRoot);

            return newRoot;
        }
        private AVLNode RotateLeft(AVLNode node)
        {
            var newRoot = node.RightChild;
            node.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = node;

            SetHeight(node);
            SetHeight(newRoot);

            return newRoot;
        }

        public bool IsBalanced() =>
            IsBalanced(root);
        
        private bool IsBalanced(AVLNode node)
        {
            if (node == null)
                return true;

            var balanceFactor = Height(node.LeftChild) - Height(node.RightChild);
            return Math.Abs(balanceFactor) <= 1 && IsBalanced(node.RightChild) && IsBalanced(node.LeftChild);

        }

        private void SetHeight(AVLNode node)
        {
            node.height =  Math.Max(Height(root.LeftChild), Height(root.RightChild)) + 1;
        }

        private bool IsLeftHeavy(AVLNode node) =>
            BalanceFactor(node) > 1;

        private bool IsRightHeavy(AVLNode node) =>
            BalanceFactor(node) < -1;

        private int BalanceFactor(AVLNode node) =>
            (node == null) ? 0 : Height(node.LeftChild) - Height(node.RightChild);

        private int Height(AVLNode node)
        {
            if (node == null)
                return -1;

            return node.height;
        }
    }
}
