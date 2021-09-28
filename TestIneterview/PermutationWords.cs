using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIneterview
{
    public class PermutationWords
    {
        public (Dictionary<string,int>, Dictionary<string, int>, bool) getPermutation(string word1, string word2) {

            var dictionaryWord1 = new Dictionary<string, int>();
            var dictionaryWord2 = new Dictionary<string, int>();

            if (word1.Length != word2.Length)
                return (dictionaryWord1, dictionaryWord2, false);

            var charactersWord1 = word1.ToArray();
            var charactersWord2 = word2.ToArray();

            dictionaryWord1 = getCountCharacters(charactersWord1);
            dictionaryWord2 = getCountCharacters(charactersWord2);

            return (dictionaryWord1, dictionaryWord2, true);
        }

        public Dictionary<string, int> getCountCharacters(char[] characters)
        {

            var dictornatyCountCharacter = new Dictionary<string, int>();

            for (var i = 0; i < characters.Length; i++)
            {

                if (dictornatyCountCharacter.ContainsKey(characters[i].ToString()))
                {
                    dictornatyCountCharacter.TryGetValue(characters[i].ToString(), out var countWordfinded);
                    dictornatyCountCharacter[characters[i].ToString()] = ++countWordfinded;
                }
                else
                    dictornatyCountCharacter.Add(characters[i].ToString(), 1);
            }
            return dictornatyCountCharacter;
        }


    }
}
