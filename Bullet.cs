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

namespace U4_SpaceInvaders
{
    class Bullet
    {
        Spaceship player;
        Point bulletPos = new Point();
        private Point point;
        public Point Point { get => point; }
        Canvas canvas;
        MainWindow window;
        Rectangle bulletRectangle;

        ImageBrush sprite_S_Bullet = new ImageBrush(new BitmapImage(new Uri("Spaceship_Bullet.png", UriKind.Relative)));
        ImageBrush sprite_F_Bullet = new ImageBrush(new BitmapImage(new Uri("Faceship_Bullet.png", UriKind.Relative)));

        public Bullet(Canvas c, MainWindow w)
        {
            //Generate Bullet
            canvas = c;
            window = w;
            point = new Point((Globals.Spaceship_x + 28), 558);
            bulletPos = point;
            bulletRectangle = new Rectangle();
            bulletRectangle.Fill = Brushes.Red;
            bulletRectangle.Height = 32;
            bulletRectangle.Width = 8;
            canvas.Children.Add(bulletRectangle);
            Canvas.SetTop(bulletRectangle, point.Y);
            Canvas.SetLeft(bulletRectangle, point.X);

            if(Globals.EasterEggActive == false)
            {
                bulletRectangle.Fill = sprite_S_Bullet;
            }
            else if (Globals.EasterEggActive == true)
            {
                bulletRectangle.Fill = sprite_F_Bullet;
            }
        }

        public void Tick()
        {
            point.Y = point.Y - 3;
            Canvas.SetTop(bulletRectangle, point.Y);

        }

        public void destroy()
        {
            canvas.Children.Remove(bulletRectangle);
        }
    }
}