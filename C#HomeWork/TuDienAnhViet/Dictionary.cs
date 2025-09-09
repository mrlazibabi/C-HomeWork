using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuDienAnhViet
{
    public class Dictionary
    {
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();
        private string _dataPath;

        public Dictionary(string dataPath)
        {
            dictionary = Utilities<Dictionary<string, string>>.ReadFile(dataPath);
            _dataPath = dataPath;
        }

        public void Add(string newWord, string meaningOfWord)
        {
            if (dictionary.ContainsKey(newWord))
            {
                throw new InvalidOperationException("New word is existed");
            }
            dictionary[newWord] = meaningOfWord;
            Utilities<Dictionary<string, string>>.WriteFile(_dataPath, dictionary);
        }

        public KeyValuePair<string, string> Search(string searchWord)
        {
            foreach (KeyValuePair<string, string> keyValuePair in dictionary)
            {
                if (keyValuePair.Key.Equals(searchWord))
                {
                    return keyValuePair;
                }
            }
            return default;
        }

        public void Remove(string removeWord)
        {
            KeyValuePair<string, string> keyValuePairOfRemoveWord = Search(removeWord);
            if (!keyValuePairOfRemoveWord.Equals(default))
            {
                dictionary.Remove(removeWord);
                Utilities<Dictionary<string, string>>.WriteFile(_dataPath, dictionary);
                return;
            }
            throw new InvalidOperationException("Word not found");
        }

        public Dictionary<string, string> GetDictionary() => dictionary;
    }
}
