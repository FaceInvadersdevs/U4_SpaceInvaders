using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace U4_SpaceInvaders
{
    class Spaceship
    {
        Point playerPos = new Point();
        int counter = 0;
        private Point point;
        public Point Point { get => point; }
        Canvas canvas;
        MainWindow window;
        Rectangle playerRectangle;
        double dbl_playerpos;
        string PlayerPosX;

        public Spaceship(Canvas c, MainWindow w)
        {
            //Generate Player
            canvas = c;
            window = w;
            point = new Point(317, 565);
            playerPos = point;
            playerRectangle = new Rectangle();
            playerRectangle.Fill = Brushes.Green;
            playerRectangle.Height = 64;
            playerRectangle.Width = 64;
            canvas.Children.Add(playerRectangle);
            Canvas.SetTop(playerRectangle, point.Y);
            Canvas.SetLeft(playerRectangle, point.X);

            if (Globals.EasterEggActive == true)
            {
                ImageBrush sprite_Faceship = new ImageBrush(new BitmapImage(new Uri("Faceship.png", UriKind.Relative)));
                playerRectangle.Fill = sprite_Faceship;
            }
            if (Globals.EasterEggActive == false)
            {
                ImageBrush Sprite_Spaceship = new ImageBrush(new BitmapImage(new Uri("Spaceship.png", UriKind.Relative)));
                playerRectangle.Fill = Sprite_Spaceship;
            }
            
        }

        public void Tick()
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                if (Globals.blockleft == false)
                {
                    //PlayerPosX = playerPos.X.ToString();
                    //double.TryParse(PlayerPosX, out dbl_playerpos);
                    playerPos.X = playerPos.X - 2.5;
                    point.X = playerPos.X;
                    Canvas.SetLeft(playerRectangle, point.X);
                    if (playerPos.X <= 64)
                    {
                        Globals.blockleft = true;
                        
                    }
                }
                else if (Globals.blockleft == true)
                {
                    if (playerPos.X > 64)
                    {
                        Globals.blockleft = false;

                    }
                }
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                if (Globals.blockright == false)
                {
                    //PlayerPosX = playerPos.X.ToString();
                    //double.TryParse(PlayerPosX, out dbl_playerpos);
                    playerPos.X = playerPos.X + 2.5;
                    point.X = playerPos.X;
                    Canvas.SetLeft(playerRectangle, point.X);
                    if (playerPos.X >= 600)
                    {
                        Globals.blockright = true;

                    }
                }
                else if (Globals.blockright == true)
                {
                    if (playerPos.X < 600)
                    {
                        Globals.blockright = false;

                    }
                }
            }
        }
    }
}