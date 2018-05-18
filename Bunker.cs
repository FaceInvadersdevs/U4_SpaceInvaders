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
using U4_SpaceInvaders;

namespace U4_spaceInvaders
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
            point = new Point(92, 629);
            bunkerPos = point;
            bunkerRectangle = new Rectangle();
            bunkerRectangle.Fill = Brushes.Green;
            bunkerRectangle.Height = 64;
            bunkerRectangle.Width = 64;
            canvas.Children.Add(bunkerRectangle);
            Canvas.SetTop(bunkerRectangle, point.Y);
            Canvas.SetLeft(bunkerRectangle, point.X); 
        }
    }
}






