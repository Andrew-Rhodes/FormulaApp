using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.UI
{
    public class Messages
    {
        public void FormulaStart()
        {
            Console.WriteLine("Enter Formula");
        }

        public void exitFormula()
        {
            Console.WriteLine("Thanks,");
            Console.WriteLine("Andy");
        }

        internal string getVariableValue(string stringVariable)
        {
            Console.WriteLine("What is the value of '" + stringVariable + "'");
            return Console.ReadLine();
        }
    }
}
