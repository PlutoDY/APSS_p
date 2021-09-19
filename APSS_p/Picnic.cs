using System;
using System.Collections.Generic;
using System.Linq;


namespace APSS_p
{
    class Picnic
    {
        public static List<bool> pair = new List<bool>();

        public static List<bool> nowPair = new List<bool>();

        public static int memberNumber;

        public static int pairCount;

        public static List<int> resultList = new List<int>();

        public static void Main()
        {
            int loopCounter = int.Parse(Console.ReadLine());

            for (int i = 0; i < loopCounter; i++)
            {
                Start();
            }

            PrintAnswer();
        }

        private static void Start()
        {
            nowPair = new List<bool>();
            pair = new List<bool>();

            string str = Console.ReadLine();

            string[] result = str.Split(' ');

            memberNumber = int.Parse(result[0]);

            nowPair = Enumerable.Repeat(false, memberNumber).ToList();

            pairCount = int.Parse(result[1]);

            pair = Enumerable.Repeat(false, memberNumber * memberNumber).ToList();

            InitValues();

            resultList.Add(SetCombi());
        }

        private static void InitValues()
        {
            string str = Console.ReadLine();

            string[] result = str.Split(' ');

            for (int i = 0; i < pairCount * 2; i += 2)
            {
                int x = int.Parse(result[i]);

                int y = int.Parse(result[i + 1]);

                int index = x + (y * memberNumber);

                pair[index] = true;
            }
        }
        private static void PrintAnswer()
        {
            foreach (int i in resultList)
            {
                Console.Write(i + " ");
            }
        }

        private static int SetCombi()
        {
            var fI = nowPair.FindIndex(_ => _ == false);

            if (fI == -1) return 1;

            int ret = 0;

            for (int pW = fI + 1; pW < memberNumber; ++pW)
            {
                int index = fI + (pW * memberNumber);

                if (!nowPair[pW] && pair[index])
                {
                    nowPair[fI] = nowPair[pW] = true;
                    ret += SetCombi();
                    nowPair[fI] = nowPair[pW] = false;
                }
            }

            return ret;
        }
    }
}
