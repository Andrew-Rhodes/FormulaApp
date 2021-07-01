using FormulaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Logic
{
    public class ParenthesesLogic
    {
        ParenthesesModel PM = new ParenthesesModel();
        ListManipulation LM = new ListManipulation();

        internal List<string> ParenthesesWorkflow(FormulaModel FM)
        {
            // check for nested parentheses
            //check for adjecent ()()
            //check for int()
            GetParenthesesContent(FM.FormulaListNoVar);
            FM.FormulaListNoVar.RemoveRange(PM.IndexOfFirstParen, PM.IndexOfLastParen - PM.IndexOfFirstParen + 1);

            SolveParenthesesArea(PM.ParenthesesContent, 0);

            FM.FormulaListNoVar.Insert(PM.IndexOfFirstParen, PM.ParenthesesContent[0].ToString());
            FM.FormulaListNoParentheses = FM.FormulaListNoVar;

            return FM.FormulaListNoParentheses;
        }

        private void GetParenthesesContent(List<string> formulaNoVaribles)
        {
            List<string> content = new List<string>();
            bool addSwith = false;

            for (int i = 0; i < formulaNoVaribles.Count; i++)
            {
                if (formulaNoVaribles[i] == "(")
                {
                    addSwith = !addSwith;
                    PM.IndexOfFirstParen = formulaNoVaribles.IndexOf(formulaNoVaribles[i]);
                }

                if (addSwith)
                {
                    content.Add(formulaNoVaribles[i]);

                    if (formulaNoVaribles[i] == ")")
                    {
                        addSwith = !addSwith;
                        PM.IndexOfLastParen = formulaNoVaribles.IndexOf(formulaNoVaribles[i]);
                    }
                }
            }

            PM.ParenthesesContent = content;
        }

        private decimal SolveParenthesesArea(List<string> ParenthesesContent, decimal value)
        {

            ParenthesesContent.Remove("(");
            ParenthesesContent.Remove(")");
            decimal valueToReturn = value;

            PEMDAS pemdas = new PEMDAS();

            value = pemdas.SolveWithPemdas(ParenthesesContent, value);

            return decimal.Parse(ParenthesesContent[0]);

            //if (ParenthesesContent.Count == 1)
            //{
            //    return valueToReturn;
            //}

            //bool hasMultiply = ParenthesesContent.Contains("*");
            //bool hasDivide = ParenthesesContent.Contains("/");
            //bool hasAddition = ParenthesesContent.Contains("+");
            //bool hasSubtratcion = ParenthesesContent.Contains("-");

            //int multipleIndex = ParenthesesContent.IndexOf("*");
            //int divisionIndex = ParenthesesContent.IndexOf("/");
            //int additionIndex = ParenthesesContent.IndexOf("+");
            //int subtractionIndex = ParenthesesContent.IndexOf("-");

            //if (hasMultiply && hasDivide && ParenthesesContent.Count != 1)
            //{
            //    if (divisionIndex > multipleIndex)
            //    {
            //        if (hasMultiply && ParenthesesContent.Count != 1)
            //        {
            //            DoMath("M", valueToReturn, ParenthesesContent, multipleIndex);
            //        }
            //    }
            //    else
            //    {
            //        if (hasDivide && ParenthesesContent.Count != 1)
            //        {
            //            DoMath("D", valueToReturn, ParenthesesContent, divisionIndex);
            //        }
            //    }
            //}

            //if (hasMultiply && ParenthesesContent.Count != 1)
            //{
            //    DoMath("M", valueToReturn, ParenthesesContent, multipleIndex);
            //}

            //if (hasDivide && ParenthesesContent.Count != 1)
            //{
            //    DoMath("D", valueToReturn, ParenthesesContent, divisionIndex);
            //}

            //if (hasAddition && hasSubtratcion && ParenthesesContent.Count != 1)
            //{
            //    if (subtractionIndex > additionIndex)
            //    {
            //        if (hasAddition && ParenthesesContent.Count != 1)
            //        {
            //            DoMath("A", valueToReturn, ParenthesesContent, additionIndex);
            //        }
            //    }
            //    else
            //    {
            //        if (hasSubtratcion && ParenthesesContent.Count != 1)
            //        {
            //            DoMath("S", valueToReturn, ParenthesesContent, subtractionIndex);
            //        }
            //    }
            //}

            //if (hasAddition && ParenthesesContent.Count != 1)
            //{
            //    DoMath("A", valueToReturn, ParenthesesContent, additionIndex);
            //}

            //if (hasSubtratcion && ParenthesesContent.Count != 1)
            //{
            //    DoMath("S", valueToReturn, ParenthesesContent, subtractionIndex);
            //}

            //return valueToReturn;
        }

        private void DoMath(string typeOfOperation, decimal valueToReturn, List<string> parenthesesContent, int indexOfOperation)
        {
            MathLogic ML = new MathLogic();
            SolvedModel SM = new SolvedModel();

            //SM = ML.GetMathStuff(parenthesesContent, indexOfOperation, typeOfOperation);
            //parenthesesContent = LM.RemoveOperation(parenthesesContent, valueToReturn);
            //SolveParenthesesArea(parenthesesContent, valueToReturn);
        }
    }
}


