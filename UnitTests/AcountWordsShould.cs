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
    public class AcountWordsShould
    {
        [Fact]
        public void CountWords() {

            //Arange
            var dictornatyCountWord = new Dictionary<string, int>();
            dictornatyCountWord.Add("javascript",3);
            dictornatyCountWord.Add("C#", 2);
            dictornatyCountWord.Add("C++", 1);
            dictornatyCountWord.Add("JAVA", 2);
            dictornatyCountWord.Add("Ruby", 1);
            //Act
            var countWords = new CountWords();

            var dictornaryCount = countWords.getCountWords();

            dictornaryCount.Should().BeEquivalentTo(dictornatyCountWord);
        }
    }
}
