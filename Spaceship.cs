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
        //Generate Player Variables
        Point playerPos = new Point();
        private Point point;
        public Point Point { get => point; }
        Canvas canvas;
        MainWindow window;
        Rectangle playerRectangle;

        //Create Sprites
        ImageBrush sprite_F_MoveLeft = new ImageBrush(new BitmapImage(new Uri("Faceship_Move_Left.png", UriKind.Relative)));
        ImageBrush sprite_F_MoveRight = new ImageBrush(new BitmapImage(new Uri("Faceship_Move_Right.png", UriKind.Relative)));
        ImageBrush sprite_F_FaceShoot = new ImageBrush(new BitmapImage(new Uri("Faceship_Shoot.png", UriKind.Relative)));
        ImageBrush sprite_F_Spaceship = new ImageBrush(new BitmapImage(new Uri("Faceship.png", UriKind.Relative)));

        ImageBrush sprite_S_MoveLeft = new ImageBrush(new BitmapImage(new Uri("Spaceship_Move_Left.png", UriKind.Relative)));
        ImageBrush sprite_S_MoveRight = new ImageBrush(new BitmapImage(new Uri("Spaceship_Move_Right.png", UriKind.Relative)));
        ImageBrush sprite_S_SpaceShoot = new ImageBrush(new BitmapImage(new Uri("Spaceship_Shoot.png", UriKind.Relative)));
        ImageBrush sprite_S_Spaceship = new ImageBrush(new BitmapImage(new Uri("Spaceship.png", UriKind.Relative)));

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
            Globals.Spaceship_x = playerPos.X;

            PlayerMovement();

            if (Globals.movecooldown < 10)
            {
                Globals.movecooldown++;
            }
            if (Globals.shotcooldown < 20)
            {
                Globals.shotcooldown++;
            }
        }

        private void PlayerMovement()
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                if (Globals.movecooldown == 10)
                {
                    if (Globals.blockleft == false)
                    {
                        //PlayerPosX = playerPos.X.ToString();
                        //double.TryParse(PlayerPosX, out dbl_playerpos);
                        playerPos.X = playerPos.X - 2.5;
                        point.X = playerPos.X;
                        Canvas.SetLeft(playerRectangle, point.X);

                        if (Globals.EasterEggActive == true)
                        {
                            playerRectangle.Fill = sprite_F_MoveLeft;
                        }
                        else if (Globals.EasterEggActive == false)
                        {
                            playerRectangle.Fill = sprite_S_MoveLeft;
                        }


                        if (playerPos.X <= 16)
                        {
                            Globals.blockleft = true;

                        }
                    }
                    else if (Globals.blockleft == true)
                    {
                        if (playerPos.X > 16)
                        {
                            Globals.blockleft = false;

                        }
                    }
                }
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                if (Globals.movecooldown == 10)
                {
                    if (Globals.blockright == false)
                    {
                        //PlayerPosX = playerPos.X.ToString();
                        //double.TryParse(PlayerPosX, out dbl_playerpos);
                        playerPos.X = playerPos.X + 2.5;
                        point.X = playerPos.X;
                        Canvas.SetLeft(playerRectangle, point.X);

                        if (Globals.EasterEggActive == true)
                        {
                            playerRectangle.Fill = sprite_F_MoveRight;
                        }
                        else if (Globals.EasterEggActive == false)
                        {
                            playerRectangle.Fill = sprite_S_MoveRight;
                        }

                        if (playerPos.X >= 584)
                        {
                            Globals.blockright = true;

                        }
                    }
                    else if (Globals.blockright == true)
                    {
                        if (playerPos.X < 584)
                        {
                            Globals.blockright = false;

                        }
                    }
                }
            }
            if (Keyboard.IsKeyDown(Key.Space))
            {
                if (Globals.movecooldown == 10)
                {
                    if (Globals.shotcooldown == 20)
                    {
                        if (Globals.EasterEggActive == true)
                        {
                            playerRectangle.Fill = sprite_F_FaceShoot;
                            Globals.movecooldown = 0;
                            Globals.shotcooldown = 0;
                        }
                        if (Globals.EasterEggActive == false)
                        {
                            playerRectangle.Fill = sprite_S_SpaceShoot;
                            Globals.movecooldown = 0;
                            Globals.shotcooldown = 0;
                        }
                    }
                }
            }
            if (Keyboard.IsKeyUp(Key.Space))
            {
                if (Keyboard.IsKeyUp(Key.Left))
                {
                    if (Keyboard.IsKeyUp(Key.Right))
                    {
                        if (Globals.movecooldown == 0 || Globals.movecooldown == 10)
                        {
                            if (Globals.EasterEggActive == true)
                            {
                                playerRectangle.Fill = sprite_F_Spaceship;
                            }
                            else if (Globals.EasterEggActive == false)
                            {
                                playerRectangle.Fill = sprite_S_Spaceship;
                            }
                        }
                    }
                }
            }
        }


        public void destroy()
        {
            canvas.Children.Remove(playerRectangle);
        }
    }
}