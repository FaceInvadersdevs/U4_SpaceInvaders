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
    class Bunker
    {
        //Generate Player Variables
        Point bunkerPos = new Point();
        private Point point;
        public Point Point { get => point; }
        Canvas canvas;
        MainWindow window;
        Rectangle bunkerRectangle;
        public Rect boundingBox { get => box; }
        Rect box;
        public int health = 20;


        //Create Sprites
        ImageBrush sprite_Bunker1 = new ImageBrush(new BitmapImage(new Uri("Bunker1.png", UriKind.Relative)));
        ImageBrush sprite_Bunker2 = new ImageBrush(new BitmapImage(new Uri("Bunker2.png", UriKind.Relative)));
        ImageBrush sprite_Bunker3 = new ImageBrush(new BitmapImage(new Uri("Bunker3.png", UriKind.Relative)));
        ImageBrush sprite_Bunker4 = new ImageBrush(new BitmapImage(new Uri("Bunker4.png", UriKind.Relative)));
        ImageBrush sprite_Bunker5 = new ImageBrush(new BitmapImage(new Uri("Bunker5.png", UriKind.Relative)));

        public Bunker(Canvas c, MainWindow w)
        {
            //Generate Bunker
            canvas = c;
            window = w;
            point = new Point((92 + (162 * Globals.BunkersCreated)), 500);
            bunkerPos = point;
            bunkerRectangle = new Rectangle();
            bunkerRectangle.Fill = sprite_Bunker1;
            bunkerRectangle.Height = 32;
            bunkerRectangle.Width = 32;
            canvas.Children.Add(bunkerRectangle);
            Canvas.SetTop(bunkerRectangle, point.Y);
            Canvas.SetLeft(bunkerRectangle, point.X);
            box = new Rect(point, new Size(64, 64));
            Globals.BunkersCreated++;
        }

        public void damage()
        {
            health--;
            if (health == 19)
            {
                bunkerRectangle.Fill = sprite_Bunker2;
            }
            if (health == 14)
            {
                bunkerRectangle.Fill = sprite_Bunker3;
            }
            if (health == 9)
            {
                bunkerRectangle.Fill = sprite_Bunker4;
            }
            if (health == 1)
            {
                bunkerRectangle.Fill = sprite_Bunker5;
            }
        }

        public void destroy()
        {
            canvas.Children.Remove(bunkerRectangle);
        }
    }
}






