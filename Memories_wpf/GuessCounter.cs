using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_wpf
{
    public static class GuessCounter
    {
        private static int counter = 0;

        public static void  updateCounter()
        {
            counter++;
        }

        public static void resetCounter()
        {
            counter = 0;
        }

        public static int getCounter()
        {
            return counter;
        }
    }
}
