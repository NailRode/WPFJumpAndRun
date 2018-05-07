
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace JumpNRun
{
    class World
    {
        public static void CreatePlatforms(ObservableCollection<Rect> Platforms)
        {
            for (int i = 1; i <= 20; i++)
            {
                Platforms.Add(new Rect(100 + i * 1700, 570, 200, 50));
                Platforms.Add(new Rect(200 + i * 1200, 350, 200, 50));
                Platforms.Add(new Rect(300 + i * 1500, 300, 200, 50));
                Platforms.Add(new Rect(400 + i * 2000, 200, 100, 50));
            }
        }


        public static void CreateTrees(ObservableCollection<Rect> Trees)
        {
            for (int i = 1; i <= 50; i++)
            {
                Trees.Add(new Rect(400+i*1000,322,282,301));
                Trees.Add(new Rect(100 + i * 3000, 322, 282, 301));
            }
        }

        public static void CreateBushes(ObservableCollection<Rect> Bushes)
        {
            for (int i = 1; i <= 20; i++)
            {
                Bushes.Add(new Rect(100 + i * 1700, 520, 200, 50));
                Bushes.Add(new Rect(200 + i * 1200, 300, 200, 50));
                Bushes.Add(new Rect(300 + i * 1500,250,200,50));
                Bushes.Add(new Rect(400 + i * 2000,150,100,50));
            }   
        }

        public static void CreateSigns(ObservableCollection<Rect> Signs)
        {
            //
        }

        public static void CreateCrates(ObservableCollection<Rect> Crates)
        {
            //
        }

        public static void CreateMushrooms(ObservableCollection<Rect> Mushrooms)
        {
            for (int i = 1; i <= 50; i++)
            {
                Mushrooms.Add(new Rect(i*1800,570,40,40));
                Mushrooms.Add(new Rect(300 + i * 900,570,40,40));
            }
        }

        public static void CreateCoins(ObservableCollection<Coin> Coins)
        {
            for (int i = 1; i <= 15; i++)
            {
                Coins.Add(new Coin(100 + i * 1700, 530, 40, 40));
                Coins.Add(new Coin(140 + i * 1700, 530, 40, 40));
                Coins.Add(new Coin(180 + i * 1700, 530, 40, 40));
                Coins.Add(new Coin(220 + i * 1700, 530, 40, 40));
                Coins.Add(new Coin(260 + i * 1700, 530, 40, 40));

                Coins.Add(new Coin(200 + i * 1200, 310, 40, 40));
                Coins.Add(new Coin(240 + i * 1200, 310, 40, 40));
                Coins.Add(new Coin(280 + i * 1200, 310, 40, 40));
                Coins.Add(new Coin(320 + i * 1200, 310, 40, 40));
                Coins.Add(new Coin(360 + i * 1200, 310, 40, 40));

            }
            for (int i = 1; i <= 15; i++)
            {
                Coins.Add(new Coin(300 + i * 1500, 260, 40, 40));
                Coins.Add(new Coin(340 + i * 1500, 260, 40, 40));
                Coins.Add(new Coin(380 + i * 1500, 260, 40, 40));
                Coins.Add(new Coin(420 + i * 1500, 260, 40, 40));
                Coins.Add(new Coin(460 + i * 1500, 260, 40, 40));
            }
            for (int i = 1; i <= 10; i++)
            {
                Coins.Add(new Coin(400 + i * 2000, 160, 40, 40));
                Coins.Add(new Coin(400 + i * 2000, 160, 40, 40));
                Coins.Add(new Coin(400 + i * 2000, 160, 40, 40));
            }
        }

        public static void CreateEnemies(ObservableCollection<Enemy> Enemies)
        {
            for (int i = 1; i <= 20; i++)
            {
                Enemies.Add(new Enemy(i * 755, 550, 80, 80));
                Enemies.Add(new Enemy(i* 1365,550,80,80));
            }
        }

    }
}
