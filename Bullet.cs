using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using U4_SpaceInvaders;

namespace U4_SpaceInvaders
{
    class Bullet
    {
        Point bulletPos = new Point();
        private Point point;
        public Point Point { get => point; }
        Canvas canvas;
        MainWindow window;
        Rectangle bulletRectangle;

        public Bullet(Canvas c, MainWindow w)
        {
            //Generate Bullet
            canvas = c;
            window = w;
            point = new Point(346, 558);
            bulletPos = point;
            bulletRectangle = new Rectangle();
            bulletRectangle.Fill = Brushes.Red;
            bulletRectangle.Height = 32;
            bulletRectangle.Width = 8;
            canvas.Children.Add(bulletRectangle);
            Canvas.SetTop(bulletRectangle, point.Y);
            Canvas.SetLeft(bulletRectangle, point.X);
        }

        public void Tick()
        {
            bulletPos.Y = bulletPos.Y + 3;

        }
    }
}
