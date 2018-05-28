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
        public Rect boundingBox { get => box; }
        Rect box;

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
            point.Y = point.Y - 5;
            Canvas.SetTop(bulletRectangle, point.Y);

            box.Y = point.Y;

        }


        public bool collidesWith(SP1Aliens sp1)
        {
            if (this.boundingBox.X > sp1.boundingBox.X && this.boundingBox.X < (sp1.boundingBox.X + 57)
                && this.boundingBox.Y < (sp1.boundingBox.Y + 64) && this.boundingBox.Y > sp1.boundingBox.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool collidesWith(SP2Aliens sp2)
        {
            if (this.boundingBox.X > sp2.boundingBox.X && this.boundingBox.X < (sp2.boundingBox.X + 57)
                && this.boundingBox.Y < (sp2.boundingBox.Y + 64) && this.boundingBox.Y > sp2.boundingBox.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool collidesWith(SP3Aliens sp3)
        {
            if (this.boundingBox.X > sp3.boundingBox.X && this.boundingBox.X < (sp3.boundingBox.X + 57)
                && this.boundingBox.Y < (sp3.boundingBox.Y + 64) && this.boundingBox.Y > sp3.boundingBox.Y)
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
                && this.boundingBox.Y < (bunk.boundingBox.Y + 32) && this.boundingBox.Y > bunk.boundingBox.Y)
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