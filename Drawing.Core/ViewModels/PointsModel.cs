using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;

namespace Drawing.Core.ViewModels
{
    public class PointsModel : MvxViewModel
    {
        private ObservableCollection<LineModel> _myPoints = new ObservableCollection<LineModel>();

        public ObservableCollection<LineModel> MyPoints
        {
            get { return _myPoints; }
            set
            {
                _myPoints = value;
                RaisePropertyChanged(() => MyPoints);
            }
        }
    }
}
