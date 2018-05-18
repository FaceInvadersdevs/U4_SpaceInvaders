using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U4_SpaceInvaders
{
    // *CREDITS*
    //
    // *Songs*
    // 8-Bit Dubstep by Ross Budgen,
    // This track is licensed under a ‘Creative Commons Attribution 4.0 International License’. 
    // The track can be found at the following URL: https://www.youtube.com/watch?v=kIBwWd2_NT8
    //
    // Wolf by Jeremy L
    // "All my music is royalty free, so check out my soundcloud for free downloads! 
    // (NOTE: This song has reached the maximum download limit on soundcloud sorry :( use a website to download it off youtube.)" - YouTube Description
    // https://www.youtube.com/watch?v=Ahfu1E_BBSI&list=PLKQWNXwX2zTkYUBbLPaTwYpDBIcFnDch3&index=20
    //
    // *Sound Effects*
    // "In celebration of GDC 2018 we are giving away 30GB+ of high-quality sound effects from our catalog. 
    // Everything is royalty-free and commercially usable. No attribution is required and you can use them 
    // on an unlimited number of projects for the rest of your lifetime. - https://sonniss.com/gameaudiogdc18/
    //
    // Boi by Kyler Campbell,
    // This effect was recorded by us. Therefore we own it.





    enum GameState { MainMenu, GameOn, GameOver }


    public static class Globals
    {
        public static bool EasterEggActive = false;
        public static bool musicPlaying = false;
        public static bool beginfade = false;
        public static bool canShoot = false;
        public static bool playerCreated = false;
        public static bool blockleft = false;
        public static bool blockright = false;
        public static bool areAliensCreated = false;
        public static bool areAliensCreated2 = false;
        public static bool areAliensCreated3 = false;

        public static int currentScore = 0;
        public static int currentLives = 3;
        public static int currentRound = 1;
        public static int bulletcount;
        public static int movecooldown = 0;
        public static int shotcooldown = 0;
        public static int SP1AliensCreated = 0;
        public static int SP2AliensCreated = 0;
        public static int SP3AliensCreated = 0;
        public static double Spaceship_x;
        public static double AlienSpeed = 0;


        public static SoundPlayer musicPlayer = new SoundPlayer();
        public static MediaPlayer effectPlayer = new MediaPlayer();

    }



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        GameState gameState;

        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        Spaceship player;
        Bullet bullet;

        List<Bullet> bullets = new List<Bullet>();
        List<SP1Aliens> sp1Aliens = new List<SP1Aliens>();
        List<SP2Aliens> sp2Aliens = new List<SP2Aliens>();
        List<SP3Aliens> sp3Aliens = new List<SP3Aliens>();


        public MainWindow()
        {
            InitializeComponent();
            canvas_mainmenu.Visibility = Visibility.Visible;


            //start Timer
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            gameTimer.Start();

            gameState = GameState.MainMenu;
            DrawMainMenu();

        }

        public void CreatePlayer()
        {
            player = new Spaceship(canvas_battleground, this);
            Rectangle spaceship = new Rectangle();
            Globals.playerCreated = true;

        }

        public void Click_EasterEggTester(object Sender, RoutedEventArgs e)
        {
            if (Globals.EasterEggActive == false)
            {
                Globals.EasterEggActive = true;
                DrawMainMenu();
            }
            else if (Globals.EasterEggActive == true)
            {
                Globals.EasterEggActive = false;
                DrawMainMenu();
            }
        }

        private void DrawMainMenu()
        {
            //sets brushes to be the same as the image specified
            ImageBrush sprite_S_MMBackground = new ImageBrush(new BitmapImage(new Uri("Space Invaders.png", UriKind.Relative)));
            ImageBrush sprite_S_AlienSP1 = new ImageBrush(new BitmapImage(new Uri("Dranino.png", UriKind.Relative)));
            ImageBrush sprite_S_AlienSP2 = new ImageBrush(new BitmapImage(new Uri("Dracadre.png", UriKind.Relative)));
            ImageBrush sprite_S_AlienSP3 = new ImageBrush(new BitmapImage(new Uri("Draconus.png", UriKind.Relative)));
            ImageBrush sprite_S_AlienSP4 = new ImageBrush(new BitmapImage(new Uri("Draxxor.png", UriKind.Relative)));
            ImageBrush sprite_S_Spaceship = new ImageBrush(new BitmapImage(new Uri("Spaceship.png", UriKind.Relative)));
            ImageBrush sprite_F_MMBackground = new ImageBrush(new BitmapImage(new Uri("Face Invaders.png", UriKind.Relative)));
            ImageBrush sprite_F_AlienSP1 = new ImageBrush(new BitmapImage(new Uri("Alien SP1.png", UriKind.Relative)));
            ImageBrush sprite_F_AlienSP2 = new ImageBrush(new BitmapImage(new Uri("Alien SP2.png", UriKind.Relative)));
            ImageBrush sprite_F_AlienSP3 = new ImageBrush(new BitmapImage(new Uri("Alien SP3.png", UriKind.Relative)));
            ImageBrush sprite_F_AlienSP4 = new ImageBrush(new BitmapImage(new Uri("Alien SP4.png", UriKind.Relative)));
            ImageBrush sprite_F_Spaceship = new ImageBrush(new BitmapImage(new Uri("Faceship.png", UriKind.Relative)));

            if (Globals.EasterEggActive == false)
            {

                //fills rectangle with specified image
                canvas_mainmenu.Background = sprite_S_MMBackground;
                MMAlienSP1.Fill = sprite_S_AlienSP1;
                MMAlienSP2.Fill = sprite_S_AlienSP2;
                MMAlienSP3.Fill = sprite_S_AlienSP3;
                MMAlienSP4.Fill = sprite_S_AlienSP4;
                MMSpaceship.Fill = sprite_S_Spaceship;
            }
            else if (Globals.EasterEggActive == true)
            {
                //fills rectangle with specified image
                canvas_mainmenu.Background = sprite_F_MMBackground;
                MMAlienSP1.Fill = sprite_F_AlienSP1;
                MMAlienSP2.Fill = sprite_F_AlienSP2;
                MMAlienSP3.Fill = sprite_F_AlienSP3;
                MMAlienSP4.Fill = sprite_F_AlienSP4;
                MMSpaceship.Fill = sprite_F_Spaceship;
            }

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //plays music specific to gamestates
            //MusicEvents();

            //Gamestate check and update
            Gamestates();

            //FadeBeginText();
        }

        private void FadeBeginText()
        {
            if (gameState == GameState.MainMenu)
            {
                if (Globals.beginfade == false)
                {
                    if (txt_Begin.Opacity != 0 || txt_Begin.Opacity >= 1)
                    {
                        txt_Begin.Opacity = txt_Begin.Opacity - 0.025;
                    }
                    if (txt_Begin.Opacity <= 0)
                    {
                        Globals.beginfade = true;
                    }
                }
                if (Globals.beginfade == true)
                {
                    if (txt_Begin.Opacity != 1 || txt_Begin.Opacity >= 0)
                    {
                        txt_Begin.Opacity = txt_Begin.Opacity + 0.025;
                    }
                    if (txt_Begin.Opacity >= 1)
                    {
                        Globals.beginfade = false;
                    }
                }
            }
        }

        private void MusicEvents()
        {
            if (gameState == GameState.MainMenu)
            {
                if (Globals.musicPlaying == false)
                {
                    Globals.musicPlayer.Stop();
                    Uri music = new Uri("mainmenu.wav", UriKind.Relative);
                    Globals.musicPlayer.SoundLocation = music.ToString();
                    Globals.musicPlayer.PlayLooping();

                    Globals.musicPlaying = true;
                }
            }
            else if (gameState == GameState.GameOn)
            {
                if (Globals.musicPlaying == false)
                {
                    Globals.musicPlayer.Stop();
                    Uri music = new Uri("playgame.wav", UriKind.Relative);
                    Globals.musicPlayer.SoundLocation = music.ToString();
                    Globals.musicPlayer.PlayLooping();

                    Globals.musicPlaying = true;
                }
            }
        }

        public void Gamestates()
        {

            //mainmenu tick events
            if (gameState == GameState.MainMenu)
            {
                canvas_mainmenu.Visibility = Visibility.Visible;
                this.Title = "Main Menu";

                if (Keyboard.IsKeyDown(Key.Enter))
                {
                    //setupGame();
                    // if (gameState == GameState.MainMenu)
                    {
                        //    gameState = GameState.GameOn;
                        //    Globals.musicPlaying = false;
                    }
                    //else if (gameState == GameState.GameOn)
                    {
                        //  gameState = GameState.MainMenu;
                        //Globals.musicPlaying = false;
                    }
                }
                if (Keyboard.IsKeyDown(Key.Space))
                {
                    if (Globals.canShoot == false)
                    {

                        canvas_mainmenu.Visibility = Visibility.Hidden;
                        // canvas.battleground.Visibility = Visibility.Visible;
                        gameState = GameState.GameOn;
                        Globals.musicPlaying = false;
                        Globals.canShoot = true;

                      //  List<SP1Aliens> SP1Aliens = new List<SP1Aliens>();


                    }
                }
                else if (Keyboard.IsKeyUp(Key.Space))
                {
                    Globals.canShoot = false;
                }
            }

            //during-game tick events
            else if (gameState == GameState.GameOn)
            {
                canvas_battleground.Visibility = Visibility.Visible;
                this.Title = "Round: " + Globals.currentRound.ToString() + " - Score: " + Globals.currentScore.ToString() + " - Lives: " + Globals.currentLives.ToString();

                List<Bullet> bulletsToDelete = new List<Bullet>();
                List<SP1Aliens> sp1aliensToDelete = new List<SP1Aliens>();
                List<SP2Aliens> sp2aliensToDelete = new List<SP2Aliens>();
                List<SP3Aliens> sp3aliensToDelete = new List<SP3Aliens>();

                // SP 1-4 Aliens below

                ImageBrush sprite_battleBackground = new ImageBrush(new BitmapImage(new Uri("BattleBackground.png", UriKind.Relative)));
                canvas_battleground.Background = sprite_battleBackground;

                if (Globals.playerCreated == false)
                {
                    CreatePlayer();
                }
                player.Tick();
                BulletEventsAndCollison(bulletsToDelete, sp1aliensToDelete, sp2aliensToDelete, sp3aliensToDelete);
                CreateAliens();
                CheckInput();

                AliensTick();

                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    MessageBox.Show(Globals.AlienSpeed.ToString());
                }
            }

            //end game tick events
            else if (gameState == GameState.GameOver)
            {
                this.Title = "Game Over!";
            }
        }

        private void AliensTick()
        {
            foreach (SP1Aliens sp1 in sp1Aliens)
            {
                sp1.Tick();
            }
            foreach (SP2Aliens sp2 in sp2Aliens)
            {
                sp2.Tick();
            }
            foreach (SP3Aliens sp3 in sp3Aliens)
            {
                sp3.Tick();
            }
        }

        private void CheckInput()
        {
            if (Keyboard.IsKeyDown(Key.Space))
            {
                if (Globals.canShoot == false)
                {
                    if (Globals.EasterEggActive == false)
                    {
                        Globals.effectPlayer.Open(new Uri("SpaceShoot.wav", UriKind.Relative));
                        Globals.effectPlayer.Play();
                        Globals.canShoot = true;
                        CreateBullet();
                    }
                    else if (Globals.EasterEggActive == true)
                    {
                        Globals.effectPlayer.Open(new Uri("boiShoot.wav", UriKind.Relative));
                        Globals.effectPlayer.Play();
                        CreateBullet();
                        Globals.canShoot = true;

                    }
                }
            }
            else if (Keyboard.IsKeyUp(Key.Space))
            {
                if (Globals.shotcooldown == 20)
                {
                    Globals.canShoot = false;
                }
            }

            if (Keyboard.IsKeyDown(Key.Enter))
            {
                //setupGame();
                if (gameState == GameState.MainMenu)
                {
                    gameState = GameState.GameOn;
                    Globals.musicPlaying = false;
                }
                else if (gameState == GameState.GameOn)
                {
                    gameState = GameState.MainMenu;
                    Globals.musicPlaying = false;

                    player.destroy();
                    Globals.playerCreated = false;

                    canvas_battleground.Visibility = Visibility.Hidden;
                }
            }

            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Clipboard.SetText(Mouse.GetPosition(this).ToString());
            }
        }

        private void BulletEventsAndCollison(List<Bullet> bulletsToDelete, List<SP1Aliens> sp1aliensToDelete, List<SP2Aliens> sp2aliensToDelete, List<SP3Aliens> sp3aliensToDelete)
        {
            foreach (Bullet b in bullets)
            {
                b.Tick();

                foreach (SP1Aliens sp1 in sp1Aliens)
                {
                    sp1.Tick();
                    if (b.collidesWith(sp1) == true)
                    {
                        b.destroy();
                        sp1.destroy();
                        bulletsToDelete.Add(b);
                        sp1aliensToDelete.Add(sp1);
                    }
                }
                foreach (SP2Aliens sp2 in sp2Aliens)
                {
                    sp2.Tick();
                    if (b.collidesWith(sp2) == true)
                    {
                        b.destroy();
                        sp2.destroy();
                        bulletsToDelete.Add(b);
                        sp2aliensToDelete.Add(sp2);
                    }
                }
                foreach (SP3Aliens sp3 in sp3Aliens)
                {
                    sp3.Tick();
                    if (b.collidesWith(sp3) == true)
                    {
                        b.destroy();
                        sp3.destroy();
                        bulletsToDelete.Add(b);
                        sp3aliensToDelete.Add(sp3);
                    }
                }
            }

            foreach (Bullet b in bulletsToDelete)
            {
                bullets.Remove(b);
            }
            foreach (SP1Aliens sp1 in sp1aliensToDelete)
            {
                sp1Aliens.Remove(sp1);
            }
            foreach (SP2Aliens sp2 in sp2aliensToDelete)
            {
                sp2Aliens.Remove(sp2);
            }
            foreach (SP3Aliens sp3 in sp3aliensToDelete)
            {
                sp3Aliens.Remove(sp3);
            }
        }

        private void CreateAliens()
        {
            if (Globals.areAliensCreated == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    sp1Aliens.Add(new SP1Aliens(canvas_battleground, this));

                    if (Globals.SP1AliensCreated == 8)
                    {
                        Globals.areAliensCreated = true;
                    }
                }
            }
            if (Globals.areAliensCreated2 == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    sp2Aliens.Add(new SP2Aliens(canvas_battleground, this));

                    if (Globals.SP2AliensCreated == 8)
                    {
                        Globals.areAliensCreated2 = true;
                    }
                }
            }
            if (Globals.areAliensCreated3 == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    sp3Aliens.Add(new SP3Aliens(canvas_battleground, this));

                    if (Globals.SP3AliensCreated == 8)
                    {
                        Globals.areAliensCreated3 = true;
                    }
                }
            }
        }

        public void CreateBullet()
        {
            bullets.Add(new Bullet(canvas_battleground, this));
        }
    }
}