/*
 *        stack
         * 1      <--- Top of stack
         * 2 
         * 3 
         * 4   
         * 
         * Put elements in a queue (and keep track of max element)
         * 
         * Queue:
         * 1      <--- Front of queue
         * 2
         * 3
         * 4
         * 
         * Pop elements from queue and push onto the stack (except for max element(s) )
         * 
         * stack
         * 
         * 3        <--- Top of stack
         * 2
         * 1
         * 
         * Transfer from stack to queue
         * 
         * queue
         * 3        <--- Front of queue
         * 2
         * 1
         * 
         * Final step: transfer from queue to stack
         * 
         * stack:   <--- Top of stack
         * 1
         * 2
         * 3
         */

using System;
using System.Collections.Generic;

namespace Ex1
{
    class RemoveMax_Stack_Queue
    {
        static void Main(string[] args)
        {
            Stack<int> stack1 = CreateStack();
            for (int ii = stack1.Count-1; ii > 0 ; --ii)
            {
                DoRemovingThingies(stack1);
            }
      }

        static public void DoRemovingThingies(Stack<int> stack)
        {
            if (!ValidateInput(stack))
            {
                Console.WriteLine("Empty stack");
                return;
            }
            Console.WriteLine("==================================================");
            Console.WriteLine("Stack before RemoveMax call:");
            Output(stack);

            int maxElement = RemoveMax(stack);
            Console.WriteLine("maxElement removed was " + maxElement);
            Console.WriteLine("Resultant stack:");
            Output(stack);
        }

        static public int RemoveMax(Stack<int> stack)
        {
            if (!ValidateInput(stack))
            {
                // throw exception
                return -1;          // we would throw an exception and wouldnt have to return -1.
                                    // Returning -1 is not great, because that could actually be a max element in the stack
            }

            ////////////////////////////////////////////////
            // First, find out the max value in the stack
            Queue<int> queue1 = new Queue<int>(stack.Count);        // allocate a queue. Size parameter is optional
            int maxElement = -11111; // TBD fix

            while (stack.Count > 0)
            {
                int element = stack.Pop();
                maxElement = Math.Max(maxElement, element);
                queue1.Enqueue(element);
            }

            ////////////////////////////////////////////////
            // Now we know the value of maximum element in the stack.
            // Push elements from queue to the stack (which is now empty), with the exception of elements == maxElement
            while (queue1.Count > 0)
            {
                int element = queue1.Dequeue();
                if (element != maxElement)
                {
                    stack.Push(element);
                }
            }

            ////////////////////////////////////////////////
            // Now, stack has all elements except those whose value is maxElement.
            // However, the order of elements in the stack is wrong.
            // Transfer from stack to queue.
            while (stack.Count > 0)
            {
                queue1.Enqueue(stack.Pop());
            }

            ////////////////////////////////////////////////
            // And back to the stack --- Final step
            while (queue1.Count > 0)
            {
                stack.Push(queue1.Dequeue());
            }

            return maxElement;
        }
        
        static private Stack<int> CreateStack()
        {
            Stack<int> stack = new Stack<int>();
            //7, 77, 88, 2, 97, 5, 117, 107, 61, 107, 52
            stack.Push(7);
            stack.Push(77);
            stack.Push(88);
            stack.Push(2);
            stack.Push(97);
            stack.Push(5);
            stack.Push(117);
            stack.Push(107);
            stack.Push(61);
            stack.Push(107);
            stack.Push(52);

            return stack;
        }

        static private void Output(Stack<int> stack)
        {
            Console.Write("topOfStack: ");
            foreach (var element in stack)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine(" :bottomOfStack");
        }

        static public bool ValidateInput(Stack<int> stack)
        {
            return (stack != null) && (stack.Count > 0);
        }
    }
}
