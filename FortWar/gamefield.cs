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
using System.Windows.Resources;
namespace FortWar
{
    class gamefield
    {
        hexagon[,] hexarray;
        int coll, row;
        public void buildfield(int borderx, int bordery, int numberofsteps, Canvas MainCanvas,int firstcityx,int firstcityy,int secondcityx,int secondcityy)
        {
            coll = borderx;
            row = bordery;
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
            hexarray[firstcityx - 1, firstcityy - 1].greencity();
            hexarray[secondcityx - 1, secondcityy - 1].redcity();
        }
        public void fillwithcolour(int x,int y)
        {
            if(x + 1 == coll)
            {
                if(y == 0)
                {
                    if(coll % 2 != 0)
                    {
                        if(hexarray[x,y].team == 1)
                        {
                            hexarray[x, y + 1].green();
                            hexarray[x - 1, y].green();
                        }
                        else if(hexarray[x, y].team == 2)
                        {
                            hexarray[x, y + 1].red();
                            hexarray[x - 1, y].red();
                        }
                    }
                    else
                    {
                        if (hexarray[x, y].team == 1)
                        {
                            hexarray[x, y + 1].green();
                            hexarray[x - 1, y].green();
                            hexarray[x - 1, y + 1].green();
                        }
                        else if (hexarray[x, y].team == 2)
                        {
                            hexarray[x, y + 1].red();
                            hexarray[x - 1, y].red();
                            hexarray[x - 1, y + 1].red();
                        }
                    }
                }
                if(y + 1 == row)
                {
                    if (coll % 2 == 0)
                    {
                        if (hexarray[x, y].team == 1)
                        {
                            hexarray[x, y - 1].green();
                            hexarray[x - 1, y].green();
                        }
                        else if (hexarray[x, y].team == 2)
                        {
                            hexarray[x, y - 1].red();
                            hexarray[x - 1, y].red();
                        }
                    }
                    else
                    {
                        if (hexarray[x, y].team == 1)
                        {
                            hexarray[x, y - 1].green();
                            hexarray[x - 1, y].green();
                            hexarray[x - 1, y - 1].green();
                        }
                        else if (hexarray[x, y].team == 2)
                        {
                            hexarray[x, y - 1].red();
                            hexarray[x - 1, y].red();
                            hexarray[x - 1, y - 1].red();
                        }
                    }
                }
                else
                {
                    if (hexarray[x, y].team == 1)
                    {
                        hexarray[x, y - 1].green();
                        hexarray[x, y + 1].green();
                        hexarray[x - 1, y].green();
                        hexarray[x - 1, y - 1].green();
                    }
                    else if (hexarray[x, y].team == 2)
                    {
                        hexarray[x, y - 1].red();
                        hexarray[x, y + 1].red();
                        hexarray[x - 1, y].red();
                        hexarray[x - 1, y - 1].red();
                    }
                }
            }
            //
            else if(x == 0)
            {
                if (y == 0)
                {
                        if (hexarray[x, y].team == 1)
                        {
                            hexarray[x, y + 1].green();
                            hexarray[x + 1, y].green();
                        }
                        else if (hexarray[x, y].team == 2)
                        {
                            hexarray[x, y + 1].red();
                            hexarray[x + 1, y].red();
                        }
                 }
                if (y + 1 == row)
                {
                        if (hexarray[x, y].team == 1)
                        {
                            hexarray[x, y - 1].green();
                            hexarray[x + 1, y].green();
                            hexarray[x + 1, y - 1].green();
                        }
                        else if (hexarray[x, y].team == 2)
                        {
                            hexarray[x, y - 1].red();
                            hexarray[x + 1, y].red();
                            hexarray[x + 1, y - 1].red();
                        }
                }
                else
                {
                    if (hexarray[x, y].team == 1)
                    {
                        hexarray[x, y - 1].green();
                        hexarray[x, y + 1].green();
                        hexarray[x - 1, y].green();
                        hexarray[x - 1, y - 1].green();
                    }
                    else if (hexarray[x, y].team == 2)
                    {
                        hexarray[x, y - 1].red();
                        hexarray[x, y + 1].red();
                        hexarray[x - 1, y].red();
                        hexarray[x - 1, y - 1].red();
                    }
                }
            }
            //
        }
    }
}
