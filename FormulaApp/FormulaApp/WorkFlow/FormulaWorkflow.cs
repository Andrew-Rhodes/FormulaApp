using FormulaApp.Logic;
using FormulaApp.Models;
using FormulaApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormulaApp.WorkFlow
{
    public class FormulaWorkflow
    {
        ListManipulation _listManipulation = new ListManipulation();
        ParenthesesLogic _parenthesesLogic = new ParenthesesLogic();
        FormulaModel _formula = new FormulaModel();

        public void StartWorkflow()
        {
            //_formula.Formula = Console.ReadLine();
            // check for balanced parentheses
            _formula.Formula = "-1.5+xu*(2*5+2-1/4*2)";

            //check for neg first number

            splitString();
            Evaluate();
        }

        private void splitString()
        {
            _formula.FormulaListSplit = _listManipulation.SplitUserInput(_formula.Formula);
        }

        private void Evaluate()
        {
            _formula.FormulaListNoVar = CheckForVariables(_formula.FormulaListSplit);
            _formula.FormulaListNoParentheses = _formula.FormulaListNoVar.Contains("(") ? HasParentheses(_formula.FormulaListNoVar) : _formula.FormulaListNoVar;
        }

        private List<string> CheckForVariables(List<string> splitFormula)
        {
            return _listManipulation.GetValuesForVariables(splitFormula);
        }

        private List<string> HasParentheses(List<string> formulaNoVaribles)
        {
            return _parenthesesLogic.ParenthesesWorkflow(_formula);
        }
    }
}
