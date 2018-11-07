using System;
using System.Collections.Generic;
using System.Text;

namespace IOValidationLibrary.Interfaces
{
    interface IReader
    {
        double[] GetDoubleArray(string @string = null);
        int[] GetIntArray(string @string);

        double GetDoubleNumber(string @string = null);
        double GetDoubleNumber(double min, string @string = null);        
        double GetDoubleNumber(double min, double max, string @string = null);

        int GetIntNumber(string @string = null);
        int GetIntNumber(int min, string @string = null);
        int GetIntNumber(int min, int max, string @string = null);

        char GetNotNullChar(string @string = null);

        string GetNotEmptyString(string @string = null);
        string GetOneWord(string @string = null);
        string GetBinary(string @string = null);
    }
}
