using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using InterpreterCore.Classes.AbstractSyntaxTree;
using InterpreterCore.Tests.TestCases;

namespace InterpreterCore.Tests
{
    [TestClass]
    public class LISPAbstractSyntaxTreeTest
    {
        [TestMethod]
        public void LISPAbstractSyntaxTreeDefaultConstructorWorks()
        {
            var testObject = new LISPAbstractSyntaxTree();
        }

        [TestMethod]
        public void LISPAbstractSyntaxTreeStringParameterConstructorAcceptsEmptyString()
        {
            var testObject = new LISPAbstractSyntaxTree("");
        }

        [TestMethod]
        public void LISPAbstractSyntaxTreeStringParameterConstructorWorksForOnePlusOne()
        {
            // Create an instance of the expected syntax tree.
            LISPAbstractSyntaxTreeNode expectedTree = TestCases
                .LISPAbstractSyntaxTreeTestCases.GetTreeForOnePlusOne();
            string testExpression = "(+ 1 1)"; // Create a tree using a string.
            var testObject = new LISPAbstractSyntaxTree(testExpression);
            // Compare tokens in the root notes of each tree.
            string expectedToken = expectedTree.Token;
            string actualToken = testObject.Root.Token;
            Assert.AreEqual(expectedToken, actualToken);
            // Check that there are an equal number of children.
            var expectedChildren = expectedTree.Children;
            var actualChildren = testObject.Root.Children;
            Assert.AreEqual(expectedChildren.Length, actualChildren.Length);
            for (int currChildIndex = 0; currChildIndex < expectedChildren.Length;
                                                          currChildIndex++)
            {   // Check that the items in the children arrays match.
                var currentExpectedChild = expectedChildren[currChildIndex];
                var currentActualChild = actualChildren[currChildIndex];
                Assert.AreEqual(currentExpectedChild.Token, currentActualChild.Token);
            }
        }

        [TestMethod]
        public void LISPAbstractSyntaxTreeStringParameterConstructorWorksForNestedExpression()
        {
            // Create an instance of the expected syntax tree.
            LISPAbstractSyntaxTreeNode expectedTree = TestCases
                .LISPAbstractSyntaxTreeTestCases.GetTreeForNestedExpression();
            string testExpression = "(+ 2 3 (+ 10 5))"; // Create a tree using a string.
            var testObject = new LISPAbstractSyntaxTree(testExpression);
            // Compare tokens in the root notes of each tree.
            string expectedToken = expectedTree.Token;
            string actualToken = testObject.Root.Token;
            Assert.AreEqual(expectedToken, actualToken);
            // Check that the correct number of nodes exist in the root Children array.
            var expectedChildren = expectedTree.Children;
            LISPAbstractSyntaxTreeNode[] actualChildren = testObject.Root.Children;
            Assert.AreEqual(expectedChildren.Length, actualChildren.Length);
            // Check the tokens in the root node's Children array.
            Assert.AreEqual("2", actualChildren[0].Token);
            Assert.AreEqual("3", actualChildren[1].Token);
            // Examine the nested expression.
            var operatorChild = actualChildren[2];
            Assert.AreEqual("+", operatorChild.Token);
            var operatorChildren = operatorChild.Children;
            int expectedOperatorChildCount = 2;
            Assert.AreEqual(expectedOperatorChildCount, operatorChildren.Length);
            Assert.AreEqual("10", operatorChildren[0].Token);
            Assert.AreEqual("5", operatorChildren[1].Token);
        }

    }
}