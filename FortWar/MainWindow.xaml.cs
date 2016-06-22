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
    public class hexagon
    {
        Image geksimage;
        public void hex(int x,int y,int w,int h,Canvas MainCanvas)
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
    public class gamefield
    {
        hexagon[,] hexarray;
        public void buildfield(int borderx,int bordery,int numberofsteps,Canvas MainCanvas)
        {
            hexarray = new hexagon[borderx,bordery];
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
                        hexarray[i, j].hex(x, y, 75, 44,MainCanvas);
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
    public class Menu
    {
        Button startgame, settings, ExitButton;
        Canvas MainCanvas;
        static public int WindowHeight = 768, WindowWidth = 1024,stepsnumber = 3,sizex = 7,sizey = 7;
        Label info; //Information about choosing the gamemode
        Label numberinfo; //Information about choosing the number of steps
        Label sizeinfo; //Information about choosing the size of the board
        Button gamemode, back;
        TextBox numberofsteps;
        TextBox borderx, bordery;
        public int gamemodecounter = 0;
        string[] gamemodes = { "I’m too young to die", "Hey, not too rough", "Hurt me plenty" };
        public void Menu_Start(Canvas x)
        {
            MainCanvas = new Canvas();
            MainCanvas = x;
            MainCanvas.Children.Clear();
            startgame = new Button();
            Thickness startgameMargin = new Thickness();
            startgameMargin.Left = WindowWidth * 2 / 3;
            startgameMargin.Top = WindowHeight / 3;
            startgame.Margin = startgameMargin;
            startgame.Height = 51;
            startgame.Width = 205;
            startgame.Content = "Начать игру";
            startgame.Click += start_Click;
            settings = new Button();
            Thickness settingsmargin = new Thickness();
            settingsmargin.Left = WindowWidth * 2 / 3;
            settingsmargin.Top = WindowHeight / 3 + 51;
            settings.Margin = settingsmargin;
            settings.Height = 51;
            settings.Width = 205;
            settings.Content = "Настройки";
            settings.Click += settings_Click;
            ExitButton = new Button();
            Thickness ExitButtonMargin = new Thickness();
            ExitButtonMargin.Left = WindowWidth * 2 / 3;
            ExitButtonMargin.Top = WindowHeight / 3 + 102;
            ExitButton.Margin = ExitButtonMargin;
            ExitButton.Height = 51;
            ExitButton.Width = 205;
            ExitButton.Content = "Выйти";
            ExitButton.Click += exitbutton_Click;
            MainCanvas.Children.Add(startgame);
            MainCanvas.Children.Add(settings);
            MainCanvas.Children.Add(ExitButton);
        }
        public void Settings_Start()
        {
            MainCanvas.Children.Clear();
            info = new Label();
            Thickness infothickness = new Thickness();
            infothickness.Left = WindowWidth * 2 / 3;
            infothickness.Top = WindowHeight / 3;
            info.Margin = infothickness;
            info.Height = 51;
            info.Width = 205;
            info.Content = "Выберете режим игры.";
            MainCanvas.Children.Add(info);
            gamemode = new Button();
            Thickness gamemodemargin = new Thickness();
            gamemodemargin.Left = WindowWidth * 2 / 3;
            gamemodemargin.Top = WindowHeight / 3 + 102;
            gamemode.Margin = gamemodemargin;
            gamemode.Height = 51;
            gamemode.Width = 205;
            gamemode.Content = gamemodes[gamemodecounter];
            gamemode.Click += gamemode_Click;
            MainCanvas.Children.Add(gamemode);
            numberinfo = new Label();
            Thickness numberinfothickness = new Thickness();
            numberinfothickness.Left = WindowWidth * 2 / 3;
            numberinfothickness.Top = WindowHeight / 3 + 153;
            numberinfo.Margin = numberinfothickness;
            numberinfo.Height = 51;
            numberinfo.Width = 205;
            numberinfo.Content = "Введите колличество ходов.";
            MainCanvas.Children.Add(numberinfo);
            numberofsteps = new TextBox();
            Thickness numberofstepsmargin = new Thickness();
            numberofstepsmargin.Left = WindowWidth * 2 / 3;
            numberofstepsmargin.Top = WindowHeight / 3 + 204;
            numberofsteps.Margin = numberofstepsmargin;
            numberofsteps.Height = 51;
            numberofsteps.Width = 205;
            numberofsteps.Text = stepsnumber.ToString();
            MainCanvas.Children.Add(numberofsteps);
            sizeinfo = new Label();
            Thickness sizeinfothickness = new Thickness();
            sizeinfothickness.Left = WindowWidth * 2 / 3;
            sizeinfothickness.Top = WindowHeight / 3 + 255;
            sizeinfo.Margin = sizeinfothickness;
            sizeinfo.Height = 51;
            sizeinfo.Width = 205;
            sizeinfo.Content = "Введите размер поля.";
            MainCanvas.Children.Add(sizeinfo);
            borderx = new TextBox();
            Thickness borderxmargin = new Thickness();
            borderxmargin.Left = WindowWidth * 2 / 3;
            borderxmargin.Top = WindowHeight / 3 + 306;
            borderx.Margin = borderxmargin;
            borderx.Height = 51;
            borderx.Width = 100;
            borderx.Text = sizex.ToString();
            MainCanvas.Children.Add(borderx);
            bordery = new TextBox();
            Thickness borderymargin = new Thickness();
            borderymargin.Left = WindowWidth * 2 / 3 + 105;
            borderymargin.Top = WindowHeight / 3 + 306;
            bordery.Margin = borderymargin;
            bordery.Height = 51;
            bordery.Width = 100;
            bordery.Text = sizey.ToString();
            MainCanvas.Children.Add(bordery);
            back = new Button();
            Thickness backmargin = new Thickness();
            backmargin.Left = WindowWidth * 2 / 3;
            backmargin.Top = WindowHeight / 3 + 357;
            back.Margin = backmargin;
            back.Height = 51;
            back.Width = 205;
            back.Content = "Назад";
            back.Click += back_Click;
            MainCanvas.Children.Add(back);
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            gamefield game = new gamefield();
            MainCanvas.Children.Clear();
            game.buildfield(sizex,sizey,stepsnumber,MainCanvas);
        }
        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings_Start();
        }
        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void gamemode_Click(object sender, RoutedEventArgs e)
        {
            gamemodecounter++;
            if (gamemodecounter > 2)
                gamemodecounter = 0;
            gamemode.Content = gamemodes[gamemodecounter];
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (numberofsteps.Text == null)
            {
                stepsnumber = 3;
            }
            stepsnumber = Int32.Parse(numberofsteps.Text);
            if (borderx.Text == null)
            {
                sizex = 7;
            }
            sizex = Int32.Parse(borderx.Text);
            if (bordery.Text == null)
            {
                sizey = 7;
            }
            sizey = Int32.Parse(bordery.Text);
            Menu_Start(MainCanvas);
        }
    }
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
