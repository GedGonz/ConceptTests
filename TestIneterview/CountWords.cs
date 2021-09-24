using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIneterview
{
    public class CountWords
    {
        public Dictionary<string, int> getCountWords() {

            var dictornatyCountWord = new Dictionary<string, int>();
            var words =new [] { "javascript","C#","C++","JAVA","Ruby", "javascript", "javascript","JAVA","C#" };

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
