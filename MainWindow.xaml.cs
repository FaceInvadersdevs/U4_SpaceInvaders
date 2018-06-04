
/*
 *Josh Degazio - Colin Jones - Kyler Campbell - Bradley Miller
 *Feb 8, 2018
 *Output
 *User inputs a "name", the system then greets the user, using their name
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Reflection;
using System.Security.AccessControl;
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




    //set gamestates
    public enum GameState { MainMenu, GameOn, GameOver }


    //creates a global class for variables
    public static class Globals
    {
        //bools
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
        public static bool areAliensCreated4 = false;
        public static bool areBunkersCreated = false;
        public static bool isLeaderboardCreated = false;
        public static bool areStatsWriten = false;
        public static bool btn_SubmitClicked = false;
        public static bool areStatsEntered = false;
        public static bool isMainMenuCreated = false;
        public static bool areBunkersBreached = false;

        //ints
        public static int currentScore = 0;
        public static int currentLives = 3;
        public static int currentRound = 1;
        public static int bulletcount = 0;
        public static int movecooldown = 0;
        public static int shotcooldown = 0;
        public static int SP1AliensCreated = 0;
        public static int SP2AliensCreated = 0;
        public static int SP3AliensCreated = 0;
        public static int SP4AliensCreated = 0;
        public static int BunkersCreated = 0;
        public static int first_p_score = 0;
        public static int first_p_round = 0;
        public static int second_p_score = 0;
        public static int second_p_round = 0;
        public static int third_p_score = 0;
        public static int third_p_round = 0;
        public static int fourth_p_score = 0;
        public static int fourth_p_round = 0;
        public static int fifth_p_score = 0;
        public static int fifth_p_round = 0;
        public static int yourPlace = 0;
        public static double Spaceship_x = 0;
        public static double AlienSpeed = 0;

        //strings
        public static string first_p_name = "name";
        public static string first_p_stats = "Score: " + first_p_score.ToString() + "\nRound:" + first_p_round.ToString();
        public static string second_p_name = "name";
        public static string second_p_stats = "Score: " + second_p_score.ToString() + "\nRound:" + second_p_round.ToString();
        public static string third_p_name = "name";
        public static string third_p_stats = "Score: " + third_p_score.ToString() + "\nRound:" + third_p_round.ToString();
        public static string fourth_p_name = "name";
        public static string fourth_p_stats = "Score: " + fourth_p_score.ToString() + "\nRound:" + fourth_p_round.ToString();
        public static string fifth_p_name = "name";
        public static string fifth_p_stats = "Score: " + fifth_p_score.ToString() + "\nRound:" + fifth_p_round.ToString();
        public static string yourName;
        public static string[] censoredwords = new string[34];

        //creates effect and music players
        public static SoundPlayer musicPlayer = new SoundPlayer();
        public static MediaPlayer effectPlayer = new MediaPlayer();

        //Creates directory in order to download and upload stats
        public static Assembly assembly = Assembly.GetExecutingAssembly();
        public static string path = System.IO.Path.GetDirectoryName(assembly.Location);
        public static Uri statspath = new Uri("ftp://ftp.ezyro.com/htdocs/stats.txt");

        //sets brushes to be the same as the image specified
        public static ImageBrush sprite_S_MMBackground = new ImageBrush(new BitmapImage(new Uri(@"Images\Space Invaders.png", UriKind.Relative)));
        public static ImageBrush sprite_S_AlienSP1 = new ImageBrush(new BitmapImage(new Uri(@"Images\Dranino.png", UriKind.Relative)));
        public static ImageBrush sprite_S_AlienSP2 = new ImageBrush(new BitmapImage(new Uri(@"Images\Dracadre.png", UriKind.Relative)));
        public static ImageBrush sprite_S_AlienSP3 = new ImageBrush(new BitmapImage(new Uri(@"Images\Draconus.png", UriKind.Relative)));
        public static ImageBrush sprite_S_AlienSP4 = new ImageBrush(new BitmapImage(new Uri(@"Images\Draxxor.png", UriKind.Relative)));
        public static ImageBrush sprite_S_Spaceship = new ImageBrush(new BitmapImage(new Uri(@"Images\Spaceship.png", UriKind.Relative)));
        public static ImageBrush sprite_F_MMBackground = new ImageBrush(new BitmapImage(new Uri(@"Images\Face Invaders.png", UriKind.Relative)));
        public static ImageBrush sprite_F_AlienSP1 = new ImageBrush(new BitmapImage(new Uri(@"Images\Alien SP1.png", UriKind.Relative)));
        public static ImageBrush sprite_F_AlienSP2 = new ImageBrush(new BitmapImage(new Uri(@"Images\Alien SP2.png", UriKind.Relative)));
        public static ImageBrush sprite_F_AlienSP3 = new ImageBrush(new BitmapImage(new Uri(@"Images\Alien SP3.png", UriKind.Relative)));
        public static ImageBrush sprite_F_AlienSP4 = new ImageBrush(new BitmapImage(new Uri(@"Images\Alien SP4.png", UriKind.Relative)));
        public static ImageBrush sprite_F_Spaceship = new ImageBrush(new BitmapImage(new Uri(@"Images\Faceship.png", UriKind.Relative)));

        public static ImageBrush sprite_S_Leaderboard = new ImageBrush(new BitmapImage(new Uri(@"Images\S_Leaderboard.png", UriKind.Relative)));
        public static ImageBrush sprite_F_Leaderboard = new ImageBrush(new BitmapImage(new Uri(@"Images\F_Leaderboard.png", UriKind.Relative)));

    }

    //Utility class
    public static class Util
    {
        //Creates a random integer
        private static Random rnd = new Random();
        public static int GetRandom()
        {
            return rnd.Next(1, (6001 - (Globals.currentRound * 10)));
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //creates a Gamestate enum called gamestate
        public GameState gameState;

        //creates a gametimer used to replicate FPS
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();

        //Creates instance of player
        Spaceship player;

        //Creates objects later used
        Rectangle MMSpaceship = new Rectangle();
        Rectangle MMAlienSP1 = new Rectangle();
        Rectangle MMAlienSP2 = new Rectangle();
        Rectangle MMAlienSP3 = new Rectangle();
        Rectangle MMAlienSP4 = new Rectangle();
        Button EasterEgg = new Button();
        TextBlock txt_Begin = new TextBlock();
        public TextBox inpt_name = new TextBox();
        public TextBlock txt_name = new TextBlock();
        public Button btn_submit = new Button();
        public TextBlock first_name = new TextBlock();
        public TextBlock first_stats = new TextBlock();
        public TextBlock second_name = new TextBlock();
        public TextBlock second_stats = new TextBlock();
        public TextBlock third_name = new TextBlock();
        public TextBlock third_stats = new TextBlock();
        public TextBlock fourth_name = new TextBlock();
        public TextBlock fourth_stats = new TextBlock();
        public TextBlock fifth_name = new TextBlock();
        public TextBlock fifth_stats = new TextBlock();
        public TextBlock your_stats = new TextBlock();
        public Button leave_Leaderboard = new Button();

        //Creates lists for instances
        List<Bullet> bullets = new List<Bullet>();
        List<Enemy_Bullet> enemy_Bullets = new List<Enemy_Bullet>();
        List<Bunker> bunkers = new List<Bunker>();
        List<SP1Aliens> sp1Aliens = new List<SP1Aliens>();
        List<SP2Aliens> sp2Aliens = new List<SP2Aliens>();
        List<SP3Aliens> sp3Aliens = new List<SP3Aliens>();
        List<SP4Aliens> sp4Aliens = new List<SP4Aliens>();

        //Creates lists to destroy instances
        List<Bullet> bulletsToDelete = new List<Bullet>();
        List<Enemy_Bullet> enemy_BulletsToDelete = new List<Enemy_Bullet>();
        List<Bunker> bunkersToDelete = new List<Bunker>();
        List<SP1Aliens> sp1aliensToDelete = new List<SP1Aliens>();
        List<SP2Aliens> sp2aliensToDelete = new List<SP2Aliens>();
        List<SP3Aliens> sp3aliensToDelete = new List<SP3Aliens>();
        List<SP4Aliens> sp4aliensToDelete = new List<SP4Aliens>();

        public MainWindow()
        {
            InitializeComponent();
            //Create click event for the previously created button "Easter egg tester"
            EasterEgg.Click += new RoutedEventHandler(Click_EasterEggTester);
            //Set main menu visibility to be visible
            canvas_mainmenu.Visibility = Visibility.Visible;

            //If the directory in the debug folder doesn't exist, create it.
            if (!Directory.Exists(Globals.path))
            {
                Directory.CreateDirectory(Globals.path);
            }
            Uri stats = new Uri(Globals.path + @"\Stats.txt");

            //start Timer
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            gameTimer.Start();

            //set enum gamestate, "gamestate" to be equal to the mainmenu state.
            gameState = GameState.MainMenu;

            //Reads stats method
            ReadStats();
            //Refresh stats method
            RefreshStats();
            //Set censored words method
            SetCensoredWords();

        }

        //Enter at your own risk. These are in place to prevent people from abusing the leaderboard system. No harm is meant in writing this code.
        private static void SetCensoredWords()
        {
            //NOTE: These are in place so that the leaderboard system doesn't get abused.
            //You have been warned.

            Globals.censoredwords[0] = "FUCK";
            Globals.censoredwords[1] = "SHIT";
            Globals.censoredwords[2] = "BITCH";
            Globals.censoredwords[3] = "CUNT";
            Globals.censoredwords[4] = "CUM";
            Globals.censoredwords[5] = "NIGGER";
            Globals.censoredwords[6] = "NIGGA";
            Globals.censoredwords[7] = "FVCK";
            Globals.censoredwords[8] = "SH1T";
            Globals.censoredwords[9] = "SH!T";
            Globals.censoredwords[10] = "B1TCH";
            Globals.censoredwords[11] = "B!TCH";
            Globals.censoredwords[12] = "SLAVE";
            Globals.censoredwords[13] = "WHORE";
            Globals.censoredwords[14] = "MOLESTER";
            Globals.censoredwords[15] = "RAPE";
            Globals.censoredwords[16] = "RAPIST";
            Globals.censoredwords[17] = "FUCKER";
            Globals.censoredwords[18] = "FVCKER";
            Globals.censoredwords[19] = "FVCK3R";
            Globals.censoredwords[20] = "FUCK3R";
            Globals.censoredwords[21] = "SLUT";
            Globals.censoredwords[22] = "5LUT";
            Globals.censoredwords[23] = "SKANK";
            Globals.censoredwords[24] = "SHITHEAD";
            Globals.censoredwords[25] = "FUCKA";
            Globals.censoredwords[26] = "POT";
            Globals.censoredwords[27] = "METH";
            Globals.censoredwords[28] = "CRACK";
            Globals.censoredwords[29] = "ASS";
            Globals.censoredwords[30] = "DUMBASS";
            Globals.censoredwords[31] = "THOT";
            Globals.censoredwords[32] = "TH0T";
            Globals.censoredwords[33] = "BIG NIGGA";
        }

        //Create a new instance of player on the battleground canvas
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
                ChangeMainMenuSprites();
            }
            else if (Globals.EasterEggActive == true)
            {
                Globals.EasterEggActive = false;
                ChangeMainMenuSprites();
            }

        }

        private void CreateMainMenu()
        {
            ResetGlobals();


            MMSpaceship.Height = 128; MMSpaceship.Width = 128; Canvas.SetTop(MMSpaceship, 384); Canvas.SetLeft(MMSpaceship, 267);
            MMAlienSP1.Height = 128; MMAlienSP1.Width = 128; Canvas.SetTop(MMAlienSP1, 148); Canvas.SetLeft(MMAlienSP1, 176);
            MMAlienSP2.Height = 128; MMAlienSP2.Width = 128; Canvas.SetTop(MMAlienSP2, 148); Canvas.SetLeft(MMAlienSP2, 101);
            MMAlienSP3.Height = 128; MMAlienSP3.Width = 128; Canvas.SetTop(MMAlienSP3, 148); Canvas.SetLeft(MMAlienSP3, 451);
            MMAlienSP4.Height = 128; MMAlienSP4.Width = 128; Canvas.SetTop(MMAlienSP4, 148); Canvas.SetLeft(MMAlienSP4, 376);
            EasterEgg.Height = 64; EasterEgg.Width = 128; Canvas.SetTop(EasterEgg, 510); Canvas.SetLeft(EasterEgg, 10); EasterEgg.Content = "Enable Face-eggedon";
            txt_Begin.Width = 260; Canvas.SetTop(txt_Begin, 530); Canvas.SetLeft(txt_Begin, 198); txt_Begin.Text = "Press 'Space' To Begin!"; txt_Begin.TextAlignment = TextAlignment.Center; txt_Begin.FontFamily = new FontFamily("Trajan Pro 3"); txt_Begin.FontSize = 20; txt_Begin.Foreground = Brushes.White;

            canvas_mainmenu.Children.Add(MMSpaceship);
            canvas_mainmenu.Children.Add(MMAlienSP1);
            canvas_mainmenu.Children.Add(MMAlienSP2);
            canvas_mainmenu.Children.Add(MMAlienSP3);
            canvas_mainmenu.Children.Add(MMAlienSP4);
            canvas_mainmenu.Children.Add(EasterEgg);
            canvas_mainmenu.Children.Add(txt_Begin);

            ChangeMainMenuSprites();
            Globals.isMainMenuCreated = true;

        }

        private void ChangeMainMenuSprites()
        {
            if (Globals.EasterEggActive == false)
            {

                //fills rectangle with specified image
                canvas_mainmenu.Background = Globals.sprite_S_MMBackground;
                MMAlienSP1.Fill = Globals.sprite_S_AlienSP1;
                MMAlienSP2.Fill = Globals.sprite_S_AlienSP2;
                MMAlienSP3.Fill = Globals.sprite_S_AlienSP3;
                MMAlienSP4.Fill = Globals.sprite_S_AlienSP4;
                MMSpaceship.Fill = Globals.sprite_S_Spaceship;
                EasterEgg.Content = "Enable Face-eggedon";
            }
            else if (Globals.EasterEggActive == true)
            {
                //fills rectangle with specified image
                canvas_mainmenu.Background = Globals.sprite_F_MMBackground;
                MMAlienSP1.Fill = Globals.sprite_F_AlienSP1;
                MMAlienSP2.Fill = Globals.sprite_F_AlienSP2;
                MMAlienSP3.Fill = Globals.sprite_F_AlienSP3;
                MMAlienSP4.Fill = Globals.sprite_F_AlienSP4;
                MMSpaceship.Fill = Globals.sprite_F_Spaceship;
                EasterEgg.Content = "Enable Space-eggedon";
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //plays music specific to gamestates
            MusicEvents();

            //Gamestate check and update
            Gamestates();

            //Control the fading of 'press space to start'
            FadeBeginText();
        }

        //Control the fading of 'press space to start'
        private void FadeBeginText()
        {
            if (gameState == GameState.MainMenu)
            {
                //Fade out
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
                //Fade in
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

        //plays music specific to gamestates
        private void MusicEvents()
        {
            if (gameState == GameState.MainMenu)
            {
                if (Globals.musicPlaying == false)
                {
                    //Stops any previous music from playing
                    Globals.musicPlayer.Stop();
                    //Begins playing mainmenu song on loop
                    Uri music = new Uri(@"Sounds\mainmenu.wav", UriKind.Relative);
                    Globals.musicPlayer.SoundLocation = music.ToString();
                    Globals.musicPlayer.PlayLooping();

                    //Sets bool to true
                    Globals.musicPlaying = true;
                }
            }
            else if (gameState == GameState.GameOn)
            {
                if (Globals.musicPlaying == false)
                {
                    //Stops any previous music from playing
                    Globals.musicPlayer.Stop();
                    //Begins playing mainmenu song on loop
                    Uri music = new Uri(@"Sounds\playgame.wav", UriKind.Relative);
                    Globals.musicPlayer.SoundLocation = music.ToString();
                    Globals.musicPlayer.PlayLooping();

                    //Sets bool to true
                    Globals.musicPlaying = true;
                }
            }
        }

        //Gamestate check and update
        public void Gamestates()
        {

            //mainmenu tick events
            if (gameState == GameState.MainMenu)
            {
                //Clear previous canvases
                canvas_leaderboard.Children.Clear();
                canvas_battleground.Children.Clear();
                canvas_mainmenu.Visibility = Visibility.Visible;
                //Set title to main menu
                this.Title = "Main Menu";

                //Create mainmenu objects
                if (Globals.isMainMenuCreated == false)
                {
                    CreateMainMenu();
                }

                //Check and set values
                if (Globals.areStatsWriten == true)
                {
                    Globals.areStatsWriten = false;
                }

                //Check and set values
                if (Globals.isLeaderboardCreated == true)
                {
                    Globals.isLeaderboardCreated = false;
                }

                //Plays soundeffect upon pressing specified key.
                if (Keyboard.IsKeyDown(Key.Space))
                {
                    if (Globals.canShoot == false)
                    {

                        canvas_mainmenu.Visibility = Visibility.Hidden;
                        // canvas.battleground.Visibility = Visibility.Visible;
                        gameState = GameState.GameOn;
                        Globals.musicPlaying = false;
                        Globals.canShoot = true;


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
                //Clears previous canvas
                canvas_mainmenu.Children.Clear();
                Globals.isMainMenuCreated = false;

                //Sets current canvas to visible.
                canvas_battleground.Visibility = Visibility.Visible;
                //Sets title to show stats.
                this.Title = "Round: " + Globals.currentRound.ToString() + " - Score: " + Globals.currentScore.ToString() + " - Lives: " + Globals.currentLives.ToString();

                //Loads background image/sprite
                ImageBrush sprite_battleBackground = new ImageBrush(new BitmapImage(new Uri(@"Images\BattleBackground.png", UriKind.Relative)));
                canvas_battleground.Background = sprite_battleBackground;

                //Creates spaceship instance
                if (Globals.playerCreated == false)
                {
                    CreatePlayer();
                }


                //Tick events
                player.Tick();
                BulletEventsAndCollison();
                CreateAliens();
                CreateBunkers();
                AliensTick();

                //Check if round over
                RoundOver();

                //Secret pause button
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    MessageBox.Show("You've found a secret pause button. You're pretty cool!");
                }
            }

            //end game tick events
            else if (gameState == GameState.GameOver)
            {
                //Clear previous canvas
                canvas_mainmenu.Children.Clear();
                Globals.isMainMenuCreated = false;

                //Set title
                this.Title = "Game Over!";
                canvas_leaderboard.Visibility = Visibility.Visible;

                //Create leaderboard
                Rectangle leaderboard = new Rectangle();
                leaderboard.Height = 480;
                leaderboard.Width = 380;
                Canvas.SetTop(leaderboard, 100);
                Canvas.SetLeft(leaderboard, 150);

                //Set leaderboard visuals
                if (Globals.EasterEggActive == true)
                {
                    leaderboard.Fill = Globals.sprite_F_Leaderboard;
                }
                else if (Globals.EasterEggActive == false)
                {
                    leaderboard.Fill = Globals.sprite_S_Leaderboard;
                }


                //Create leaderboard instance/objects
                if (Globals.isLeaderboardCreated == false)
                {
                    CreateLeaderboard(leaderboard);
                }

                if (Globals.btn_SubmitClicked == true)
                {
                    SubmitClicked(leaderboard);
                }

            }
        }

        public void CreateLeaderboard(Rectangle leaderboard)
        {
            //Reads stats from stats.txt
            ReadStats();

            //Adds objects
            if (Globals.areStatsEntered == false)
            {
                UpdateLeaderboard();

                canvas_leaderboard.Children.Add(leaderboard);
                canvas_leaderboard.Children.Add(txt_name);
                canvas_leaderboard.Children.Add(inpt_name);
                canvas_leaderboard.Children.Add(btn_submit);
                canvas_leaderboard.Children.Add(first_name);
                canvas_leaderboard.Children.Add(first_stats);
                canvas_leaderboard.Children.Add(second_name);
                canvas_leaderboard.Children.Add(second_stats);
                canvas_leaderboard.Children.Add(third_name);
                canvas_leaderboard.Children.Add(third_stats);
                canvas_leaderboard.Children.Add(fourth_name);
                canvas_leaderboard.Children.Add(fourth_stats);
                canvas_leaderboard.Children.Add(fifth_name);
                canvas_leaderboard.Children.Add(fifth_stats);
                canvas_leaderboard.Children.Add(your_stats);
            }

            //Removes objects and prepares for switch to main menu
            else if (Globals.areStatsEntered == true)
            {
                leave_Leaderboard.Height = 25; leave_Leaderboard.Width = 291; leave_Leaderboard.Content = "Main Menu"; Canvas.SetTop(leave_Leaderboard, 575); Canvas.SetLeft(leave_Leaderboard, 195); leave_Leaderboard.Click += new RoutedEventHandler(click_leaveLeaderboard);

                canvas_leaderboard.Children.Remove(txt_name);
                canvas_leaderboard.Children.Remove(inpt_name);
                canvas_leaderboard.Children.Remove(btn_submit);
                canvas_leaderboard.Children.Add(leave_Leaderboard);
            }


            Globals.isLeaderboardCreated = true;
        }

        private void UpdateLeaderboard()
        {
            if (Globals.areStatsEntered == false)
            {
                //Set leaderboard text object attributes
                txt_name.Height = 250; txt_name.Width = 200; txt_name.Text = "Enter your name"; txt_name.TextAlignment = TextAlignment.Center; txt_name.FontSize = 24; txt_name.FontFamily = new FontFamily("Times New Roman"); Canvas.SetTop(txt_name, 10); Canvas.SetLeft(txt_name, 240);
                inpt_name.Height = 25; inpt_name.Width = 291; inpt_name.Text = "Enter your name here! (Max 10 letters)"; inpt_name.TextAlignment = TextAlignment.Center; inpt_name.FontSize = 12; inpt_name.FontFamily = new FontFamily("Times New Roman"); Canvas.SetTop(inpt_name, 50); Canvas.SetLeft(inpt_name, 195);
                btn_submit.Height = 25; btn_submit.Width = 291; btn_submit.Content = "Submit"; Canvas.SetTop(btn_submit, 75); Canvas.SetLeft(btn_submit, 195); btn_submit.Click += new RoutedEventHandler(click_btnSubmit);
                first_name.Height = 25; first_name.Width = 200; first_name.Text = Globals.first_p_name; Canvas.SetTop(first_name, 160); Canvas.SetLeft(first_name, 273); first_name.FontSize = 18; first_name.FontFamily = new FontFamily("Times New Roman");
                first_stats.Height = 50; first_stats.Width = 200; first_stats.Text = Globals.first_p_stats; Canvas.SetTop(first_stats, 200); Canvas.SetLeft(first_stats, 273); first_stats.FontSize = 18; first_stats.FontFamily = new FontFamily("Times New Roman");
                second_name.Height = 25; second_name.Width = 200; second_name.Text = Globals.second_p_name; Canvas.SetTop(second_name, 262); Canvas.SetLeft(second_name, 273); second_name.FontSize = 12; second_name.FontFamily = new FontFamily("Times New Roman");
                second_stats.Height = 25; second_stats.Width = 200; second_stats.Text = Globals.second_p_stats; Canvas.SetTop(second_stats, 300); Canvas.SetLeft(second_stats, 273); second_stats.FontSize = 12; second_stats.FontFamily = new FontFamily("Times New Roman");
                third_name.Height = 25; third_name.Width = 200; third_name.Text = Globals.third_p_name; Canvas.SetTop(third_name, 335); Canvas.SetLeft(third_name, 273); third_name.FontSize = 12; third_name.FontFamily = new FontFamily("Times New Roman");
                third_stats.Height = 25; third_stats.Width = 200; third_stats.Text = Globals.third_p_stats; Canvas.SetTop(third_stats, 375); Canvas.SetLeft(third_stats, 273); third_stats.FontSize = 12; third_stats.FontFamily = new FontFamily("Times New Roman");
                fourth_name.Height = 25; fourth_name.Width = 200; fourth_name.Text = Globals.fourth_p_name; Canvas.SetTop(fourth_name, 410); Canvas.SetLeft(fourth_name, 273); fourth_name.FontSize = 12; fourth_name.FontFamily = new FontFamily("Times New Roman");
                fourth_stats.Height = 25; fourth_stats.Width = 200; fourth_stats.Text = Globals.fourth_p_stats; Canvas.SetTop(fourth_stats, 432); Canvas.SetLeft(fourth_stats, 273); fourth_stats.FontSize = 12; fourth_stats.FontFamily = new FontFamily("Times New Roman");
                fifth_name.Height = 25; fifth_name.Width = 200; fifth_name.Text = Globals.fifth_p_name; Canvas.SetTop(fifth_name, 465); Canvas.SetLeft(fifth_name, 273); fifth_name.FontSize = 12; fifth_name.FontFamily = new FontFamily("Times New Roman");
                fifth_stats.Height = 25; fifth_stats.Width = 200; fifth_stats.Text = Globals.fifth_p_stats; Canvas.SetTop(fifth_stats, 488); Canvas.SetLeft(fifth_stats, 273); fifth_stats.FontSize = 12; fifth_stats.FontFamily = new FontFamily("Times New Roman");
                your_stats.Height = 25; your_stats.Width = 200; your_stats.Text = "Score: " + Globals.currentScore + "\nRound: " + Globals.currentRound; Canvas.SetTop(your_stats, 525); Canvas.SetLeft(your_stats, 273); your_stats.FontSize = 12; your_stats.FontFamily = new FontFamily("Times New Roman");
            }

            else if (Globals.areStatsEntered == true)
            {
                //Set leaderboard text object attributes
                txt_name.Height = 250; txt_name.Width = 200; txt_name.Text = "Enter your name"; txt_name.TextAlignment = TextAlignment.Center; txt_name.FontSize = 24; txt_name.FontFamily = new FontFamily("Times New Roman"); Canvas.SetTop(txt_name, 10); Canvas.SetLeft(txt_name, 240);
                inpt_name.Height = 25; inpt_name.Width = 291; inpt_name.Text = "Enter your name here! (Max 10 letters)"; inpt_name.TextAlignment = TextAlignment.Center; inpt_name.FontSize = 12; inpt_name.FontFamily = new FontFamily("Times New Roman"); Canvas.SetTop(inpt_name, 50); Canvas.SetLeft(inpt_name, 195);
                btn_submit.Height = 25; btn_submit.Width = 291; btn_submit.Content = "Submit"; Canvas.SetTop(btn_submit, 75); Canvas.SetLeft(btn_submit, 195); btn_submit.Click += new RoutedEventHandler(click_btnSubmit);
                first_name.Height = 25; first_name.Width = 200; first_name.Text = Globals.first_p_name; Canvas.SetTop(first_name, 160); Canvas.SetLeft(first_name, 273); first_name.FontSize = 18; first_name.FontFamily = new FontFamily("Times New Roman");
                first_stats.Height = 50; first_stats.Width = 200; first_stats.Text = Globals.first_p_stats; Canvas.SetTop(first_stats, 200); Canvas.SetLeft(first_stats, 273); first_stats.FontSize = 18; first_stats.FontFamily = new FontFamily("Times New Roman");
                second_name.Height = 25; second_name.Width = 200; second_name.Text = Globals.second_p_name; Canvas.SetTop(second_name, 260); Canvas.SetLeft(second_name, 273); second_name.FontSize = 12; second_name.FontFamily = new FontFamily("Times New Roman");
                second_stats.Height = 25; second_stats.Width = 200; second_stats.Text = Globals.second_p_stats; Canvas.SetTop(second_stats, 300); Canvas.SetLeft(second_stats, 273); second_stats.FontSize = 12; second_stats.FontFamily = new FontFamily("Times New Roman");
                third_name.Height = 25; third_name.Width = 200; third_name.Text = Globals.third_p_name; Canvas.SetTop(third_name, 335); Canvas.SetLeft(third_name, 273); third_name.FontSize = 12; third_name.FontFamily = new FontFamily("Times New Roman");
                third_stats.Height = 25; third_stats.Width = 200; third_stats.Text = Globals.third_p_stats; Canvas.SetTop(third_stats, 375); Canvas.SetLeft(third_stats, 273); third_stats.FontSize = 12; third_stats.FontFamily = new FontFamily("Times New Roman");
                fourth_name.Height = 25; fourth_name.Width = 200; fourth_name.Text = Globals.fourth_p_name; Canvas.SetTop(fourth_name, 410); Canvas.SetLeft(fourth_name, 273); fourth_name.FontSize = 12; fourth_name.FontFamily = new FontFamily("Times New Roman");
                fourth_stats.Height = 25; fourth_stats.Width = 200; fourth_stats.Text = Globals.fourth_p_stats; Canvas.SetTop(fourth_stats, 432); Canvas.SetLeft(fourth_stats, 273); fourth_stats.FontSize = 12; fourth_stats.FontFamily = new FontFamily("Times New Roman");
                fifth_name.Height = 25; fifth_name.Width = 200; fifth_name.Text = Globals.fifth_p_name; Canvas.SetTop(fifth_name, 465); Canvas.SetLeft(fifth_name, 273); fifth_name.FontSize = 12; fifth_name.FontFamily = new FontFamily("Times New Roman");
                fifth_stats.Height = 25; fifth_stats.Width = 200; fifth_stats.Text = Globals.fifth_p_stats; Canvas.SetTop(fifth_stats, 488); Canvas.SetLeft(fifth_stats, 273); fifth_stats.FontSize = 12; fifth_stats.FontFamily = new FontFamily("Times New Roman");
                your_stats.Height = 25; your_stats.Width = 200; your_stats.Text = "Score: " + Globals.currentScore + "\nRound: " + Globals.currentRound; Canvas.SetTop(your_stats, 525); Canvas.SetLeft(your_stats, 273); your_stats.FontSize = 12; your_stats.FontFamily = new FontFamily("Times New Roman");
                leave_Leaderboard.Height = 25; leave_Leaderboard.Width = 291; leave_Leaderboard.Content = "Main Menu"; Canvas.SetTop(leave_Leaderboard, 575); Canvas.SetLeft(leave_Leaderboard, 195); leave_Leaderboard.Click += new RoutedEventHandler(click_leaveLeaderboard);

                //Remove unnecessary objects
                canvas_leaderboard.Children.Remove(txt_name);
                canvas_leaderboard.Children.Remove(inpt_name);
                canvas_leaderboard.Children.Remove(btn_submit);
                canvas_leaderboard.Children.Add(leave_Leaderboard);
            }
        }

        public void click_btnSubmit(object sender, RoutedEventArgs e)
        {
            //Plot twist
            Globals.btn_SubmitClicked = true;
        }

        public void click_leaveLeaderboard(object sender, RoutedEventArgs e)
        {
            //Changes visibility
            canvas_mainmenu.Visibility = Visibility.Visible;
            canvas_leaderboard.Visibility = Visibility.Hidden;
            canvas_battleground.Visibility = Visibility.Hidden;
            //Clears unnecessary objects
            canvas_battleground.Children.Clear();
            canvas_leaderboard.Children.Clear();
            canvas_mainmenu.Children.Clear();
            //Prepares for mainmenu creation
            Globals.isMainMenuCreated = false;
            ResetGame();
            CreateMainMenu();
            gameState = GameState.MainMenu;
        }

        public void SubmitClicked(Rectangle leaderboard)
        {
            //Check for validation of entered name / compare with censored words
            for (int i = 0; i <= 32; i++)
            {
                //If censored word appears, change name to something stupid
                if (inpt_name.Text.ToUpper() == Globals.censoredwords[i]) { inpt_name.Text = "Carebear #" + i; MessageBox.Show("That is a Banned word. Your name will now be " + inpt_name.Text); }
            }
            if (inpt_name.Text.Contains('%'))
            {
                //Allows for secret names that only people who know the trick, can use.
                if (inpt_name.Text.Length < 15 && inpt_name.Text.Length > 1)
                {
                    //Fix name
                    string fixed_name = inpt_name.Text.Remove('%');
                    //Set name and stats
                    Globals.areStatsEntered = true;
                    Globals.yourName = fixed_name;
                    //Methods to update and refresh. Stay relevant
                    RefreshStats();
                    UpdateLeaderboard();
                    WriteStats();
                    //Tell player that the game is functioning properly
                    MessageBox.Show("Thanks " + Globals.yourName + ", for entering your name. The leaderboards should now be updated.");
                }
                else
                {
                    //Give the player no clue as to what they did wrong.
                    MessageBox.Show("Oops, something went wrong. Please try again.");
                }
            }
            //Standard names
            else if (!inpt_name.Text.Contains('%'))
            {
                if (inpt_name.Text.Length < 13 && inpt_name.Text.Length > 2 && !inpt_name.Text.Contains('.') && !inpt_name.Text.Contains('_'))
                {
                    Globals.areStatsEntered = true;
                    Globals.yourName = inpt_name.Text;
                    RefreshStats();
                    UpdateLeaderboard();
                    WriteStats();
                    MessageBox.Show("Thanks " + Globals.yourName + ", for entering your name. The leaderboards should now be updated.");
                }
                else
                {
                    MessageBox.Show("Oops, something went wrong. Please try again.");
                }
            }
            Globals.btn_SubmitClicked = false;
        }


        private void RoundOver()
        {
            //Checks if no aliens exist
            if (sp1Aliens.Count() == 0 && sp2Aliens.Count() == 0 && sp3Aliens.Count() == 0)
            {
                //Tell player they're doing well, despite the impending doom
                MessageBox.Show("You successfully completed round " + Globals.currentRound + ", with a total of " + Globals.currentLives + " lives. The next round will begin after you close this box.");

                //Adjust stats
                Globals.currentRound = Globals.currentRound + 1;
                Globals.currentScore = Globals.currentScore + (5 * Globals.currentRound);
                ResetRound();
            }
        }

        public void ResetRound()
        {
            //Reset aliens
            Globals.areAliensCreated = false;
            Globals.SP1AliensCreated = 0;

            Globals.areAliensCreated2 = false;
            Globals.SP2AliensCreated = 0;

            Globals.areAliensCreated3 = false;
            Globals.SP3AliensCreated = 0;

            Globals.areAliensCreated4 = false;
            Globals.SP4AliensCreated = 0;

            //Reset Lists
            foreach (Bullet b in bullets)
            {
                bulletsToDelete.Add(b);
                b.destroy();
            }
            foreach (Enemy_Bullet e_b in enemy_Bullets)
            {
                enemy_BulletsToDelete.Add(e_b);
                e_b.destroy();
            }
            foreach (SP1Aliens sp1 in sp1Aliens)
            {
                sp1.destroy();
                sp1aliensToDelete.Add(sp1);
            }
            foreach (SP2Aliens sp2 in sp2Aliens)
            {
                sp2.destroy();
                sp2aliensToDelete.Add(sp2);
            }
            foreach (SP3Aliens sp3 in sp3Aliens)
            {
                sp3.destroy();
                sp3aliensToDelete.Add(sp3);
            }
            foreach (SP4Aliens sp4 in sp4Aliens)
            {
                sp4.destroy();
                sp4aliensToDelete.Add(sp4);
            }

            //Create Aliens. pretty obvious
            CreateAliens();
        }

        public void ResetGame()
        {
            //Methods that help reset the game!
            ResetRound();
            ResetGlobals();

            //Reset lists
            foreach (SP1Aliens sp1 in sp1Aliens)
            {
                sp1.destroy();
                sp1aliensToDelete.Add(sp1);
            }
            foreach (SP2Aliens sp2 in sp2Aliens)
            {
                sp2.destroy();
                sp2aliensToDelete.Add(sp2);
            }
            foreach (SP3Aliens sp3 in sp3Aliens)
            {
                sp3.destroy();
                sp3aliensToDelete.Add(sp3);
            }
            foreach (SP4Aliens sp4 in sp4Aliens)
            {
                sp4.destroy();
                sp4aliensToDelete.Add(sp4);
            }
            foreach (Bullet b in bullets)
            {
                b.destroy();
                bulletsToDelete.Add(b);
            }
            foreach (Enemy_Bullet e_b in enemy_Bullets)
            {
                e_b.destroy();
                enemy_BulletsToDelete.Add(e_b);
            }

        }

        private static void ResetGlobals()
        {
            //Reset important global variables
            Globals.musicPlaying = false;
            Globals.beginfade = false;
            Globals.canShoot = false;
            Globals.playerCreated = false;
            Globals.blockleft = false;
            Globals.blockright = false;
            Globals.areAliensCreated = false;
            Globals.areAliensCreated2 = false;
            Globals.areAliensCreated3 = false;
            Globals.areAliensCreated4 = false;
            Globals.areBunkersCreated = false;
            Globals.isLeaderboardCreated = false;
            Globals.btn_SubmitClicked = false;
            Globals.areStatsEntered = false;

            Globals.currentScore = 0;
            Globals.currentLives = 3;
            Globals.currentRound = 1;
            Globals.bulletcount = 0;
            Globals.movecooldown = 0;
            Globals.shotcooldown = 0;
            Globals.SP1AliensCreated = 0;
            Globals.SP2AliensCreated = 0;
            Globals.SP3AliensCreated = 0;
            Globals.SP4AliensCreated = 0;
            Globals.BunkersCreated = 0;
            Globals.Spaceship_x = 0;
            Globals.AlienSpeed = 0;
        }

        private void AliensTick()
        {
            foreach (SP1Aliens sp1 in sp1Aliens)
            {
                //Run tick events per alien instance
                sp1.Tick();
                //If any alien should move down
                if (sp1.AlienMoveDown == true)
                {
                    //For each alien that exists, move down.
                    foreach (SP1Aliens spA1 in sp1Aliens) { spA1.MoveDown(); }
                    foreach (SP2Aliens spA2 in sp2Aliens) { spA2.MoveDown(); }
                    foreach (SP3Aliens spA3 in sp3Aliens) { spA3.MoveDown(); }
                }

                foreach (Bunker bunk in bunkers)
                {
                    //if any alien collides with any bunker
                    if (sp1.collidesWith(bunk))
                    {
                        //delete them boys
                        sp1aliensToDelete.Add(sp1);
                        sp1.destroy();
                        //Tell the player they would've died if this game was real
                        MessageBox.Show("The bunkers have been breached by the 1st species of Aliens!");
                        //Set bool to true
                        Globals.areBunkersBreached = true;
                    }
                }

                if (Globals.areAliensCreated4 == false)
                {
                    if (sp1.boundingBox.Y > 126 && sp1.boundingBox.Y < 130)
                    {
                        sp4Aliens.Add(new SP4Aliens(canvas_battleground, this));
                        Globals.SP4AliensCreated++;
                    }

                    foreach (SP4Aliens sp4 in sp4Aliens)
                    {
                        if (sp1.boundingBox.Y > 190 && sp1.boundingBox.Y < 194)
                        {
                            if (sp4.boundingBox.X <= -10 || sp4.boundingBox.X >= 600)
                            {
                                Globals.areAliensCreated4 = false;
                            }
                        }
                    }
                }
            }
            foreach (SP2Aliens sp2 in sp2Aliens)
            {
                sp2.Tick();
                if (sp2.AlienMoveDown == true)
                {
                    foreach (SP1Aliens spA1 in sp1Aliens) { spA1.MoveDown(); }
                    foreach (SP2Aliens spA2 in sp2Aliens) { spA2.MoveDown(); }
                    foreach (SP3Aliens spA3 in sp3Aliens) { spA3.MoveDown(); }
                }
                foreach (Bunker bunk in bunkers)
                {
                    if (sp2.collidesWith(bunk))
                    {
                        sp2aliensToDelete.Add(sp2);
                        sp2.destroy();
                        MessageBox.Show("The bunkers have been breached by the 2nd species of Aliens!");
                        Globals.areBunkersBreached = true;
                    }
                }
            }
            foreach (SP3Aliens sp3 in sp3Aliens)
            {
                sp3.Tick();
                if (sp3.AlienMoveDown == true)
                {
                    foreach (SP1Aliens spA1 in sp1Aliens) { spA1.MoveDown(); }
                    foreach (SP2Aliens spA2 in sp2Aliens) { spA2.MoveDown(); }
                    foreach (SP3Aliens spA3 in sp3Aliens) { spA3.MoveDown(); }
                }
                foreach (Bunker bunk in bunkers)
                {
                    if (sp3.collidesWith(bunk))
                    {
                        sp3aliensToDelete.Add(sp3);
                        sp3.destroy();
                        MessageBox.Show("The bunkers have been breached by the 3rd species of Aliens!");
                        Globals.areBunkersBreached = true;
                    }
                }
            }
            foreach (SP4Aliens sp4 in sp4Aliens)
            {
                //Tick 
                sp4.Tick();
                //Check if alien is outside window
                if (sp4.boundingBox.X <= -20 || sp4.boundingBox.X >= 610)
                {
                    //Delete this boi
                    sp4aliensToDelete.Add(sp4);
                    sp4.destroy();
                }
            }

            //If bunkers get breached
            if(Globals.areBunkersBreached == true)
            {
                Globals.areBunkersBreached = false;
                //Act as if player got shot
                player.Shot();
            }
        }

        private void BulletEventsAndCollison()
        {
            foreach (Bullet b in bullets)
            {
                //Tick per bullet
                b.Tick();

                foreach (SP1Aliens sp1 in sp1Aliens)
                {
                    //If any bullet collides with any SP1Alien
                    if (b.collidesWith(sp1) == true)
                    {
                        //Destroy self
                        b.destroy();
                        //Destroy alien that self collided with
                        sp1.destroy();
                        //Remove both from canvas
                        bulletsToDelete.Add(b);
                        sp1aliensToDelete.Add(sp1);
                        //Add score accordingly
                        Globals.currentScore = Globals.currentScore + 4 + (Globals.currentLives * 2) + Globals.currentRound;
                    }
                }
                foreach (SP2Aliens sp2 in sp2Aliens)
                {
                    if (b.collidesWith(sp2) == true)
                    {
                        b.destroy();
                        sp2.destroy();
                        bulletsToDelete.Add(b);
                        sp2aliensToDelete.Add(sp2);
                        Globals.currentScore = Globals.currentScore + 2 + (Globals.currentLives * 2) + Globals.currentRound;
                    }
                }
                foreach (SP3Aliens sp3 in sp3Aliens)
                {
                    if (b.collidesWith(sp3) == true)
                    {
                        b.destroy();
                        sp3.destroy();
                        bulletsToDelete.Add(b);
                        sp3aliensToDelete.Add(sp3);
                        Globals.currentScore = Globals.currentScore + 1 + (Globals.currentLives * 2) + Globals.currentRound;
                    }
                }
                foreach (SP4Aliens sp4 in sp4Aliens)
                {
                    if (b.collidesWith(sp4) == true)
                    {
                        b.destroy();
                        sp4.destroy();
                        bulletsToDelete.Add(b);
                        sp4aliensToDelete.Add(sp4);
                        Globals.currentScore = Globals.currentScore + (((1 + Globals.SP4AliensCreated) * Globals.currentRound * Globals.currentLives) - (5 * Globals.currentLives));
                    }
                }
                foreach (Bunker bunk in bunkers)
                {
                    if (b.collidesWith(bunk) == true)
                    {
                        //Destroy bullet
                        b.destroy();
                        //Deal damage to bunk
                        bunk.damage();
                        bulletsToDelete.Add(b);

                        //If bunk has no health left
                        if (bunk.health == 1)
                        {
                            //remove this boi
                            bunkersToDelete.Add(bunk);
                        }
                    }
                }
            }

            foreach (Enemy_Bullet e_b in enemy_Bullets)
            {
                e_b.Tick();

                if (e_b.collidesWith(player))
                {
                    e_b.destroy();
                    enemy_BulletsToDelete.Add(e_b);
                    player.Shot();
                }

                foreach (Bunker bunk in bunkers)
                {
                    if (e_b.collidesWith(bunk) == true)
                    {
                        e_b.destroy();
                        bunk.damage();
                        enemy_BulletsToDelete.Add(e_b);

                        if (bunk.health == 1)
                        {
                            bunkersToDelete.Add(bunk);
                        }
                    }
                }
            }

            //For each object in delete list, remove from canvas
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
            foreach (SP4Aliens sp4 in sp4aliensToDelete)
            {
                sp4Aliens.Remove(sp4);
            }
            foreach (Bunker bunk in bunkersToDelete)
            {
                bunk.destroy();
                bunkers.Remove(bunk);
            }
            foreach (Enemy_Bullet e_b in enemy_BulletsToDelete)
            {
                enemy_Bullets.Remove(e_b);
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

        private void CreateBunkers()
        {
            if (Globals.areBunkersCreated == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    bunkers.Add(new Bunker(canvas_battleground, this));

                    if (Globals.BunkersCreated == 4)
                    {
                        Globals.areBunkersCreated = true;
                    }
                }
            }
        }

        public void CreateEnemyBullet(Point point)
        {
            enemy_Bullets.Add(new Enemy_Bullet(canvas_battleground, this, point));
        }

        public static void ReadStats()
        {

            WebClient wc = new WebClient();
            wc.Credentials = new NetworkCredential(@"ezyro_22162395".Normalize(), @"Icecream5*".Normalize());
            wc.DownloadFile(Globals.statspath, Globals.path + @"\Stats.txt");

            using (StreamReader StatsReader = new StreamReader(Globals.path + @"\Stats.txt"))
            {
                using (StreamReader StatLineReader = new StreamReader(Globals.path + @"\Stats.txt"))
                {
                    string allLines = StatsReader.ReadToEnd();
                    for (int x = allLines.Count(i => i == '\n'); x > 0; x--)
                    {
                        string line = StatLineReader.ReadLine();
                        if (line.Contains("1st"))
                        {
                            Globals.first_p_name = StatLineReader.ReadLine();
                            int.TryParse(StatLineReader.ReadLine(), out Globals.first_p_round);
                            int.TryParse(StatLineReader.ReadLine(), out Globals.first_p_score);
                            x = x - 3;
                        }
                        if (line.Contains("2nd"))
                        {
                            Globals.second_p_name = StatLineReader.ReadLine();
                            int.TryParse(StatLineReader.ReadLine(), out Globals.second_p_round);
                            int.TryParse(StatLineReader.ReadLine(), out Globals.second_p_score);
                            x = x - 3;
                        }
                        if (line.Contains("3rd"))
                        {
                            Globals.third_p_name = StatLineReader.ReadLine();
                            int.TryParse(StatLineReader.ReadLine(), out Globals.third_p_round);
                            int.TryParse(StatLineReader.ReadLine(), out Globals.third_p_score);
                            x = x - 3;
                        }
                        if (line.Contains("4th"))
                        {
                            Globals.fourth_p_name = StatLineReader.ReadLine();
                            int.TryParse(StatLineReader.ReadLine(), out Globals.fourth_p_round);
                            int.TryParse(StatLineReader.ReadLine(), out Globals.fourth_p_score);
                            x = x - 3;
                        }
                        if (line.Contains("5th"))
                        {
                            Globals.fifth_p_name = StatLineReader.ReadLine();
                            int.TryParse(StatLineReader.ReadLine(), out Globals.fifth_p_round);
                            int.TryParse(StatLineReader.ReadLine(), out Globals.fifth_p_score);
                            x = x - 3;
                        }
                    }
                }
                StatsReader.Close();
                Console.WriteLine(Globals.first_p_name);
                Console.WriteLine(Globals.first_p_round.ToString());
                Console.WriteLine(Globals.first_p_score.ToString());
                Console.WriteLine(Globals.second_p_name);
                Console.WriteLine(Globals.second_p_round.ToString());
                Console.WriteLine(Globals.second_p_score.ToString());
                Console.WriteLine(Globals.third_p_name);
                Console.WriteLine(Globals.third_p_round.ToString());
                Console.WriteLine(Globals.third_p_score.ToString());
                Console.WriteLine(Globals.fourth_p_name);
                Console.WriteLine(Globals.fourth_p_round.ToString());
                Console.WriteLine(Globals.fourth_p_score.ToString());
                Console.WriteLine(Globals.fifth_p_name);
                Console.WriteLine(Globals.fifth_p_round.ToString());
                Console.WriteLine(Globals.fifth_p_score.ToString());
            }
        }

        public static void RefreshStats()
        {

            if (Globals.currentScore > Globals.first_p_score)
            {
                Globals.fifth_p_name = Globals.fourth_p_name;
                Globals.fifth_p_round = Globals.fourth_p_round;
                Globals.fifth_p_score = Globals.fourth_p_score;
                Globals.fourth_p_name = Globals.third_p_name;
                Globals.fourth_p_round = Globals.third_p_round;
                Globals.fourth_p_score = Globals.third_p_score;
                Globals.third_p_name = Globals.second_p_name;
                Globals.third_p_round = Globals.second_p_round;
                Globals.third_p_score = Globals.second_p_score;
                Globals.second_p_name = Globals.first_p_name;
                Globals.second_p_round = Globals.first_p_round;
                Globals.second_p_score = Globals.first_p_score;
                Globals.first_p_score = Globals.currentScore;
                Globals.first_p_round = Globals.currentRound;
                Globals.first_p_name = Globals.yourName;
            }
            else if (Globals.currentScore > Globals.second_p_score)
            {
                Globals.fifth_p_name = Globals.fourth_p_name;
                Globals.fifth_p_round = Globals.fourth_p_round;
                Globals.fifth_p_score = Globals.fourth_p_score;
                Globals.fourth_p_name = Globals.third_p_name;
                Globals.fourth_p_round = Globals.third_p_round;
                Globals.fourth_p_score = Globals.third_p_score;
                Globals.third_p_name = Globals.second_p_name;
                Globals.third_p_round = Globals.second_p_round;
                Globals.third_p_score = Globals.second_p_score;
                Globals.second_p_score = Globals.currentScore;
                Globals.second_p_round = Globals.currentRound;
                Globals.second_p_name = Globals.yourName;
            }
            else if (Globals.currentScore > Globals.third_p_score)
            {
                Globals.fifth_p_name = Globals.fourth_p_name;
                Globals.fifth_p_round = Globals.fourth_p_round;
                Globals.fifth_p_score = Globals.fourth_p_score;
                Globals.fourth_p_name = Globals.third_p_name;
                Globals.fourth_p_round = Globals.third_p_round;
                Globals.fourth_p_score = Globals.third_p_score;
                Globals.third_p_score = Globals.currentScore;
                Globals.third_p_round = Globals.currentRound;
                Globals.third_p_name = Globals.yourName;
            }
            else if (Globals.currentScore > Globals.fourth_p_score)
            {
                Globals.fifth_p_name = Globals.fourth_p_name;
                Globals.fifth_p_round = Globals.fourth_p_round;
                Globals.fifth_p_score = Globals.fourth_p_score;
                Globals.fourth_p_score = Globals.currentScore;
                Globals.fourth_p_round = Globals.currentRound;
                Globals.fourth_p_name = Globals.yourName;
            }
            else if (Globals.currentScore > Globals.fifth_p_score)
            {
                Globals.fifth_p_score = Globals.currentScore;
                Globals.fifth_p_round = Globals.currentRound;
                Globals.fifth_p_name = Globals.yourName;
            }

            Globals.first_p_stats = "Score: " + Globals.first_p_score.ToString() + "\nRound:" + Globals.first_p_round.ToString();
            Globals.second_p_stats = "Score: " + Globals.second_p_score.ToString() + "\nRound:" + Globals.second_p_round.ToString();
            Globals.third_p_stats = "Score: " + Globals.third_p_score.ToString() + "\nRound:" + Globals.third_p_round.ToString();
            Globals.fourth_p_stats = "Score: " + Globals.fourth_p_score.ToString() + "\nRound:" + Globals.fourth_p_round.ToString();
            Globals.fifth_p_stats = "Score: " + Globals.fifth_p_score.ToString() + "\nRound:" + Globals.fifth_p_round.ToString();
        }

        public static void WriteStats()
        {
            ReadStats();
            RefreshStats();

            using (StreamWriter StatWriter = new StreamWriter(Globals.path + @"\Stats.txt"))
            {
                StatWriter.WriteLine("1st");
                StatWriter.WriteLine(Globals.first_p_name);
                StatWriter.WriteLine(Globals.first_p_round);
                StatWriter.WriteLine(Globals.first_p_score);
                StatWriter.WriteLine("");
                StatWriter.WriteLine("2nd");
                StatWriter.WriteLine(Globals.second_p_name);
                StatWriter.WriteLine(Globals.second_p_round);
                StatWriter.WriteLine(Globals.second_p_score);
                StatWriter.WriteLine("");
                StatWriter.WriteLine("3rd");
                StatWriter.WriteLine(Globals.third_p_name);
                StatWriter.WriteLine(Globals.third_p_round);
                StatWriter.WriteLine(Globals.third_p_score);
                StatWriter.WriteLine("");
                StatWriter.WriteLine("4th");
                StatWriter.WriteLine(Globals.fourth_p_name);
                StatWriter.WriteLine(Globals.fourth_p_round);
                StatWriter.WriteLine(Globals.fourth_p_score);
                StatWriter.WriteLine("");
                StatWriter.WriteLine("5th");
                StatWriter.WriteLine(Globals.fifth_p_name);
                StatWriter.WriteLine(Globals.fifth_p_round);
                StatWriter.WriteLine(Globals.fifth_p_score);
            }

            WebClient wc = new WebClient();
            wc.Credentials = new NetworkCredential(@"ezyro_22162395".Normalize(), @"Icecream5*".Normalize());
            wc.UploadFile(Globals.statspath, Globals.path + @"\Stats.txt");

        }
    }
}