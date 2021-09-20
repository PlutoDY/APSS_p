using System;
using System.Collections.Generic;
using System.Text;

namespace APSS_p.Fullsearch
{
    public static class ClockSync
    {
        private const int INF = 9999;
        private const int SWITCHES = 10;
        private const int CLOCKS = 16;

        private static int[] clocks = new int[16];

        private static List<int> resultList = new List<int>();
        private static int result = INF;

        private static int[][] linkedClock = new int[10][]
        {
            new int[] { 0,1,2 },
            new int[] { 3,7,9,11 },
            new int[] { 4,10,14,15 },
            new int[] { 0,4,5,6,7 },
            new int[] { 6,7,8,10,12 },
            new int[] { 0,2,14,15 },
            new int[] { 3,14,15 },
            new int[] { 4,5,7,14,15 },
            new int[] { 1,2,3,4,5 },
            new int[] { 3,4,5,9,13 },
        };

        private static bool AreAligned()
        {
            if (Array.FindAll(clocks, _ => _ == 12).Length == clocks.Length) return true;
            else return false;
        }

        public static void Init()
        {
            int looppingCount = int.Parse(Console.ReadLine());

            for(int i = 0; i < looppingCount; i++)
            {
                Start();
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            foreach(int i in resultList)
            {
                Console.WriteLine(i);
            }
        }

        private static void Start()
        {
            ResetClocks();

            result = Calculation(0);

            resultList.Add(result != INF ? result : -1);
        }

        private static void ResetClocks()
        {
            string str = Console.ReadLine();

            string[] splitStr = str.Split(' ');

            for (int i = 0; i < 16; i++)
            {
                clocks[i] = int.Parse(splitStr[i]);
            }
        }

        private static int count = 0;

        private static void Push(int currentSwitch)
        {
            for(int i = 0; i < linkedClock[currentSwitch].Length; i++)
            {
                var linkedNumber = linkedClock[currentSwitch][i];

                clocks[linkedNumber] += 3;
                if (clocks[linkedNumber] >= 15) clocks[linkedNumber] = 3;
            }

            /*var s = string.Empty;

            for(int i = 0; i < 16; i++)
            {
                s += clocks[i] + " ";
            }

            Console.WriteLine($"CNT = {++count} | {s}");

            s = string.Empty;*/
        }

        private static int Calculation(int currentSwitch)
        {
            if (currentSwitch == SWITCHES) return AreAligned() ? 0 : INF;

            int ret = INF;

            for(int cnt = 0; cnt < 4; ++cnt)
            {

                ret = Math.Min(ret,cnt + Calculation(currentSwitch+1));

                Push(currentSwitch);
            }

            return ret;
        }
    }
}
