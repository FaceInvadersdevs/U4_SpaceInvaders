
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
    class Enemy_Bullet
    {
        Point bulletPos = new Point();
        private Point point;
        public Point Point { get => point; }
        Canvas canvas;
        MainWindow window;
        Rectangle bulletRectangle;
        public Rect boundingBox { get => box; }
        Rect box;

        ImageBrush sprite_S_Bullet = new ImageBrush(new BitmapImage(new Uri(@"Images\Enemy_Bullet.png", UriKind.Relative)));
        ImageBrush sprite_F_Bullet = new ImageBrush(new BitmapImage(new Uri(@"Images\Enemy_Bullet.png", UriKind.Relative)));

        public Enemy_Bullet(Canvas c, MainWindow w, Point startingpos)
        {
            //Generate Bullet
            canvas = c;
            window = w;

            point = startingpos;
            point.X = startingpos.X + 28;
            point.Y = startingpos.Y + 16;
            bulletPos = point;
            bulletRectangle = new Rectangle();
            bulletRectangle.Fill = Brushes.Red;
            bulletRectangle.Height = 32;
            bulletRectangle.Width = 8;
            canvas.Children.Add(bulletRectangle);
            Canvas.SetTop(bulletRectangle, point.Y);
            Canvas.SetLeft(bulletRectangle, point.X);
            box = new Rect(point, new Size(8, 32));

            if (Globals.EasterEggActive == false)
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
            point.Y = point.Y + 3;
            Canvas.SetTop(bulletRectangle, point.Y);

            box.X = point.X;
            box.Y = point.Y;

        }


        public bool collidesWith(Spaceship player)
        {
            if (this.boundingBox.X > player.boundingBox.X + 4 && this.boundingBox.X < (player.boundingBox.X + 60)
                && this.boundingBox.Y < (player.boundingBox.Y + 15) && this.boundingBox.Y > player.boundingBox.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool collidesWith(Bunker bunk)
        {
            if (this.boundingBox.X > (bunk.boundingBox.X - 8) && this.boundingBox.X < (bunk.boundingBox.X + 32)
                && this.boundingBox.Y + 16 < (bunk.boundingBox.Y + 64) && this.boundingBox.Y + 16 > bunk.boundingBox.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void destroy()
        {
            canvas.Children.Remove(bulletRectangle);
        }
    }
}