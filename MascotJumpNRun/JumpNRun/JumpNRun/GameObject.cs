using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace JumpNRun
{
    public abstract class GameObject : INotifyPropertyChanged
    {
        private int height;
        private int width;
        private double x;
        private double y;
        private ImageSource myimage;
        private ScaleTransform mirror;

        public float Gravity { get; set; }
        public bool Jump { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public ObservableCollection<GameObject> GameObjects { get; set; }

        public GameObject(double x, double y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            GameObjects = new ObservableCollection<GameObject>();
        }

        public ScaleTransform Mirror
        {
            get { return mirror; }
            set
            {
                mirror = value;
                NotifyPropertyChanged();
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                    throw new Exception("Die Höhe muss größer als 0 sein!");

                height = value;
                NotifyPropertyChanged();
            }
        }

        public int Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                    throw new Exception("Die Breite muss größer als 0 sein!");

                width = value;
                NotifyPropertyChanged();
            }
        }

        public double X
        {
            get { return x; }
            set
            {
                if (value < 0 || value > 30000)
                    throw new Exception("Die X-Koordinate muss >=0 && <=30.000 sein!");

                x = value;
                NotifyPropertyChanged();
                OnMoved();
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (value < 0)
                    throw new Exception("Die Y-Koordinate muss größer gleich 0 sein! ");
                y = value;
                NotifyPropertyChanged();
            }
        }

        public ImageSource MyImage
        {
            get { return myimage; }
            set
            {
                myimage = value;
                NotifyPropertyChanged();
            }
        }

        public void MoveLeft()
        {
            X -= VelocityX;
        }

        public void MoveRight()
        {
            X += VelocityX;
        }

        public void MJump()
        {
            Y += VelocityY;
        }
        public delegate void MovedxEventHandler(object sender, double x);

        public event MovedxEventHandler Moved;

        protected virtual void OnMoved()
        {
            Moved?.Invoke(this, X);
        }

    }
}
