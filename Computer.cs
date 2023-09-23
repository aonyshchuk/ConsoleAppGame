using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGame
{
    public class Computer
    {
        public char computerSymbol;
        public Random random;

        public Computer(char symbol)
        {
            computerSymbol = symbol;
            random = new Random();
        }

        public void MakeMove(char[,] board)
        {
            int row, col;

            do
            {
                row = random.Next(0, 3);
                col = random.Next(0, 3);
            } while (board[row, col] != ' ');

            board[row, col] = computerSymbol;
        }
    }
}
