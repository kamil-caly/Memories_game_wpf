using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_wpf
{
    public class Board
    {
        private int [] gameBoard;
        private Random rand = new Random();
        public Board()
        {
            gameBoard = new int[12];
            bool temp = true;
            while (temp)
            {
                temp = false;
                for (int i = 0; i < 6; i++)
                {
                    gameBoard[i] = rand.Next(2, 8);
                }

                for (int i = 2; i < 8; i++)
                {
                    if (!gameBoard.Contains(i))
                        temp = true;
                }
            }

            int[] tempBoard = new int[6];
            temp = true;
            while (temp)
            {
                temp = false;
                for (int i = 0; i < 6; i++)
                {
                    tempBoard[i] = rand.Next(2, 8);
                }

                for (int i = 2; i < 8; i++)
                {
                    if (!tempBoard.Contains(i))
                        temp = true;
                }
            }

            for (int i = 6; i < 12; i++)
            {
                gameBoard[i] = tempBoard[i-6];
            }
            
        }

        public int getField(int index)
        {
            return gameBoard[index];
        }

        public void setField(int index, int value)
        {
            gameBoard[index] = value;
        }

        public int[] getGameBoard()
        {
            return gameBoard;
        }
    }
}
