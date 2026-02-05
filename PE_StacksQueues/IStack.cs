using System;
using System.Collections.Generic;
using System.Text;

namespace PE_StacksQueues
{
    internal interface IStack<T>
    {
        // Gets the current count of items in the stack
        int Count { get; }

        // Gets whether or not there are items in the stack
        bool IsEmpty { get; }

        // Return the top-most element of the stack.
        // Throws an exception if the stack is empty.
        T Peek();

        // Adds new data to the top of the stack.
        // T: The data to add
        void Push(T item);

        // Removes and returns the top-most element of the stack.
        // Throws an exception if the stack is empty.
        T Pop();

    }
}
