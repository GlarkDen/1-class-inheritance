using System;
using System.Collections;

namespace Lab_10
{
    public class SortByName: IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Person personX)
                if (y is Person personY)
                    return personX.Name.CompareTo(personY.Name);
                else
                    throw new Exception("NotCompareY");
            else
                throw new Exception("NotCompareX");
        }
    }
}
