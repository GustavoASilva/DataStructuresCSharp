using System;
using System.Collections.Generic;

namespace DataStructuresStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            var newDA = new DynamicArray<string>();
            Console.WriteLine(newDA.Size);

            var aux = new string[16];

            for(int i = 0; i < aux.Length; i++)
            {
                aux[i] = i.ToString();
            }

           


            newDA.AddRange(aux);
        }
    }
}