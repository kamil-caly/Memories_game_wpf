using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_wpf
{
    public static class GameOver
    {
        public static bool isGameOver(Board board)
        {
            for (int i = 0; i < board.getGameBoard().Length; i++)
            {
                if (board.getField(i) != 1)
                    return false;
            }
            return true;
        }
    }
}
