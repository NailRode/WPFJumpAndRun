using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace JumpNRun
{
    public class Player:GameObject
    {
        private int count;
        private static int Ground = 510;
        private int life;

        private int coincounter = 0;
        private int screenwidth = 30000;

        public int CoinCounter
        {
            get { return coincounter; }
            set
            {
                coincounter = value;
                NotifyPropertyChanged();
            }
        }


        public Player(double x, double y ,int width, int height) : base(x,y,width,height) { }
        public Player() : this(10, Ground, 64, 140) { }

        public int Life
        {
            get { return life; }
            set
            {
                life = value;
                NotifyPropertyChanged();
            }
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A: Left = true; break;
                case Key.D: Right = true; break;
                case Key.W: Jump = true; break;
                case Key.Escape: Application.Current.Shutdown();
                    break;
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A: Left = false; break;
                case Key.D: Right = false; break;
                case Key.W: Jump = false;break;
            }
        }
      
        public void StartJump(object sender, KeyEventArgs e)
        {
            if (Y == Ground || Collision.OnPlatform)
            {
                VelocityY = -25;
                Jump = false;
            }
        }

        public void EndJump(object sender, KeyEventArgs e)
        {
            if (VelocityY < -12.5)
                VelocityY = -12.5;
        }

        public void InitializeMovement(ObservableCollection<Rect> bloecke)
        {
            if (Right &&!Collision.RightCollision(this, bloecke) && X + Width < screenwidth)
                MoveRight();
            if (Left && !Collision.LeftCollision(this, bloecke) && X > 0)
                MoveLeft();
            if (Jump && !Collision.TopCollision(this, bloecke) && Y > 30)
                MJump();
        }

        public void UpdateGravity()
        {
            if (Y > Ground)
            {
                Gravity = 0;
                Y = Ground;
            }

            if (Y < Ground)
            {
                VelocityY += Gravity;
                Y += Gravity;
            }

            if (Gravity > 25f)
                Gravity = 25f;

            Gravity +=0.2f;
        }

        protected string[] JumpUpUri =
        {
            "/Resources/ImagesForAnimation/Player/jump/jump-up.png"
        };

        protected string[] JumpFallUri =
        {
            "/Resources/ImagesForAnimation/Player/jump/jump-fall.png"
        };

        protected string[] RunUris =
        {
            "/Resources/ImagesForAnimation/Player/Run/run1.png","/Resources/ImagesForAnimation/Player/Run/run2.png",
            "/Resources/ImagesForAnimation/Player/Run/run3.png","/Resources/ImagesForAnimation/Player/Run/run4.png",
            "/Resources/ImagesForAnimation/Player/Run/run5.png"
        };

        protected string[] IdleUris =
        {
            "/Resources/ImagesForAnimation/Player/Idle/idle1.png","/Resources/ImagesForAnimation/Player/Idle/idle2.png"
        };

        protected string[] DeathUris =
        {
            "/Resources/ImagesForAnimation/Player/Death/death1.png","/Resources/ImagesForAnimation/Player/Death/death2.png",
            "/Resources/ImagesForAnimation/Player/Death/death3.png","/Resources/ImagesForAnimation/Player/Death/death3.png",
            "/Resources/ImagesForAnimation/Player/Death/death5.png"
        };

        protected string[] DizzyUris =
        {
            "/Resources/ImagesForAnimation/Player/Dizzy/dizzy1.png","/Resources/ImagesForAnimation/Player/Dizzy/dizzy2.png"
        };

        private void AnimateJumpUp()
        {
            if (count > JumpUpUri.Length - 1)
                count = 0;
            MyImage = new BitmapImage(new Uri(JumpUpUri[count], UriKind.RelativeOrAbsolute));
            count++;
        }

        private void AnimateJumpFall()
        {
            if (count > JumpFallUri.Length - 1)
                count = 0;
            MyImage = new BitmapImage(new Uri(JumpFallUri[count], UriKind.RelativeOrAbsolute));
            count++;
        }

        private void AnimateRuntoRight()
        {
            Mirror = new ScaleTransform() { ScaleX = +1 };
            if (count > RunUris.Length - 1)
                count = 0;
            MyImage = new BitmapImage(new Uri(RunUris[count], UriKind.RelativeOrAbsolute));
            count++;
        }

        private void AnimateRuntoLeft()
        {
            Mirror = new ScaleTransform() { ScaleX = -1 };
            if (count > RunUris.Length - 1)
                count = 0;
            MyImage = new BitmapImage(new Uri(RunUris[count], UriKind.RelativeOrAbsolute));
            count++;
        }

        private void AnimateIdle()
        {
            if (count > IdleUris.Length - 1)
                count = 0;
            MyImage = new BitmapImage(new Uri(IdleUris[count], UriKind.RelativeOrAbsolute));
            count++;
        }

        public void AnimateDeath()
        {
            if (count > DeathUris.Length - 1)
                count = 0;
            MyImage = new BitmapImage(new Uri(DeathUris[count], UriKind.RelativeOrAbsolute));
            count++;
            
        }

        public void AnimateDizzy()
        {
            if (count > DizzyUris.Length - 1)
                count = 0;
            MyImage = new BitmapImage(new Uri(DizzyUris[count], UriKind.RelativeOrAbsolute));
            count++;
        }

        public void AnimatePlayer(ObservableCollection<Rect> Platforms,ObservableCollection<Enemy> Enemies)
        {
            if (Right && !Collision.RightCollision(this,Platforms) && !Jump)
                AnimateRuntoRight();

            if (Left && !Collision.LeftCollision(this,Platforms) && !Jump)
                AnimateRuntoLeft();

            if (!Right && !Left && !Jump)
                AnimateIdle();
               
            if (Collision.LeftCollisionEnemy(this, Enemies) || Collision.RightCollisionEnemy(this, Enemies))
                AnimateDizzy();

            if(Life <= 0)
                AnimateDeath();

            if (Y < Ground && !Collision.BottomCollision(this,Platforms))
            {
                AnimateJumpUp();

                if (Gravity < VelocityY)
                {
                    AnimateJumpFall();
                }
            }
        }



    }
}
