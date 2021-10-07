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
    public class BinarySearchShould
    {
        [Fact]
        public void VerifySearchBinaryIsCorrect() {

            //Arange
            int findNumber=11;
            int []array = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

            //Act
            var binarysearch = new BinarySearch();

            var index = binarysearch.Search(array, findNumber);

            //Asert
            index.Should().Be(4);
        }

        [Fact]
        public void VerifySearchBinaryNotFoundResult()
        {

            //Arange
            int findNumber = 1;
            int[] array = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

            //Act
            var binarysearch = new BinarySearch();

            var index = binarysearch.Search(array, findNumber);

            //Asert
            index.Should().Be(-1);
        }

    }
}