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
namespace FortWar
{
    public partial class MainWindow : Window
    {
        public static int MouseX = 0, MouseY = 0;
        public void ifMouseMove(object sender, MouseEventArgs e)
        {
            Point MousePt = e.GetPosition(this);
            CordsPanel.Content = String.Format("X: {0}, Y: {1}", MousePt.X, MousePt.Y);
            MouseX = (int)MousePt.X;
            MouseY = (int)MousePt.Y;
        }
        public MainWindow()
        {
            InitializeComponent();
            Menu choose = new Menu();
            choose.Menu_Start(MainCanvas);
        }
        
    }
}
