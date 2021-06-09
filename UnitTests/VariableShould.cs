using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using CoreDynamic;
using System.Text.RegularExpressions;
using CoreDynamic.MathCore;

namespace UnitTests
{
    public class VariableShould
    {

        [Fact]
        public void verifyValueForRange()
        {
            var operadorMenorQue = new Operator("<");
            var operadorMayorIgualQue = new Operator(">=");

            var campoCriterio = new FieldCriterion("CantidadContratoMix");

            var range1 = new Rank(1, operadorMenorQue, 1, 0.0M);
            var range2 = new Rank(1, operadorMenorQue, 5, 0.8M);
            var range3 = new Rank(1, operadorMenorQue, 10, 0.9M);
            var range4 = new Rank(1, operadorMenorQue, 15, 1.0M);
            var range5 = new Rank(1, operadorMayorIgualQue, 15, 1.2M);

            range1.isPorcentage();
            range1.addFieldCriterion(campoCriterio);

            range2.isPorcentage();
            range2.addFieldCriterion(campoCriterio);

            range3.isPorcentage();
            range3.addFieldCriterion(campoCriterio);

            range4.isPorcentage();
            range4.addFieldCriterion(campoCriterio);

            range5.isPorcentage();
            range5.addFieldCriterion(campoCriterio);

            var variable = new Variable(1, "PorcentajeComision");

            variable.addRanks(new List<Rank>() { range1, range2, range3, range4, range5 });

            variable.isRank();
            variable.setMathResolve(new MathXParserResolve());

            var pcomision=variable.resolve();

            pcomision.Should().Be(0.8M);

        }

        [Fact]
        public void verifyValueForFormula()
        {
            
            var campoCriterio1 = new FieldCriterion("PorcentajeComision");
            var campoCriterio2 = new FieldCriterion("MultiplicadorPersitencia");

            var expresion = new VariableExpression("PorcentajeComision*MultiplicadorPersitencia*70", new List<FieldCriterion>() { campoCriterio1,campoCriterio2});

            var variable = new Variable(1, "PorcentajeComision", expresion);
            variable.isCriterion();
            variable.setMathResolve(new MathXParserResolve());

            var valorformula = variable.resolve();

            valorformula.Should().Be(5.6M);

        }



    }
}
