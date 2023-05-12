using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Partiel_MAI2023_CSharp_CASTLEVANIA_BRUSCHWIG_Nemo
{
    internal class Apple
    {
        public int x;
        public int y;

        public static Apple instance;

        private Random rand = new Random();

        public void Place(int gridSizeX, int gridSizeY)
        {
            x = rand.Next(1, gridSizeX);
            y = rand.Next(1, gridSizeY);
        }
    }
}
