using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_wpf
{
    public static class Points
    {
        private static int gamePoints = 0;

        public static void updatePoints()
        {
            gamePoints+=2;
        }

        public static void resetPoints()
        {
            gamePoints = 0;
        }

        public static int getPoints()
        {
            return gamePoints;
        }
    }
}
