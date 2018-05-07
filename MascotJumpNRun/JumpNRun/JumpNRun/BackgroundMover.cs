using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JumpNRun
{
    static class BackgroundMover
    {
        public static double leftOffset = 500;
        public static double rightOffset = 1300;

        public static void MoveBackground(Image img, Player player, double offset)
        {
            if (player.Left == true)
            {
                Canvas.SetLeft(img,Canvas.GetLeft(img) + offset);

            }
            else if (player.Right == true)
            {
                Canvas.SetLeft(img, Canvas.GetLeft(img) - offset);
            }
        }

        public static void MoveBackground(Image img1, Image img2, Image img3, Player player, double offset)
        {
            MoveBackground(img1, player, offset);
            MoveBackground(img2, player, offset);
            MoveBackground(img3, player, offset);
        }

        public static void UpdateToRight(Image img1,Image img2, Image img3, Player player,double distance)
        {
            if (player.Right)
            {
                if (Canvas.GetLeft(img1) + img1.Width <= player.X - distance)
                {
                    Canvas.SetLeft(img1, Canvas.GetLeft(img3) + img3.Width);
                }
                if (Canvas.GetLeft(img2) + img2.Width <= player.X - distance)
                {
                    Canvas.SetLeft(img2, Canvas.GetLeft(img1) + img1.Width);
                }
                if (Canvas.GetLeft(img3) + img3.Width <= player.X - distance)
                {
                    Canvas.SetLeft(img3, Canvas.GetLeft(img2) + img2.Width);
                }
            }
        }



        public static void UpdateToLeft(Image img1, Image img2,Image img3, Player player,double distance)
        {
            if (player.Left)
            {
                if (Canvas.GetLeft(img3) >= player.X + distance)
                {
                    Canvas.SetLeft(img3, Canvas.GetLeft(img1) - img1.Width);
                }
                if (Canvas.GetLeft(img2) >= player.X + distance)
                {
                    Canvas.SetLeft(img2,Canvas.GetLeft(img3) - img3.Width);
                }
                if (Canvas.GetLeft(img1) >= player.X + distance)
                {
                    Canvas.SetLeft(img1,Canvas.GetLeft(img2) - img2.Width);
                }
            }
        }

        public static void MoveCoinCounter(Image coinImg, Label coincounter,Player player, double offset)
        {
            if (player.Right || player.Left)
            {
                if (player.X >= 500 || player.X <= 500)
                {
                    Canvas.SetLeft(coinImg, player.X - 450);
                    Canvas.SetLeft(coincounter, player.X - 500);
                }
            }

        }

    }
}
