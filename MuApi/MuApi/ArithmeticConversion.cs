using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuApi
{
    public class ArithmeticConversion
    {
        public static int Bin2Dec(string binary)
        {
            // 2진수 문자열을 10진수로 변환
            return Convert.ToInt32(binary, 2);
        }
        public static int Bin2Hex(string binary)
        {
            // 2진수 문자열을 16진수로 변환
            return Convert.ToInt32(binary, 2);
        }
        public static int Bin2Oct(string binary)
        {
            // 2진수 문자열을 8진수로 변환
            return Convert.ToInt32(binary, 2);
        }
        public static string Dec2Bin(int decimalNumber)
        {
            // 10진수를 2진수 문자열로 변환
            return Convert.ToString(decimalNumber, 2);
        }
        public static string Dec2Hex(int decimalNumber)
        {
            // 10진수를 16진수 문자열로 변환
            return Convert.ToString(decimalNumber, 16);
        }
        public static string Dec2Oct(int decimalNumber)
        {
            // 10진수를 8진수 문자열로 변환
            return Convert.ToString(decimalNumber, 8);
        }
        public static string Hex2Bin(string hex)
        {
            // 16진수 문자열을 2진수로 변환
            return Convert.ToString(Convert.ToInt32(hex, 16), 2);
        }
        public static int Hex2Dec(string hex)
        {
            // 16진수 문자열을 10진수로 변환
            return Convert.ToInt32(hex, 16);
        }
        public static string Hex2Oct(string hex)
        {
            // 16진수 문자열을 8진수로 변환
            return Convert.ToString(Convert.ToInt32(hex, 16), 8);
        }
        public static string Oct2Bin(string oct)
        {
            // 8진수 문자열을 2진수로 변환
            return Convert.ToString(Convert.ToInt32(oct, 8), 2);
        }
        public static int Oct2Dec(string oct)
        {
            // 8진수 문자열을 10진수로 변환
            return Convert.ToInt32(oct, 8);
        }
        public static string Oct2Hex(string oct)
        {
            // 8진수 문자열을 16진수로 변환
            return Convert.ToString(Convert.ToInt32(oct, 8), 16);
        }
    }
}
