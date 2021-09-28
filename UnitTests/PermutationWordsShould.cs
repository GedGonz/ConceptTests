using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIneterview;
using Xunit;
using FluentAssertions;

namespace UnitTests
{
    public class PermutationWordsShould
    {
        [Fact]
        public void VerifyPermutatioWordsIsCorrect() {

            //Arange
            const string word1 = "CASA";
            const string word2 = "SACA";
            var dictornatyPermutationWord = new Dictionary<string, int>
            {
                { "C", 1 },
                { "A", 2 },
                { "S", 1 }
            };

            //Act
            var permutationsWords = new PermutationWords();

            var (dictornaryWord1, dictornaryWord2, _) = permutationsWords.getPermutation(word1, word2);

            //Asert
            dictornaryWord1.Should().BeEquivalentTo(dictornatyPermutationWord);
            dictornaryWord2.Should().BeEquivalentTo(dictornatyPermutationWord);
        }

        [Fact]
        public void VerifyDifferentWord()
        {
            //Arange
            const string word1 = "CAMISA";
            const string word2 = "SACA";

            //Act
            var permutationsWords = new PermutationWords();

            var (_, _, state) = permutationsWords.getPermutation(word1, word2);

            //Asert
            state.Should().BeFalse();
        }
        [Fact]
        public void VerifyLengthWordEqualsButDiferentCountLetters()
        {

            //Arange
            const string word1 = "CASA";
            const string word2 = "CACA";
            var dictornatyPermutationWord = new Dictionary<string, int>
            {
                { "C", 1 },
                { "A", 2 },
                { "S", 1 }
            };

            //Act
            var permutationsWords = new PermutationWords();

            var (_, dictornaryWord2, _) = permutationsWords.getPermutation(word1, word2);

            //Asert
            dictornaryWord2.Should().NotEqual(dictornatyPermutationWord);
        }
    }
}