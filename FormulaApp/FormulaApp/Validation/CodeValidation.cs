using FormulaApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Validation
{
    public class CodeValidation
    {
        Messages MS = new Messages();

        internal string validateFormula(string formula)
        {
            string isNotEmpty = checkForEmpty(formula);
            string isBalenced = checkForBalencedParen(isNotEmpty);

            return isBalenced;
        }

        private string checkForBalencedParen(string formula)
        {
            var stack = new Stack<char>();
            var allowedChars = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' } };

            var wellFormated = true;
            foreach (var chr in formula)
            {
                if (allowedChars.ContainsKey(chr))
                {
                    stack.Push(chr);
                }
                else if (allowedChars.ContainsValue(chr))
                {
                    wellFormated = stack.Any();
                    if (wellFormated)
                    {
                        var startingChar = stack.Pop();
                        wellFormated = allowedChars.Contains(new KeyValuePair<char, char>(startingChar, chr));
                    }
                    if (!wellFormated)
                    {
                        formula = MS.NotBalenced();
                    }
                }

            }

            if (stack.Count > 0)
            {
                formula = MS.NotBalenced();
            }
            return formula;

        }

        private string checkForEmpty(string formula)
        {
            if(String.IsNullOrEmpty(formula))
            {
                formula = MS.AlertEmpty();
            }

            return formula;
        }
    }
}
