using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuApi
{
    public class Math
    {
        // 가변 인자를 사용하여 임의의 개수의 수를 더하는 메서드
        public static int Add(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        // 가변 인자를 사용하여 임의의 개수의 수를 빼는 메서드
        public static int Subtract(params int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result -= numbers[i];
            }
            return result;
        }

        // 가변 인자를 사용하여 임의의 개수의 수를 곱하는 메서드
        public static int Multiply(params int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            int product = 1;
            foreach (int number in numbers)
            {
                product *= number;
            }
            return product;
        }

        // 가변 인자를 사용하여 임의의 개수의 수를 나누는 메서드
        public static double Divide(params double[] numbers)
        {
            if (numbers.Length == 0) return 0;
            double result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                    throw new DivideByZeroException("0으로 나눌 수 없습니다.");
                result /= numbers[i];
            }
            return result;
        }

        // 가변 인자를 사용하여 임의의 개수의 수의 제곱을 구하는 메서드
        public static double Pow(double baseNum, double exponent)
        {
            return System.Math.Pow(baseNum, exponent);
        }

        // 가변 인자를 사용하여 임의의 개수의 수의 평균을 구하는 메서드
        public static double Average(params double[] numbers)
        {
            if (numbers.Length == 0) return 0;
            double sum = Add(numbers.Select(n => (int)n).ToArray()); // 정수로 변환하여 합계 계산
            return sum / numbers.Length;
        }

        // 가변 인자를 사용하여 임의의 개수의 수 중 최대값을 찾는 메서드
        public static int Max(params int[] numbers)
        {
            if (numbers.Length == 0) throw new ArgumentException("최대값을 찾을 수 없습니다.");
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                    max = number;
            }
            return max;
        }

        // 가변 인자를 사용하여 임의의 개수의 수 중 최소값을 찾는 메서드
        public static int Min(params int[] numbers)
        {
            if (numbers.Length == 0) throw new ArgumentException("최소값을 찾을 수 없습니다.");
            int min = numbers[0];
            foreach (int number in numbers)
            {
                if (number < min)
                    min = number;
            }
            return min;
        }

        // 원점(0, 0, 0)으로부터 (x, y, z)까지의 거리 계산
        public static double Distance(double x, double y, double z)
        {
            return System.Math.Sqrt(x * x + y * y + z * z); // 거리 계산
        }
    }
}
