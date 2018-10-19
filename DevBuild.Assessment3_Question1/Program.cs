using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBuild.Utilities;

namespace DevBuild.Assessment2_Question1
{
    class Program
    {
        static int arraySize = 0;
        static double[] userValues;
        static string userResponse = "";

        static void Main(string[] args)
        {
            double maxArrayValue = 0.00;
            while (true)
            {
                //Console.WriteLine("Please enter the number of values we'll be entering: ");
                
                while (!int.TryParse(userResponse, out arraySize) || arraySize < 1)
                {
                    UserInput.PromptUntilValidEntry("Please enter the number of values we'll be entering (number needs to be greater than zero): ", ref userResponse, InformationType.Numeric);
                }
                userValues = new double[arraySize];
                userResponse = "";

                for (int i = 0; i < userValues.Length; i++)
                {
                    Console.Write("Please enter a number: ");
                    while (!double.TryParse(Console.ReadLine(), out userValues[i]))
                    {
                        Console.Write("Invalid entry. Please enter a number: ");
                    }
                }

                foreach (double k in userValues)
                {
                    if (k > maxArrayValue) { maxArrayValue = k; }
                }
                Console.WriteLine("Maximum value of the numbers you entered is: \n{0} . ", maxArrayValue);

                maxArrayValue = 0;
                userResponse = "";
                userValues = null;

                YesNoAnswer yesNoAnswer = UserInput.GetYesOrNoAnswer("Would you like to enter another set of numbers? ");

                switch (yesNoAnswer)
                {
                    case YesNoAnswer.Yes: continue;
                    case YesNoAnswer.No: return;
                }
            }
        }
    }
}
