using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Era
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashtable = new HashTable();
            hashtable.Insert("LIq", "Djekelbe");
            ShowHashTable(hashtable, "First");

        }
        private static void ShowHashTable(HashTable hash, string title)
        {
            Console.WriteLine(title);
            foreach (var k in hash.Items)
            {
                Console.WriteLine(k.Key);
                foreach(var value in k.Value)
                {
                    Console.WriteLine($"\t{value.Key}-{value.Value}");
                }
            }
            Console.WriteLine();
         
        }
    }
}
