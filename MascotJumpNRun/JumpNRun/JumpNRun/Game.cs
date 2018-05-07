using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace JumpNRun
{
    class Game:Window
    {
        private DispatcherTimer Timer;
        public DispatcherTimer AnimTimer;

        public Player player = new Player();

        public ObservableCollection<Rect> Platforms { get; set; }
        public ObservableCollection<Rect> Trees { get; set; }
        public ObservableCollection<Rect> Bushes { get; set; }
        public ObservableCollection<Rect> Mushrooms { get; set; }
        public ObservableCollection<Player> Players { get; set; }
        public ObservableCollection<Coin> Coins { get; set; }
        public ObservableCollection<Enemy> Enemies { get; set; }

        public delegate void GameStateHandler(object sender, GameStateHandlerEventArgs e);
        public event GameStateHandler GameStateChanged;

        public void Start()
        {
            InitCollections();
            CreateTheGameWorld();
            InitGameTimer();
            InitAnimationTimer();

            player.Life = 5;
            player.VelocityX = 10;
            player.VelocityY = -10;
        }

        public void End()
        {
            Application.Current.Shutdown();
        }

        private void InitCollections()
        {
            Enemies = new ObservableCollection<Enemy>();
            Coins = new ObservableCollection<Coin>();
            Platforms = new ObservableCollection<Rect>();
            Trees = new ObservableCollection<Rect>();
            Bushes = new ObservableCollection<Rect>();
            Mushrooms = new ObservableCollection<Rect>();
        }

        private void InitGameTimer()
        {
            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            Timer.IsEnabled = true;
            Timer.Start();
        }



        private void InitAnimationTimer()
        {
            AnimTimer = new DispatcherTimer();
            AnimTimer.Tick += Animation_Tick;
            AnimTimer.Interval = new TimeSpan(0, 0, 0, 0, 60);
            AnimTimer.IsEnabled = true;
            AnimTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
                {
                player.InitializeMovement(Platforms);
                player.UpdateGravity();
                Enemy.FollowPlayer(player, Enemies, Platforms);
                Collision.CoinCollision(player, Coins);
                Collision.MushroomCollision(player,Mushrooms);
                Collision.BottomCollision(player,Platforms);
                Collision.BottomCollisionEnemy(player, Enemies);
                CheckLose();
                CheckWin();
             });
        }

        private void Animation_Tick(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                player.AnimatePlayer(Platforms, Enemies);
                Coin.PlayCoinAnimation(Coins, player);
                Enemy.PlayEnemyAnimation(player, Enemies);
            });
        }

        private void CreateTheGameWorld()
        {
            this.Dispatcher.Invoke(() =>
            {
                World.CreatePlatforms(Platforms);
                World.CreateTrees(Trees);
                World.CreateBushes(Bushes);
                World.CreateCoins(Coins);
                World.CreateEnemies(Enemies);
                World.CreateMushrooms(Mushrooms);
            });
        }

        private void CheckLose()
        {
            if (player.Life == 0)
            {
                Timer.Stop();
                GameStateChanged?.Invoke(this, new GameStateHandlerEventArgs(GameState.Lose));
            }
        }


        private void CheckWin()
        {
            if (player.X == 29500)
            {
                Timer.Stop();
                GameStateChanged?.Invoke(this, new GameStateHandlerEventArgs(GameState.Win));
            }
        }
    }
}
