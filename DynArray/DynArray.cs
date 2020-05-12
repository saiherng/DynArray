using System;
using System.Collections;

namespace Dynamic_array
{
    public class DynArray
    {
       
        int[] array = new int[1] {-1};
        int itemCount = 0;
         

        /// <summary>
        /// This should return the array in its entirety.
        /// </summary>
        public int[] GetArray()
        {       
            return array;
        }

        /// <summary>
        /// This should return only the initialized part of the array, not the uninitalized
        /// </summary>
        public int[] GetFilledArray()
        {

            int[] filledArray = new int[itemCount];

            for (int i = 0; i < itemCount ; i++)
            {
                filledArray[i] = array[i];
            }

            return filledArray;
        }

        /// <summary>
        /// This should return the size of instantiated ints
        /// </summary>
        public int GetFilledSize()
        {
            return itemCount;
        }

        /// <summary>
        /// This should return the size of the array, both the initialized and uninitialized
        /// </summary>
        public int GetTotalSize()
        {
            return array.Length;
        }

        /// <summary>
        /// This should add the int to the list, and double the lists size if its full
        /// </summary>
        public void AddInt(int intToAdd)
        {

            if (itemCount == array.Length)
            {
                DoubleArray();
            }

            array[itemCount] = intToAdd;
            itemCount++;

                     
        }

        /// <summary>
        /// Doubles the size of the array. Any new indexes in the array should be set to -1.
        /// </summary>
        public void DoubleArray()
        {
            int[] newArray = new int[itemCount * 2];

            for (int i=0; i < newArray.Length; i++)
            {
                if (i < array.Length)
                {
                    newArray[i] = array[i];
                }
                else
                {
                    newArray[i] = -1;
                }
            }

            array = newArray;
            
        }
    }
}