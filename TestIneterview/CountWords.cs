using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIneterview
{
    public class CountWords
    {
        public Dictionary<string, int> getCountWords(string[] words) {

            var dictornatyCountWord = new Dictionary<string, int>();
            

            for (var i=0; i<words.Length; i++) {

                if (dictornatyCountWord.ContainsKey(words[i]))
                {
                    dictornatyCountWord.TryGetValue(words[i], out var countWordfinded);
                    dictornatyCountWord[words[i]] = ++countWordfinded;
                }
                else
                    dictornatyCountWord.Add(words[i], 1);
            }
            return dictornatyCountWord;
        }
    }
}
