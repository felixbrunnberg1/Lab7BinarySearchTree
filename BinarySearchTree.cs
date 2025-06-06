using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public TreeNode DeleteIterative(int value)
        {
            TreeNode current = SearchIterative(value);
            TreeNode successor = GetSuccessor(current);
            
            current.Value = successor.Value;

            TreeNode successorParent = current.Right;
            while (successorParent.Left.Value != current.Value) //find parent of the successor
            {
                successorParent = successorParent.Left;
            }
            successorParent.Left = null; // Remove the successor
            return root;
        }

        public TreeNode DeleteRecursive(int value)
        {
            return DeleteRecursiveHelper(root, value);
        }

        private TreeNode DeleteRecursiveHelper(TreeNode current, int value)
        {
            if (current == null)
            {
                return current;
            }

            if (current.Value > value)
            {
                current.Left = DeleteRecursiveHelper(current.Left, value);
            }
            else if (current.Value < value)
            {
                current.Right = DeleteRecursiveHelper(current.Right, value);
            }
            else
            {
                if (current.Left == null)
                {
                    return current.Right;
                }
                if (root.Right == null)
                {
                    return current.Left;
                }


                TreeNode successor = GetSuccessor(current);
                current.Value = successor.Value;
                current.Right = DeleteRecursiveHelper(current.Right, successor.Value);
            }
            return current;
        }

        private TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode current = node.Right;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }

        public void InorderTraversal(TreeNode current)
        {
            if (current != null)
            {
                InorderTraversal(current.Left);
                Console.Write(current.Value + " ");
                InorderTraversal(current.Right);
            }
        }

        public TreeNode SearchIterative(int value)
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
                return current;
            return current;
        }

        public TreeNode SearchRecursive(int value)
        {
            return SearchRecursiveHelper(root, value);
        }

        private TreeNode SearchRecursiveHelper(TreeNode current, int value)
        {
            if (current == null)
            {
                throw new Exception("Value does not exist");
            }
            if (value == current.Value)
            {
                return current;
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

        public TreeNode GetNextInorder(int value)
        {
            TreeNode current = root;
            TreeNode next = null;

            while (current != null)
            {
                if (value < current.Value)
                { 
                    next = current; 
                    current = current.Left; 
                }
                else
                {
                    current = current.Right; 
                }
            }
            if (next == null)
            {
                throw new Exception("No next inorder value found");
            }
            return next;
        }
    }
}
