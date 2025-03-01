using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayUtilsDoubleArrayElements
{
    public class ArrayUtils
    {
        public static int[] DoubleArrayElements(int[] array)
        {
            if(array == null)
            {
                throw new ArgumentNullException(nameof(array), "array cannot be null");
            }

            int[] doubleArray = new int[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                doubleArray[i] = array[i] * 2;
            }
            return doubleArray;
        }
    }
}
