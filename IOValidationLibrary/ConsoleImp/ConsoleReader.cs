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
            while (true)
            {
                try
                {//comment
                    bool isHasError = false;
                    @string = GetNotEmptyString();
                    string oneOfNumbers = String.Empty;
                    List<char> separatingChars = new List<char> { ' ', '.', '\t', '\n', '\b' , '\r'};
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
                                isHasError = true;
                                Console.WriteLine("'" + oneOfNumbers + "' does not parse. Try again!");
                                break;
                            }
                        }
                    }
                    if (!isHasError && arrayOfNumbers.Count > 0) return arrayOfNumbers.ToArray();
                    else Console.WriteLine("Error. Try Again. Attention: '.' is separating char but ',' is a part of double number.\nEnter:");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception + ". Try again.");
                }
            }
        }

        public int[] GetIntArray(string @string)
        {
            while (true)
            {
                try
                {
                    bool isHasError = false;
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
                                isHasError = true;
                                Console.WriteLine("'" + oneOfNumbers + "' does not parse. Try again!");
                                break;
                            }
                        }
                    }
                    if (!isHasError && arrayOfNumbers.Count > 0) return arrayOfNumbers.ToArray();
                    else Console.WriteLine("Error. Try Again.");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception + ". Try again.");
                }
            }

        }


        public double GetDoubleNumber(string @string = null)
        {
            while (true)
            {
                try
                {
                    if (!double.TryParse(GetNotEmptyString(), out double number))
                    {
                        Console.WriteLine("Error, try again");
                    }
                    else return number;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception + ". Try again.");
                }
            };
        }

        public double GetDoubleNumber(double min, string @string = null)
        {
            while (true)
            {
                try
                {
                    double number = GetDoubleNumber();
                    if (number < min)
                    {
                        Console.WriteLine("Error, number should be more than " + min);
                    }
                    else return number;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception + ". Try again.");
                }
            }
        }

        public double GetDoubleNumber(double min, double max, string @string = null)
        {
            while (true)
            {
                try
                {
                    double number = GetDoubleNumber();
                    if (number < min)
                    {
                        Console.WriteLine("Entered number is less than min. Try again!");
                    }
                    else if (number > min)
                    {
                        Console.WriteLine("Entered number is more than max. Try again!");
                    }
                    else return number;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception + ". Try again.");
                }
            }
        }        


        public int GetIntNumber(string @string = null)
        {
            while (true)
            {
                try
                {
                    if (!int.TryParse(GetNotEmptyString(), out int n)) 
                    {                                                  
                        Console.WriteLine("Error, try again");
                    }
                    else return n;
                }

                catch (Exception exception)
                {
                    Console.WriteLine(exception + ". Try again.");
                }
            }
        }

        public int GetIntNumber(int min, string @string = null)
        {
            while (true)
            {
                try
                {
                    int number = GetIntNumber();
                    if (number < min)
                    {
                        Console.WriteLine("Error, number should be more than " + min);
                    }
                    else return number;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception + ". Try again.");
                }
            }
        }

        public int GetIntNumber(int min, int max, string @string = null)
        {
            while (true)
            {
                try
                {
                    int number = GetIntNumber();
                    if (number < min)
                    {
                        Console.WriteLine("Entered number is less than min. Try again!");
                    }
                    else if (number > max)
                    {
                        Console.WriteLine("Entered number is more than max. Try again!");
                    }
                    else return number;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception + ". Try again.");
                }
            }
        }

        
        public char GetNotNullChar(string @string = null)
        {
            while (true)
            {
                try
                {
                    @string = Console.ReadLine().Trim();
                    if (@string.Length == 1 && !Char.IsSeparator(@string[0])) return @string[0];
                    else Console.WriteLine("This is not one not empty char. Try again!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error, try again! " + e.Message);
                }
            }
        }


        public string GetNotEmptyString(string @string = null)
        {
            while (true)
            {
                try
                {
                    @string = Console.ReadLine().Trim();
                    if (!String.IsNullOrEmpty(@string)) return @string;
                    else Console.WriteLine("Error, try again! ");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error, try again! " + e.Message);
                }
            }
        }        

        public string GetOneWord(string @string = null)
        {
            while (true)
            {
                try
                {
                    @string = GetNotEmptyString();
                    if (@string.IndexOfAny(new char[] { ',', '.', ' ', '\n', '\t' }) == -1)
                    {
                        return @string;
                    }
                    else Console.WriteLine("This is not one @string. Try again!");
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Wrong : " + exception + ". Try again!");
                }
            }
        }

        public string GetBinary(string @string = null)
        {
            while (true)
            {
                try
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
                        else
                        {
                            Console.WriteLine("Wrong. Try again!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong. Try again!");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Wrong :" + exception + ". Try again!");
                }
            }
        }
    }
}
