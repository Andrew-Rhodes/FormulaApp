using FormulaApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormulaApp.Logic
{
    public class ListManipulation
    {
        internal List<string> SplitUserInput(string stringFormulaToEvaluate)
        {
            Regex rx = new Regex(@"(?<=[-+*/()])|(?=[-+*/()])", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.Split(stringFormulaToEvaluate).ToList();
        }

        internal List<string> GetValuesForVariables(List<string> splitFormula)
        {
            for (var i = 0; i < splitFormula.Count; i++)
            {
                string evaluating = splitFormula[i];
                bool isLetter = Regex.IsMatch(evaluating, @"^[a-zA-Z]+$");

                if (isLetter)
                {
                    string variableValue = GetValueOfVariable(evaluating);
                    //check that a number was input
                    splitFormula[i] = variableValue;
                }
            }

            return splitFormula;
        }

        private string GetValueOfVariable(string stringVariable)
        {
            Messages message = new Messages();
            return message.getVariableValue(stringVariable);
        }

        internal List<string> RemoveOperation(List<string> parenthesesContent, decimal valueToReturn
            )
        {
            var start = parenthesesContent.IndexOf(valueToReturn.ToString());
            parenthesesContent.RemoveAt(start - 1);

            start = parenthesesContent.IndexOf(valueToReturn.ToString());
            parenthesesContent.RemoveAt(start - 1);

            start = parenthesesContent.IndexOf(valueToReturn.ToString());
            parenthesesContent.RemoveAt(start - 1);

            return parenthesesContent;
        }
    }
}
