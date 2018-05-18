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
    class SP3Aliens
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


        //Create Sprites
        ImageBrush sprite_SP3alien = new ImageBrush(new BitmapImage(new Uri("Alien SP3.png", UriKind.Relative)));
        ImageBrush sprite_LittleRed = new ImageBrush(new BitmapImage(new Uri("Draconus.png", UriKind.Relative)));

        public SP3Aliens(Canvas c, MainWindow w)
        {
            //Generate Alien
            canvas = c;
            window = w;
            point = new Point((64 * Globals.SP3AliensCreated), 128);
            AlienPos = point;
            AlienRectangle = new Rectangle();
            AlienRectangle.Fill = Brushes.Green;
            AlienRectangle.Height = 64;
            AlienRectangle.Width = 64;
            canvas.Children.Add(AlienRectangle);
            Canvas.SetTop(AlienRectangle, point.Y);
            Canvas.SetLeft(AlienRectangle, point.X);
            Globals.SP3AliensCreated++;
            box = new Rect(point, new Size(64, 64));

            //Sprites
            if (Globals.EasterEggActive == false)
            {
                AlienRectangle.Fill = sprite_LittleRed;
            }
            else if (Globals.EasterEggActive == true)
            {
                AlienRectangle.Fill = sprite_SP3alien;
            }

        }

        public void Tick()
        {
            Globals.AlienSpeed = Globals.currentRound;
            point.X = point.X + (Globals.AlienSpeed / 5);
            Canvas.SetLeft(AlienRectangle, point.X);
            box.X = point.X;
        }

        public void destroy()
        {
            canvas.Children.Remove(AlienRectangle);
            Globals.currentScore = Globals.currentScore + 2;
        }


    }

}