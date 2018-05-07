using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace JumpNRun
{
    public class Coin:GameObject
    {

        public int count;
        public static ImageBrush coinImage;

        public Coin(double x,double y,int width,int height):base(x,y,width,height) { }

        private static int coinCounter;

        public static int CoinCounter
        {
            get { return coinCounter; }
            set { coinCounter = value; }
        }

        protected string[] CoinUris =
        {
            "/Resources/ImagesForAnimation/Coin/coin1.png","/Resources/ImagesForAnimation/Coin/coin2.png",
            "/Resources/ImagesForAnimation/Coin/coin3.png","/Resources/ImagesForAnimation/Coin/coin4.png",
            "/Resources/ImagesForAnimation/Coin/coin5.png","/Resources/ImagesForAnimation/Coin/coin6.png",
        };

        private void CoinAnimation(Coin coin)
        {
            if (count > CoinUris.Length - 1)
                count = 0;
            coin.MyImage = new BitmapImage((new Uri(CoinUris[count], UriKind.RelativeOrAbsolute)));
            count++;
        }

        public static void PlayCoinAnimation(ObservableCollection<Coin> Coins,Player player)
        {
            foreach (Coin coin in Coins)
            {
                if (coin.X >= player.X - 500 && coin.X <= player.X + 1300)
                {
                    coin.CoinAnimation(coin);
                }
            }
        }



    }
}
