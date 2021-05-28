using CoreDynamic;
using CoreDynamic.MathCore;
using CoreDynamic.util;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public partial class FormulaShould
    {
        Formula _formula = null;
        public FormulaShould()
        {

            var operadorMenorQue = new Operator("<");
            var operadorMayorIgualQue = new Operator(">=");

            var campoCriterio1 = new FieldCriterion(1, "Cantidad_Contratos", 0);//4

            var range1 = new Rank(1, operadorMenorQue, 1, 0.5M);

            range1.isPorcentage();
            range1.addFieldCriterion(campoCriterio1);

            var range2 = new Rank(1, operadorMenorQue, 5, 0.8M);

            range2.isPorcentage();
            range2.addFieldCriterion(campoCriterio1);

            var range3 = new Rank(1, operadorMenorQue, 10, 0.9M);

            range3.isPorcentage();
            range3.addFieldCriterion(campoCriterio1);

            var range4 = new Rank(1, operadorMenorQue, 15, 1.0M);
            range4.isPorcentage();
            range4.addFieldCriterion(campoCriterio1);

            var range5 = new Rank(1, operadorMayorIgualQue, 15, 1.2M);
            range5.isPorcentage();
            range5.addFieldCriterion(campoCriterio1);

            var PorcentajeComision = new Variable(1, "PorcentajeComision");
            PorcentajeComision.isRank();
            PorcentajeComision.addRanks(new List<Rank>() { range1, range2, range3, range4, range5 });

            var campoCriterio2 = new FieldCriterion(1, "Porcentaje_Persistencia", 0);//0.8

            var range21 = new Rank(1, operadorMenorQue, 0.70M, 0.5M);
            range21.isPorcentage();
            range21.addFieldCriterion(campoCriterio2);

            var range22 = new Rank(1, operadorMenorQue, 0.75M, 0.7M);
            range22.isPorcentage();
            range22.addFieldCriterion(campoCriterio2);

            var range23 = new Rank(1, operadorMenorQue, 0.85M, 0.9M);
            range23.isPorcentage();
            range23.addFieldCriterion(campoCriterio2);

            var range24 = new Rank(1, operadorMayorIgualQue, 0.85M, 1.0M);
            range24.isPorcentage();
            range24.addFieldCriterion(campoCriterio2);

            var PorcentajePersistencia = new Variable(1, "PorcentajePersistencia");
            PorcentajePersistencia.isRank();
            PorcentajePersistencia.addRanks(new List<Rank>() { range21, range22, range23, range24 });

            var campoCriterio31 = new FieldCriterion(1, "Cantidad_Contratos", 0);//4

            var expresion = new VariableExpression("Cantidad_Contratos*0.5", new List<FieldCriterion>() { campoCriterio31 });

            var PorcentajeSegundoPago = new Variable(1, "PorcentajeSegundoPago", expresion);
            PorcentajeSegundoPago.isCriterion();
            
            _formula = new Formula(1, "Calculo de Persistencia", "PorcentajeComision*PorcentajePersistencia*PorcentajeSegundoPago");
            
            _formula.addVariable(PorcentajeComision);
            _formula.addVariable(PorcentajePersistencia);
            _formula.addVariable(PorcentajeSegundoPago);
        }
        [Fact]
        public void verifyValueFor_Formula()
        {
            var resultado= _formula.resolveFormula();

            resultado.Should().Be(1.12M);
        }

        [Fact]
        public void verifyFormula_with_ListData()
        {
            var Fecha_inicial = DateTime.Now.AddDays(-2);
            var Fecha_final = DateTime.Now;

            var tabla_Contratos = new tabla(1, "contratos", new List<Campo>() { new Campo(1, "Cantidad_Contratos"), new Campo(1, "Cantidad_x") });
            var tabla_Persistencia = new tabla(1, "persistencia", new List<Campo>() { new Campo(1, "Porcentaje"), new Campo(1, "OtroCampo") });
            var tabla_SegundoPago = new tabla(1, "segundopago", new List<Campo>() { new Campo(1, "Porcentaje"), new Campo(1, "OtroCampo") });

            var listatablas = new List<tabla>() { tabla_Contratos, tabla_Persistencia, tabla_SegundoPago };

            var pedro = new Persona(1,"pedro","garcias","asesor");
            var alexander = new Persona(2, "alexander", "garcias", "asesor");
            var gerald = new Persona(3, "gerald", "garcias", "asesor");
            var carlos = new Persona(4, "carlos", "garcias", "asesor");
            var maria = new Persona(5, "maria", "garcias", "asesor");

            var pedro_antiguedad = new Antiguedad(1, "descripcion1", 10, pedro);
            var alexander_antiguedad = new Antiguedad(2, "descripcion1", 0, alexander);
            var gerald_antiguedad = new Antiguedad(3, "descripcion1", 5, gerald);
            var carlos_antiguedad = new Antiguedad(4, "descripcion1", 2, carlos);
            var cmaria_antiguedad = new Antiguedad(5, "descripcion1", 7, maria);


            var persistencia_pedro = new Persistencia(1, pedro, 0.1M, 1, 2021, Fecha_inicial, Fecha_final, 5, 5);
            var persistencia_alexander = new Persistencia(1, alexander, 0.8M, 1, 2021, Fecha_inicial, Fecha_final, 2, 1);
            var persistencia_gerald = new Persistencia(1, gerald, 0.5M, 1, 2021, Fecha_inicial, Fecha_final, 10, 5);
            var persistencia_carlos = new Persistencia(1, carlos, 0.2M, 1, 2021, Fecha_inicial, Fecha_final, 2, 2);
            var persistencia_maria = new Persistencia(1, maria, 0.9M, 1, 2021, Fecha_inicial, Fecha_final, 10, 9);


            var segundo_pedro = new SegundoPago(1, pedro, 0.2M, 1, 2021, Fecha_inicial, Fecha_final, 5, 5);
            var segundo_alexander = new SegundoPago(1, alexander, 0.7M, 1, 2021, Fecha_inicial, Fecha_final, 2, 1);
            var segundo_gerald = new SegundoPago(1, gerald, 0.3M, 1, 2021, Fecha_inicial, Fecha_final, 10, 5);
            var segundo_carlos = new SegundoPago(1, carlos, 0.5M, 1, 2021, Fecha_inicial, Fecha_final, 2, 2);
            var psegundo_maria = new SegundoPago(1, maria, 0.4M, 1, 2021, Fecha_inicial, Fecha_final, 10, 9);

            var Lista_Antiguedad = new List<Antiguedad>() { pedro_antiguedad, alexander_antiguedad, gerald_antiguedad, carlos_antiguedad, cmaria_antiguedad };
            var Lista_Persistencia = new List<Persistencia>() { persistencia_pedro, persistencia_alexander, persistencia_gerald, persistencia_carlos, persistencia_maria };
            var Lista_SegundoPago = new List<SegundoPago>() { segundo_pedro, segundo_alexander, segundo_gerald, segundo_carlos, psegundo_maria };

            _formula.setMathResolve(new MathXParserResolve());

            var Listdata = (from a in Lista_Antiguedad
                        join p in Lista_Persistencia on a.persona.Id equals p.persona.Id
                        join s in Lista_SegundoPago on p.persona.Id equals s.persona.Id
                        select new DataRepositorio
                        {
                            
                            nombre = a.persona.Nombre,
                            Porcentaje_Persistencia = p.Porcentaje,
                            porcentaje_segundoPago = s.Porcentaje,
                            Cantidad_Contratos = s.Cantidad_Contratos,
                            Cantidad_Solventes = s.Contratos_Solventes
                        }
                       ).ToList();


            var result = (from x in Listdata
                          select new DataRepositorio
                          {
                              nombre=x.nombre,
                              Porcentaje_Persistencia = x.Porcentaje_Persistencia,
                              porcentaje_segundoPago = x.porcentaje_segundoPago,
                              Cantidad_Contratos = x.Cantidad_Contratos,
                              Cantidad_Solventes = x.Cantidad_Solventes,
                              comision = x.Cantidad_Solventes * _formula.calculateFormula(x),
                              formula=_formula.getFormula()
                          }
                          ).ToList();



            //resultado.Should().Be(1.12M);
        }

       
    }
}
