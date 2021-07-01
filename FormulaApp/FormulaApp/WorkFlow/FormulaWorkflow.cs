using FormulaApp.Logic;
using FormulaApp.Models;
using FormulaApp.UI;
using FormulaApp.Validation;
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
        PEMDAS _pemdas = new PEMDAS();
        CodeValidation _validation = new CodeValidation();

        public string StartWorkflow()
        {
            //_formula.Formula = Console.ReadLine();
            //_formula.Formula = "-1.5y+x3";  "-1.5*1+2*3"
            //_formula.Formula = "+1.5y+x3";
            //_formula.Formula = "(x2)";
            //_formula.Formula = "-(x2)";
            //_formula.Formula = "+(x2)";
            //_formula.Formula = "";
            //_formula.Formula = "(x2";
            //_formula.Formula = "1*2/3+4-5";
            //_formula.Formula = "5-4+3/2*1";
            //_formula.Formula = "5-4+3-2+1";
            //_formula.Formula = "5+4+3-2-1";
            //_formula.Formula = "5*4/3*2/1";
            //_formula.Formula = "5*4*3/2/1";
            //_formula.Formula = "(3+2)-3)";
            //_formula.Formula = "(3+2)+(3+2";
            //_formula.Formula = "x2+5/99*7x-54*567";
            //_formula.Formula = "2/0";
            //_formula.Formula = "0/2";





            //bug
            //_formula.Formula = "-5*-9";
            //_formula.Formula = "3*-6";
            //_formula.Formula = "(2)(4)";
            //_formula.Formula = "((3+2)-3)";
            //_formula.Formula = "2(3+2)+(3+2)";
            //_formula.Formula = "(3+2)+(3+3)";
            //_formula.Formula = "x2+5/99*7y-54*567/0";



            _formula.Formula = _validation.validateFormula(_formula.Formula);
            splitString();
            SplitNumberVariableCombos();
            StartingNumberSymbol();
            Evaluate();
            return _formula.ValueToReturn;

        }

        private void SplitNumberVariableCombos()
        {
            _formula.FormulaListSplit = _listManipulation.SplitNumberVariableCombos(_formula.FormulaListSplit);
        }

        private void StartingNumberSymbol()
        {
            _formula.FormulaListSplit = _listManipulation.StartingNumberSymbol(_formula.FormulaListSplit);
        }

        private void splitString()
        {
            _formula.FormulaListSplit = _listManipulation.SplitUserInput(_formula.Formula);
            _formula.FormulaListSplit = _formula.FormulaListSplit.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        }

        private void Evaluate()
        {
            _formula.FormulaListNoVar = CheckForVariables(_formula.FormulaListSplit);
            _formula.FormulaListNoParentheses = _formula.FormulaListNoVar.Contains("(") ? HasParentheses(_formula.FormulaListNoVar) : _formula.FormulaListNoVar;
            StartingNumberSymbol();
            _pemdas.SolveWithPemdas(_formula.FormulaListNoParentheses, 0);

            if (_formula.FormulaListNoParentheses.Count == 0)
            {
                _formula.ValueToReturn = "Cannot Divide by 0";
            }
            else
            {
                _formula.ValueToReturn = decimal.Parse(_formula.FormulaListNoParentheses[0]).ToString();
            }
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
