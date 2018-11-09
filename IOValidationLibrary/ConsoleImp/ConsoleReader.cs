using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOValidation.Interfaces;

namespace IOValidation.ConsoleImp
{
   public class ConsoleReader : IReader
    {
        public double[] GetDoubleArray(string @string = null)
        {
            try
            {                
                @string = GetNotEmptyString();
                string oneOfNumbers = String.Empty;
                List<char> separatingChars = new List<char> { ' ', '.', '\t', '\n', '\b', '\r' };
                List<double> arrayOfNumbers = new List<double>();

                for (int i = 0; i < @string.Length; i++)
                {
                    if (Char.IsSeparator(@string[i]) || separatingChars.Contains(@string[i])) continue;
                    else
                    {
                        oneOfNumbers = String.Empty;
                        while (!separatingChars.Contains(@string[i]) && !Char.IsSeparator(@string[i]))
                        {
                            oneOfNumbers += @string[i++];
                            if (i == @string.Length) break;
                        }
                        if (double.TryParse(oneOfNumbers, out double res)) arrayOfNumbers.Add(res);
                        else
                        {
                            throw new FormatException("'" + oneOfNumbers + "' can not be parsed.");
                        }
                    }
                }
                if (arrayOfNumbers.Count > 0) return arrayOfNumbers.ToArray();
                else throw new ArgumentException("User inputed no one number");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }            
        }

        public int[] GetIntArray(string @string)
        {
            try
            {                
                @string = GetNotEmptyString();
                string oneOfNumbers = String.Empty;
                List<char> separatingChars = new List<char> { ' ', '.', '\t', '\n', '\b', '\r' };
                List<int> arrayOfNumbers = new List<int>();

                for (int i = 0; i < @string.Length; i++)
                {
                    if (Char.IsSeparator(@string[i]) || separatingChars.Contains(@string[i])) continue;
                    else
                    {
                        oneOfNumbers = String.Empty;
                        while (!separatingChars.Contains(@string[i]) && !Char.IsSeparator(@string[i]))
                        {
                            oneOfNumbers += @string[i++];
                            if (i == @string.Length) break;
                        }
                        if (int.TryParse(oneOfNumbers, out int res)) arrayOfNumbers.Add(res);
                        else
                        {                            
                            throw new FormatException("'" + oneOfNumbers + "' can not be parsed.");                            
                        }
                    }
                }
                if (arrayOfNumbers.Count > 0) return arrayOfNumbers.ToArray();
                else throw new ArgumentException("User inputed no one number");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }


        public double GetDoubleNumber(string @string = null)
        {
            if (!double.TryParse(GetNotEmptyString(), out double number))
            {
                throw new ArgumentException("I can not parse it :c");
            }
            else return number;
        }

        public double GetDoubleNumber(double min, string @string = null)
        {
            double number = GetDoubleNumber();
            if (number < min)
            {
                throw new ArgumentException("Number should be not less than minimum!");
            }
            else return number;
        }

        public double GetDoubleNumber(double min, double max, string @string = null)
        {
            double number = GetDoubleNumber(min);
            if (number > max)
            {
                throw new ArgumentException("Number should be not more than maximum!");
            }
            else return number;
        }        


        public int GetIntNumber(string @string = null)
        {
            if (!int.TryParse(GetNotEmptyString(), out int n))
            {
                throw new ArgumentException("I can not parse it :c");
            }
            else return n;
        }

        public int GetIntNumber(int min, string @string = null)
        {
            int number = GetIntNumber();
            if (number < min)
            {
                throw new ArgumentException("Number should be not less than minimum!");
            }
            else return number;
        }

        public int GetIntNumber(int min, int max, string @string = null)
        {
            int number = GetIntNumber();
            if (number > max)
            {
                throw new ArgumentException("Number should be not more than maximum!");
            }
            else return number;
        }

        
        public char GetNotNullChar(string @string = null)
        {
            @string = Console.ReadLine().Trim();
            if (@string.Length == 1 && !Char.IsSeparator(@string[0])) return @string[0];
            else throw new ArgumentException("This is not one not empty char!");
        }


        public string GetNotEmptyString(string @string = null)
        {
            @string = Console.ReadLine().Trim();
            if (!String.IsNullOrEmpty(@string)) return @string;
            else throw new ArgumentException("This is not non-empty string!");
        }        

        public string GetOneWord(string @string = null)
        {
            @string = GetNotEmptyString();
            if (@string.IndexOfAny(new char[] { ',', '.', ' ', '\n', '\t' }) == -1)
            {
                return @string;
            }
            else throw new ArgumentException("This is not one word.");
        }

        public string GetBinary(string @string = null)
        {
            @string = GetNotEmptyString();
            string result = @string.Clone() as string;
            if (@string.Contains('1') || @string.Contains('0'))
            {
                while (result.Contains('1') || result.Contains('0'))
                {
                    result = result.Remove(result.IndexOfAny(new char[] { '1', '0' }));
                }

                if (result.Length > 0)
                {
                    if (!@string.Contains('1'))
                    {
                        return "0";
                    }
                    else
                    {
                        return @string;
                    }
                }               
            }

            throw new FormatException("Wrong input.");
        }
    }
}
