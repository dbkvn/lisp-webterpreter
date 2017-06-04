using System;
using System.Collections.Generic;

using InterpreterCore.Classes;

namespace InterpreterCore.AbstractSyntaxTree
{
    public class LISPAbstractSyntaxTreeNode
    {
        private string _token;
        private IEnumerable<LISPAbstractSyntaxTreeNode> _children;
        public LISPAbstractSyntaxTreeNode()
        {
            _token = null;
            _children = null;
        }
        public LISPAbstractSyntaxTreeNode(string token)
        {
            _token = token;
            _children = null;
        }
        public LISPAbstractSyntaxTreeNode(string token, IEnumerable<LISPAbstractSyntaxTreeNode> children)
        {
            _token = token;
            _children = null;
        }
        public string Token
        {
            get { return _token; }
        }
        public string Value
        {
            get { return _token; }
        }
        public IEnumerable<LISPAbstractSyntaxTreeNode> Children
        {
            get { return _children; }
            set { _children = value; }
        }
        public bool IsOperator()
        {
            if(_token == "+" || _token == "-" || _token == "*" || _token == "/")
                return true;
            return false;
        }
    }
}