using System;
using System.Collections.Generic;
using System.Linq;

namespace APSS_p.Fullsearch
{
    public static class BoardCover
    {
        private static int[,,] coverType = {
            { { 0, 0 },{ 1, 0 },{ 0, 1 } },
            { { 0, 0 },{ 0, 1 },{ 1, 1 } },
            { { 0, 0 },{ 1, 0 },{ 1, 1 } },
            { { 0, 0 },{ 1, 0 },{ 1, -1 } }
        };

        private static List<int> currentMapState = new List<int>();

        private static int mapWidth;
        private static int mapHeight;

        private static List<int> resultList = new List<int>();

        public static void Init()
        {
            Start();
        }

        private static void Start()
        {
            int looppingCount = int.Parse(Console.ReadLine());

            for(int i = 0; i < looppingCount; i++)
            {
                ResetMap();
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

        private static void ResetMap()
        {
            currentMapState = new List<int>();

            string str = Console.ReadLine();

            string[] splitStr = str.Split(' ');

            mapHeight = int.Parse(splitStr[0]);

            mapWidth = int.Parse(splitStr[1]);

            currentMapState = Enumerable.Repeat(-1, mapHeight * mapWidth).ToList();

            for(int i = 0; i < mapHeight; i++)
            {
                string mapLine = Console.ReadLine();

                for(int j = 0; j< mapWidth; j++)
                {
                    currentMapState[(i * mapWidth) + j] = ((mapLine[j].CompareTo('#') == 0) ? 1 : 0);
                }
            }

            if (currentMapState.FindAll(_ => _ == 0).Count % 3 != 0) resultList.Add(0);
            else resultList.Add(Calculation());


        }

        private static bool SetMap(int y, int x, int type, int delta)
        {
            bool check = true;

            for (int i = 0; i < 3; i++) {
                
                int dY = y + coverType[type, i, 0];
                int dX = x + coverType[type, i, 1];

                int index = (dY * mapWidth) + dX;

                if ((dY < 0) || (dX < 0) || (dY >= mapHeight) || (dX >= mapWidth)) check = false;
                else if ((currentMapState[index] += delta) > 1) check = false;
            }
            return check;
        }

        private static int ret = 0;

        private static int Calculation()
        {
            int x = -1;
            int y = -1;

            #region Found Not Fill Area

            for(int i = 0; i < mapHeight; i++)
            {
                for(int j = 0; j < mapWidth; j++)
                {
                    var index = (i * mapWidth) + j;

                    if(currentMapState[index] == 0)
                    {
                        y = i;
                        x = j;

                        break;
                    }
                }

                if (y != -1) break;
            }
            #endregion

            if (y == -1) return 1;
            ret = 0;

            #region Set Map

            for(int i = 0; i < 4; i++)
            {
                if (SetMap(y, x, i, 1))
                    ret += Calculation();

                SetMap(y, x, i, -1);
            }
            #endregion

            return ret;
        }
    }
}
