
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace JumpNRun
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game = new Game();

        public MainWindow()
        {
            DataContext = game;
            
            game.GameStateChanged += Game_GameStateChanged;
            KeyDown += game.player.StartJump;
            KeyUp += game.player.EndJump;

            game.Start();
            game.player.Moved += OnMoved;

            InitializeComponent();
            counter.DataContext = game.player;
            xPlayer.DataContext = game.player;
        }


        private void Game_GameStateChanged(object sender, GameStateHandlerEventArgs e)
        {
            if (e.State == GameState.Win)
            {
                MessageBox.Show("Gewonnen! Gesammelte Coins: "+counter.Content);
                game.End();
            }
            else
            {
                MessageBox.Show("Verloren! Gesammelte Coins: "+counter.Content);
                MainWindow mainwindow = new MainWindow();
                game.End();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            game.player.KeyDown(sender, e);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            game.player.KeyUp(sender, e);
        }

        private void OnMoved(object sender, double x)
        {
           Camera.ScrollToHorizontalOffset(x - BackgroundMover.leftOffset );

           BackgroundMover.MoveBackground(BackgroundImg1,BackgroundImg2,BackgroundImg3,game.player,5);
           BackgroundMover.MoveBackground(GroundImg1,GroundImg2,GroundImg3,game.player,5);

           BackgroundMover.UpdateToRight(BackgroundImg1,BackgroundImg2,BackgroundImg3,game.player,BackgroundMover.leftOffset);
           BackgroundMover.UpdateToRight(GroundImg1,GroundImg2,GroundImg3,game.player,BackgroundMover.leftOffset);

           BackgroundMover.UpdateToLeft(BackgroundImg1,BackgroundImg2,BackgroundImg3,game.player,BackgroundMover.rightOffset);
           BackgroundMover.UpdateToLeft(GroundImg1,GroundImg2,GroundImg3,game.player,BackgroundMover.rightOffset);
           
           BackgroundMover.MoveCoinCounter(coinImg,counter,game.player,500);
        }



    }
}
