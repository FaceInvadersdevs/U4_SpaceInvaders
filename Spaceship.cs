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
        public Rect boundingBox { get => box; }
        Rect box;

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
            box = new Rect(point, new Size(64, 64));

            if (Globals.EasterEggActive == true)
            {
                playerRectangle.Fill = sprite_F_Spaceship;
            }
            if (Globals.EasterEggActive == false)
            {
                playerRectangle.Fill = sprite_S_Spaceship;
            }

        }

        public void Tick()
        {
            Globals.Spaceship_x = playerPos.X;
            box.X = playerPos.X;
            box.Y = playerPos.Y;

            PlayerControls();

            if (Globals.movecooldown < 10)
            {
                Globals.movecooldown++;
            }
            if (Globals.shotcooldown < 30)
            {
                Globals.shotcooldown++;
            }
        }

        public void PlayerControls()
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                if (Globals.movecooldown == 10)
                {
                    if (Globals.blockleft == false)
                    {
                        //PlayerPosX = playerPos.X.ToString();
                        //double.TryParse(PlayerPosX, out dbl_playerpos);
                        playerPos.X = playerPos.X - 5;
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


                        if (playerPos.X <= 8)
                        {
                            Globals.blockleft = true;

                        }
                    }
                    else if (Globals.blockleft == true)
                    {
                        if (playerPos.X > 8)
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
                        playerPos.X = playerPos.X + 5;
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

                        if (playerPos.X >= 592)
                        {
                            Globals.blockright = true;

                        }
                    }
                    else if (Globals.blockright == true)
                    {
                        if (playerPos.X < 592)
                        {
                            Globals.blockright = false;

                        }
                    }
                }
            }
            if (Keyboard.IsKeyDown(Key.Space) || Keyboard.IsKeyDown(Key.Space) && Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.Space) && Keyboard.IsKeyDown(Key.Left))
            {
                if (Globals.movecooldown == 10)
                {
                    if (Globals.shotcooldown == 30)
                    {
                        if (Globals.EasterEggActive == true)
                        {
                            window.CreateBullet();
                            Globals.movecooldown = 0;
                            Globals.shotcooldown = 0;
                            Globals.effectPlayer.Open(new Uri("boiShoot.wav", UriKind.Relative));
                            Globals.effectPlayer.Play();
                            playerRectangle.Fill = sprite_F_FaceShoot;
                        }
                        if (Globals.EasterEggActive == false)
                        {
                            window.CreateBullet();
                            Globals.movecooldown = 0;
                            Globals.shotcooldown = 0;
                            Globals.effectPlayer.Open(new Uri("SpaceShoot.wav", UriKind.Relative));
                            Globals.effectPlayer.Play();
                            playerRectangle.Fill = sprite_S_SpaceShoot;
                        }
                    }
                }
            }
            if (Globals.shotcooldown > 15)
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

        public void Shot()
        {
            if (Globals.currentLives > 1)
            {
                Globals.currentLives--;

                if (Globals.currentRound > 1)
                {
                    Globals.currentRound--;
                    Globals.currentScore = Globals.currentScore - 100;
                    MessageBox.Show("OH NO YOU DIED!1!1! How inconvenient :(. You have lost a life, been set back a round and lost 100 score. Now get back out there and fight!");
                    window.ResetRound();
                }
                else if (Globals.currentRound == 1)
                {
                    Globals.currentScore = Globals.currentScore - 100;
                    MessageBox.Show("OH NO YOU DIED!1!1! How inconvenient :(. You have lost a life and lost 100 score. Now get back out there and fight!");
                    window.ResetRound();
                }

            }
            else if (Globals.currentLives == 1)
            {
                window.gameState = GameState.GameOver;
            }
        }


        public void destroy()
        {
            canvas.Children.Remove(playerRectangle);
        }
    }
}