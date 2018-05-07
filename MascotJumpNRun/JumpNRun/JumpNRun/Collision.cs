
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;


namespace JumpNRun
{
    public class Collision:MainWindow
    {

        public static bool OnPlatform;

        public static bool LeftCollision(GameObject gameobject, ObservableCollection<Rect> bloecke)
        {
            Rect BoundingBox = new Rect(gameobject.X -1 , gameobject.Y +1,1, gameobject.Height - 27);

            foreach (Rect block in bloecke)
            {
                if (BoundingBox.IntersectsWith(block))
                    return true; 
            }
            return false;
        }

        public static bool RightCollision(GameObject gameobject, ObservableCollection<Rect> bloecke)
        {
            Rect BoundingBox = new Rect(gameobject.X + gameobject.Width, gameobject.Y + 1, 1, gameobject.Height - 27);

            foreach (Rect block in bloecke)
            {
                if (BoundingBox.IntersectsWith(block))
                    return true;
            }
            return false;
        }

        public static bool BottomCollision(GameObject gameobject, ObservableCollection<Rect> bloecke)
        {
            Rect BoundingBox = new Rect(gameobject.X + 3, gameobject.Y + gameobject.Height - 23, gameobject.Width - 3, 1);

            for (int i = bloecke.Count - 1; i >= 0; i--)
            {
                Rect BlockBox = new Rect(bloecke[i].X, bloecke[i].Y, bloecke[i].Width, bloecke[i].Height);

                if (BoundingBox.IntersectsWith(BlockBox))
                {
                    gameobject.Gravity = 0;
                    gameobject.Jump = false;
                    BlockBox.Y = BoundingBox.Y + BoundingBox.Height;
                    OnPlatform = true;
                    return true;
                }
                OnPlatform = false;
            }
            return false;
        }



        public static bool TopCollision(GameObject gameobject, ObservableCollection<Rect> bloecke)
        {
            Rect BoundingBox = new Rect(gameobject.X + 3, gameobject.Y + 15,gameobject.Width - 6, 1);

            foreach (Rect block in bloecke)
            {
                if (BoundingBox.IntersectsWith(block))
                    return true;
            }
            return false;
        }

        public static void CoinCollision(Player player, ObservableCollection<Coin> coins)
        {
            Rect BoundingBox = new Rect(player.X, player.Y, player.Width, player.Height);
           
            for (int i = coins.Count - 1; i >= 0; i--)
            {
                Rect CoinBox = new Rect(coins[i].X, coins[i].Y, coins[i].Width, coins[i].Height);

                if (BoundingBox.IntersectsWith(CoinBox))
                {
                    coins.RemoveAt(i);
                    player.CoinCounter++;
                }
            }
        }

        public static bool BottomCollisionEnemy(Player player, ObservableCollection<Enemy> enemies)
        {
            Rect BoundingBox = new Rect(player.X, player.Y + player.Height, player.Width, 1);

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                Rect EnemyBox = new Rect(enemies[i].X, enemies[i].Y, enemies[i].Width, enemies[i].Height);

                if (BoundingBox.IntersectsWith(EnemyBox))
                {
                    enemies.RemoveAt(i);
                    return true;
                }
            }
            return false;

        }

        public static bool LeftCollisionEnemy(Player player, ObservableCollection<Enemy> enemies)
        {
            Rect BoundingBox = new Rect(player.X - 1, player.Y - 10, 1, player.Height - 10);

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                Rect EnemyBox = new Rect(enemies[i].X, enemies[i].Y, enemies[i].Width, enemies[i].Height);

                if (BoundingBox.IntersectsWith(EnemyBox))
                {
                    player.Life--;
                    return true;
                }
            }
            return false;

        }

        public static bool RightCollisionEnemy(Player player, ObservableCollection<Enemy> enemies)
        {
            Rect BoundingBox = new Rect(player.X + player.Width, player.Y - 10 , 1, player.Height - 10);

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                Rect EnemyBox = new Rect(enemies[i].X, enemies[i].Y, enemies[i].Width, enemies[i].Height);

                if (BoundingBox.IntersectsWith(EnemyBox))
                {
                    player.Life--;
                    return true;
                }
            }
            return false;
        }

        public static void MushroomCollision(Player player, ObservableCollection<Rect> Mushrooms)
        {
            if (BottomCollision(player, Mushrooms))
            {
                player.Jump = true;
                player.VelocityY = -30;
            }
            if (RightCollision(player, Mushrooms))
            {
                player.Right = false;
            }
            if (LeftCollision(player, Mushrooms))
            {
                player.Left = false;
            }
        }
    }
}

