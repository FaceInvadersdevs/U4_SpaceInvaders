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


        //Create Sprites
        ImageBrush sprite_SP1alien = new ImageBrush(new BitmapImage(new Uri("Alien SP1.png", UriKind.Relative)));
        ImageBrush sprite_SP2alien = new ImageBrush(new BitmapImage(new Uri("Alien SP2.png", UriKind.Relative)));
        ImageBrush sprite_SP3alien = new ImageBrush(new BitmapImage(new Uri("Alien SP3.png", UriKind.Relative)));
        ImageBrush sprite_SP4alien = new ImageBrush(new BitmapImage(new Uri("Alien SP4.png", UriKind.Relative)));

        ImageBrush sprite_BigGreen = new ImageBrush(new BitmapImage(new Uri("Dracadre.png", UriKind.Relative)));
        ImageBrush sprite_LittleGreen = new ImageBrush(new BitmapImage(new Uri("Dranino.png", UriKind.Relative)));
        ImageBrush sprite_BigRed = new ImageBrush(new BitmapImage(new Uri("Draxxor.png", UriKind.Relative)));
        ImageBrush sprite_LittleRed = new ImageBrush(new BitmapImage(new Uri("Draconus.png", UriKind.Relative)));

        public SP1Aliens(Canvas c, MainWindow w)
        {
            //Generate Alien
            canvas = c;
            window = w;
            point = new Point((64 * Globals.SP1AliensCreated), 0);
            AlienPos = point;
            AlienRectangle = new Rectangle();
            AlienRectangle.Fill = Brushes.Green;
            AlienRectangle.Height = 64;
            AlienRectangle.Width = 64;
            canvas.Children.Add(AlienRectangle);
            Canvas.SetTop(AlienRectangle, point.Y);
            Canvas.SetLeft(AlienRectangle, point.X);
            Globals.SP1AliensCreated++;

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




    }

}

