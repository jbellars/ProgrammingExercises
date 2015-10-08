using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TitleCapitalization
{
    class Program
    {
        /* 
         * Exercise from Pluralsight.com
         *
         * Title Capitalization
         * 
         * Problem scenario: Many writers are often confused by the different methods of capitalizing titles. There are several forms of capitalization rules, but one of the most popular is called 'title case' or 'up style.' Implement a function that will take a title in the form of a string and return the string with the correct capitalization for a title according to these rules.
         * 
         * Always capitalize the first word in a title.
         * Always capitalize the last word in a title.
         * Lowercase the following words, unless they are the first or last word of a title:
         * "a", "an", "the", "to", "at", "in", "with", "and", "but", "or", "for", "nor", "on", "up", "by", "as"
         * Uppercase the words not in the list above.
         * 
         * A word is defined as a series of non-space characters.
         * 
         * Example 1: "i love solving problems and it is fun"
         * Example 2: "wHy DoeS A biRd Fly?"
         */

        static void Main(string[] args)
        {
            const string example1 = "i love solving problems and it is fun";
            const string example2 = "wHy DoeS A biRd Fly?";
            
            // Pseudo-code solution:
            // lowercase everything
            // split sentence into words
            // determine first and last word [0] and [count-1]
            // uppercase the first letter of the first and last word
            // check other words against exception list
               // uppercase non-matches
            // recombine words into original sequence

            Console.WriteLine(example1 + ": " + ConvertToTitleCase(example1));
            Console.WriteLine(example2 + ": " + ConvertToTitleCase(example2));
            Console.ReadLine();

            RepeatUntilDone();
        }

        protected static void RepeatUntilDone()
        {
            var continueYn = true;

            while (continueYn)
            {
                Console.Write("Please enter a title to be corrected: ");
                var input = Console.ReadLine();
                Console.WriteLine(ConvertToTitleCase(input));
                Console.WriteLine("Continue? (y/n)");
                var x = Console.ReadLine();
                if (!string.IsNullOrEmpty(x))
                {
                    continueYn = x.ToLower() == "y";
                }
                else
                {
                    continueYn = false;
                }
            }
        }

        protected static string ConvertToTitleCase(string example)
        {
            var result = LowerCaseEverything(example);
            var lstWords = ReturnArrayFromSplitString(result);
            lstWords = DetermineCaps(lstWords);
            lstWords[0] = UpperCaseFirstLetter(lstWords.First());
            lstWords[lstWords.Count() - 1] = UpperCaseFirstLetter(lstWords.Last());
            return ReassembleTitle(lstWords);
        }

        protected static string LowerCaseEverything(string s)
        {
            return s.ToLower();
        }

        protected static string[] ReturnArrayFromSplitString(string s)
        {
            var regex = new Regex("\\s");
            return regex.Split(s);
        }

        protected static string UpperCaseFirstLetter(string s)
        {
            var sb = new StringBuilder(s);
            sb[0] = char.ToUpper(sb[0]);
            return sb.ToString();
        }

        protected static string[] DetermineCaps(string[] lstWords)
        {
            
            for (var x = 0; x < lstWords.Length;x++)
            {
                lstWords[x] = UpperCaseNonMatches(lstWords[x]);
            }
            return lstWords;
        }

        protected static string UpperCaseNonMatches(string word)
        {
            var lowercaseWords = new List<string> { "a", "an", "the", "to", "at", "in", "with", "and", "but", "or", "for", "nor", "on", "up", "by", "as" };
            if (!lowercaseWords.Contains(word))
            {
                word = UpperCaseFirstLetter(word);
            }
            return word;
        }

        protected static string ReassembleTitle(IEnumerable<string> lstWords)
        {
            var sb = new StringBuilder();
            foreach (var w in lstWords)
            {
                sb.Append(w + " ");
            }
            return sb.ToString().Trim();
        }
    }
}
