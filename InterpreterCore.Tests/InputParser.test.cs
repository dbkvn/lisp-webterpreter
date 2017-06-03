using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using InterpreterCore;

namespace InterpreterCore.Tests
{
    [TestClass]
    public class InputParserTest
    {
        private readonly InputParser _InputParser;
        public InputParserTest()
        {
            _InputParser = new InputParser();
        }

        [TestMethod]
        public void InputParserCanBeInstantiated()
        {
            var testObject = new InputParser();
        }

        [TestMethod]
        public void TestInputParserCanParseSimpleAdditionExpressions()
        {
            var simpleAdditionExpressions = new Dictionary<string,List<string>>()
            {
                { "(+ 1 1)", new List<string> {"(", "+", "1", "1", ")"} },
                { " (+ 1 1)", new List<string> {"(", "+", "1", "1", ")"} },
                { "(+ 1 1) ", new List<string> {"(", "+", "1", "1", ")"} },
                { "( + 1 1 )", new List<string> {"(", "+", "1", "1", ")"} },
                // Template Test Case Row
                // { "", new List<string> {} },
            };
            TestAllExpressionsParseCorrectly(simpleAdditionExpressions);
        }

        [TestMethod]
        public void TestInputParserCanParseNestedExpressions()
        {
            var simpleAdditionExpressions = new Dictionary<string,List<string>>()
            {
                { "(+ 1 (+ 1))", new List<string> {
                    "(", "+", "1", "(", "+", "1", ")", ")"} },
                // Template Test Case Row
                // { "", new List<string> {} },
            };
            TestAllExpressionsParseCorrectly(simpleAdditionExpressions);
        }

        [TestMethod]
        public void TestInputParserCanHandleEmptyExpressions()
        {
            var simpleAdditionExpressions = new Dictionary<string,List<string>>()
            {
                { "", new List<string> {} },
                { " ", new List<string> {} },
                { "\t", new List<string> {} },
                { "   ", new List<string> {} },
                // Template Test Case Row
                // { "", new List<string> {} },
            };
            TestAllExpressionsParseCorrectly(simpleAdditionExpressions);
        }

        /// <summary>
        /// This is a private helper method that will read a dictionary of test
        /// inputs and expected outputs. For each item in the dictionary, the
        /// actual results of the InputParser.ParseExpressionIntoList method
        /// will be checked using the CheckSyntaxTokenListsAreEqual method.
        /// </summary>
        private void TestAllExpressionsParseCorrectly(Dictionary<string,List<string>> expressionsAndResults)
        {
            foreach(var currentTestCase in expressionsAndResults)
            {
                string inputExpression = currentTestCase.Key;
                List<string> expectedSyntaxTokenList = currentTestCase.Value;
                List<string> actualSyntaxTokenList = InputParser.ParseExpressionIntoList(inputExpression);
                Assert.IsTrue(CheckSyntaxTokenListsAreEqual(expectedSyntaxTokenList, actualSyntaxTokenList));
            }
        }

        /// <summary>
        /// This is a private helper method that will examine two syntax
        /// token lists, assert that they have equal lengths, and then
        /// assert that each element in the list is identical. If the
        /// 'verbosity' parameter is set to true, the two token lists
        /// will be printed in full before comparing.
        /// </summary>
        private bool CheckSyntaxTokenListsAreEqual(List<string> expectedSyntaxTokenList,
                                                   List<string> actualSyntaxTokenList)
        {
            if(expectedSyntaxTokenList.Count != actualSyntaxTokenList.Count)
            {
                return false;
            }
            for(int currentTokenIndex = 0; currentTokenIndex < expectedSyntaxTokenList.Count;
                                           currentTokenIndex++)
            {
                string expectedToken = expectedSyntaxTokenList[currentTokenIndex];
                string actualToken = actualSyntaxTokenList[currentTokenIndex];
                if(expectedToken != actualToken)
                    return false;
            }
            return true;
        }
    }
}