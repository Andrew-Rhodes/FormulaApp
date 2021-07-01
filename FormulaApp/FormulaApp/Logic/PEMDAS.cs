using FormulaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Logic
{
    public class PEMDAS
    {
        ListManipulation LM = new ListManipulation();
        SolvedModel SM = new SolvedModel();
        MathLogic ML = new MathLogic();

        public decimal SolveWithPemdas(List<string> equationToSolve, decimal value)
        {
            if (SM.DivideByZero == true)
            {
                return 0;
            }


            decimal valueToReturn = value;

            bool hasMultiply = equationToSolve.Contains("*");
            bool hasDivide = equationToSolve.Contains("/");
            bool hasAddition = equationToSolve.Contains("+");
            bool hasSubtratcion = equationToSolve.Contains("-");
            int multipleIndex = equationToSolve.IndexOf("*");
            int divisionIndex = equationToSolve.IndexOf("/");
            int additionIndex = equationToSolve.IndexOf("+");
            int subtractionIndex = equationToSolve.IndexOf("-");

            if (hasMultiply && hasDivide && equationToSolve.Count != 1)
            {
                if (divisionIndex > multipleIndex)
                {
                    if (hasMultiply && equationToSolve.Count != 1)
                    {
                        DoMath("M", valueToReturn, equationToSolve, multipleIndex);
                    }
                }
                else
                {
                    if (hasDivide && equationToSolve.Count != 1)
                    {
                        DoMath("D", valueToReturn, equationToSolve, divisionIndex);
                    }
                }
            }

            if (hasMultiply && equationToSolve.Count != 1)
            {
                DoMath("M", valueToReturn, equationToSolve, multipleIndex);
            }

            if (hasDivide && equationToSolve.Count != 1)
            {
                DoMath("D", valueToReturn, equationToSolve, divisionIndex);
            }

            if (hasAddition && hasSubtratcion && equationToSolve.Count != 1)
            {
                if (subtractionIndex > additionIndex)
                {
                    if (hasAddition && equationToSolve.Count != 1)
                    {
                        DoMath("A", valueToReturn, equationToSolve, additionIndex);
                    }
                }
                else
                {
                    if (hasSubtratcion && equationToSolve.Count != 1)
                    {
                        DoMath("S", valueToReturn, equationToSolve, subtractionIndex);
                    }
                }
            }

            if (hasAddition && equationToSolve.Count != 1)
            {
                DoMath("A", valueToReturn, equationToSolve, additionIndex);
            }

            if (hasSubtratcion && equationToSolve.Count != 1)
            {
                DoMath("S", valueToReturn, equationToSolve, subtractionIndex);
            }

            return valueToReturn;
        }

        private void DoMath(string typeOfOperation, decimal valueToReturn, List<string> equationContent, int indexOfOperation)
        {
            SM = ML.GetMathStuff(equationContent, indexOfOperation, typeOfOperation);

            if (SM.DivideByZero == false)
            {
                equationContent = LM.RemoveOperation(equationContent, valueToReturn, SM.IndexofEquation);
            }

            if (SM.DivideByZero == true)
            {
                equationContent.Clear();
            }

            SolveWithPemdas(equationContent, valueToReturn);
        }
    }
}
