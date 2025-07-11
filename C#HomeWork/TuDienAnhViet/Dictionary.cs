using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuDienAnhViet
{
    public class Dictionary
    {
        private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        private string _dataPath;

        public Dictionary(string dataPath)
        {
            dictionary = Utilities<Dictionary<string, List<string>>>.ReadFile(dataPath);
            _dataPath = dataPath;
        }

        public void Add(string newWord, List<string> meaningOfWord)
        {
            if (dictionary.ContainsKey(newWord))
            {
                throw new InvalidOperationException("New word is existed");
            }
            dictionary[newWord] = meaningOfWord;
            Utilities<Dictionary<string, List<string>>>.WriteFile(_dataPath, dictionary);
        }

        public KeyValuePair<string, List<string>> Search(string searchWord)
        {
            if (dictionary.ContainsKey(searchWord))
                foreach (KeyValuePair<string, List<string>> keyValuePair in dictionary)
                {
                    if (keyValuePair.Key.Contains(searchWord))
                    {
                        return keyValuePair;
                    }
                }
            KeyValuePair<string, List<string>> result = new KeyValuePair<string, List<string>>(searchWord, new List<string>());
            result.Value.AddRange(dictionary.Keys.Where(k => dictionary[k].Contains(searchWord)));
            if (result.Value.Count > 0)
                return result;
            return default;
        }

        public void Remove(string removeWord)
        {
            KeyValuePair<string, List<string>> keyValuePairOfRemoveWord = Search(removeWord);
            if (!keyValuePairOfRemoveWord.Equals(default))
            {
                dictionary.Remove(removeWord);
                Utilities<Dictionary<string, List<string>>>.WriteFile(_dataPath, dictionary);
                return;
            }
            throw new InvalidOperationException("Word not found");
        }

        public Dictionary<string, List<string>> GetDictionary() => dictionary;
    }
}
