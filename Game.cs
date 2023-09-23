using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGame
{
    public class Game
    {
        public char[,] board;
        public char currentPlayer;

        public Game()
        {
            board = new char[3, 3];
            currentPlayer = 'X';
            InitializeBoard();
        }

        public void PlayGame()
        {
            bool gameIsOver = false;

            do
            {
                DisplayBoard();
                MakeMove(currentPlayer);

                if (CheckForWin(currentPlayer))
                {
                    DisplayBoard();
                    Console.WriteLine($"Гравець {currentPlayer} переміг!");
                    gameIsOver = true;
                }
                else if (IsBoardFull())
                {
                    DisplayBoard();
                    Console.WriteLine("Нічия!");
                    gameIsOver = true;
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';

            } while (!gameIsOver);

            Console.WriteLine("Гра закінчена.");
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("Гра Хрестики-Нулики");
            Console.WriteLine();
            Console.WriteLine("   0   1   2");
            Console.WriteLine("0  {0} | {1} | {2}", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("  ---+---+---");
            Console.WriteLine("1  {0} | {1} | {2}", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("  ---+---+---");
            Console.WriteLine("2  {0} | {1} | {2}", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine();
        }

        public void MakeMove(char player)
        {
            bool validMove = false;
            int row, col;

            do
            {
                Console.Write($"Гравець {player}, введіть рядок (0, 1 або 2) і стовпчик (0, 1 або 2) через пробіл: ");
                string[] input = Console.ReadLine().Split(' ');
                row = int.Parse(input[0]);
                col = int.Parse(input[1]);

                if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
                {
                    board[row, col] = player;
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Некоректний хід. Спробуйте ще раз.");
                }
            } while (!validMove);
        }

        public bool CheckForWin(char player)
        {

            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||                    (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                {
                    return true;
                }
            }

            if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
                (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
            {
                return true;
            }

            return false;
        }
        public bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public char[,] GetBoard()
        {
            return board;
        }

        public void ResetBoard()
        {
            InitializeBoard();
            currentPlayer = 'X';
        }
    }
}
    

