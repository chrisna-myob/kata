using System;

namespace Strings.Calculator
{
    public interface IDelimiter
    {
        string[] GetDelimiters(string sequence);
    }
}