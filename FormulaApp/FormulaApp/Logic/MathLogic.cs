using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Logic
{
    public class MathLogic
    {
        internal decimal GetMathStuff(List<string> parenthesesContent, int indexOfOperation, string operation)
        {
            //add validation
            decimal firstNum;
            decimal.TryParse(parenthesesContent[indexOfOperation - 1], out firstNum);

            decimal secondNum;
            decimal.TryParse(parenthesesContent[indexOfOperation + 1], out secondNum);

            decimal valueToReturn = OperationSwitch(operation, firstNum, secondNum);

            parenthesesContent.Insert(indexOfOperation + 2, valueToReturn.ToString());

            return valueToReturn;
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
                    operationValue = firstNum / secondNum;
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
