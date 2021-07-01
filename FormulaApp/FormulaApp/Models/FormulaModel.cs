using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Models
{
    public class FormulaModel
    {
        public string Formula { get; set; }
        public List<string> FormulaListSplit { get; set; }
        public List<string> FormulaListNoVar { get; set; }
        public List<string> FormulaListNoParentheses { get; set; }
        public string ValueToReturn { get; set; }

    }
}
