using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Models
{
    public class ParenthesesModel
    {
        public bool AddSwith { get; set; }
        public int IndexOfFirstParen { get; set; }
        public int IndexOfLastParen { get; set; }
        public List<string> ParenthesesContent { get; set; }
    }
}
