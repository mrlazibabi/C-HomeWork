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
            Console.Write("Input meaning: ");
            string meaning = Console.ReadLine();
            try
            {
                dictionary.Add(newWord, meaning);
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
            if (searchResult.Equals(default(KeyValuePair<string, string>)))
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine($"{searchResult.Key} | Meaning: {searchResult.Value}");
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
            foreach (var word in dictionary.GetDictionary())
            {
                Console.WriteLine($"{word.Key} | Meaning: {word.Value}");
            }
        }
    }
}
