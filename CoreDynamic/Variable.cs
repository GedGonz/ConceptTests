using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Globalization;
using CoreDynamic.util;
using System.Text.RegularExpressions;
using CoreDynamic.MathCore;

namespace CoreDynamic
{
    public class Variable
    {
        public Variable()
        {

        }
        public Variable(int id, string name)
        {
            this.id = id;
            this.name = name;
            rank = new List<Rank>();
        }
        public Variable(int id, string name,  VariableExpression expression)
        {
            this.id = id;
            this.name = name;
            this.expression = expression;
            rank = new List<Rank>();
        }

        public int id { get; private set; }
        public string name { get; private set; }
        private List<Rank> rank { get; set; }
        public VariableExpression expression { get; private set; }
        private TypeVariable typeVariable { get; set; }
        private IMathResolve _resolve { get; set; }

        public void addRanks(List<Rank> ranks) 
        {
            
            rank.AddRange(ranks);
        }

        public List<Rank> getRanks() 
        {
            return rank.ToList();
        }

        public void isRank() 
        {
            typeVariable = TypeVariable.RANK;
        }
        public void isCriterion()
        {
            typeVariable = TypeVariable.CRITERION;
        }
        public TypeVariable getTypeVariable() 
        {
            return typeVariable;
        }

        public void setMathResolve(IMathResolve resolve)
        {
            this._resolve = resolve;
        }
        //REVISAR
        public decimal resolve()
        {
            if (typeVariable == TypeVariable.RANK)
                return rank.FirstOrDefault(x=> 
                $"{x.getFieldCriterion().value.ToDecimalFormat()}{x.Operator}{x.valueRank.ToDecimalFormat()}".toResolveExpresion(_resolve)
                ).value;

            if (typeVariable == TypeVariable.CRITERION)
                return getExpressionResolve();

            return 0;
        }

        private decimal getExpressionResolve()
        {
            var listaCampos = expression.getFieldsCriterion()
                      .Select(x =>
                      new {
                          variable = x.name,
                          valor = x.value
                      }
                      ).Cast<dynamic>().ToList();

            return mapFormula(expression.value, listaCampos)
                .toResolveFormula(_resolve);
        }
        private string mapFormula(string expresionFormula, List<dynamic> variables)
        {
            variables.ForEach(x =>
            {
                expresionFormula = expresionFormula.Replace(x.variable, x.valor.ToString());
            }
            );

            return expresionFormula;
        }


    }
}
