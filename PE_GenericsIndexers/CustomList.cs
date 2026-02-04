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

        // **************************************************
        // * Answer the following question:                 *
        // * - Why DON'T we need an extra field to hold     *
        // *   the list's capacity?                         *
        // **************************************************
        // ANSWER(s): 
        // Because there is already a built in .Capacity property in the list class
        //


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

        // **************************************************
        // * Answer the following questions:                *
        // * - Why is the Count property get-only?          *
        // * - Why not include a set?                       *
        // **************************************************
        // ANSWER(s): 
        // 
        // setting the 'count' of a list doesn't really make sense. you would need to A) resize the list,
        // which is its own operation, and B) populate those new slots with some value. also if you could
        // arbitrarily set it, then it could become disassociated with the actual number of elements in the
        // list and would probably not be very useful.
        //


        /// <summary>
        /// Returns the overall number of elements the internal data structure
        /// can hold before a resize operation.
        /// </summary>
        public int Capacity
        {
            get { return data.Length; }
        }


        /*
        // NOOOOO! Don't do this! This is included to show what NOT to do.
        public double[] Data
        {
            get { return data; }
            set { data = value; }
        }
        */
        // **************************************************
        // * Answer the following question:                 *
        // * - Why DON'T we want a property that gets or    *
        // *   sets the data array?                         *
        // **************************************************
        // ANSWER(s): 
        //
        // Because now access to this array (which should be a field) is not being protected or controlled,
        // potentially breaking internal stuff which might rely on it.


        // --------------------------------------------------------------------
        // Indexer Property
        // --------------------------------------------------------------------

        // TODO: Write an indexer property with get and set

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
            // **************************************************
            // * Comment this conditional.                      *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

            // if the list is almost full of stuff, more space needs to be made in order to add
            // more stuff, so the backing array needs to be resized so it can fit more stuff
            //
            // I am truly a word wizard
            if (count == data.Length - 1)
            {
                IncreaseSizeAndCopyData();
            }

            // **************************************************
            // * Comment this code.                             *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************
            
            // it is sticking the new piece of data onto the end of the array and ticking the
            // count + 1 so that the count matches the # of data bits in the array.
            data[count] = item;
            count++;
        }


        // **************************************************
        // * Answer the following questions:                *
        // * - What is the purpose of a private method?     *
        // * - Why is the IncreaseSizeAndCopyData method    *
        // *   private?                                     *
        // **************************************************
        // ANSWER(s): 
        //
        // It is so that the class can function correctly internally. You probably
        // shouldnt resize your list unless you have to since it is slow and 
        // computationally expensive. Making the method private means it only
        // runs when it must.

        /// <summary>
        /// Doubles the size of the data array.
        /// </summary>
        private void IncreaseSizeAndCopyData()
        {
            // **************************************************
            // * Comment this conditional.                      *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

            // if the list isnt full, dont resize it bozo!
            if (count != data.Length - 1)
            {
                return;
            }

            // **************************************************
            // * Comment every line of this code.               *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

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


        // **************************************************
        // * Answer the following questions:                *
        // * - Where is GetData's thrown exception being    *
        // *   caught?                                      *
        // * - Why is the thrown exception NOT caught       *
        // *   directly in the GetData method?              *
        // **************************************************
        // ANSWER(s): 
        //
        // the thrown error is caught in main so that the programmer working
        // with the custom data structure can decide how to proceed, which is 
        // usually going to be context dependent.
        //

        /// <summary>
        /// Retrieve data at an index.
        /// </summary>
        /// <param name="index">Integer index between 0 and the list's count.</param>
        /// <returns>Data at a specified index.</returns>
        /// <exception cref="Exception">Thrown exception when the index is out of range.</excepti
        public T GetData(int index)
        {

            return data[index];

            // **************************************************
            // * Comment this conditional.                      *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

            // if index is valid, return the data at that point
            if (index >= 0 && index < count)
            {
                return data[index];
            }

            // **************************************************
            // * Comment every statement in this code.          *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

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
