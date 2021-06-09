using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using CoreDynamic.MathCore;
using CoreDynamic.util;

namespace CoreDynamic
{


    public class Formula 
    {
        public Formula()
        {

        }
        public Formula(int id, string name, string expresion, int positionId)
        {
            this.id = id;
            this.name = name;
            this.expresion = expresion;
            this.PositionId = positionId;
            variables = new List<Variable>();

        }

        public int id { get; private set; }
        public string name { get; private set; }
        public string expresion { get; private set; }
        private List<Variable> variables { get; set; }
        private IMathResolve resolve { get; set; }
        private string formula { get; set; }
        public int PositionId { get; set; }
        public void addVariable(Variable variable) 
        {
            variables.Add(variable);
        }
        public void addExpression(string expresion) 
        {
            this.expresion = expresion;
        }
        public void setMathResolve(IMathResolve resolve) 
        {
            this.resolve = resolve;
            variables.ForEach(variable=> {
                variable.setMathResolve(resolve);
            });
        }

        public decimal resolveFormula() 
        {

            var patron = @"[*/+-]";
            var variablesExpression = Regex.Split(expresion, patron);

            var listaVariables = variables.Where(x => variablesExpression.Contains(x.name))
                      .Select(x =>
                      new {
                          variable = x.name,
                          valor = x.resolve()
                      }
                      ).Cast<dynamic>().ToList();

            return mapeoFormula(expresion, listaVariables)
                   .toResolveFormula(resolve);
        }


        public decimal calculateFormula<T>(T data)
        {
            var field = getField();
            var properties = getProperties(data, field);
            changeValuefromFieldCriterio(data, properties);

            return resolveFormula();
        }

        public string getFormula() 
        {
            return formula;
        }

        private void changeValuefromFieldCriterio<T>(T data, List<PropertyInfo> properties)
        {
            variables.ForEach(variable =>
            {
                if (variable.getTypeVariable() ==TypeVariable.RANK)
                    
                    variable.getRanks().ToList().ForEach(rango =>
                    {
                        var value = decimal.Parse(properties.FirstOrDefault(x => x.Name == rango.getFieldCriterion().name).GetValue(data).ToString());

                        rango.changeValueFieldCriterion(value);

                    });

                if (variable.getTypeVariable() == TypeVariable.CRITERION)

                    variable.expression.getFieldsCriterion().ForEach(field =>
                    {
                        var value = decimal.Parse(properties.FirstOrDefault(x=>x.Name==field.name).GetValue(data).ToString());

                        field.changeValueFieldCriterion(value);

                    });

            });
        }

        private List<PropertyInfo> getProperties<T>(T data, List<FieldCriterion> fields)
        {
            var result = new List<PropertyInfo>();
            var properties = data.GetType().GetProperties().Where(x => x.PropertyType == typeof(decimal) && x.CanRead && x.CanWrite).ToList();

            fields.ForEach(field =>
            {
                properties.ForEach(properti =>
                {
                    if (field.name == properti.Name)
                        result.Add(properti);
                });

            });

            return result;
        }

        private List<FieldCriterion> getField()
        {
            var fields = new List<FieldCriterion>();
            variables.ForEach(variable =>
            {
                if(variable.getRanks()!=null)
                    variable.getRanks().ToList().ForEach(rango =>
                    {
                        if(!fields.Contains(rango.getFieldCriterion()))
                            fields.Add(rango.getFieldCriterion());
                    });
            });

            return fields;
        }

        private string mapeoFormula(string expresionFormula, List<dynamic> variables) 
        {
            variables.ForEach(x => 
            { 
                expresionFormula = expresionFormula.Replace(x.variable, x.valor.ToString()); 
            }
            );
            formula = expresionFormula;
            return expresionFormula;
        }
    }

}
