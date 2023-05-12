using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partiel_MAI2023_CSharp_CASTLEVANIA_BRUSCHWIG_Nemo
{
    /// <summary>
    /// Snake behaviour
    /// </summary>
    internal class Snake
    {
        public int x; // x position
        public int y; // y position
        public Dir direction; // direction
        //public int oldX; // old x position
        //public int oldY; // old y position

        public List<Tail> tails; // array of tails

        public static Snake instance; // singleton

        public Snake(int x, int y, Dir direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            tails = new List<Tail>()
            {
                new Tail(x,y),
                new Tail(x,y)
            };
        }

        /// <summary>
        /// Change the direction of the snake
        /// </summary>
        public void ChangeDir(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.Z:
                    direction = Dir.UP;
                    break;
                case ConsoleKey.S:
                    direction = Dir.DOWN;
                    break;
                case ConsoleKey.Q:
                    direction = Dir.LEFT;
                    break;
                case ConsoleKey.D:
                    direction = Dir.RIGHT;
                    break;
            }
        }

        /// <summary>
        /// Move the snake on the grid
        /// </summary>
        public void Move()
        {
            for(int i = 0; i < tails.Count; i++)
            {
                tails[i].oldX = tails[i].x;
                tails[i].oldY = tails[i].y;

                if (i == 0)
                {
                    tails[i].x = x;
                    tails[i].y = y;
                } else
                {
                    tails[i].x = tails[i - 1].oldX;
                    tails[i].y = tails[i - 1].oldY;
                }
            }

            switch (direction)
            {
                case Dir.UP:
                    y--;
                    break;
                case Dir.DOWN:
                    y++;
                    break;
                case Dir.RIGHT:
                    x++;
                    break;
                case Dir.LEFT:
                    x--;
                    break;
            }
        }
    }

    internal class Tail
    {
        public int x;
        public int y;

        public int oldX;
        public int oldY;

        public Tail(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
