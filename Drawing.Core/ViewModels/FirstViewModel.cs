using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Drawing.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        //private string _hello = "Hello MvvmCross";
        //public string Hello
        //{ 
        //    get { return _hello; }
        //    set { _hello = value; RaisePropertyChanged(() => Hello); }
        //}

        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }

        double[] preXArray = new double[10];
        double[] preYArray = new double[10];


/*        private PointsModel _pointsCollection;

        public PointsModel PointsCollection
        {
            get { return _pointsCollection; }
            set
            {
                _pointsCollection = value;
                RaisePropertyChanged(() => PointsCollection);
            }
        }*/



        private ObservableCollection<LineModel> _points = new ObservableCollection<LineModel>();

        public ObservableCollection<LineModel> Points
        {
            get { return _points; }
            set
            {
                _points = value;
                RaisePropertyChanged(() => Points);
            }
        }

        //private MvxCommand _pointerPressedCommand;

        //public MvxCommand PointerPressedCommand
        //{
        //    get
        //    {
        //        _pointerPressedCommand = _pointerPressedCommand ?? new MvxCommand(DoPointerPressedCommand);
        //        return _pointerPressedCommand;
        //    }
        //}

        //private void DoPointerPressedCommand()
        //{
        //    if (this != null)
        //    {
                
        //    }
        //}



        private MvxCommand<object> _pointerPressedCommand;

        public MvxCommand<object> PointerPressedCommand
        {
            get
            {
                _pointerPressedCommand = _pointerPressedCommand ?? new MvxCommand<object>(DoPointerPressedCommand);
                return _pointerPressedCommand;
            }
        }

        private void DoPointerPressedCommand(object temp)
        {
            var temp2 = temp;
        }





        private MvxCommand _testCommand;

        public ICommand TestCommand
        {
            get
            {
                _testCommand = _testCommand ?? new MvxCommand(DoTestCommand);
                return _testCommand;
            }
        }

        private void DoTestCommand()
        {
            Hello = "ValueChanged";

            ((Dictionary<uint, PointModel>)FirstContactPoint).Add(12, new PointModel(){X = 100, Y = 100});

            //var temp = new LineModel(){X1 = 2, Y1 = 100, X2 = 2, Y2 = 100};
            
            //Points.Add(new LineModel() { X1 = 2, Y1 = 2, X2 = 100, Y2 = 100 });
            ////Points.Add(new LineModel() { X1 = 2, Y1 = 2, X2 = 100, Y2 = 100 });
            ////Points.Add(new LineModel() { X1 = 100, Y1 = 100, X2 = 100, Y2 = 500 });
            //Points.Add(new LineModel() { X1 = 2, Y1 = 100, X2 = 2, Y2 = 100 });

            /*Points.Add(new LineModel(2, 100, 2, 100));
            Points.Add(new LineModel(50, 20, 50, 20));
            Points.Add(new LineModel(200, 200, 200, 200));
            Points.Add(new LineModel(300, 370, 300, 370));*/
            
        }


        private MvxCommand _refeshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                _refeshCommand = _refeshCommand ?? new MvxCommand(DoRefreshCommand);
                return _refeshCommand;
            }
        }

        private void DoRefreshCommand()
        {
            Points.Clear();
        }


        #region comment FirstContactPointX, FirstContactPointY, ContactPointX, ContactPointY
        //private object _firtContactPointX;

        //public object FirstContactPointX
        //{
        //    get { return _firtContactPointX; }
        //    set
        //    {
        //        _firtContactPointX = value;
        //        RaisePropertyChanged(() => FirstContactPointX);
        //    }
        //}

        //private object _firtContactPointY;

        //public object FirstContactPointY
        //{
        //    get { return _firtContactPointY; }
        //    set
        //    {
        //        _firtContactPointY = value;
        //        RaisePropertyChanged(() => FirstContactPointY);
        //    }
        //}

        //private object _contactPointX;

        //public object ContactPointX
        //{
        //    get { return _contactPointX; }
        //    set
        //    {
        //        _contactPointX = value;
        //        RaisePropertyChanged(() => ContactPointX);
        //    }
        //}

        //private object _contactPointY;

        //public object ContactPointY
        //{
        //    get { return _contactPointY; }
        //    set
        //    {
        //        _contactPointY = value;
        //        RaisePropertyChanged(() => ContactPointY);
        //    }
        //} 
        #endregion


        #region comment for StackOverflow
        //#region TestDictionary, TestCollection
        //private Dictionary<uint, double> _testDictionary = new Dictionary<uint, double>();

        //public Dictionary<uint, double> TestDictionary
        //{
        //    get { return _testDictionary; }
        //    set
        //    {
        //        _testDictionary = value;
        //        RaisePropertyChanged(() => TestDictionary);
        //    }
        //}

        //private ObservableCollection<PointModel> _testCollection = new ObservableCollection<PointModel>();

        //public ObservableCollection<PointModel> TestCollection
        //{
        //    get { return _testCollection; }
        //    set
        //    {
        //        _testCollection = value;
        //        RaisePropertyChanged(() => TestCollection);
        //    }
        //}
        //#endregion 
        #endregion

        
        private Dictionary<uint, PointModel> _firstContactPoint = new Dictionary<uint, PointModel>();

        public Dictionary<uint, PointModel> FirstContactPoint
        {
            get { return _firstContactPoint; }
            set
            {
                _firstContactPoint = value;
                RaisePropertyChanged(() => FirstContactPoint);
            }
        }
        
        private Dictionary<uint, PointModel> _contactPoint = new Dictionary<uint, PointModel>();

        public Dictionary<uint, PointModel> ContactPoint
        {
            get { return _contactPoint; }
            set
            {
                _contactPoint = value;

                foreach (var item in (Dictionary<uint, PointModel>) _contactPoint)
                {
                    if (FirstContactPoint.ContainsKey(item.Key))
                    {
                        if (
                            Distance(FirstContactPoint[item.Key].X, FirstContactPoint[item.Key].Y, item.Value.X,
                                item.Value.Y) > 1)
                        {
                            Points.Add(new LineModel()
                            {
                                X1 = FirstContactPoint[item.Key].X,
                                Y1 = FirstContactPoint[item.Key].Y,
                                X2 = item.Value.X,
                                Y2 = item.Value.Y
                            });

                            FirstContactPoint[item.Key] = _contactPoint[item.Key];

                            #region comment

                            //Points.Add(new LineModel() { X1 = ((PointModel)FirstContactPoint).X, Y1 = ((PointModel)FirstContactPoint).Y, X2 = ((PointModel)ContactPoint).X, Y2 = ((PointModel)ContactPoint).Y });
                            //FirstContactPoint = _contactPoint; 

                            #endregion

                        }
                    }
                }

                //RaisePropertyChanged(() => ContactPoint);

                //if (Distance( ((PointModel)FirstContactPoint).X, ((PointModel)FirstContactPoint).Y, ((PointModel)ContactPoint).X, ((PointModel)ContactPoint).Y)  > 10)
                //{
                //    //RaisePropertyChanged(() => ContactPoint);
                //    Points.Add(new LineModel() { X1 = ((PointModel)FirstContactPoint).X, Y1 = ((PointModel)FirstContactPoint).Y, X2 = ((PointModel)ContactPoint).X, Y2 = ((PointModel)ContactPoint).Y });

                //    FirstContactPoint = _contactPoint;
                //}
            }
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            double d = 0;
            d = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return d;
        }



















        ////private object _firtContactPoint;
        //////private object _firtContactPoint = new Dictionary<uint, PointModel>();

        ////public object FirstContactPoint
        ////{
        ////    get { return _firtContactPoint; }
        ////    set
        ////    {
        ////        _firtContactPoint = value;
        ////        RaisePropertyChanged(() => FirstContactPoint);
        ////    }
        ////}

        ////private object _contactPoint;
        //////private object _contactPoint = new Dictionary<uint, PointModel>();

        ////public object ContactPoint
        ////{
        ////    get { return _contactPoint; }
        ////    set
        ////    {
        ////        _contactPoint = value;

        ////        //foreach (var item in (Dictionary<uint, PointModel>)_contactPoint)
        ////        //{

        ////        //}

        ////        //if (Distance( ((PointModel)FirstContactPoint).X, ((PointModel)FirstContactPoint).Y, ((PointModel)ContactPoint).X, ((PointModel)ContactPoint).Y)  > 10)
        ////        //{
        ////        //    //RaisePropertyChanged(() => ContactPoint);
        ////        //    Points.Add(new LineModel() { X1 = ((PointModel)FirstContactPoint).X, Y1 = ((PointModel)FirstContactPoint).Y, X2 = ((PointModel)ContactPoint).X, Y2 = ((PointModel)ContactPoint).Y });

        ////        //    FirstContactPoint = _contactPoint;
        ////        //}
        ////    }
        ////}

    }
}
