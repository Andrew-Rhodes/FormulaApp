using FormulaApp.UI;
using FormulaApp.WorkFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Messages message = new Messages();
            FormulaWorkflow workflow = new FormulaWorkflow();



            //add loop
            message.FormulaStart();
            string valueToReturn = workflow.StartWorkflow();

            message.DisplayReturnedValue(valueToReturn);
            message.exitFormula();

            Console.ReadLine();
        }
    }
}
