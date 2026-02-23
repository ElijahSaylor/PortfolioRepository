using System;
using System.Collections.Generic;
using System.Text;

namespace SaylorE_Proj3_Dictionary
{
    internal class CustomPair<K,V>
    {

        private K key;
        private V value;

        public K Key
        {
            get { return key; } 
            //IMPLEMENT SET, requires rehash
        }
        
        public V Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public CustomPair(K key, V value) 
        {
            this.key = key;
            this.value = value;
        }

        public CustomPair()
        {
            key = default(K);
            value = default(V);
        }

    }
}
