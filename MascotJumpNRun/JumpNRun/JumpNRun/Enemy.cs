using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using JumpNRun.Properties;

namespace JumpNRun
{
    public class Enemy : GameObject
    {

        public int count;
        public static bool PlayerNear;

        public Enemy(double x, double y, int width, int height) : base(x, y, width, height) { }
        public Enemy() : this(10, 510, 64, 140) { }


        public static string[] GreenMonsterIdleUris =
        {
            "/Resources/ImagesForAnimation/Enemy/GreenMonster/Idle/idle1.png","/Resources/ImagesForAnimation/Enemy/GreenMonster/Idle/idle2.png",
        };

        public string[] GreenMonsterGotHitUris =
        {
            "/Resources/ImagesForAnimation/Enemy/GreenMonster/GotHit/gothit1.png","/Resources/ImagesForAnimation/Enemy/GreenMonster/GotHit/gothit2.png",
        };

        public static string[] OrangeMonsterIdleUris =
        {
            "/Resources/ImagesForAnimation/Enemy/OrangeMonster/Idle/idle1.png","/Resources/ImagesForAnimation/Enemy/OrangeMonster/Idle/idle2.png",
            "/Resources/ImagesForAnimation/Enemy/OrangeMonster/Idle/idle3.png","/Resources/ImagesForAnimation/Enemy/OrangeMonster/Idle/idle4.png",
            "/Resources/ImagesForAnimation/Enemy/OrangeMonster/Idle/idle5.png","/Resources/ImagesForAnimation/Enemy/OrangeMonster/Idle/idle6.png",
            "/Resources/ImagesForAnimation/Enemy/OrangeMonster/Idle/idle7.png","/Resources/ImagesForAnimation/Enemy/OrangeMonster/Idle/idle8.png",
        };

        public static string[] OrangeMonsterGotHitUris =
        {
            "/Resources/ImagesForAnimation/Enemy/OrangeMonster/GotHit/gothit1.png","/Resources/ImagesForAnimation/Enemy/OrangeMonster/GotHit/gothit2.png",
        };



        public void AnimateMonster(Enemy enemy,string[] AnimationUri,Player player)
        {
            if (count > AnimationUri.Length - 1)
                count = 0;
            enemy.MyImage = new BitmapImage((new Uri(AnimationUri[count], UriKind.RelativeOrAbsolute)));
            count++;
        }

        public static void PlayEnemyAnimation(Player player,ObservableCollection<Enemy> Enemies)
        {
            if (!Collision.BottomCollisionEnemy(player, Enemies))
            {
                foreach (Enemy enemy in Enemies)
                {
                    if (enemy.X >= player.X - 500 && enemy.X <= player.X + 1300)
                    {
                        enemy.AnimateMonster(enemy,GreenMonsterIdleUris,player);
                    }
                }
            }
            else
            {
                Rect BoundingBox = new Rect(player.X, player.Y + player.Height, player.Width, 1);

                for (int i = Enemies.Count - 1; i >= 0; i--)
                {
                    Rect EnemyBox = new Rect(Enemies[i].X, Enemies[i].Y, Enemies[i].Width, Enemies[i].Height);

                    if (BoundingBox.IntersectsWith(EnemyBox))
                    {
                       Enemies[i].AnimateMonster(Enemies[i], Enemies[i].GreenMonsterGotHitUris,player);
                       Enemies.RemoveAt(i);
                    }
                }
            }

        }

  
        public bool FindOutIfMonsterCanSeePlayer(Player player)
        {
            if (player.X >= this.X + 200 && player.X <= this.X - 200)
                return PlayerNear == true;
            else return PlayerNear == false;
        }

        public static void FollowPlayer(Player player,ObservableCollection<Enemy> Enemies,ObservableCollection<Rect> Platforms)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (player.X < enemy.X && !Collision.LeftCollision(enemy, Platforms))
                    enemy.X -= 6;

                else if (player.X > enemy.X && !Collision.RightCollision(enemy,Platforms))
                    enemy.X += 6;
            }
        }

    }
}
