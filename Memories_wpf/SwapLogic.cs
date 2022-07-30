using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_wpf
{
    public class SwapLogic
    {
        public bool isTheSamePictures(Board board, List<int> pictures)
        {
            return board.getField(pictures[0]) == board.getField(pictures[1]) ? true : false;
        }

        public void setWhiteFieldAfterGuess(Board board, List<int> pictures)
        {
            board.setField(pictures[0], 1);
            board.setField(pictures[1], 1);
        }

        public bool isWhitePicture(Board board, List<int> pictures)
        {
            return board.getField(pictures[0]) == 1 ? true : false;
        }

    }
}
