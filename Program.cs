using System.Text;

namespace ConsoleAppGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;


            Console.WriteLine("Ласкаво просимо до гри Хрестики-Нулики!");
            Console.WriteLine();





            bool playAgain1 = true;
            Game game = new Game();

            while (playAgain1)
            {
                Console.WriteLine("Гравець 1, ви граєте Х, гравець 2, ви граєте О.");
                Console.WriteLine("Починає гравець 1.");
                Console.WriteLine("Натисніть Enter, щоб продовжити...");
                Console.ReadLine();


                while (true)
                {
                    game.PlayGame();

                    Console.Write("Бажаєте грати ще раз? (так/ні): ");
                    string playAgainResponse = Console.ReadLine().ToLower();

                    if (playAgainResponse != "так")
                    {
                        playAgain1 = false;
                        break;
                    }

                    game.ResetBoard();
                }
            }


        }
    }
}
      