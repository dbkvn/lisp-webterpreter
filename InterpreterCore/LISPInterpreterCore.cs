﻿using System;
using System.Collections.Generic;

// using InterpreterCore.Classes.Lisp;

namespace InterpreterCore
{
    public class LISPInterpreterCore
    {
        public Dictionary<string,Object> variables { get; }
        public LISPInterpreterCore()
        {
            variables = new Dictionary<string,Object>();
        }

        public string[] ParseInputLine(string inputLine)
        {
            return InputParsing.RawInputParser
                .ParseExpressionIntoList(inputLine);
        }
    }
}
