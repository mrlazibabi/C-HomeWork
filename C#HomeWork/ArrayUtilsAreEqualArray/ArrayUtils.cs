using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayUtilsAreEqualArray
{
    public class ArrayUtils
    {
        public static bool AreArraysEqual(int[] array1, int[] array2)
        {
            if(array1 == null || array2 == null)
            {
                throw new ArgumentNullException(nameof(array1), "One of the array must not be null");
            }

            if(array1.Length != array2.Length)
            {
                return false;
            }

            for(int i = 0;  i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
