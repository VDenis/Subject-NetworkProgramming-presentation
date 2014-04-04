using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;

namespace Drawing.Core.ViewModels
{
    public class LineModel : MvxViewModel
    {

        /*public LineModel(int newX1, int newY1, int newX2, int newY2)
        {
            X1 = newX1;
            Y1 = newY1;
            X2 = newX2;
            Y2 = newY2;
        }*/



        private double _x1;

        public double X1
        {
            get { return _x1; }
            set
            {
                _x1 = value;
                RaisePropertyChanged(() => X1);
            }
        }

        private double _y1;

        public double Y1
        {
            get { return _y1; }
            set
            {
                _y1 = value;
                RaisePropertyChanged(() => Y1);
            }
        }



        private double _x2;

        public double X2
        {
            get { return _x2; }
            set
            {
                _x2 = value;
                RaisePropertyChanged(() => X2);
            }
        }

        private double _y2;

        public double Y2
        {
            get { return _y2; }
            set
            {
                _y2 = value;
                RaisePropertyChanged(() => Y2);
            }
        }
    }
}
