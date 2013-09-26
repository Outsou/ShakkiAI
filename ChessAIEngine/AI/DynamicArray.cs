using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ChessEngine.AI
{
    public class DynamicArray : IEnumerator, IEnumerable
    {
        private byte[] array;
        private int endIndex = 0;
        int position = -1;  //Index for enumerator

        public DynamicArray()
        {
            array = new byte[16];
        }

        #region Array commands

        public void Add(byte item)
        {
            //Create bigger array if needed
            if (endIndex >= array.Length)
            {
                byte[] newArray = new byte[array.Length * 2];

                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }

                array = newArray;
            }

            array[endIndex] = item;
            endIndex++;
        }

        public int Count
        {
            get { return endIndex; }
        }

        public int TrueSize
        {
            get { return array.Length; }
        }

        #endregion

        #region Enumerator members

        public object Current
        {
            get { return array[position]; }
        }

        public bool MoveNext()
        {
            position++;
            return (position < endIndex);
        }

        public void Reset()
        {
            position = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        #endregion
    }
}
