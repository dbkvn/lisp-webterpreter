using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace InterpreterCore.InputParsing
{
    public class RawInputParser
    {
        /// <summary>
        /// This class is a wrapper around the helper methods used to parse
        /// a string input from the interpreter into a list of arguments
        /// for runtime. Note that this does not implement an abstract syntax
        /// tree. The list returned is a flat list of strings, with superfluous
        /// characters removed.
        /// </summary>
        public static string[] ParseExpressionIntoList(string expression)
        {
            if(expression == null)
            {   // Null parameter check.
                throw new NullReferenceException();
            }
            if(expression.Length == 0)
            {   // Empty parameter check.
                return new string[]{};
            }
            // First, remove any extraneous whitespace from the expression.
            string trimmedExpression = TrimWhitespace(expression);
            // Next, split the trimmed expression into raw tokens based on whitespace.
            string[] rawTokens = SplitTrimmedExpression(trimmedExpression);
            // Handle the raw token list, splitting raw tokens by syntactical meaning.
            string[] tokens = SyntaxTokenParser.SplitRawTokens(rawTokens);
            return tokens;   // Return the ordered list of syntax tokens.
        }

        /// <summary>
        /// This method removes extra whitespace from the input expression.
        /// </summary>
        private static string TrimWhitespace(string expression)
        {
            if(expression == null) // Check for a null parameter.
            {
                throw new NullReferenceException();
            }
            // Replace all whitespace regions with a single ' ' character.
            string cleanedExpression = Regex.Replace(expression, @"\s+", " ");
            // Trim leading and/or trailing whitespace from the expression.
            string trimmedExpression = cleanedExpression.Trim();
            return trimmedExpression;
        }

        /// <summary>
        /// This method will handle a string that has been treated by the
        /// WhitespaceParser module. This splits the string into a list of
        /// raw tokens, based on whitespace characters in the expression.
        /// <summary>
        private static string[] SplitTrimmedExpression(string expression)
        {
            if(expression == null)
            {
                throw new NullReferenceException();
            }
            List<String> rawTokens = new List<String>(expression.Split(' '));
            return rawTokens.ToArray();
        }
    }
}