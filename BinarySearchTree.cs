using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7BinarySearchTree
{
    internal class BinarySearchTree
    {
        public TreeNode root;

        public BinarySearchTree(int value)
        {
            root = new TreeNode(value);
        }

        public void AddIterative(int value)
        {
            TreeNode current = root;
            bool loop = true;
            while (loop)
            {
                if (value == current.Value)
                {
                    throw new Exception("Cannot add duplicate key");
                }
                else if (value < current.Value)
                {
                    if (current.Left == null)
                    {
                        current.Left = new TreeNode(value);
                        loop = false;
                    }
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new TreeNode(value);
                        loop = false;
                    }
                    current = current.Right;
                }
            }
        }

        public void AddRecursive(int value)
        {
            if (value == root.Value)
            {
                throw new Exception("Cannot add duplicate key");
            }
            AddRecursiveHelper(root, value);
        }

        private void AddRecursiveHelper(TreeNode current, int value)
        {
            if (value < current.Value)
            {
                if (current.Left == null)
                {
                    current.Left = new TreeNode(value);
                    return;
                }
                AddRecursiveHelper(current.Left, value);
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new TreeNode(value);
                    return;
                    
                }
                AddRecursiveHelper(current.Right, value);
            }

        }

        public void DeleteIterative(int value)
        {
            TreeNode current = root;
            TreeNode prev = current;

            while (current != null && current.Value != value)
            {
                if (value < current.Value)
                {
                    prev = current;
                    current = current.Left;
                }
                else
                {
                    prev = current;
                    current = current.Right;
                }
            }
            if (current != null)
            {
                throw new Exception("Value does not exist");
            }

            
        }

        public void DeleteRecursive(int value)
        {

        }

        private void DeleteRecursiveHelper(TreeNode current, int value)
        {

        }

        public bool SearchIterative(int value)
        {
            TreeNode current = root;

            while (current != null && current.Value != value)
            {
                if (value < current.Value)
                {
                    current = current.Left;
                }
                else
                { 
                    current = current.Right;
                }
            }
            if (current == null)
                return false;
            return true;
        }

        public bool SearchRecursive(int value)
        {
            return SearchRecursiveHelper(root, value);
        }

        private bool SearchRecursiveHelper(TreeNode current, int value)
        {
            if (current == null)
            {
                return false;
            }
            if (value == current.Value)
            {
                return true;
            }
            else if (value < current.Value)
            { 
                return SearchRecursiveHelper(current.Left, value);
            }
            else
            {
                return SearchRecursiveHelper(current.Right, value);
            }


        }
    }
}
