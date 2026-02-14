using System;
using System.Collections.Generic;
using System.Text;

namespace PE_GenericsIndexers
{
    /// <summary>
    /// A list of doubles with custom written methods.
    /// </summary>
    internal class CustomList<T>
    {
        // --------------------------------------------------------------------
        // Fields of the class
        // --------------------------------------------------------------------

        private T[] data;      // Underlying array that holds all list data
        private int count;          // Size of the list

        // --------------------------------------------------------------------
        // Properties of the class
        // --------------------------------------------------------------------

        /// <summary>
        /// Returns the current amount of data in the list.
        /// </summary>
        public int Count
        {
            get { return count; }
        }


        /// <summary>
        /// Returns the overall number of elements the internal data structure
        /// can hold before a resize operation.
        /// </summary>
        public int Capacity
        {
            get { return data.Length; }
        }


 


        // --------------------------------------------------------------------
        // Indexer Property
        // --------------------------------------------------------------------


        public T this[int numba]
        {
            get {
                ValidateIndex(numba);
                return data[numba]; }
            
            
            set {
                ValidateIndex(numba);
                data[numba] = value; }
        }


        // --------------------------------------------------------------------
        // Class Constructors
        // --------------------------------------------------------------------

        /// <summary>
        /// Instantiates a new list of doubles with a starting size of 4.
        /// </summary>
        public CustomList()
        {
            data = new T[4];
        }


        /// <summary>
        /// Instantiates a new list of doubles with a specified starting size.
        /// </summary>
        /// <param name="listSize">Initial size of the list.</param>
        public CustomList(int listSize)
        {
            data = new T[listSize];
        }


        // --------------------------------------------------------------------
        // Methods
        // --------------------------------------------------------------------

        /// <summary>
        /// Add new data to the list.
        /// </summary>
        /// <param name="item">Item to add to the next available spot.</param>
        public void Add(T item)
        {
          
            if (count == data.Length - 1)
            {
                IncreaseSizeAndCopyData();
            }

          
            data[count] = item;
            count++;
        }


        

        /// <summary>
        /// Doubles the size of the data array.
        /// </summary>
        private void IncreaseSizeAndCopyData()
        {
            

            // if the list isnt full, dont resize it bozo!
            if (count != data.Length - 1)
            {
                return;
            }

           

            // creates a new array of 2x size
            T[] largerCopy = new T[data.Length * 2];

            // for everything in the smaller array, copy it to the larger array at the same place
            for (int i = 0; i < data.Length; i++)
            {
                largerCopy[i] = data[i];
            }

            // set the reference of the smaller array to the larger one
            data = largerCopy;
        }


        

        /// <summary>
        /// Retrieve data at an index.
        /// </summary>
        /// <param name="index">Integer index between 0 and the list's count.</param>
        /// <returns>Data at a specified index.</returns>
        /// <exception cref="Exception">Thrown exception when the index is out of range.</excepti
        public T GetData(int index)
        {

            return data[index];

           

            // if index is valid, return the data at that point
            if (index >= 0 && index < count)
            {
                return data[index];
            }

           
            // let there be some exception message pointer!
            string exceptionMessage;

            // if theres nothing in the array, nothing can be returned
            if (count == 0)
            {
                exceptionMessage = "No data to retrieve, list is empty.";
            }

            // else if there is more than no data, then the error is probably accessing an
            // index not in range, so set the error message accordingly
            else
            {
                exceptionMessage = String.Format(
                    "Index {0} is out of range. Index must be between 0 and {1}",
                    index,
                    count - 1);
            }

            // throw the set error 
            throw new IndexOutOfRangeException(exceptionMessage);
        }


        /// <summary>
        /// validates and sets the data at the specified index to the passed value
        /// </summary>
        /// <param name="index">index to replace</param>
        /// <param name="newValue">new data</param>
        public void SetData(int index, T newValue)
        {
            data[index] = newValue;
            return;

            if (index >= 0 && index < count)
            {
                data[index] = newValue;
            }

            ValidateIndex(index);

        }

        /// <summary>
        /// Index validation helper function. if index is out of range or
        /// array is empty, throws the appropriate error
        /// </summary>
        /// <param name="index"> index to validate </param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void ValidateIndex(int index) 
        {
            if (index >= 0 && index < count)
            {
                return;
            }

            string exceptionMessage;

            if (count == 0)
            {
                exceptionMessage = "No data to retrieve, list is empty.";
            }

            else
            {
                exceptionMessage = String.Format(
                    "Index {0} is out of range. Index must be between 0 and {1}",
                    index,
                    count - 1);
            }

            throw new IndexOutOfRangeException(exceptionMessage);

        }
    }
}
