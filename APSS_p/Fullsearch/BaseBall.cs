using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APSS_p.Fullsearch
{
    public static class BaseBall
    {
        public static List<int> numberList = new List<int>();

        public static List<int> strike = new List<int>();
        public static List<int> ball = new List<int>();

        public static bool[] canPick = new bool[10];

        public enum Type { H = 2, T = 1, O = 0 }

        public static void Init()
        {
            canPick = Enumerable.Repeat(true, 10).ToArray();

            int loopping = int.Parse(Console.ReadLine());

            for (int i = 0; i < loopping; i++)
            {
                SetValue();
            }

            Console.Write(StartCalculation(0));
        }

        public static void SetValue()
        {
            string str = Console.ReadLine();

            string[] splitStr = str.Split(' ');

            numberList.Add(int.Parse(splitStr[0]));

            strike.Add(int.Parse(splitStr[1]));

            ball.Add(int.Parse(splitStr[2]));
        }

        public static int SetNumber(int number)
        {
            int h = (number / 100);
            int t = (number / 10 % 10);
            int o = (number % 10);

            bool isNumber = (h != t) && (h != o) && (t != o) && (h != 0) && (t != 0) && (o != 0);

            if (isNumber && number < 988) return number;
            else if (number >= 988) return -1;
            else return SetNumber(number + 1);
        }

        public static int ret = 0;

        public static int StartCalculation(int num)
        {
            int number = num;

            if (num < 988)
            {
                number = SetNumber(num);
            }

            if (CanAnswer(number) && num <= 987)
            {
                ret += 1;
            }

            if (number < 987)
            {
                StartCalculation(number + 1);
            }

            return ret;
        }

        public static bool CanAnswer(int number)
        {
            bool isAnswer = true;

            for (int i = 0; i < numberList.Count; i++)
            {
                string str1 = string.Empty;

                if (numberList[i] < 100) str1 += "0";

                str1 += numberList[i].ToString();

                string str2 = string.Empty;

                if (number < 100) str2 += "0";

                str2 += number.ToString();

                var stk = 0;
                var ba = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (str2[j] == str1[j]) { stk++; continue; }
                    if (str2.Contains(str1[j])) ba++;
                }

                if (strike[i] != stk || ball[i] != ba)
                {
                    isAnswer = false;
                    break;
                }
            }

            return isAnswer;
        }

    }
}
