using System;
using System.Collections.Generic;
using System.Text;

namespace APSS_p.Fullsearch
{
    public static class FullSearchMainClass
    {
        public static void Main()
        {
            // Picnic
            //PicnicStart();

            // BoardCover
            //BoardCoverStart();

            // ClockSync
            ClockSyncStart();
        }

        public static void PicnicStart()
        {
            Picnic.Init();
        }

        public static void BoardCoverStart()
        {
            BoardCover.Init();
        }

        public static void ClockSyncStart()
        {
            ClockSync.Init();
        }
    }
}
