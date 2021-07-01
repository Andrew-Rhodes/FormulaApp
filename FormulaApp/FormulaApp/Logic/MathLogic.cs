using FormulaApp.Models;
using FormulaApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Logic
{
    public class MathLogic
    {
        SolvedModel SM = new SolvedModel();

        internal SolvedModel GetMathStuff(List<string> equationToSolve, int indexOfOperation, string operation)
        {
            //add validation
            decimal firstNum;
            decimal.TryParse(equationToSolve[indexOfOperation - 1], out firstNum);

            decimal secondNum;
            decimal.TryParse(equationToSolve[indexOfOperation + 1], out secondNum);

            SM.ValueReturned = OperationSwitch(operation, firstNum, secondNum);

            if (SM.DivideByZero == false)
            {
                equationToSolve.Insert(indexOfOperation + 2, SM.ValueReturned.ToString());
                SM.IndexofEquation = indexOfOperation + 2;
            }

            return SM;
        }

        private decimal OperationSwitch(string operation, decimal firstNum, decimal secondNum)
        {
            decimal operationValue = 0;

            switch (operation)
            {
                case "M":
                    operationValue = firstNum * secondNum;
                    break;
                case "D":
                    if (secondNum != 0)
                    {
                        operationValue = firstNum / secondNum;
                    }
                    else
                    {
                        Messages MS = new Messages();
                        MS.AlertDivideByZero();
                        operationValue = 0;
                        SM.DivideByZero = true;
                    }
                    break;
                case "A":
                    operationValue = firstNum + secondNum;
                    break;
                case "S":
                    operationValue = firstNum - secondNum;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            return operationValue;
        }
    }
}
