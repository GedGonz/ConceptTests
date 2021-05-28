using CoreDynamic.MathCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDynamic.util
{
    public static class CalculoExtension
    {
        public static decimal toResolveFormula(this string value, IMathResolve resolve)
        {
            return resolve.resulveFormula(value);
        }

        public static bool toResolveExpresion(this string value, IMathResolve resolve)
        {
            return  resolve.resolveExpresion(value);

        }


       


    }
}
