using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FortWar
{
    class gamefield
    {
        hexagon[,] hexarray;
        public void buildfield(int borderx, int bordery, int numberofsteps, Canvas MainCanvas)
        {
            hexarray = new hexagon[borderx, bordery];
            int x = 0, y = 0;
            if (bordery >= 13 && bordery < 24)
            {

                for (int i = 0; i < borderx; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        y += 22;
                    }
                    for (int j = 0; j < bordery; j++)
                    {
                        hexarray[i, j] = new hexagon();
                        hexarray[i, j].hex(x, y, 75, 44, MainCanvas);
                        y += 43;
                    }
                    x += 37;
                    y = 0;
                }
            }
            else if (bordery >= 24)
            {
                for (int i = 0; i < borderx; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        y += 16;
                    }
                    for (int j = 0; j < bordery; j++)
                    {
                        hexarray[i, j] = new hexagon();
                        hexarray[i, j].hex(x, y, 56, 32, MainCanvas);
                        y += 32;
                    }
                    x += 27;
                    y = 0;
                }
            }
            else
            {
                for (int i = 0; i < borderx; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        y += 32;
                    }
                    for (int j = 0; j < bordery; j++)
                    {
                        hexarray[i, j] = new hexagon();
                        hexarray[i, j].hex(x, y, 111, 64, MainCanvas);
                        y += 64;
                    }
                    x += 54;
                    y = 0;
                }
            }
        }
    }
}
