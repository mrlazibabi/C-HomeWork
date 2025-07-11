using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuDienAnhViet
{
    public class DictionaryUI
    {
        private Dictionary dictionary = new Dictionary("Dictionary.json");

        public void Add()
        {
            Console.Write("Input newWord: ");
            string newWord = Console.ReadLine();
            Console.Write("Input number of meaning: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfMeaning))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            if (numberOfMeaning <= 0 || numberOfMeaning > 20)
            {
                Console.WriteLine("Invalid number of meaning");
                return;
            }
            Console.Write("Input meaning: ");
            List<string> listOfMeaning = new List<string>();
            for (int i = 0; i < numberOfMeaning; i++)
            {
                listOfMeaning.Add(Console.ReadLine());
            }
            try
            {
                dictionary.Add(newWord, listOfMeaning);
                Console.WriteLine("Add success");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Search()
        {
            Console.Write("Input searchWord: ");
            string searchWord = Console.ReadLine();
            var searchResult = dictionary.Search(searchWord);
            if (searchResult.Equals(default(KeyValuePair<string, List<string>>)))
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine($"{searchResult.Key} \nMeaning or relevant word:");
                foreach (var meaning in searchResult.Value) Console.Write($"{meaning} ");
                Console.WriteLine();
            }
        }

        public void Remove()
        {
            Console.Write("Input removeWord: ");
            string removeWord = Console.ReadLine();
            try
            {
                dictionary.Remove(removeWord);
                Console.WriteLine("Remove success");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetDictionary()
        {
            if (dictionary.GetDictionary().Count > 0)
                foreach (var word in dictionary.GetDictionary())
                {
                    Console.WriteLine($"++{word.Key}++ \n--Meaning--:");
                    foreach (var meaning in word.Value) Console.Write($"{meaning}.  ");
                    Console.WriteLine("\n=========");
                    Console.WriteLine();
                }
            else { Console.WriteLine("There is no word in dictionary"); }
        }
    }
}
