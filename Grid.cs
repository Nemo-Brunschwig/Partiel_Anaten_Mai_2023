using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partiel_MAI2023_CSharp_CASTLEVANIA_BRUSCHWIG_Nemo
{
    internal class Grid
    {
        public int sizeX; // size of the grid on the x axe
        public int sizeY; // size of the grid on the y axe

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="grid">Grid to copy</param>
        public Grid(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        /// <summary>
        /// Draw the grid on the console
        /// </summary>
        public void Draw()
        {
            Console.Clear();

            StringBuilder strBd = new StringBuilder();

            for (int i = 0; i <= sizeY; ++i)
            {
                for (int j = 0; j <= sizeX; ++j)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                            strBd.Append(String.Format("{0,-2}", '◢'));
                        else if (j == sizeX)
                            strBd.Append(String.Format("{0,-2}", "◣\n"));
                        else
                            strBd.Append(String.Format("{0,-2}", '▬'));
                    }
                    else if (i == sizeY)
                    {
                        if (j == 0)
                            strBd.Append(String.Format("{0,-2}", '◥'));
                        else if (j == sizeX)
                            strBd.Append(String.Format("{0,-2}", '◤'));
                        else
                            strBd.Append(String.Format("{0,-2}", '▬'));
                    }
                    else
                    {
                        if (j == 0)
                            strBd.Append(String.Format("{0,-2}", '▮'));
                        else if (j == sizeX)
                            strBd.Append(String.Format("{0,-2}", "▮\n"));
                        //else if (i == Snake.instance.y && j == Snake.instance.x)
                        //    strBd.Append(String.Format("{0,-2}", "🐍"));
                        else if (i == Apple.instance.y && j == Apple.instance.x)
                            strBd.Append(String.Format("{0,-2}", "🍎"));
                        else
                            strBd.Append(String.Format("{0,-2}", ' '));
                    }
                }
            }

            // Trying to do snake tail, but beacause of Unicode characters, 1 charter is in reality 2 characters
            // draw head
            strBd[(Snake.instance.y * (sizeX + 1)) * 2 + Snake.instance.x * 2] = "🐍"[0]; // firts part of head
            strBd[((Snake.instance.y * (sizeX + 1)) * 2 + Snake.instance.x * 2) + 1] = "🐍"[1]; // second part of head
            // draw tail
            foreach(Tail tail in Snake.instance.tails)
            {
                strBd[(tail.y * (sizeX + 1)) * 2 + tail.x * 2] = "🐍"[0]; // firts part of tail
                strBd[((tail.y * (sizeX + 1)) * 2 + tail.x * 2) + 1] = "🐍"[1]; // second part of tail
            }

            Console.Write(strBd);
        }
    }
}
