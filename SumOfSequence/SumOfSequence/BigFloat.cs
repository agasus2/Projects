using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SumOfSequence
{
    public class BigFloat : IEquatable<BigFloat>
    {
        private string _exponentialFormat = "0.0e+0";
        private string _exponentialMantissa = "0";
        private string _exponentialOrder = "0";
        private bool _sign = true;//if true number is positive, if false number is negative
        private const string Pattern = @"^\s*([0]|[1-9]+\d*)\.\d+e[+\-]?\d+\s*$";
        private const int    MantissaMaxSize = 39;

        public string FloatFormat { get; }

        public BigFloat(string str)
        {
            _exponentialFormat = str.Trim().ToLower();
            _sign = IsPositive();
            _exponentialMantissa = ToMantissa(DropExponent());
            _exponentialOrder = ToOrder(); ;
            FloatFormat = ToFloatFormat(); 
		}

        public BigFloat()
        {
            FloatFormat = ToFloatFormat(); 
        }

        #region  IEquatable

        public bool Equals(BigFloat other) 
        {
            if (other == null)
            {
                return false;
            }
            if (_exponentialFormat == other._exponentialFormat)
            {
                return true;
            }
            else if (FloatFormat == other.FloatFormat)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            BigFloat BigFloatObj = obj as BigFloat;

            if (BigFloatObj == null)
            {
                return false;
            }
            else
            {
                return Equals(BigFloatObj);
            }
        }

        public override int GetHashCode()
        {
            return this._exponentialFormat.GetHashCode();
        }
        #endregion

        #region Formatters

        //return string in float format
        private string ToFloatFormat()
        {
            StringBuilder result = new StringBuilder();
            StringBuilder order;
            StringBuilder mantissa = new StringBuilder(_exponentialMantissa);
           
            int power = ToPower();
          
            if (IsNotZeroOrder())
            {
                order = new StringBuilder(_exponentialOrder);
            }
            else if (power == 0)
            {
                order = new StringBuilder("0");
            }
            else
            {
                order = new StringBuilder("");
            }

            if (_sign)
            {
                if (power >= mantissa.Length)
                {
                    ToFloatFormatPositive(mantissa.Length, order, mantissa);
                    result.Append(order.ToString());
                    for (int i = 0; i < power - mantissa.Length; i++)
                    {
                        result.Append("0");
                    }
                    result.Append(".0");
                }
                else
                {
                    ToFloatFormatPositive(power, order, mantissa);
                    result.Append(order + "." + mantissa.Remove(0, power));
                }
            }
            else
            {
                if (power > order.Length)
                {
                    result.Append(order.ToString() + mantissa.ToString().TrimEnd('0'));
                    for (int i = 0; i < power - order.Length  ; i++)
                    {
                        result.Insert(0, "0");
                    }
                    result.Insert(0, "0.");
                }
                else if (power == order.Length)
                {
                    result.Append(order.ToString() + mantissa.ToString());
                    result.Insert(0, "0.");
                }
                else 
                {
                    ToFloatFormatNegative(power, order, mantissa);
                    result.Append(order.Remove(order.Length - power, power) + "." + mantissa);
                }
            }

            return result.ToString();
        }

        //checks if string is in exponencial format
        public static bool IsExponentialFormat(string userString)
        {
            return Regex.IsMatch(userString, Pattern, RegexOptions.IgnoreCase);
        }

        //format string with positive sign
        private void ToFloatFormatPositive(int power, StringBuilder order, StringBuilder mantissa)
        {
            for (int i = 0; i < power; i++)
            {
                order.Append(mantissa[i]);
            }
        }

        //format string with negative sign
        private void ToFloatFormatNegative(int power, StringBuilder order, StringBuilder mantissa)
        {
            int orderLastElementPos = order.Length-1;

            for(int i = 0; i < power; i++)
            {
                mantissa.Insert(0, order[orderLastElementPos--]);
            }
        }
       
        public override string ToString() 
        {
            return _exponentialFormat;
        }
      
        //checking the string for zero order
        private bool IsNotZeroOrder()
        {
            if (_sign)
            {
                if (_exponentialOrder == "0")
                {
                    return false;
                }
            }
            return true;
        }

        //return oreder of the current string
        private string ToOrder()
        {
            return _exponentialFormat.Remove(_exponentialFormat.IndexOf('.'), _exponentialFormat.Length - _exponentialFormat.IndexOf('.'));
        }

        //return oreder of the string
        public static string ToOrder(string formatedString)
        {
            return formatedString.Remove(formatedString.IndexOf('.'), formatedString.Length - formatedString.IndexOf('.'));
        }

        //return mantissa of the current string
        private string ToMantissa()
        {
            return _exponentialFormat.Substring(_exponentialFormat.IndexOf('.') + 1, _exponentialFormat.Length - _exponentialFormat.IndexOf('.') - 1);
        }

        //return mantissa of the string
        public static string ToMantissa(string formatedString)
        {
            return formatedString.Substring(formatedString.IndexOf('.') + 1, formatedString.Length - formatedString.IndexOf('.') - 1);
        }

        //return exponential power of the current string
        private int ToPower()
        {  
           return int.Parse(_exponentialFormat.Substring(_exponentialFormat.IndexOf('e')).Trim('+','-','e'));
        }

        //checks if  exponential power is positive
        private bool IsPositive()
        {
            if (!_exponentialFormat.Contains("-"))
            {
                return true;
            }

            return false;
        }

        //return string wihtout
        private string DropExponent()
        {
            return _exponentialFormat.Remove(_exponentialFormat.IndexOf('e'), _exponentialFormat.Length - _exponentialFormat.IndexOf('e'));
        }

        //checking that curent string is not zero number
        private bool StringIsNotZero()
        {
            return Regex.IsMatch(_exponentialFormat, @"[1-9]");
        }

        //checking that string is not zero number
        private static bool StringIsNotZero(string verifiableString)
        {
            return Regex.IsMatch(verifiableString, @"[1-9]");
        }

        //return string in exponential format
        public static string ToExponentialFormat(string formatedString)

        {
            StringBuilder order = new StringBuilder(ToOrder(formatedString));
            StringBuilder mantissa = new StringBuilder(ToMantissa(formatedString));
            int bufferPower = 0;
            int countOfZero = 0;
            if (StringIsNotZero(formatedString))
            {
                if (order.Length == 1 && order[order.Length - 1].ToString() == "0")
                {
                    for (int i = 0; i < mantissa.Length; ++i)
                    {
                        if (int.Parse(mantissa[i].ToString()) == 0)
                        {
                            countOfZero++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    mantissa.Remove(0, countOfZero);
                    order.Clear();
                    order.Append(mantissa[0]);
                    mantissa.Remove(0, 1);
                    if (mantissa.Length == 0)
                    {
                        mantissa.Append("0");
                    }
                    bufferPower = countOfZero + 1;
                    if (StringIsNotZero(mantissa.ToString()))
                    {
                        return order + "." + MantissaCut(mantissa).TrimEnd('0') + "e-" + bufferPower;
                    }
                    return order + "." + MantissaCut(mantissa) + "e-" + bufferPower;
                }
                else
                {
                    bufferPower = order.Length - 1;
                    mantissa.Insert(0, order.ToString().Remove(0, 1));
                    mantissa = new StringBuilder(mantissa.ToString().TrimEnd('0'));
                    if (mantissa.Length == 0)
                    {
                        mantissa.Append("0"); ;
                    }
                    order.Remove(1, order.Length - 1);

                    if (StringIsNotZero(mantissa.ToString())) 
                    {
                        return order + "." + MantissaCut(mantissa).TrimEnd('0') + "e+" + bufferPower;
                    }
                    return order + "." + MantissaCut(mantissa) + "e+" + bufferPower;
                }
            }
            return formatedString + "e+0";
        }

        //cut mantissa to 39 symbols
        private static string MantissaCut(StringBuilder mantissa)
        {
            if (mantissa.Length > MantissaMaxSize)
            {
                return mantissa.Remove(MantissaMaxSize, mantissa.Length - MantissaMaxSize).ToString();
            }

            return mantissa.ToString();
        }

        #endregion

        #region Adders

        //make orders length equal by adding zero to smaller
        private static void OrderLengthEqualization(StringBuilder biggerOrder, StringBuilder smallerOrder)
        {
            for (int i = biggerOrder.Length - smallerOrder.Length - 1; i >= 0; i--)
            {
                smallerOrder.Insert(0, "0");
            }
        }

        //make mantissas length equal by adding zero to smaller
        private static void MantissaLengthEqualization(StringBuilder biggerMantissa, StringBuilder smallerMantissa)
        {
            for (int i = biggerMantissa.Length - smallerMantissa.Length - 1; i >= 0; i--)
            {
                smallerMantissa.Append("0");
            }
        }

        //character addition
        private static void Add(StringBuilder firstTerm, StringBuilder secondTerm, StringBuilder result, ref int carryover)
        {
            for (int i = secondTerm.Length - 1; i >= 0; i--)
            {
                int buff = int.Parse(secondTerm[i].ToString()) + int.Parse(firstTerm[i].ToString()) + carryover;
                if (buff.ToString().Length > 1)
                {
                    carryover = int.Parse(buff.ToString()[0].ToString());
                    result.Insert(0, buff.ToString()[1].ToString());
                }
                else
                {
                    carryover = 0;
                    result.Insert(0, buff.ToString());
                }
            }

        }

        private static string AddOrders(StringBuilder firstOrder, StringBuilder secondOrder, ref int carryover)
        {
            StringBuilder result = new StringBuilder();

            if (firstOrder.Length > secondOrder.Length)
            {
                OrderLengthEqualization(firstOrder, secondOrder);
            }
            else if (secondOrder.Length > firstOrder.Length)
            {
                OrderLengthEqualization(secondOrder, firstOrder);

            }

            Add(secondOrder, firstOrder, result, ref carryover);

            if (carryover != 0)
            {
                result.Insert(0, carryover.ToString());
            }

            return result.ToString();
        }

        private static string AddMantissas(StringBuilder firstMantissa, StringBuilder secondMantissa, ref int carryover)
        {
            StringBuilder result = new StringBuilder();

            if (firstMantissa.Length > secondMantissa.Length)
            {
                MantissaLengthEqualization(firstMantissa, secondMantissa);
            }
            else if (secondMantissa.Length > firstMantissa.Length)
            {
                MantissaLengthEqualization(secondMantissa, firstMantissa);
            }

            Add(firstMantissa, secondMantissa, result, ref carryover);

            return result.ToString();
        }

        public static BigFloat operator +(BigFloat firstNumber, BigFloat secondNumber)
        {
            StringBuilder firstOrder = new StringBuilder(ToOrder(firstNumber.FloatFormat));
            StringBuilder firstMantissa = new StringBuilder(ToMantissa(firstNumber.FloatFormat));
            StringBuilder secondOrder = new StringBuilder(ToOrder(secondNumber.FloatFormat));
            StringBuilder secondMantissa = new StringBuilder(ToMantissa(secondNumber.FloatFormat));
            int carryover = 0;
            StringBuilder result = new StringBuilder(AddMantissas(firstMantissa, secondMantissa, ref carryover));

            result.Insert(0, ".");
            result.Insert(0, AddOrders(firstOrder, secondOrder, ref carryover));

            return new BigFloat(ToExponentialFormat(result.ToString()));
        }

        #endregion
    }
}
