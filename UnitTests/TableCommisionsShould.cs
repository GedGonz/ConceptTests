using CompareBetween;
using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
namespace UnitTests
{
    public class TableCommisionsShould
    {
        [Theory(DisplayName ="verifica que este en el primer rango")]
        [InlineData(10)]
        public void Verify_that_first_range(decimal sale)
        {
            //Arrange
            var range0 = new Ranges(0, 14, "0.0");
            var range1 = new Ranges(15, 30, "0.10");
            var range2 = new Ranges(31, 40, "0.15");
            var range3 = new Ranges(41, 49, "0.20");
            var range4 = new Ranges(50, 0, "0.25");
            var ListArange = new List<Ranges>() { range1, range2, range3, range4 };
            var TableCommision = new CommissionTable(1, "GERENTE DE PRODUCTO PLAN CORPORTATIVO", "DECCRIPTION 1", TYPETABE_COMMISION.PRODUCT_MANAGER, TYPRANGE.PERCENTAGE, ListArange);
            
            //Act
            var percentage = TableCommision.getValueFromRanges(sale);

            //Assert
            percentage.Should().Be("0.10");
        }
        [Theory(DisplayName = "verifica que este en el segundo rango")]
        [InlineData(35)]
        public void Verify_that_second_range(decimal sale)
        {
            //Arrange
            var range1 = new Ranges(15, 30, "0.10");
            var range2 = new Ranges(31, 40, "0.15");
            var range3 = new Ranges(41, 49, "0.20");
            var range4 = new Ranges(50, 0, "0.25");
            var ListArange = new List<Ranges>() { range1, range2, range3, range4 };
            var TableCommision = new CommissionTable(1, "GERENTE DE PRODUCTO PLAN CORPORTATIVO", "DECCRIPTION 1", TYPETABE_COMMISION.PRODUCT_MANAGER, TYPRANGE.PERCENTAGE, ListArange);


            //Act
            var percentage = TableCommision.getValueFromRanges(sale);

            //Assert
            percentage.Should().Be("0.15");
        }

        [Theory(DisplayName = "verifica que este en el tercer rango")]
        [InlineData(45)]
        public void Verify_that_third_range(decimal sale)
        {
            //Arrange
            var range1 = new Ranges(15, 30, "0.10");
            var range2 = new Ranges(31, 40, "0.15");
            var range3 = new Ranges(41, 49, "0.20");
            var range4 = new Ranges(50, 0, "0.25");
            var ListArange = new List<Ranges>() { range1, range2, range3, range4 };
            var TableCommision = new CommissionTable(1, "GERENTE DE PRODUCTO PLAN CORPORTATIVO", "DECCRIPTION 1", TYPETABE_COMMISION.PRODUCT_MANAGER, TYPRANGE.PERCENTAGE, ListArange);


            //Act
            var percentage = TableCommision.getValueFromRanges(sale);

            //Assert
            percentage.Should().Be("0.20");
        }
        [Theory(DisplayName = "verifica que se mayor o igual al ultimo rango")]
        [InlineData(70)]
        public void Verify_that_latest_range(decimal sale)
        {
            //Arrange
            var range1 = new Ranges(15, 30, "0.10");
            var range2 = new Ranges(31, 40, "0.15");
            var range3 = new Ranges(41, 49, "0.20");
            var range4 = new Ranges(50, 0, "0.25");
            var ListArange = new List<Ranges>() { range1, range2, range3, range4 };
            var TableCommision = new CommissionTable(1, "GERENTE DE PRODUCTO PLAN CORPORTATIVO", "DECCRIPTION 1", TYPETABE_COMMISION.PRODUCT_MANAGER, TYPRANGE.PERCENTAGE, ListArange);

            //Act
            var percentage = TableCommision.getValueFromRanges(sale);

            //Assert
            percentage.Should().Be("0.25");
        }

        //[Theory(DisplayName = "verifica se ejecute la validacion del rango de inicio")]
        //[InlineData(70)]
        //public void Verify_that_validate_range(decimal sale)
        //{
        //    //Arrange
        //    var range1 = new Ranges(0, 30, "0.10");
        //    var range2 = new Ranges(31, 40, "0.15");
        //    var range3 = new Ranges(41, 49, "0.20");
        //    var range4 = new Ranges(50, 0, "0.25");
        //    var ListArange = new List<Ranges>() { range1, range2, range3, range4 };
        //    var TableCommision = new CommissionTable(1, "GERENTE DE PRODUCTO PLAN CORPORTATIVO", "DECCRIPTION 1", TYPETABE_COMMISION.PRODUCT_MANAGER, TYPRANGE.PERCENTAGE, ListArange);

        //    //Act
        //    var percentage = TableCommision.getValueFromRanges(sale);

        //    //Assert
        //    percentage.ShouldThrow<InvalidOperationException>().WithMessage("some message");
        //}
    }
}
