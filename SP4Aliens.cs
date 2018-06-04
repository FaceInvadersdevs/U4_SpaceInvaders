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
    class SP4Aliens
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
        public bool AlienMoveRight = true;
        public bool AlienMoveLeft = false;
        int alienscreated = Globals.SP4AliensCreated;


        //Create Sprites
        ImageBrush sprite_SP4alien = new ImageBrush(new BitmapImage(new Uri(@"Images\Alien SP4.png", UriKind.Relative)));
        ImageBrush sprite_BigRed = new ImageBrush(new BitmapImage(new Uri(@"Images\Draxxor.png", UriKind.Relative)));

        public SP4Aliens(Canvas c, MainWindow w)
        {
            //Generate Alien
            canvas = c;
            window = w;
            Globals.areAliensCreated4 = true;

            if ((Globals.currentRound % 2) == 1)
            {
                point = new Point(592, 0);
                AlienMoveLeft = true;
                AlienMoveRight = false;
            }
            else if ((Globals.currentRound % 2) == 0)
            {
                point = new Point(0, 0);
                AlienMoveRight = true;
                AlienMoveLeft = false;
            }
            AlienPos = point;
            AlienRectangle = new Rectangle();
            AlienRectangle.Fill = Brushes.Green;
            AlienRectangle.Height = 64;
            AlienRectangle.Width = 64;
            canvas.Children.Add(AlienRectangle);
            Canvas.SetTop(AlienRectangle, point.Y);
            Canvas.SetLeft(AlienRectangle, point.X);
            Globals.SP4AliensCreated++;
            box = new Rect(point, new Size(64, 64));

            //Sprites
            if (Globals.EasterEggActive == false)
            {
                AlienRectangle.Fill = sprite_BigRed;
            }
            else if (Globals.EasterEggActive == true)
            {
                AlienRectangle.Fill = sprite_SP4alien;
            }

        }

        public void Tick()
        {
            Movement();


        }

        private void Movement()
        {
            //Move down if near border
            if (point.X >= 612)
            {
                destroy();
                Globals.areAliensCreated4 = false;

            }
            if (point.X <= -10)
            {
                destroy();
                Globals.areAliensCreated4 = false;
            }

            //Move left or right
            if (AlienMoveRight == true)
            {
                point.X = point.X + 1.5;
                Canvas.SetLeft(AlienRectangle, point.X);
                Canvas.SetTop(AlienRectangle, point.Y);
                box.X = point.X;
                box.Y = point.Y;
            }
            if (AlienMoveLeft == true)
            {
                point.X = point.X - 1.5;
                Canvas.SetLeft(AlienRectangle, point.X);
                Canvas.SetTop(AlienRectangle, point.Y);
                box.X = point.X;
                box.Y = point.Y;
            }
        }


        public void destroy()
        {
            canvas.Children.Remove(AlienRectangle);
        }

    }

}
