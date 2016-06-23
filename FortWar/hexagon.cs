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
    class hexagon
    {
        Image geksimage;
        public void hex(int x, int y, int w, int h, Canvas MainCanvas)
        {
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
            MainCanvas.Children.Add(geksimage);
        }
    }
}
