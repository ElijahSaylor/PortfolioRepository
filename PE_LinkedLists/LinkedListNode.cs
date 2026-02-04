using System;
using System.Collections.Generic;
using System.Text;

namespace PE_LinkedLists
{
    internal class LinkedListNode<T>
    {

        private LinkedListNode<T> next;
        private LinkedListNode<T> prev;
        private T data;

        public LinkedListNode(T dataIn)
        {
            next = null;
            prev = null;
            data = dataIn;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public LinkedListNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public LinkedListNode<T> Prev
        {
            get { return prev; }
            set { prev = value; }
        }


    }
}
