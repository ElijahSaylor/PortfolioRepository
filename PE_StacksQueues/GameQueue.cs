using System;
using System.Collections.Generic;
using System.Text;

namespace PE_StacksQueues
{
    internal class GameQueue<T> : IQueue<T>
    {
        List<T> dataList = new List<T>();
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
            if(dataList.Count == 0)
            {
                throw new NullReferenceException("Can't peek an empty queue bro");
            }

            return dataList[dataList.Count - 1];
        }

        public void Enqueue(T item)
        {
            dataList.Add(item);
        }

        public void Enqueue(T[] items)
        {
            foreach(T item in items)
            {
                dataList.Add(item);
            }
        }

        public T Dequeue()
        {
            if(dataList.Count == 0)
            {
                throw new NullReferenceException("Can't dequeue an empty queue");
            }

            T holder = dataList[0];
            dataList.RemoveAt(0);
            return holder;
        }
    }
}
