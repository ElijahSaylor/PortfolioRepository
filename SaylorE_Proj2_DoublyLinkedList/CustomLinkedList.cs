using System;
using System.Collections.Generic;
using System.Text;

namespace SaylorE_Proj2_DoublyLinkedList
{
    internal class CustomLinkedList<T>
    {

        int count = 0;
        CustomNode<T> head = null;
        CustomNode<T> tail = null;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        //indexer: just runs getIndex(index)
        public T this[int index]
        {
            get { return GetData(index); }
            set { GetNode(index).Data = value; }
        }

        public CustomLinkedList()
        {

        }

        /// <summary>
        /// returns a reference to the node at the specified index
        /// </summary>
        /// <param name="index">index to search</param>
        /// <returns>CustomNode object</returns>
        /// <exception cref="IndexOutOfRangeException">if no node is found at index</exception>
        public CustomNode<T> GetNode(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }

            CustomNode<T> currentNode = head;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        /// <summary>
        /// Adds data to the end of the list
        /// </summary>
        /// <param name="data">data to add</param>
        public void Add(T data)
        {

            CustomNode<T> newNode = new CustomNode<T>(data);
            //if head == null, make a new node, and assign that as head with the data.
            // else, start at head, iterate until next == null

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }

            else
            {
                CustomNode<T> thisNode = head;

                while (thisNode.Next != null)
                {
                    thisNode = thisNode.Next;
                }

                thisNode.Next = newNode;
                newNode.Prev = thisNode;
                tail = thisNode;
            }

            Count++;
        }
        
        /// <summary>
        /// returns the data at the specified index. This is mostly used by the indexer.
        /// </summary>
        /// <param name="index">index of data to retrieve</param>
        /// <returns>data at index</returns>
        /// <exception cref="NullReferenceException">if no node is found at index</exception>
        public T GetData(int index)
        {
            if(GetNode(index) == null)
            {
                throw new NullReferenceException("Null reference exception bro");
            }

            return GetNode(index).Data;
        }

        /// <summary>
        /// Clears head & tail pointers and resets Count to 0.
        /// </summary>
        public void Clear()
        {
            head = null!;
            tail = null!;
            Count = 0;
        }

        /// <summary>
        /// Removes and returns node at specified index
        /// </summary>
        /// <param name="index">Index to remove</param>
        /// <returns>removed index</returns>
        public T RemoveAt(int index) 
        {
            //if head index
            if (index == 0)
            {
                CustomNode<T> headNode = GetNode(index);
                head = head.Next;
                Count--;
                return headNode.Data;
            }

            //if tail index
            if (index == Count - 1)
            {
                CustomNode<T> tailHolder = tail;

                tail.Prev.Next = null!;
                tail = tail.Prev;

                Count--;
                return tailHolder.Data;
            }

            CustomNode<T> thisNode = GetNode(index);

            CustomNode<T> nextNode = thisNode.Next;
            CustomNode<T> lastNode = thisNode.Prev;

            nextNode.Prev = thisNode.Prev;
            lastNode.Next = thisNode.Next;


            Count--;
            return thisNode.Data;
        }

        /// <summary>
        /// inserts data at index.
        /// </summary>
        /// <param name="data">data to insert</param>
        /// <param name="index">index to insert data</param>
        public void Insert(T data, int index) 
        {
            //1. if list is empty
            //2. if head node insertion
            //3. if tail node insertion
            //4. regular

            CustomNode<T> newNode = new CustomNode<T>(data);

            //1.
            if (Count == 0)
            {
                Add(data);
                return;
            }

            //1.5: if index == count+1

            if (index == Count)
            {
                Add(data);
                return;
            }

            //2.
            if(Count > 0 && index == 0)
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
                Count++;
                return;
            }

            //3.
            if (index == Count - 1)
            {
                newNode.Prev = tail.Prev;
                newNode.Next = tail;

                tail.Prev.Next = newNode;
                tail.Prev = newNode;

                Count++;
                return;
            }

            CustomNode<T> currentNode = GetNode(index);

            newNode.Prev = currentNode.Prev;
            newNode.Next = currentNode.Next;

            currentNode.Prev = newNode;
            

            Count++;

        }

        /// <summary>
        /// prints list contents from front to back
        /// </summary>
        public void PrintForward() 
        {
            for(int i = 0; i < Count;  i++)
            {
                Console.WriteLine(this[i]!.ToString());
            }

            if(Count == 0)
            {
                Console.WriteLine("Nothing to print dude (or dudette)");
            }
        }

        /// <summary>
        /// prints list contents from back to front
        /// </summary>
        public void PrintBackward()
        {
            for (int i = Count-1;i >= 0; i--)
            {
                Console.WriteLine(this[i]!.ToString());
            }

            if (Count == 0)
            {
                Console.WriteLine("Nothing to print dude (or dudette)");
            }
        }
    }
}
