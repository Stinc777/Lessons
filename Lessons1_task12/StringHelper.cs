using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons1_task12
{
    internal class StringHelper
    {
        public static string DoubleCharactersInString(string inputString, string charactersToDouble)
        {
            foreach (char c in charactersToDouble)
            {
                inputString = inputString.Replace(c.ToString(), new string(c, 2));
            }

            return inputString;
        }
    }
}
