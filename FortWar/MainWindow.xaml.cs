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
    public partial class MainWindow : Window
    {
        string MainMode = "MainMenu", GameMode = "0", ScreenMode = "640x480";
        TextBox x, y;
        public static int MouseX = 0, MouseY = 0, WindowHeight = 480, WindowWidth = 640, borderX, borderY;
        public void BuildGame(int w, int h)
        {
            int X = 0, Y = 0;
            if (borderY >= 13 && borderY < 24)
            {

                for (int i = 0; i < borderX; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        Y += 22;
                    }
                    for (int j = 0; j < borderY; j++)
                    {
                        Geks(X, Y, 75, 44);
                        Y += 43;
                    }
                    X += 37;
                    Y = 0;
                }
            }
            else if(borderY >= 24)
            {
                for (int i = 0; i < borderX; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        Y += 16;
                    }
                    for (int j = 0; j < borderY; j++)
                    {
                        Geks(X, Y, 56, 32);
                        Y += 32;
                    }
                    X += 27;
                    Y = 0;
                }
            }
            else
            {
                for (int i = 0; i < borderX; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        Y += 32;
                    }
                    for (int j = 0; j < borderY; j++)
                    {
                        Geks(X, Y, 111, 64);
                        Y += 64;
                    }
                    X += 54;
                    Y = 0;
                }
            }
            if(borderX >= 32)
            {
                //Здесб нужно сделать скролл
            }
        }
        public void BuildMainMenu(int w, int h)
        {
            MainCanvas.Children.Clear();
            Button one_Player = new Button();
            Thickness one_Player_Margin = new Thickness();
            one_Player_Margin.Left = w * 2 / 3;
            one_Player_Margin.Top = h / 3;
            one_Player.Margin = one_Player_Margin;
            one_Player.Height = 32;
            one_Player.Width = 128;
            one_Player.Content = "Один игрок";
            one_Player.Click += GameModePanel_one;
            MainCanvas.Children.Add(one_Player);
            Button two_Players = new Button();
            Thickness two_Players_Margin = new Thickness();
            two_Players_Margin.Left = w * 2 / 3;
            two_Players_Margin.Top = h / 3 + 31;
            two_Players.Margin = two_Players_Margin;
            two_Players.Height = 32;
            two_Players.Width = 128;
            two_Players.Content = "Два игрока";
            two_Players.Click += GameModePanel_two;
            MainCanvas.Children.Add(two_Players);
            Button ExitButton = new Button();
            Thickness ExitButtonMargin = new Thickness();
            ExitButtonMargin.Left = w * 2 / 3;
            ExitButtonMargin.Top = h / 3 + 62;
            ExitButton.Margin = ExitButtonMargin;
            ExitButton.Height = 32;
            ExitButton.Width = 128;
            ExitButton.Content = "Выйти";
            ExitButton.Click += ExitGame;
            MainCanvas.Children.Add(ExitButton);
        }
        private void StartMenu(object sender, RoutedEventArgs e)
        {
            BuildMainMenu(WindowWidth, WindowHeight);
        }
        /*private void StartGame(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
            BuildGame(640, 480);
            MainMode = "Game";
        }*/
        /*private void SettingsPanel(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
            MainMode = "Settings";
            Button ChangeScreenButton = new Button();
            Thickness ChangeScreenButtonMargin = new Thickness();
            ChangeScreenButtonMargin.Left = WindowWidth * 2 / 3;
            ChangeScreenButtonMargin.Top = WindowHeight / 3;
            ChangeScreenButton.Margin = ChangeScreenButtonMargin;
            ChangeScreenButton.Height = 32;
            ChangeScreenButton.Width = 128;
            ChangeScreenButton.Content = "Разрешение окна";
            ChangeScreenButton.Click += ChangeScreenPanel;
            MainCanvas.Children.Add(ChangeScreenButton);
            Button ChangeGameMode = new Button();
            Thickness ChangeGameModeMargin = new Thickness();
            ChangeGameModeMargin.Left = WindowWidth * 2 / 3;
            ChangeGameModeMargin.Top = WindowHeight / 3 + 31;
            ChangeGameMode.Margin = ChangeGameModeMargin;
            ChangeGameMode.Height = 32;
            ChangeGameMode.Width = 128;
            ChangeGameMode.Content = "Режим игры";
            ChangeGameMode.Click += ChangeGameModePanel;
            MainCanvas.Children.Add(ChangeGameMode);
        }
        */
        //старт игры
        private void next_click(object sender, RoutedEventArgs e)
        {
            borderX = Int32.Parse(x.Text);
            borderY = Int32.Parse(y.Text);
            MainCanvas.Children.Clear();
            BuildGame(640, 480);
            if(borderY < 13)
            {
                this.Height = 64 * borderY + 64;
                this.Width = 111 * ((borderX + 1) / 2) + 15 * (borderX / 2);
            }
            else if(borderY >= 13 && borderY < 24)
            {
                this.Height = 44 * borderY + 44;
                this.Width = 75 * ((borderX + 1) / 2) + 6 * (borderX / 2);
            }
            else if(borderY >= 24 && borderY <= 31)
            {
                this.Height = 32 * borderY + 64;
                this.Width = 56 * ((borderX + 1) / 2) + 4 * (borderX / 2);
            }
            else
            {
                this.Height = 32 * 31 + 64;
                this.Width = 56 * ((borderX + 1) / 2) + 4 * (borderX / 2);
            }
            MainMode = "Game";
        }
        //Размер доски
        private void board_size(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
            Label info = new Label();
            Thickness info_margin = new Thickness();
            info_margin.Left = WindowWidth * 2 / 3;
            info_margin.Top = WindowHeight / 3;
            info.Margin = info_margin;
            info.Height = 32;
            info.Width = 128;
            info.Content = "Введите размер доски";
            MainCanvas.Children.Add(info);
            x = new TextBox();
            Thickness x_margin = new Thickness();
            x_margin.Left = WindowWidth * 2 / 3;
            x_margin.Top = WindowHeight / 3 + 31;
            x.Margin = x_margin;
            x.Height = 32;
            x.Width = 60;
            MainCanvas.Children.Add(x);
            y = new TextBox();
            Thickness y_margin = new Thickness();
            y_margin.Left = WindowWidth * 2 / 3 + 68;
            y_margin.Top = WindowHeight / 3 + 31;
            y.Margin = y_margin;
            y.Height = 32;
            y.Width = 60;
            MainCanvas.Children.Add(y);
            Button next = new Button();
            Thickness next_margin = new Thickness();
            next_margin.Left = WindowWidth * 2 / 3;
            next_margin.Top = WindowHeight / 3 + 62;
            next.Margin = next_margin;
            next.Height = 32;
            next.Width = 128;
            next.Content = "Далее";
            next.Click += next_click;
            MainCanvas.Children.Add(next);
            Button back = new Button();
            Thickness back_margin = new Thickness();
            back_margin.Left = WindowWidth * 2 / 3;
            back_margin.Top = WindowHeight / 3 + 93;
            back.Margin = back_margin;
            back.Height = 32;
            back.Width = 128;
            back.Content = "Назад";
            back.Click += StartMenu;
            MainCanvas.Children.Add(back);
        }
        //Режими для одного игрока
        private void GameModePanel_one(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
            MainMode = "Gamemode";
            Button first_mode = new Button();
            Thickness first_mode_margin = new Thickness();
            first_mode_margin.Left = WindowWidth * 2 / 3;
            first_mode_margin.Top = WindowHeight / 3;
            first_mode.Margin = first_mode_margin;
            first_mode.Height = 32;
            first_mode.Width = 128;
            first_mode.Content = "I’m too young to die";
            first_mode.Click += board_size;
            MainCanvas.Children.Add(first_mode);
            Button second_mode = new Button();
            Thickness second_mode_margin = new Thickness();
            second_mode_margin.Left = WindowWidth * 2 / 3;
            second_mode_margin.Top = WindowHeight / 3 + 31;
            second_mode.Margin = second_mode_margin;
            second_mode.Height = 32;
            second_mode.Width = 128;
            second_mode.Content = "Hey, not too rough";
            second_mode.Click += board_size;
            MainCanvas.Children.Add(second_mode);
            Button third_mode = new Button();
            Thickness third_mode_margin = new Thickness();
            third_mode_margin.Left = WindowWidth * 2 / 3;
            third_mode_margin.Top = WindowHeight / 3 + 62;
            third_mode.Margin = third_mode_margin;
            third_mode.Height = 32;
            third_mode.Width = 128;
            third_mode.Content = "Hurt me plenty";
            third_mode.Click += board_size;
            MainCanvas.Children.Add(third_mode);
            //кнопка назад
            Button back = new Button();
            Thickness back_margin = new Thickness();
            back_margin.Left = WindowWidth * 2 / 3;
            back_margin.Top = WindowHeight / 3 + 93;
            back.Margin = back_margin;
            back.Height = 32;
            back.Width = 128;
            back.Content = "Назад";
            back.Click += StartMenu;
            MainCanvas.Children.Add(back);
        }
        //для двоих игроков
        private void GameModePanel_two(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
            MainMode = "Gamemode";
            Button first_mode = new Button();
            Thickness first_mode_margin = new Thickness();
            first_mode_margin.Left = WindowWidth * 2 / 3;
            first_mode_margin.Top = WindowHeight / 3;
            first_mode.Margin = first_mode_margin;
            first_mode.Height = 32;
            first_mode.Width = 128;
            first_mode.Content = "I’m too young to die";
            first_mode.Click += board_size;
            MainCanvas.Children.Add(first_mode);
            Button second_mode = new Button();
            Thickness second_mode_margin = new Thickness();
            second_mode_margin.Left = WindowWidth * 2 / 3;
            second_mode_margin.Top = WindowHeight / 3 + 31;
            second_mode.Margin = second_mode_margin;
            second_mode.Height = 32;
            second_mode.Width = 128;
            second_mode.Content = "Hey, not too rough";
            second_mode.Click += board_size;
            MainCanvas.Children.Add(second_mode);
            Button third_mode = new Button();
            Thickness third_mode_margin = new Thickness();
            third_mode_margin.Left = WindowWidth * 2 / 3;
            third_mode_margin.Top = WindowHeight / 3 + 62;
            third_mode.Margin = third_mode_margin;
            third_mode.Height = 32;
            third_mode.Width = 128;
            third_mode.Content = "Hurt me plenty";
            third_mode.Click += board_size;
            MainCanvas.Children.Add(third_mode);
            //кнопка назад
            Button back = new Button();
            Thickness back_margin = new Thickness();
            back_margin.Left = WindowWidth * 2 / 3;
            back_margin.Top = WindowHeight / 3 + 93;
            back.Margin = back_margin;
            back.Height = 32;
            back.Width = 128;
            back.Content = "Назад";
            back.Click += StartMenu;
            MainCanvas.Children.Add(back);
        }
        private void ExitGame(object sender, RoutedEventArgs e)
        {
                this.Close();
        }
        private void ChangeScreenPanel(object sender, RoutedEventArgs e)
        {
                MainCanvas.Children.Clear();
        }
        private void ChangeGameModePanel(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
        }
        public void Geks(int X, int Y, int W, int H)
        {
            Image GeksImage = new Image();
            BitmapImage GeksImageSource = new BitmapImage();
            GeksImageSource.BeginInit();
            GeksImageSource.UriSource = new Uri("Geks.png", UriKind.Relative);
            GeksImageSource.EndInit();
            GeksImage.Source = GeksImageSource;
            Thickness GeksMarginCord = new Thickness();
            GeksMarginCord.Left = X;
            GeksMarginCord.Top = Y;
            GeksImage.Margin = GeksMarginCord;
            GeksImage.Height = H;
            GeksImage.Width = W;
            MainCanvas.Children.Add(GeksImage);
        }
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
            BuildMainMenu(WindowWidth, WindowHeight);
        }
        
    }
}
