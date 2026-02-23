using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Text;

namespace SaylorE_Proj3_Dictionary
{
    internal class CustomDictionary<K, V>
    {
        private int count; //number of dictionary entries in comparison to capacity
        List<List<CustomPair<K, V>>> data; //list of lists of pairs
        private int hashValue;
        private int hashedIndex;

        public int Count
        {
            get { return count; }
        }

        public float LoadFactor
        {
            get { return ((float)Count / (float)data.Capacity); }
        }

        public V this[K key]
        {
            // write get block, run 'key' through hash function, go to that index, search through that
            // list to see if there is something with a matching key.
            get {

                hashValue = key!.GetHashCode();

                hashedIndex = hashValue % data.Capacity;

                //for each thing at the index, look for matching key, if found, return, else throw error.

                foreach (CustomPair<K, V> pair in data[hashedIndex])
                {
                    if (EqualityComparer<K>.Default.Equals(pair.Key, key)) // "if they are the same" ('==' wasnt working)
                    {
                        return pair.Value;
                    }
                }

                throw new KeyNotFoundException($"Key {key} not found!");

            }

            //write set block
            set
            {
                hashValue = key!.GetHashCode();

                hashedIndex = hashValue % data.Capacity;

                //for each thing at the index, look for matching key, if found, return, else throw error.

                foreach (CustomPair<K, V> pair in data[hashedIndex])
                {
                    if (EqualityComparer<K>.Default.Equals(pair.Key, key)) // "if they are the same" ('==' wasnt working)
                    {
                        pair.Value = value;
                        return;
                    }
                }

                data[hashedIndex].Add(new CustomPair<K, V>(key, value));

            }
        }

        /// <summary>
        /// initiallizes dictionary with the specified size
        /// </summary>
        /// <param name="initialSize"></param>
        public CustomDictionary(int initialSize)
        {
            data = new List<List<CustomPair<K, V>>>(initialSize);
            Populate(data);
        }
        /// <summary>
        /// initializes the dictionary with a size of 100
        /// </summary>
        public CustomDictionary() 
        {
            data = new List<List<CustomPair<K, V>>>(100);
            Populate(data);
        }

        /// <summary>
        /// checks if entry with this key exists, if not, adds it to the dictionary
        /// </summary>
        /// <param name="pair"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(K key, V value) 
        {
            // 1. hash the key
            // 2. go to that index
            // 3. is there a dupe there? error!
            // 4. if not, add the pair to the list there
            



            hashValue = Math.Abs(key!.GetHashCode());
            //Console.WriteLine($"Generated hash code {hashValue}");

            hashedIndex = hashValue % data.Capacity;
            //Console.WriteLine($"Generated hash index {hashedIndex}");


            //check for duplicate keys
            foreach (CustomPair<K, V> entry in data[hashedIndex])
            {
                if (EqualityComparer<K>.Default.Equals(entry.Key, key)) 
                {
                    throw new ArgumentException($"Error, duplicate key '{key}' found!");
                }
            }

            data[hashedIndex].Add(new CustomPair<K, V>(key, value));
            count++;

            if (LoadFactor > 0.7)
            {
                Console.WriteLine("Rehashing");
                Rehash();
            }

        }

        private void Add(CustomPair<K,V> pair, List<List<CustomPair<K,V>>> newList)
        {
            hashValue = Math.Abs(pair.Key!.GetHashCode());

            hashedIndex = hashValue % newList.Count;

            //check for duplicate keys
            foreach (CustomPair<K, V> entry in newList[hashedIndex])
            {
                if (EqualityComparer<K>.Default.Equals(entry.Key, pair.Key))
                {
                    throw new ArgumentException($"Error, duplicate key '{pair.Key}' found! " +
                        $"(this was probably during a resizing operation)");
                }
            }


            newList[hashedIndex].Add(pair);
            
        }

        /// <summary>
        /// returns a bool reflecting if the specified key exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(K key) 
        {
            hashValue = Math.Abs(key!.GetHashCode());

            hashedIndex = hashValue % data.Capacity;

            foreach (CustomPair<K, V> entry in data[hashedIndex])
            {
                if (EqualityComparer<K>.Default.Equals(entry.Key, key))
                {
                    return true;
                }
            }

            Console.WriteLine($"Key '{key}' not found.");
            return false;
        }

        /// <summary>
        /// attempts to remove the passed key, returns the bool reflecting whether or not it was successful.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(K key)
        {
            hashValue = Math.Abs(key!.GetHashCode());

            hashedIndex = hashValue % data.Capacity;

            CustomPair<K, V> toRemove = null!;

            foreach (CustomPair<K, V> entry in data[hashedIndex])
            {
                if (EqualityComparer<K>.Default.Equals(entry.Key, key))
                {
                    toRemove = entry;
                }
            }

            if (toRemove != null) 
            {
                data[hashedIndex].Remove(toRemove);
                count--;
                return true;
            }

            return false;
        }

        /// <summary>
        /// clears the dictionary
        /// </summary>
        public void Clear()
        {
            data.Clear();
            count = 0;
        }

        /// <summary>
        /// resizes the dictionary to avoid collisions
        /// </summary>
        private void Rehash() // back to strangers
        {

            //make new array 2x as large
            List<List<CustomPair<K, V>>> resizedData = new List<List<CustomPair<K, V>>>(data.Capacity * 2);
            Populate(resizedData);

            

            //Console.WriteLine("Running rehash() bucket loop...");
            //for each bucket
            foreach(List<CustomPair<K,V>> bucket in data)
            {
                //skip empty buckets
                if(bucket.Count == 0)
                {
                    continue;
                }

                //add that pair to resized data
                foreach (CustomPair<K,V> pair in bucket) 
                {
                    Add(pair, resizedData);
                }
            }

            //Console.WriteLine("Finished rehashing loop");

            // resize base array
            // for each entry where the list isnt empty, take each thing in that list, and run add() on it
            // that should work probably

            data = resizedData;
            
        }

        /// <summary>
        /// prints all entries in the dictionary, count and capacity
        /// </summary>
        public void PrintDebug()
        {
            Console.WriteLine($"Here is the debug info:\n" +
                $"Count: {Count}\n" +
                $"Capacity: {data.Capacity}");

            foreach (List<CustomPair<K, V>> bucket in data)
            {
                //skip empty buckets
                if (bucket.Count == 0)
                {
                    continue;
                }

                //add that pair to resized data
                foreach (CustomPair<K, V> pair in bucket)
                {
                    Console.WriteLine($"Key: {pair.Key}\n Value: {pair.Value}");
                }
            }

            //Console.WriteLine("print debug (not implemented yet)");
        }

        /// <summary>
        /// adds empty list<custompair<K,V>> objects to the list
        /// </summary>
        /// <param name="list"></param>
        private void Populate(List<List<CustomPair<K, V>>> list)
        {
            for(int i = 0; i < data.Capacity; i++)
            {
                list.Add(new List<CustomPair<K, V>>());
            }
        }

    }
}
