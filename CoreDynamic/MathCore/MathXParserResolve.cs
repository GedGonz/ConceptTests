using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreDynamic.util;
namespace CoreDynamic.MathCore
{
    public class MathXParserResolve : IMathResolve
    {
        public bool resolveExpresion(string expression)
        {
            var result=  new Expression(expression).calculate();

            return (result != 0);
        }

        public decimal resulveFormula(string formula)
        {
            var result = new Expression(formula.toReplaceFormatPoint()).calculate();

            return result.ToDecimal();
        }
    }
}
