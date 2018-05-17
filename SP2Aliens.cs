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
    class SP2Aliens
    {
        //Generate Player Variables
        Point AlienPos = new Point();
        private Point point;
        public Point Point { get => point; }
        Canvas canvas;
        MainWindow window;
        Rectangle AlienRectangle2;


        //Create Sprites
        ImageBrush sprite_SP1alien = new ImageBrush(new BitmapImage(new Uri("Alien SP1.png", UriKind.Relative)));
        ImageBrush sprite_SP2alien = new ImageBrush(new BitmapImage(new Uri("Alien SP2.png", UriKind.Relative)));
        ImageBrush sprite_SP3alien = new ImageBrush(new BitmapImage(new Uri("Alien SP3.png", UriKind.Relative)));
        ImageBrush sprite_SP4alien = new ImageBrush(new BitmapImage(new Uri("Alien SP4.png", UriKind.Relative)));

        ImageBrush sprite_BigGreen = new ImageBrush(new BitmapImage(new Uri("Dracadre.png", UriKind.Relative)));
        ImageBrush sprite_LittleGreen = new ImageBrush(new BitmapImage(new Uri("Dranino.png", UriKind.Relative)));
        ImageBrush sprite_BigRed = new ImageBrush(new BitmapImage(new Uri("Draxxor.png", UriKind.Relative)));
        ImageBrush sprite_LittleRed = new ImageBrush(new BitmapImage(new Uri("Draconus.png", UriKind.Relative)));

        public SP2Aliens(Canvas c, MainWindow w)
        {
            //Generate Alien
            canvas = c;
            window = w;
            point = new Point((64 * Globals.SP2AliensCreated), 64);
            AlienPos = point;
            AlienRectangle2 = new Rectangle
            {
                Fill = Brushes.Green,
                Height = 64,
                Width = 64
            };
            canvas.Children.Add(AlienRectangle2);
            Canvas.SetTop(AlienRectangle2, point.Y);
            Canvas.SetLeft(AlienRectangle2, point.X);
            Globals.SP2AliensCreated++;

            //Sprites
            if (Globals.EasterEggActive == false)
            {
                AlienRectangle2.Fill = sprite_BigGreen;
            }
            else if (Globals.EasterEggActive == true)
            {
                AlienRectangle2.Fill = sprite_SP2alien;
            }

        }




    }

}

