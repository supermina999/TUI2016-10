﻿using System;
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
//kek
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Menu choose = new Menu();
            choose.Menu_Start(MainCanvas);
        }
        
    }
}
