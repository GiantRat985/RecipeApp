﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Exceptions
{
    /// <summary>
    /// Represents errors during parsing.
    /// </summary>
    public class ParsingFailureException : Exception
    {
        public ParsingFailureException()
        {
            
        }

        public ParsingFailureException(string message) : base(message)
        {
            
        }

        public ParsingFailureException(string message, Exception inner) : base(message, inner)
        {
            
        }

        public static void ThrowIfNull(object? argument, string message, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
        {
            if (argument is null)
            {
                throw new ParsingFailureException(message);
            }
        }
    }
}
