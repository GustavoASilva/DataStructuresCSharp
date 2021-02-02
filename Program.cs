using System;
using System.Collections.Generic;

namespace DataStructuresStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            new System.Globalization.CultureInfo("pt-br");
            var newDA = new DynamicArray<string>(16);

            for (int i = 0; i < newDA.Capacity; i++)
            {
                newDA[i] = i.ToString();
            }

            newDA.Reset();
        }
    }
}