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

            message.FormulaStart();
            workflow.StartWorkflow();
            message.exitFormula();

            Console.ReadLine();


        }
    }
}
