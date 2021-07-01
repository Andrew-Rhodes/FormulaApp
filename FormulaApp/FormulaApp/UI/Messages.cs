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
            Console.WriteLine("Andrew");
        }

        internal string getVariableValue(string stringVariable)
        {
            Console.WriteLine("What is the value of '" + stringVariable + "'");
            bool success = false;
            string userInput = Console.ReadLine();

            decimal number;
            success = decimal.TryParse(userInput, out number);

            while (!success)
            {
                success = decimal.TryParse(userInput, out number);

                if (!success)
                {
                    Console.WriteLine("Invalid Number....Enter a valid Number");
                    userInput = Console.ReadLine();
                }
            }

            return userInput;
        }

        internal void DisplayReturnedValue(string valueToReturn)
        {
            Console.WriteLine("Your value is " + valueToReturn);
            Console.WriteLine("Enter a formula to continue.");
        }

        internal string AlertEmpty()
        {
            Console.WriteLine("You have not entered a formula....");
            Console.WriteLine("Enter a formula to continue.");

            bool success = false;
            string userInput = Console.ReadLine();


            while (!success)
            {
                success = String.IsNullOrEmpty(userInput) ? false : true;

                if (!success)
                {
                    Console.WriteLine("You have not entered a formula....");
                    Console.WriteLine("Enter a formula to continue.");
                    userInput = Console.ReadLine();
                }
            }

            return userInput;
        }

        internal string AlertDivideByZero()
        {
            Console.WriteLine("Cannot divide by zero");
            Console.WriteLine("Enter in another formula");

            return "0";
        }

        internal string NotBalenced()
        {
            Console.WriteLine("Your formula is not balanced....");
            Console.WriteLine("Please open and Close all of your ()");
            Console.WriteLine("Enter a formula to continue.");

            bool success = false;
            string userInput = Console.ReadLine();


            while (!success)
            {
                success = checkForBalencedParen(userInput);

                if (!success)
                {
                    Console.WriteLine("Your formula is not balanced....");
                    Console.WriteLine("Please open and Close all of your ()");
                    Console.WriteLine("Enter a formula to continue.");

                    userInput = Console.ReadLine();
                }
            }

            return userInput;
        }


        private bool checkForBalencedParen(string formula)
        {
            bool success = false;
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
                        success = true;
                    }
                    if (!wellFormated)
                    {
                        success = false;
                    }
                }
            }

            if (stack.Count > 0)
            {
                success = false;
            }
            return success;
        }
    }
}
