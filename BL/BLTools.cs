using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    class BLTools
    {
        /// <summary>
        /// The function compares 2 strings with up to 2 misspellings to one word
        /// </summary>
        /// <param name="original">The original string you want to check</param>
        /// <param name="compared">The new string that they want to compare to the original</param>
        /// <param name="maxErrors">Maximum number of incorrect letters in sequence</param>
        /// <returns>True if the strings are similar, false if not</returns>
        public bool Similar(string original, string compared, int maxErrors = 1)
        {
            bool result = false;

            List<Regex> regexList = new List<Regex>();
            for (int i = 1; i < compared.Length + 1; i++)
            {
                string prefix = compared.Substring(0, i - 1);
                string suffix = compared.Substring(i);

                string regex = "";
                for (int j = 0; j < maxErrors; j++)
                    regex += "\\w?";

                regexList.Add(new Regex(".*" + prefix + regex + suffix + ".*"));
            }

            foreach (Regex regex in regexList)
            {
                if (regex.IsMatch(original))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
