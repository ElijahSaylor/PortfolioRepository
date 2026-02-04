using System;
using System.Collections.Generic;
using System.Text;

namespace PE_LinkedLists
{
    internal class LinkedList<T>
    {

        private int count;
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;

        /// <summary>
        /// Constructor, sets count to 0
        /// </summary>
        public LinkedList()
        {
            count = 0;
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index"> index to access</param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return GetData(index); }
        }

        /// <summary>
        /// number of elements in this list
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Returns the node object at a specified index
        /// </summary>
        /// <param name="index">index to retrieve</param>
        /// <returns> LinkedListNode<T> object</T></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public LinkedListNode<T> GetNode(int index)
        {
            

            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range broseph!");
            }


            LinkedListNode<T> currentNode = head;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        /// <summary>
        /// returns the data at a specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public T GetData(int index)
        {
            

            LinkedListNode<T> node = GetNode(index);

            if(node != null)
            {
                return node.Data;
            }

            else
            {
                
                throw new NullReferenceException($"Data at {index} is null!!!!!!");
            }

        }

        /// <summary>
        /// appends the passed data to the end of the list
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(data);

            if (head == null)
            {
                head = newNode;
            }

            else
            {
                LinkedListNode<T> currentNode = tail;

                //while (currentNode.Next != null)
                //{
                //    currentNode = currentNode.Next;
                //}

                currentNode.Next = newNode;

                newNode.Prev = currentNode;
            }

            tail = newNode;
            count++;
        }

        public T RemoveAt(int index)
        {
 
            if (index < 0 || index >= count || count == 0)
            {
                throw new IndexOutOfRangeException("Index out of range broseph!");
            }

            //if index is the last element
            if (index == count - 1)
            {
                T holder = tail.Data;

                tail = GetNode(index - 1);
                GetNode(index - 1).Next = null;

                count--;
                return holder;
            }

            //if first, set head to be the second node
            if (index == 0)
            {
                T holder = GetData(index);
                head = head.Next;
                count--;
                return holder;
            }

            T holder2 = GetData(index);
            GetNode(index - 1).Next = GetNode(index + 1);

            count--;

            return holder2; // my brain is actually operating on dial up rn
            //return currentNode;
        }
    }
}
