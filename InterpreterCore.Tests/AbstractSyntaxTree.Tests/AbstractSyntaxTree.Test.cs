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
            // Check that there are an equal number of children.
            var expectedChildren = expectedTree.Children;
            LISPAbstractSyntaxTreeNode[] actualChildren = testObject.Root.Children;
            Assert.AreEqual(expectedChildren.Length, actualChildren.Length);
            // Find the Operator token in the root node's children.
            var operatorChildren = new List<LISPAbstractSyntaxTreeNode>();
            foreach(var currentChild in actualChildren)
            {
                if(LISPAbstractSyntaxTreeNode.IsOperator(currentChild.Token))
                {
                    operatorChildren.Add(currentChild);
                }
            }
            int expectedOperatorChildrenLength = 1;
            int actualOperatorChildrenLength = operatorChildren.Count;
            Assert.AreEqual(expectedOperatorChildrenLength, actualOperatorChildrenLength);
        }

    }
}