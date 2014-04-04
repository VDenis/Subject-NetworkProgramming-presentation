using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Windows.UI.Input;
using Cirrious.MvvmCross.WindowsPhone.Views;

namespace Drawing.WinPhone.Views
{
    public partial class FirstView : MvxPhonePage
    {

        private Point _previousContactPt;
        private Point currentContactPt;
        private double x1;
        private double y1;
        private double x2;
        private double y2;

        public FirstView()
        {
            InitializeComponent();

            //MyCanvas.Cursor = null;
        }

/*        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition(MyCanvas);
            
            _previousContactPt = pt;

            //PointerPoint pt = e.GetCurrentPoint(MyCanvas);

            //PointerPoint pt = e.(MyCanvas);
        }

        private void MyCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition(MyCanvas);
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(MyCanvas);
            currentContactPt = pt;

            // Render a red line on the canvas as the pointer moves. 
                // Distance() is an application-defined function that tests
                // whether the pointer has moved far enough to justify 
                // drawing a new line.
                //currentContactPt = pt.;
                x1 = _previousContactPt.X;
                y1 = _previousContactPt.Y;
               
                x2 = currentContactPt.X;
                y2 = currentContactPt.Y;

            if (Distance(x1, y1, x2, y2) > 10.0) // We need to developp this method now 
            {
                Line line = new Line()
                {
                    X1 = x1,
                    Y1 = y1,
                    X2 = x2,
                    Y2 = y2,
                    StrokeThickness = 4.0,
                    Stroke = new SolidColorBrush(Colors.Green)
                };

                _previousContactPt = currentContactPt;

                // Draw the line on the canvas by adding the Line object as
                // a child of the Canvas object.
                MyCanvas.Children.Add(line);
            }
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            double d = 0;
            d = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return d;
        }

        private void MyCanvas_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        //private void MyCanvas_OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        //{

        //}

        //private void MyCanvas_OnTap(object sender, GestureEventArgs e)
        //{
        //    throw new System.NotImplementedException();
        //}*/
    }
}