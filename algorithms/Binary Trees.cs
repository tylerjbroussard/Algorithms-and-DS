using System;
using System.Linq;
using System.Collections.Generic;

class BinarySearchTree
{
    public Node root = null;
    int counter = 0;
    bool finalNote = false;


    public class Node
    {
        public int Value { get; set; }

        public Node LeftChild, RightChild = null;

        public Node(int listValue)
        {
            Value = listValue;
        }
    }


    public int ComputeTree(Node nodeRoot)
    {
        if (nodeRoot == null)
        {
            return counter--;
        }
        if (nodeRoot.LeftChild != null)
        {
            ComputeTree(nodeRoot.LeftChild);

            return counter++;
        }
        if (nodeRoot.RightChild != null)
        {
            ComputeTree(nodeRoot.RightChild);

            return counter++;
        }

        return counter++;
    }

    public Node GrowTree(Node root, int growValue)
    {
        if (root == null)
        {
            root = new Node(growValue);
        }
        else if (growValue < root.Value)
        {
            root.LeftChild = GrowTree(root.LeftChild, growValue);
        }
        else
        {
            root.RightChild = GrowTree(root.RightChild, growValue);
        }
        return root;
    }

    // 1) Write a function that takes in a list of integers, creates a binary tree with those integers
    public BinarySearchTree(List<int> values)
    {
        foreach (var x in values)
        {
            root = GrowTree(root, x);
        }
    }

    // 2) Write a function that returns the in-order traversal of the tree as space-separated string.
    public string InOrder(Node nodeRoot)
    {
        if (nodeRoot.LeftChild != null & nodeRoot.RightChild != null)
        {
            return InOrder(nodeRoot.LeftChild) + nodeRoot.Value.ToString() + " " + InOrder(nodeRoot.RightChild);
        }
        if (nodeRoot.LeftChild != null)
        {
            return InOrder(nodeRoot.LeftChild) + nodeRoot.Value.ToString() + " ";
        }
        if (nodeRoot.RightChild != null)
        {
            return nodeRoot.Value.ToString() + " " + InOrder(nodeRoot.RightChild);
        }
        return nodeRoot.Value.ToString() + " ";
    }

    // 3) Write a function that returns the pre-order traversal of the tree as space-separated string.
    public string PreOrder(Node nodeRoot)
    {
        if (nodeRoot.LeftChild != null & nodeRoot.RightChild != null)
        {
            return nodeRoot.Value.ToString() + " " + PreOrder(nodeRoot.LeftChild) + PreOrder(nodeRoot.RightChild);
        }
        if (nodeRoot.LeftChild != null)
        {
            return nodeRoot.Value.ToString() + " " + PreOrder(nodeRoot.LeftChild);
        }
        if (nodeRoot.RightChild != null)
        {
            return nodeRoot.Value.ToString() + " " + PreOrder(nodeRoot.RightChild);
        }
        return nodeRoot.Value.ToString() + " ";
    }

    // 4) Write a function that returns the post-order traversal of the tree as space-separated string.
    public string PostOrder(Node nodeRoot)
    {
        if (nodeRoot.LeftChild != null & nodeRoot.RightChild != null)
        {
            return PostOrder(nodeRoot.LeftChild) + PostOrder(nodeRoot.RightChild) + nodeRoot.Value.ToString() + " ";
        }
        if (nodeRoot.LeftChild != null)
        {
            return PostOrder(nodeRoot.LeftChild) + nodeRoot.Value.ToString() + " ";
        }
        if (nodeRoot.RightChild != null)
        {
            return PostOrder(nodeRoot.RightChild) + nodeRoot.Value.ToString() + " ";
        }
        return nodeRoot.Value.ToString() + " ";
    }

    // 5) Write a function that determines the height of a given tree.
    public int Height => ComputeTree(root);

    // 6) Write a function that returns the sum of all values in a tree.
    public int Sum(Node nodeRoot)
    {
        {
            if (nodeRoot.LeftChild != null & nodeRoot.RightChild != null)
            {
                return Sum(nodeRoot.LeftChild) + nodeRoot.Value + +Sum(nodeRoot.RightChild);
            }
            if (nodeRoot.LeftChild != null)
            {
                return Sum(nodeRoot.LeftChild) + nodeRoot.Value;
            }
            if (nodeRoot.RightChild != null)
            {
                return nodeRoot.Value + Sum(nodeRoot.RightChild);
            }
            return nodeRoot.Value;
        }
    }

    // 7) Write a function that returns a bool indicating that a value exists (or not) in a given tree.
    public bool Contains(Node root, int value)
    {
        if (value.ToString() == root.Value.ToString())
        {
            finalNote = true;
            return finalNote;
        }
        if (value < root.Value)
        {
            Contains(root.LeftChild, value);
        }
        if (value > root.Value)
        {
            Contains(root.RightChild, value);
        }
        return finalNote;

    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        var mode = Console.ReadLine();
        var input = Console.ReadLine();
        var values = input.Split(new[] { ' ' }).Select(Int32.Parse).ToList();
        var tree = new BinarySearchTree(values);
        switch (mode)
        {
            case "in_order":
                Console.WriteLine(tree.InOrder(tree.root));
                break;
            case "pre_order":
                Console.WriteLine(tree.PreOrder(tree.root));
                break;
            case "post_order":
                Console.WriteLine(tree.PostOrder(tree.root));
                break;
            case "height":
                Console.WriteLine(tree.Height);
                break;
            case "sum":
                Console.WriteLine(tree.Sum(tree.root));
                break;
            case "contains":
                int value = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(tree.Contains(tree.root, value));
                break;
        }
    }
}