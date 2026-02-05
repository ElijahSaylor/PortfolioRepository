using System;
using System.Collections.Generic;
using System.Text;

namespace PE_StacksQueues
{
    internal class GameStack<T> : IStack<T>
    {
        protected List<T> dataList = new List<T>();
        public int Count
        {
            get { return dataList.Count; }
        }

        public bool IsEmpty
        {
            get { if (dataList.Count == 0) return true;
                                      else return false;
                }
        }

        public T Peek()
        {
            if (dataList.Count == 0)
            {
                throw new NullReferenceException("Can't peek() at an empty stack ding dong...");
            }

            return dataList[Count - 1];
        }

        public void Push(T item)
        {
            dataList.Add(item);
            
        }

        public void Push(T[] item)
        {
            foreach(T thing in item)
            {
                this.Push(thing);
            }
        }

        public T Pop()
        {
            if(dataList.Count == 0)
            {
                throw new NullReferenceException("Can't pop() from an empty stack ding dong...");
            }

            T holder = dataList[dataList.Count - 1];
            dataList.RemoveAt(dataList.Count - 1);

            
            return holder;
        }
    }
}
