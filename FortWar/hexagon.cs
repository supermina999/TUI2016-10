using System;
//using System.Drawing;
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
using System.IO;
namespace FortWar
{
    class hexagon
    {
        public Image geksimage;
        public bool iscity = false;
        public bool istower = false,isredtower = false,isgreentower = false;
        public int team = 0;//1 = green, 2 = red
        Canvas z;
        public void hex(int x, int y, int w, int h, Canvas MainCanvas)
        {
            z = MainCanvas;
            geksimage = new Image();
            BitmapImage GeksImageSource = new BitmapImage();
            GeksImageSource.BeginInit();
            GeksImageSource.UriSource = new Uri("Geks.png", UriKind.Relative);
            GeksImageSource.EndInit();
            geksimage.Source = GeksImageSource;
            Thickness GeksMarginCord = new Thickness();
            GeksMarginCord.Left = x;
            GeksMarginCord.Top = y;
            geksimage.Margin = GeksMarginCord;
            geksimage.Height = h;
            geksimage.Width = w;
            //geksimage.MouseUp += geksimage_Click; 
            MainCanvas.Children.Add(geksimage);
        }
        public void greentower()
        {
            if (iscity == false)
            {
                isgreentower = true;
                isredtower = false;
                team = 1;
                istower = true;
                geksimage.Source = new BitmapImage(new Uri("firsttower.png", UriKind.Relative));
            }
        }
        public void redtower()
        {
            if (iscity == false)
            {
                isgreentower = false;
                isredtower = true;
                team = 2;
                istower = true;
                geksimage.Source = new BitmapImage(new Uri("secondtower.png", UriKind.Relative));
            }
        }
        public void greencity()
        {
            team = 1;
            iscity = true;
            geksimage.Source = new BitmapImage(new Uri("firstcastle.png", UriKind.Relative));
        }
        public void redcity()
        {
            team = 2;
            iscity = true;
            geksimage.Source = new BitmapImage(new Uri("secondcastle.png", UriKind.Relative));
        }
        public void green()
        {
            if (iscity == false)
            {
                    team = 1;
                if (istower == false)
                {
                    geksimage.Source = new BitmapImage(new Uri("firstteamgeks.png", UriKind.Relative));
                }
            }
        }
        public void red()
        {
            if (iscity == false)
            {
                team = 2;
                if (istower == false)
                {
                    geksimage.Source = new BitmapImage(new Uri("secondteamgeks.png", UriKind.Relative));
                }
            }
        }
    }
}
