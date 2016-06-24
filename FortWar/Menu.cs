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
    class Menu
    {

        Button startgame, settings, ExitButton;
        Canvas MainCanvas;
        static public int WindowHeight = 768, WindowWidth = 1024, stepsnumber = 3, sizex = 7, sizey = 7,startfcx = 1,startfcy = sizey / 2,startscx = sizex,startscy = startfcy + 2;
        Label info; //Information about choosing the gamemode
        Label numberinfo; //Information about choosing the number of steps
        Label sizeinfo; //Information about choosing the size of the board
        Label startpositioninfo;
        Label numberofplayersinfo;
        Button gamemode, back,player;
        TextBox numberofsteps;
        TextBox borderx, bordery;
        TextBox firstcityx, firstcityy, secondcityx, secondcityy;
        public int gamemodecounter = 0,playercounter = 0;
        string[] gamemodes = { "I’m too young to die", "Hey, not too rough", "Hurt me plenty" },players = {"One player", "Two players"};
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
            infothickness.Top = WindowHeight / 3 - 176;
            info.Margin = infothickness;
            info.Height = 51;
            info.Width = 205;
            info.Content = "Выберете режим игры.";
            MainCanvas.Children.Add(info);
            gamemode = new Button();
            Thickness gamemodemargin = new Thickness();
            gamemodemargin.Left = WindowWidth * 2 / 3;
            gamemodemargin.Top = WindowHeight / 3 - 153;
            gamemode.Margin = gamemodemargin;
            gamemode.Height = 51;
            gamemode.Width = 205;
            gamemode.Content = gamemodes[gamemodecounter];
            gamemode.Click += gamemode_Click;
            MainCanvas.Children.Add(gamemode);
            numberinfo = new Label();
            Thickness numberinfothickness = new Thickness();
            numberinfothickness.Left = WindowWidth * 2 / 3;
            numberinfothickness.Top = WindowHeight / 3 - 74;
            numberinfo.Margin = numberinfothickness;
            numberinfo.Height = 51;
            numberinfo.Width = 205;
            numberinfo.Content = "Введите колличество ходов.";
            MainCanvas.Children.Add(numberinfo);
            numberofsteps = new TextBox();
            Thickness numberofstepsmargin = new Thickness();
            numberofstepsmargin.Left = WindowWidth * 2 / 3;
            numberofstepsmargin.Top = WindowHeight / 3 - 51;
            numberofsteps.Margin = numberofstepsmargin;
            numberofsteps.Height = 51;
            numberofsteps.Width = 205;
            numberofsteps.Text = stepsnumber.ToString();
            MainCanvas.Children.Add(numberofsteps);
            sizeinfo = new Label();
            Thickness sizeinfothickness = new Thickness();
            sizeinfothickness.Left = WindowWidth * 2 / 3;
            sizeinfothickness.Top = WindowHeight / 3 + 28;
            sizeinfo.Margin = sizeinfothickness;
            sizeinfo.Height = 51;
            sizeinfo.Width = 205;
            sizeinfo.Content = "Введите размер поля.";
            MainCanvas.Children.Add(sizeinfo);
            borderx = new TextBox();
            Thickness borderxmargin = new Thickness();
            borderxmargin.Left = WindowWidth * 2 / 3;
            borderxmargin.Top = WindowHeight / 3 + 51;
            borderx.Margin = borderxmargin;
            borderx.Height = 51;
            borderx.Width = 100;
            borderx.Text = sizex.ToString();
            MainCanvas.Children.Add(borderx);
            bordery = new TextBox();
            Thickness borderymargin = new Thickness();
            borderymargin.Left = WindowWidth * 2 / 3 + 105;
            borderymargin.Top = WindowHeight / 3 + 51;
            bordery.Margin = borderymargin;
            bordery.Height = 51;
            bordery.Width = 100;
            bordery.Text = sizey.ToString();
            MainCanvas.Children.Add(bordery);
            startpositioninfo = new Label();
            Thickness startpositioninfothickness = new Thickness();
            startpositioninfothickness.Left = WindowWidth * 2 / 3;
            startpositioninfothickness.Top = WindowHeight / 3 + 130;
            startpositioninfo.Margin = startpositioninfothickness;
            startpositioninfo.Height = 51;
            startpositioninfo.Width = 205;
            startpositioninfo.Content = "Введите координаты городов.";
            MainCanvas.Children.Add(startpositioninfo);
            firstcityx = new TextBox();
            Thickness firstcityxmargin = new Thickness();
            firstcityxmargin.Left = WindowWidth * 2 / 3;
            firstcityxmargin.Top = WindowHeight / 3 + 153;
            firstcityx.Margin = firstcityxmargin;
            firstcityx.Height = 23;
            firstcityx.Width = 100;
            firstcityx.Text = startfcx.ToString(); 
            MainCanvas.Children.Add(firstcityx);
            firstcityy = new TextBox();
            Thickness firstcityymargin = new Thickness();
            firstcityymargin.Left = WindowWidth * 2 / 3 + 105;
            firstcityymargin.Top = WindowHeight / 3 + 153;
            firstcityy.Margin = firstcityymargin;
            firstcityy.Height = 23;
            firstcityy.Width = 100;
            firstcityy.Text = startfcy.ToString();
            MainCanvas.Children.Add(firstcityy);
            secondcityx = new TextBox();
            Thickness secondcityxmargin = new Thickness();
            secondcityxmargin.Left = WindowWidth * 2 / 3;
            secondcityxmargin.Top = WindowHeight / 3 + 153 + 28;
            secondcityx.Margin = secondcityxmargin;
            secondcityx.Height = 23;
            secondcityx.Width = 100;
            secondcityx.Text = startscx.ToString(); 
            MainCanvas.Children.Add(secondcityx);
            secondcityy = new TextBox();
            Thickness secondcityymargin = new Thickness();
            secondcityymargin.Left = WindowWidth * 2 / 3 + 105;
            secondcityymargin.Top = WindowHeight / 3 + 153 + 28;
            secondcityy.Margin = secondcityymargin;
            secondcityy.Height = 23;
            secondcityy.Width = 100;
            secondcityy.Text = startscy.ToString(); 
            MainCanvas.Children.Add(secondcityy);
            numberofplayersinfo = new Label();
            Thickness numberofplayersinfothickness = new Thickness();
            numberofplayersinfothickness.Left = WindowWidth * 2 / 3;
            numberofplayersinfothickness.Top = WindowHeight / 3 + 232;
            numberofplayersinfo.Margin = numberofplayersinfothickness;
            numberofplayersinfo.Height = 51;
            numberofplayersinfo.Width = 205;
            numberofplayersinfo.Content = "Один или два игрока.";
            MainCanvas.Children.Add(numberofplayersinfo);
            player = new Button();
            Thickness playermargin = new Thickness();
            playermargin.Left = WindowWidth * 2 / 3;
            playermargin.Top = WindowHeight / 3 + 255;
            player.Margin = playermargin;
            player.Height = 51;
            player.Width = 205;
            player.Content = players[playercounter];
            player.Click += player_Click;
            MainCanvas.Children.Add(player);
            back = new Button();
            Thickness backmargin = new Thickness();
            backmargin.Left = WindowWidth * 2 / 3;
            backmargin.Top = WindowHeight / 3 + 337;
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
            game.buildfield(sizex, sizey, stepsnumber, MainCanvas, startfcx, startfcy, startscx, startscy);
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
        private void player_Click(object sender, RoutedEventArgs e)
        {
            playercounter++;
            if(playercounter > 1)
               playercounter = 0;
            player.Content = players[playercounter];
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
            startfcx = Int32.Parse(firstcityx.Text);
            if (startfcx < 1 || startfcx > sizex)
            {
                MessageBox.Show("Недопустимое значение координат города!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                startfcx = 1;
            }
            startfcy = Int32.Parse(firstcityy.Text);
            if (startfcy < 1 || startfcy > sizey)
            {
                MessageBox.Show("Недопустимое значение координат города!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                startfcy = sizey / 2;
            }
            startscx = Int32.Parse(secondcityx.Text);
            if (startscx < 1 || startscx > sizex)
            {
                MessageBox.Show("Недопустимое значение координат города!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                startscx = sizex;
            }
            startscy = Int32.Parse(secondcityy.Text);
            if (startscy < 1 || startscy > sizey)
            {
                MessageBox.Show("Недопустимое значение координат города!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                startscy = sizey / 2;
            }
            if(startfcx == startscx && startfcy == startscy)
            {
                MessageBox.Show("Недопустимое значение координат города!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                startscy = sizey / 2;
                startfcy = sizey / 2;
                startfcx = 1;
                startscx = sizex;
            }
            Menu_Start(MainCanvas);
        }
    }
}
/* public int Startfcx
       {
           get
           {
               return startfcx;
           }
           set
           {
               if (value < sizex || value > sizex || value == startscx)
               {
                   MessageBox.Show("Недопустимое значение координат города!","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                   startfcx = 1;
               }
               else startfcx = value;
           }
       }
       public int Startfcy
       {
           get
           {
               return startfcy;
           }
           set
           {
               if (value < sizey || value > sizey || value == startscy)
               {
                   MessageBox.Show("Недопустимое значение координат города!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                   startfcy = sizey / 2;
               }
               else startfcy = value;
           }
       }
       public int Startscx
       {
           get
           {
               return startscx;
           }
           set
           {
               if (value < sizex || value > sizex || value == startfcx)
               {
                   MessageBox.Show("Недопустимое значение координат города!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                   startscx = sizex;
               }
               else startscx = value;
           }
       }
       public int Startscy
       {
           get
           {
               return startscy;
           }
           set
           {
               if (value < sizey || value > sizey)
               {
                   MessageBox.Show("Недопустимое значение координат города!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                   startscy = sizey / 2;
               }
               else startscy = value;
           }
       }
       */
