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
        Point playerPos = new Point();
        private Point point;
        public Point Point { get => point; }
        Canvas canvas;
        MainWindow window;
        Rectangle playerRectangle;

        //Create Sprites
        ImageBrush sprite_F_MoveLeft = new ImageBrush(new BitmapImage(new Uri("Faceship_Move_Left.png", UriKind.Relative)));
        ImageBrush sprite_F_MoveRight = new ImageBrush(new BitmapImage(new Uri("Faceship_Move_Right.png", UriKind.Relative)));
        ImageBrush sprite_F_FaceShoot = new ImageBrush(new BitmapImage(new Uri("Faceship_Shoot.png", UriKind.Relative)));
        ImageBrush sprite_F_Spaceship = new ImageBrush(new BitmapImage(new Uri("Faceship.png", UriKind.Relative)));

        ImageBrush sprite_S_MoveLeft = new ImageBrush(new BitmapImage(new Uri("Spaceship_Move_Left.png", UriKind.Relative)));
        ImageBrush sprite_S_MoveRight = new ImageBrush(new BitmapImage(new Uri("Spaceship_Move_Right.png", UriKind.Relative)));
        ImageBrush sprite_S_SpaceShoot = new ImageBrush(new BitmapImage(new Uri("Spaceship_Shoot.png", UriKind.Relative)));
        ImageBrush sprite_S_Spaceship = new ImageBrush(new BitmapImage(new Uri("Spaceship.png", UriKind.Relative)));

        
    }
}
