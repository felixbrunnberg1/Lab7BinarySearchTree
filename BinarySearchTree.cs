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
    public class BinarySearchTree
    {
        public TreeNode root;

        public BinarySearchTree()
        {
            root = null;
        }

        public void AddIterative(int value)
        {
            TreeNode current = root;
            bool loop = true;

            if (root == null)
            {
                root = new TreeNode(value);
                return;
            }
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
            if (root == null)
            {
                root = new TreeNode(value);
                return;
            }
            AddRecursiveHelper(root, value);
        }

        private void AddRecursiveHelper(TreeNode current, int value)
        {
            if (current.Value == value)
            {
                throw new Exception("Cannot add duplicate key");
            }
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
            TreeNode parent = null;
            TreeNode current = root;
            while (current != null && current.Value != value)
            {
                parent = current;
                if (value < current.Value)
                    current = current.Left;
                else
                    current = current.Right;
            }
            if (current == null)
            {
                throw new Exception("Value does not exist in the tree");
            }

            //node has no children
            if (current.Left == null && current.Right == null)
            {
                if (parent == null)
                    root = null;
                else if (parent.Left == current)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
            // node has one child
            else if (current.Left == null || current.Right == null)
            {
                TreeNode child = current.Left ?? current.Right;
                if (parent == null)
                    root = child;
                else if (parent.Left == current)
                    parent.Left = child;
                else
                    parent.Right = child;
            }
            // node has 2 children
            else
            {
                // find successor and its parent
                TreeNode successorParent = current;
                TreeNode successor = current.Right;
                while (successor.Left != null)
                {
                    successorParent = successor;
                    successor = successor.Left;
                }
                current.Value = successor.Value;
                //remove successor
                if (successorParent.Left == successor)
                    successorParent.Left = successor.Right;
                else
                    successorParent.Right = successor.Right;
            }
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
            
            return next;
        }
    }
}
