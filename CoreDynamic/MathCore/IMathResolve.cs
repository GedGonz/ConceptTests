using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDynamic.MathCore
{
    public interface IMathResolve
    {
        bool resolveExpresion(string expression);
        decimal resulveFormula(string formula);
    }
}
