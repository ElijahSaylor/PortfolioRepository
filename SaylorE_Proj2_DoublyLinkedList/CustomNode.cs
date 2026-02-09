using System;
using System.Collections.Generic;
using System.Text;

namespace SaylorE_Proj2_DoublyLinkedList
{
    internal class CustomNode<T>
    {
        /// <summary>
        /// All this class does is hold some data of type T
        /// and a reference to the next/previous nodes in the
        /// list
        /// </summary>

        private T data;
        private CustomNode<T> prev;
        private CustomNode<T> next;

        public T Data
        {
            get { return data; } 
            set { data = value; }
        }

        public CustomNode<T> Prev
        {
            get { return prev; }
            set { prev = value; }
        }

        public CustomNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public CustomNode(T data) 
        {
            Data = data;
        }

        public CustomNode()
        {
            
        }
    }
}
