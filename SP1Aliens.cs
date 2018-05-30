using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace U4_SpaceInvaders
{
    class SP1Aliens
    {
        //Generate Player Variables
        Point AlienPos = new Point();
        private Point point;
        public Point Point { get => point; }
        Canvas canvas;
        MainWindow window;
        Rectangle AlienRectangle;
        public Rect boundingBox { get => box; }
        Rect box;
        public bool AlienMoveDown = false;
        public bool AlienMoveRight = true;
        public bool AlienMoveLeft = false;
        int rnumber;
        int alienscreated = Globals.SP1AliensCreated;
        Random r = new Random(5);


        //Create Sprites
        ImageBrush sprite_SP1alien = new ImageBrush(new BitmapImage(new Uri("Alien SP1.png", UriKind.Relative)));
        ImageBrush sprite_LittleGreen = new ImageBrush(new BitmapImage(new Uri("Dranino.png", UriKind.Relative)));

        public SP1Aliens(Canvas c, MainWindow w)
        {
            //Generate Alien
            canvas = c;
            window = w;

            if ((Globals.currentRound % 2) == 1)
            {
                point = new Point((64 * Globals.SP1AliensCreated), 0);
                AlienMoveLeft = false;
                AlienMoveRight = true;
            }
            else if ((Globals.currentRound % 2) == 0)
            {
                point = new Point((512 - (64 * Globals.SP1AliensCreated)), 0);
                AlienMoveRight = false;
                AlienMoveLeft = true;
            }
            AlienPos = point;
            AlienRectangle = new Rectangle();
            AlienRectangle.Fill = Brushes.Green;
            AlienRectangle.Height = 64;
            AlienRectangle.Width = 64;
            canvas.Children.Add(AlienRectangle);
            Canvas.SetTop(AlienRectangle, point.Y);
            Canvas.SetLeft(AlienRectangle, point.X);
            Globals.SP1AliensCreated++;
            box = new Rect(point, new Size(64, 64));
            int rOthernumber = r.Next();

            //Sprites
            if (Globals.EasterEggActive == false)
            {
                AlienRectangle.Fill = sprite_LittleGreen;
            }
            else if (Globals.EasterEggActive == true)
            {
                AlienRectangle.Fill = sprite_SP1alien;
            }

        }

        public void Tick()
        {
            Movement();

            rnumber = r.Next();
            var i = Util.GetRandom();
            if (i <= 2 + Globals.currentRound)
            {
                r = new Random();

                window.CreateEnemyBullet(point);
            }
        }

        private void Movement()
        {
            //Move down if near border
            if (point.X >= 592)
            {
                if (AlienMoveRight == true)
                {
                    AlienMoveDown = true;
                    point.X = point.X - 3;
                }

            }
            if (point.X <= 0)
            {
                if (AlienMoveLeft == true)
                {
                    AlienMoveDown = true;
                    point.X = point.X + 3;
                }
            }

            //Move left or right
            if (AlienMoveRight == true)
            {
                Globals.AlienSpeed = Globals.currentRound;
                point.X = point.X + (Globals.AlienSpeed / 5);
                Canvas.SetLeft(AlienRectangle, point.X);
                Canvas.SetTop(AlienRectangle, point.Y);
                box.X = point.X;
                box.Y = point.Y;
            }
            if (AlienMoveLeft == true)
            {
                Globals.AlienSpeed = Globals.currentRound;
                point.X = point.X - (Globals.AlienSpeed / 5);
                Canvas.SetLeft(AlienRectangle, point.X);
                Canvas.SetTop(AlienRectangle, point.Y);
                box.X = point.X;
                box.Y = point.Y;
            }
        }
        // Moves down at max/ min X Values
        public void MoveDown()
        {
            point.Y = point.Y + 64;
            AlienMoveDown = false;
            Canvas.SetTop(AlienRectangle, point.Y);

            if (AlienMoveRight == true)
            {
                AlienMoveRight = false;
                AlienMoveLeft = true;
            }

            else if (AlienMoveLeft == true)
            {
                AlienMoveRight = true;
                AlienMoveLeft = false;
            }

        }

        // Create and use hitboxes
        public void destroy()
        {
            canvas.Children.Remove(AlienRectangle);
        }

        public bool collidesWith(Bunker bunk)
        {
            if (this.boundingBox.Y < (500 + 32) && this.boundingBox.Y > 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}