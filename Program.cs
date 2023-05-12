using System.Text;

namespace Partiel_MAI2023_CSharp_CASTLEVANIA_BRUSCHWIG_Nemo
{
    /// <summary>
    /// DIrection of the snake
    /// </summary>
    enum Dir
    {
        UP, DOWN, LEFT, RIGHT
    }

    /// <summary>
    /// Main program
    /// </summary>
    class Program
    {

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode; // to show characters correctly
            ConsoleKeyInfo key; // key init (for menu)


            // system loop
            do
            {
                int gridSize = 16; // size of the grid
                // init grid
                Grid grid = new Grid(gridSize, gridSize); // grid

                // init Snake
                Snake.instance = new Snake(2, (int)(gridSize * 0.5f), Dir.RIGHT);

                // init Apple
                Apple.instance = new Apple();
                Apple.instance.Place(grid.sizeX, grid.sizeY);
                int score = 0; // init score

                int frameRate = 1000; // frame rate

                // game loop
                while (true)
                {
                    // read input
                    if (Console.KeyAvailable)
                    {
                        Snake.instance.ChangeDir(Console.ReadKey(true));
                    }

                    Snake.instance.Move(); // snake move

                    // apple collision
                    if (Snake.instance.x == Apple.instance.x && Snake.instance.y == Apple.instance.y)
                    {
                        Apple.instance.Place(grid.sizeX, grid.sizeY);
                        score++;
                        Tail lastTail = Snake.instance.tails[Snake.instance.tails.Count - 1];
                        Snake.instance.tails.Add(new Tail(lastTail.oldX, lastTail.oldY));
                    }

                    grid.Draw(); // draw grid

                    // wall collisions
                    if (Snake.instance.x >= grid.sizeX || Snake.instance.x <= 0 || Snake.instance.y >= grid.sizeY || Snake.instance.y <= 0)
                        break;


                    System.Threading.Thread.Sleep(frameRate); // pause thread
                }

                // menu loop
                do
                {
                    Console.Clear();
                    // source GAME OVER : https://patorjk.com/software/taag/#p=display&f=Big&t=GAME%20OVER
                    Console.WriteLine("   _____          __  __ ______    ______      ________ _____  \r\n  / ____|   /\\   |  \\/  |  ____|  / __ \\ \\    / /  ____|  __ \\ \r\n | |  __   /  \\  | \\  / | |__    | |  | \\ \\  / /| |__  | |__) |\r\n | | |_ | / /\\ \\ | |\\/| |  __|   | |  | |\\ \\/ / |  __| |  _  / \r\n | |__| |/ ____ \\| |  | | |____  | |__| | \\  /  | |____| | \\ \\ \r\n  \\_____/_/    \\_\\_|  |_|______|  \\____/   \\/   |______|_|  \\_\\");
                    Console.Write("Your score: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(score);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Retry ? [");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('n');
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(": no, ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('y');
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(": yes]");
                    key = Console.ReadKey();

                } while (key.Key != ConsoleKey.N && key.Key != ConsoleKey.Y);

            } while (key.Key == ConsoleKey.Y);
        }
    }
}