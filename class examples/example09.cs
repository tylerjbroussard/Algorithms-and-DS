/*
 * Q1: Mirror image of a binary tree
 *     Write a recursive method that takes a tree node and morphs it to create a mirror image of the tree rooted at that node.
 
 * Q2: Any path has a given sum
 *     Write a recursive method that takes a tree node and an integer value, and returns :
 *      - true if there is exists a path from the passed in node to any leaf in the tree that has the sum equal to passed in value
 *      - false otherwise.
 *      
 *  Q3: Compute height function
 * */

using System;
using System.Collections.Generic;


namespace Ex1
{
    class BinaryTree
    {
        class Node
        {
            public int mValue;
            public Node mLeft;
            public Node mRight;

            public Node(int value)
            {
                mValue = value;
                mLeft = mRight = null;
            }
        };

        private static void DoTreeStuff()
        {
            DoMirrorStuff();
            DoPathHasSumStuff();
            ComputeHeightStuff();
            DoTraversalStuff();
        }

        static private void DoTraversalStuff()
        {
            Node root1 = CreateTree1();

            Console.WriteLine("Post order traversal");
            DoPostOrder(root1);
            Console.WriteLine("");
            Console.WriteLine("-----------------");
        }

        static private void DoPostOrder(Node node)
        {
            if (node == null)
                return;

            DoPostOrder(node.mLeft);
            DoPostOrder(node.mRight);
            Console.Write(node.mValue + " ");
        }

        static private void ComputeHeightStuff()
        {
            Node root1 = CreateTree1();
            int heightRootNode = TreeHeight(root1) - 1;
            Console.WriteLine("Tree height is " + heightRootNode);
        }

        static private int TreeHeight(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                int heightOfMyLeftSubTree  = TreeHeight(node.mLeft);
                int heightOfMyRightSubTree = TreeHeight(node.mRight);
                int myHeight = 1 + Math.Max(heightOfMyLeftSubTree, heightOfMyRightSubTree);

                return myHeight;

                // Can also say:
                //    return 1 + Math.Max(TreeHeight(node.mLeft), TreeHeight(node.mRight));
            }
        }

        static private void DoPathHasSumStuff()
        {
            Node root1 = CreateTree1();

            for (int ii = 1; ii < 200; ++ ii)
            {
                if (AnyPathToLeafHasSum(root1, ii))
                    Console.WriteLine("Tree has sum " + ii);
            }
        }

        static private void DoMirrorStuff()
        {
            Node root1 = CreateTree1();

            OutputTree(root1);
            Mirrorize(root1);
            OutputTree(root1);
        }

        static private bool AnyPathToLeafHasSum(Node node, int sum)
        {
            if (node == null)
                return sum == 0;

            return AnyPathToLeafHasSum(node.mLeft, sum - node.mValue) || AnyPathToLeafHasSum(node.mRight, sum - node.mValue);
        }

        static private void Mirrorize(Node node)
        {
            if (node == null)
                return;

            Node temp = node.mLeft;
            node.mLeft = node.mRight;
            node.mRight = temp;

            Mirrorize(node.mLeft);
            Mirrorize(node.mRight);
        }

        static void Main(string[] args)
        {
            DoTreeStuff();
        }

        static private void OutputTree(Node root)
        {
            if (root == null)
                return;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                Node n = q.Dequeue();
                if (n.mLeft != null)
                    q.Enqueue(n.mLeft);
                if (n.mRight != null)
                    q.Enqueue(n.mRight);

                Console.Write(n.mValue + " ");
            }
            Console.WriteLine();
        }

        private static Node CreateTree1()
        {
            Node root = new Node(10);
            root.mLeft = new Node(7);
            root.mRight = new Node(17);

            root.mLeft.mLeft = new Node(4);
            root.mLeft.mRight = new Node(55);

            root.mRight.mLeft = new Node(44);
            root.mRight.mRight = new Node(25);

            return root;
        }
    }
}
