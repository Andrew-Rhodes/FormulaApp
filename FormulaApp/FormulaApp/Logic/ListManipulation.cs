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
                    splitFormula[i] = variableValue;
                }
            }

            return splitFormula;
        }

        internal List<string> SplitNumberVariableCombos(List<string> formulaListSplit)
        {
            for (var i = 0; i < formulaListSplit.Count; i++)
            {
                List<string> concatList = new List<string>();
                string evaluating = formulaListSplit[i];
                bool hasLetters = Regex.IsMatch(evaluating, @"[a-zA-Z]");
                bool hasNumbers = evaluating.Any(char.IsDigit);

                if (hasLetters && hasNumbers)
                {
                    var charArray = evaluating.ToArray();

                    for (int j = 0; j < charArray.Length; j++)
                    {
                        int number;
                        bool success = int.TryParse(charArray[j].ToString(), out number);

                        if (!success && charArray[j].ToString() != ".")
                        {
                            concatList = evaluating.Split(charArray[j]).ToList();
                            concatList.Add("*");
                            concatList.Add(charArray[j].ToString());
                            concatList = concatList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                            if (Char.IsLetter(charArray[0]))
                            {
                                concatList.Reverse();
                            }
                        }
                    }

                    for (int k = concatList.Count - 1; k >= 0; k--)
                    {
                        formulaListSplit.Insert(i + 1, concatList[k]);
                    }

                    formulaListSplit.Remove(formulaListSplit[i]);
                }
            }

            return formulaListSplit;
        }

        internal List<string> StartingNumberSymbol(List<string> formulaListSplit)
        {
            {
                if (formulaListSplit.FirstOrDefault() == "-")
                {
                    decimal number = 0;
                    bool success = decimal.TryParse(formulaListSplit[1], out number); 

                    if (success)
                    {
                        formulaListSplit.RemoveAt(0);
                        formulaListSplit.Insert(0, (number * -1).ToString());
                        formulaListSplit.RemoveAt(1);
                    }
                }

                if (formulaListSplit.FirstOrDefault() == "+")
                {
                    formulaListSplit.Remove(formulaListSplit.FirstOrDefault());
                }

                return formulaListSplit;
            }
        }


        private string GetValueOfVariable(string stringVariable)
        {
            Messages message = new Messages();
            return message.getVariableValue(stringVariable);
        }

        internal List<string> RemoveOperation(List<string> equationContent, decimal valueToReturn, int indexOfOperation)
        {
            int startPoint = indexOfOperation - 1;
            equationContent.RemoveAt(indexOfOperation - 1);
            equationContent.RemoveAt(startPoint - 1);
            equationContent.RemoveAt(startPoint - 2);

            return equationContent;
        }
    }
}
