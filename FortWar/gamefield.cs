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
        int step, queue = 3;
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
                        hexarray[i, j].geksimage.MouseUp += geksimage_Click;
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
                        hexarray[i, j].geksimage.MouseUp += geksimage_Click;
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
                        hexarray[i, j].geksimage.MouseUp += geksimage_Click;
                        y += 64;
                    }
                    x += 54;
                    y = 0;
                }
            }
            hexarray[firstcityx - 1, firstcityy - 1].greencity();
            hexarray[secondcityx - 1, secondcityy - 1].redcity();
            fillwithcolour(firstcityx - 1, firstcityy - 1,0);
            fillwithcolour(secondcityx - 1, secondcityy - 1,0);
        }
        public void fillwithcolour(int x, int y,int que)
        {
            if (x + 1 == coll)
            {
                if (y == 0)
                {
                    if (coll % 2 != 0)
                    {
                        if (hexarray[x, y].team == 1 || (que % 2 == 0 && que !=0))
                        {
                            hexarray[x, y + 1].green();
                            hexarray[x - 1, y].green();
                        }
                        else if (hexarray[x, y].team == 2 || que % 2 != 0)
                        {
                            hexarray[x, y + 1].red();
                            hexarray[x - 1, y].red();
                        }
                    }
                    else
                    {
                        if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                        {
                            hexarray[x, y + 1].green();
                            hexarray[x - 1, y].green();
                            hexarray[x - 1, y + 1].green();
                        }
                        else if (hexarray[x, y].team == 2 || que % 2 != 0)
                        {
                            hexarray[x, y + 1].red();
                            hexarray[x - 1, y].red();
                            hexarray[x - 1, y + 1].red();
                        }
                    }
                }
               else if (y + 1 == row)
                {
                    if (coll % 2 == 0)
                    {
                        if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                        {
                            hexarray[x, y - 1].green();
                            hexarray[x - 1, y].green();
                        }
                        else if (hexarray[x, y].team == 2 || que % 2 != 0)
                        {
                            hexarray[x, y - 1].red();
                            hexarray[x - 1, y].red();
                        }
                    }
                    else
                    {
                        if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                        {
                            hexarray[x, y - 1].green();
                            hexarray[x - 1, y].green();
                            hexarray[x - 1, y - 1].green();
                        }
                        else if (hexarray[x, y].team == 2 || que % 2 != 0)
                        {
                            hexarray[x, y - 1].red();
                            hexarray[x - 1, y].red();
                            hexarray[x - 1, y - 1].red();
                        }
                    }
                }
                else
                {
                    if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                    {
                        hexarray[x, y - 1].green();
                        hexarray[x, y + 1].green();
                        hexarray[x - 1, y].green();
                        hexarray[x - 1, y - 1].green();
                    }
                    else if (hexarray[x, y].team == 2 || que % 2 != 0)
                    {
                        hexarray[x, y - 1].red();
                        hexarray[x, y + 1].red();
                        hexarray[x - 1, y].red();
                        hexarray[x - 1, y - 1].red();
                    }
                }
            }
            //
            else if (x == 0)
            {
                if (y == 0)
                {
                    if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                    {
                        hexarray[x, y + 1].green();
                        hexarray[x + 1, y].green();
                    }
                    else if (hexarray[x, y].team == 2 || que % 2 != 0)
                    {
                        hexarray[x, y + 1].red();
                        hexarray[x + 1, y].red();
                    }
                }
                else if (y + 1 == row)
                {
                    if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                    {
                        hexarray[x, y - 1].green();
                        hexarray[x + 1, y].green();
                        hexarray[x + 1, y - 1].green();
                    }
                    else if (hexarray[x, y].team == 2 || que % 2 != 0)
                    {
                        hexarray[x, y - 1].red();
                        hexarray[x + 1, y].red();
                        hexarray[x + 1, y - 1].red();
                    }
                }
                else
                {
                    if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                    {
                        hexarray[x, y - 1].green();
                        hexarray[x, y + 1].green();
                        hexarray[x + 1, y].green();
                        hexarray[x + 1, y - 1].green();
                    }
                    else if (hexarray[x, y].team == 2 || que % 2 != 0)
                    {
                        hexarray[x, y - 1].red();
                        hexarray[x, y + 1].red();
                        hexarray[x + 1, y].red();
                        hexarray[x + 1, y - 1].red();
                    }
                }
            }
            //
            else if (y == 0)
            {
                if ((x + 1) % 2 == 0)
                {
                    if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                    {
                        hexarray[x, y + 1].green();
                        hexarray[x - 1, y].green();
                        hexarray[x - 1, y + 1].green();
                        hexarray[x + 1, y].green();
                        hexarray[x + 1, y + 1].green();
                    }
                    else if (hexarray[x, y].team == 2 || que % 2 != 0)
                    {
                        hexarray[x, y + 1].red();
                        hexarray[x - 1, y].red();
                        hexarray[x - 1, y + 1].red();
                        hexarray[x + 1, y].red();
                        hexarray[x + 1, y + 1].red();
                    }
                }
                else
                {
                    if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                    {
                        hexarray[x, y + 1].green();
                        hexarray[x - 1, y].green();
                        hexarray[x + 1, y].green();
                    }
                    else if (hexarray[x, y].team == 2 || que % 2 != 0)
                    {
                        hexarray[x, y + 1].red();
                        hexarray[x - 1, y].red();
                        hexarray[x + 1, y].red();
                    }
                }
            }
            //
            else if(y + 1 == row)
            {
                if ((x + 1) % 2 != 0)
                {
                    if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                    {
                        hexarray[x, y - 1].green();
                        hexarray[x - 1, y].green();
                        hexarray[x - 1, y - 1].green();
                        hexarray[x + 1, y].green();
                        hexarray[x + 1, y - 1].green();
                    }
                    else if (hexarray[x, y].team == 2 || que % 2 != 0)
                    {
                        hexarray[x, y - 1].red();
                        hexarray[x - 1, y].red();
                        hexarray[x - 1, y - 1].red();
                        hexarray[x + 1, y].red();
                        hexarray[x + 1, y - 1].red();
                    }
                }
                else
                {
                    if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                    {
                        hexarray[x, y - 1].green();
                        hexarray[x - 1, y].green();
                        hexarray[x + 1, y].green();
                    }
                    else if (hexarray[x, y].team == 2 || que % 2 != 0)
                    {
                        hexarray[x, y - 1].red();
                        hexarray[x - 1, y].red();
                        hexarray[x + 1, y].red();
                    }
                }
            }
            else
            {
                if((x + 1) % 2 == 0)
                {
                    if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                    {
                        hexarray[x, y + 1].green();
                        hexarray[x, y - 1].green();
                        hexarray[x - 1, y].green();
                        hexarray[x - 1, y + 1].green();
                        hexarray[x + 1, y].green();
                        hexarray[x + 1, y + 1].green();
                    }
                    else if (hexarray[x, y].team == 2 || que % 2 != 0)
                    {
                        hexarray[x, y + 1].red();
                        hexarray[x, y - 1].red();
                        hexarray[x - 1, y].red();
                        hexarray[x - 1, y + 1].red();
                        hexarray[x + 1, y].red();
                        hexarray[x + 1, y + 1].red();
                    }
                }
                else
                {
                    if (hexarray[x, y].team == 1 || (que % 2 == 0 && que != 0))
                    {
                        hexarray[x, y + 1].green();
                        hexarray[x, y - 1].green();
                        hexarray[x - 1, y].green();
                        hexarray[x - 1, y - 1].green();
                        hexarray[x + 1, y].green();
                        hexarray[x + 1, y - 1].green();
                    }
                    else if (hexarray[x, y].team == 2 || que % 2 != 0)
                    {
                        hexarray[x, y + 1].red();
                        hexarray[x, y - 1].red();
                        hexarray[x - 1, y].red();
                        hexarray[x - 1, y - 1].red();
                        hexarray[x + 1, y].red();
                        hexarray[x + 1, y - 1].red();
                    }
                }
            }
        }
        public bool clickcheck(int x, int y, int que)
        {
            if(que % 2 == 0 && hexarray[x, y].team == 2)
            {
                return false;
            }
            if(que % 2 != 0 && hexarray[x, y].team == 1)
            {
                return false;
            }
            bool a = false;
            if (x + 1 == coll)
            {
                if (y == 0)
                {
                    if (coll % 2 != 0)
                    {
                        if (que % 2 == 0)
                        {
                            if(hexarray[x, y + 1].team == 1 || hexarray[x - 1, y].team == 1)
                            {
                                a = true;
                            }
                        }
                        else if (que % 2 != 0)
                        {
                            if (hexarray[x, y + 1].team == 2 || hexarray[x - 1, y].team == 2)
                            {
                                a = true;
                            }
                        }
                    }
                    else
                    {
                        if (que % 2 == 0)
                        {
                            if (hexarray[x, y + 1].team == 1 || hexarray[x - 1, y].team == 1 || hexarray[x - 1, y + 1].team == 1)
                            {
                                a = true;
                            }
                        }
                        else if (que % 2 != 0)
                        {
                            if (hexarray[x, y + 1].team == 2 || hexarray[x - 1, y].team == 2 || hexarray[x - 1, y + 1].team == 2)
                            {
                                a = true;
                            }
                        }
                    }
                }
                else if (y + 1 == row)
                {
                    if (coll % 2 == 0)
                    {
                        if (que % 2 == 0)
                        {
                            if (hexarray[x, y - 1].team == 1 || hexarray[x - 1, y].team == 1)
                            {
                                a = true;
                            }
                        }
                        else if (que % 2 != 0)
                        {
                            if (hexarray[x, y - 1].team == 2 || hexarray[x - 1, y].team == 2)
                            {
                                a = true;
                            }
                        }
                    }
                    else
                    {
                        if (que % 2 == 0)
                        {
                            if (hexarray[x, y - 1].team == 1 || hexarray[x - 1, y].team == 1 || hexarray[x - 1, y - 1].team == 1)
                            {
                                a = true;
                            }
                        }
                        else if (que % 2 != 0)
                        {
                            if (hexarray[x, y - 1].team == 2 || hexarray[x - 1, y].team == 2 || hexarray[x - 1, y - 1].team == 2)
                            {
                                a = true;
                            }
                        }
                    }
                }
                else
                {
                    if (que % 2 == 0)
                    {
                        if (hexarray[x, y - 1].team == 1 || hexarray[x - 1, y].team == 1 || hexarray[x - 1, y - 1].team == 1 || hexarray[x, y + 1].team == 1)
                        {
                            a = true;
                        }
                    }
                    else if (que % 2 != 0)
                    {
                        if (hexarray[x, y - 1].team == 1 || hexarray[x - 1, y].team == 1 || hexarray[x - 1, y - 1].team == 1 || hexarray[x, y + 1].team == 1)
                        {
                            a = true;
                        }
                    }
                }
            }
            //
            else if (x == 0)
            {
                if (y == 0)
                {
                    if (que % 2 == 0)
                    {
                        if(hexarray[x, y + 1].team == 1 || hexarray[x + 1, y].team == 1)
                        {
                            a = true;
                        }
                    }
                    else if (que % 2 != 0)
                    {
                        if (hexarray[x, y + 1].team == 2 || hexarray[x + 1, y].team == 2)
                        {
                            a = true;
                        }
                    }
                }
                else if (y + 1 == row)
                {
                    if (que % 2 == 0)
                    {
                        if (hexarray[x, y - 1].team == 1 || hexarray[x + 1, y].team == 1 || hexarray[x + 1, y - 1].team == 1)
                        {
                            a = true;
                        }
                    }
                    else if (que % 2 != 0)
                    {
                        if (hexarray[x, y - 1].team == 2 || hexarray[x + 1, y].team == 2 || hexarray[x + 1, y - 1].team == 2)
                        {
                            a = true;
                        }
                    }
                }
                else
                {
                    if (que % 2 == 0)
                    {
                        if (hexarray[x, y - 1].team == 1 || hexarray[x + 1, y].team == 1 || hexarray[x + 1, y - 1].team == 1 || hexarray[x, y + 1].team == 1)
                        {
                            a = true;
                        }
                    }
                    else if (que % 2 != 0)
                    {
                        if (hexarray[x, y - 1].team == 2 || hexarray[x + 1, y].team == 2 || hexarray[x + 1, y - 1].team == 2 || hexarray[x, y + 1].team == 2)
                        {
                            a = true;
                        }
                    }
                }
            }
            //
            else if (y == 0)
            {
                if ((x + 1) % 2 == 0)
                {
                    if (que % 2 == 0)
                    {
                        if (hexarray[x, y + 1].team == 1 || hexarray[x - 1, y].team == 1 || hexarray[x - 1, y + 1].team == 1 || hexarray[x + 1, y].team == 1 || hexarray[x + 1, y + 1].team == 1)
                        {
                            a = true;
                        }
                    }
                    else if (que % 2 != 0)
                    {
                        if (hexarray[x, y + 1].team == 2 || hexarray[x - 1, y].team == 2 || hexarray[x - 1, y + 1].team == 2 || hexarray[x + 1, y].team == 2 || hexarray[x + 1, y + 1].team == 2)
                        {
                            a = true;
                        }
                    }
                }
                else
                {
                    if (que % 2 == 0)
                    {
                        if (hexarray[x, y + 1].team == 1 || hexarray[x - 1, y].team == 1 || hexarray[x + 1, y].team == 1)
                        {
                            a = true;
                        }
                    }
                    else if (que % 2 != 0)
                    {
                        if (hexarray[x, y + 1].team == 2 || hexarray[x - 1, y].team == 2 || hexarray[x + 1, y].team == 2)
                        {
                            a = true;
                        }
                    }
                }
            }
            //
            else if (y + 1 == row)
            {
                if ((x + 1) % 2 != 0)
                {
                    if(que % 2 == 0)
                    {
                        if (hexarray[x, y - 1].team == 1 || hexarray[x - 1, y].team == 1 || hexarray[x - 1, y - 1].team == 1 || hexarray[x + 1, y].team == 1 || hexarray[x + 1, y - 1].team == 1)
                        {
                            a = true;
                        }
                    }
                    else if (que % 2 != 0)
                    {
                        if (hexarray[x, y - 1].team == 2 || hexarray[x - 1, y].team == 2 || hexarray[x - 1, y - 1].team == 2 || hexarray[x + 1, y].team == 2 || hexarray[x + 1, y - 1].team == 2)
                        {
                            a = true;
                        }
                    }
                }
                else
                {
                    if (que % 2 == 0)
                    {
                        if (hexarray[x, y - 1].team == 1 || hexarray[x - 1, y].team == 1 || hexarray[x + 1, y].team == 1)
                        {
                            a = true;
                        }
                    }
                    else if (que % 2 != 0)
                    {
                        if (hexarray[x, y - 1].team == 2 || hexarray[x - 1, y].team == 2 || hexarray[x + 1, y].team == 2)
                        {
                            a = true;
                        }
                    }
                }
            }
            else
            {
                if ((x + 1) % 2 == 0)
                {

                    if (que % 2 == 0)
                    {
                        if (hexarray[x, y + 1].team == 1 || hexarray[x, y - 1].team == 1 || hexarray[x - 1, y].team == 1 || hexarray[x - 1, y + 1].team == 1 || hexarray[x + 1, y].team == 1 || hexarray[x + 1, y + 1].team == 1)
                        {
                            a = true;
                        }
                    }
                    else if (que % 2 != 0)
                    {
                        if (hexarray[x, y + 1].team == 2 || hexarray[x, y - 1].team == 2 || hexarray[x - 1, y].team == 2 || hexarray[x - 1, y + 1].team == 2 || hexarray[x + 1, y].team == 2 || hexarray[x + 1, y + 1].team == 2)
                        {
                            a = true;
                        }
                    }
                }
                else
                {
                    if (que % 2 == 0)
                    {
                        if (hexarray[x, y + 1].team == 1 || hexarray[x, y - 1].team == 1 || hexarray[x - 1, y].team == 1 || hexarray[x - 1, y - 1].team == 1 || hexarray[x + 1, y].team == 1 || hexarray[x + 1, y - 1].team == 1)
                        {
                            a = true;
                        }
                    }
                    else if (que % 2 != 0)
                    {
                        if (hexarray[x, y + 1].team == 2 || hexarray[x, y - 1].team == 2 || hexarray[x - 1, y].team == 2 || hexarray[x - 1, y - 1].team == 2 || hexarray[x + 1, y].team == 2 || hexarray[x + 1, y - 1].team == 2)
                        {
                            a = true;
                        }
                    }
                }
            }
            return a;
        }
        public void geksimage_Click(object sender, MouseEventArgs e)
        {
            int xelement = 0, yelement = 0;
            for(int i = 0;i < coll;i++)
            {
                for(int j = 0;j < row;j++)
                {
                    if(hexarray[i,j].geksimage.IsMouseOver)
                    {
                        xelement = i;
                        yelement = j;
                        break;
                    }
                }
            }
            if (hexarray[xelement, yelement].iscity == false && hexarray[xelement, yelement].istower == false && clickcheck(xelement,yelement,queue))
            {
                fillwithcolour(xelement, yelement, queue);
                if(queue % 2 == 0)
                {
                    hexarray[xelement, yelement].greentower();
                }
                else
                {
                    hexarray[xelement, yelement].redtower();
                }
                queue++;
            }
        }
    }
}
