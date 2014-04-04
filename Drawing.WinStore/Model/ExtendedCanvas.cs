using System.Windows.Input;
#if NETFX_CORE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Drawing.Core.ViewModels;
using System.Collections.ObjectModel;
#elif WINDOWS_PHONE
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Windows.Devices.Input;
using Drawing.Core.ViewModels;
using Windows.UI.Input;
using Microsoft.Xna.Framework.Input;
#endif

#if NETFX_CORE
namespace Drawing.WinStore.Model
#elif WINDOWS_PHONE
namespace Drawing.WinPhone.Model
#endif
{
#if NETFX_CORE
    public class ExtendedCanvas : Canvas
#elif WINDOWS_PHONE
    public class ExtendedCanvas : Canvas
#endif
    {
        #region comment
        //public static readonly DependencyProperty FirstContactProperty =
        //    DependencyProperty.Register("FirstContact", typeof(object), typeof(ExtendedCanvas), new PropertyMetadata(default(object)));

        //public static readonly DependencyProperty ContactProperty =
        //    DependencyProperty.Register("Contact", typeof(object), typeof(ExtendedCanvas), new PropertyMetadata(default(object)));

        //    public static readonly DependencyProperty FirstContactProperty =
        //        DependencyProperty.Register("FirstContact", typeof(object), typeof(ExtendedCanvas), new PropertyMetadata(new Dictionary<uint, PointModel>()));

        //    public static readonly DependencyProperty ContactProperty =
        //DependencyProperty.Register("Contact", typeof(object), typeof(ExtendedCanvas), new PropertyMetadata(new Dictionary<uint, PointModel>()));

        //    public static readonly DependencyProperty FirstContactProperty =
        //DependencyProperty.Register("FirstContact", typeof(Dictionary<uint, PointModel>), typeof(ExtendedCanvas), new PropertyMetadata(new Dictionary<uint, PointModel>()));

        //    public static readonly DependencyProperty ContactProperty =
        //        DependencyProperty.Register("Contact", typeof(Dictionary<uint, PointModel>), typeof(ExtendedCanvas), new PropertyMetadata(new Dictionary<uint, PointModel>())); 
        #endregion

        public static readonly DependencyProperty FirstContactProperty =
            DependencyProperty.Register("FirstContact", typeof(Dictionary<uint, PointModel>), typeof(ExtendedCanvas), null);

        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Dictionary<uint, PointModel>), typeof(ExtendedCanvas), null);

        #region comment
        //#region TestBinding
        //public static readonly DependencyProperty TestDictionaryProperty =
        //    DependencyProperty.Register("TestDictionary", typeof(Dictionary<uint, double>), typeof(ExtendedCanvas), null);

        //public static readonly DependencyProperty TestCollectionProperty =
        //    DependencyProperty.Register("TestCollection", typeof(ObservableCollection<PointModel>), typeof(ExtendedCanvas), null);
        //#endregion 
        #endregion

        #region comment
        //public object FirstContact
        //{
        //    get { return (object)GetValue(FirstContactProperty); }
        //    set { SetValue(FirstContactProperty, value); }
        //}

        //public object Contact
        //{
        //    get { return (object)GetValue(ContactProperty); }
        //    set { SetValue(ContactProperty, value); }
        //} 
        #endregion

        #region comment
        //#region TestBinding
        //public Dictionary<uint, double> TestDictionary
        //{
        //    get { return (Dictionary<uint, double>)GetValue(TestDictionaryProperty); }
        //    set
        //    {
        //        SetValue(TestDictionaryProperty, value);
        //    }
        //}

        //public ObservableCollection<PointModel> TestCollection
        //{
        //    get { return (ObservableCollection<PointModel>)GetValue(TestCollectionProperty); }
        //    set
        //    {
        //        SetValue(TestCollectionProperty, value);
        //    }
        //}
        //#endregion 
        #endregion

        public Dictionary<uint, PointModel> FirstContact
        {
            get { return (Dictionary<uint, PointModel>)GetValue(FirstContactProperty); }
            set { SetValue(FirstContactProperty, value); }
        }

        public Dictionary<uint, PointModel> Contact
        {
            get { return (Dictionary<uint, PointModel>)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        #region comment
        //private bool _isPointerHandled = false;

        //private Dictionary<uint, PointModel> _firstContact = new Dictionary<uint, PointModel>();
        //private Dictionary<uint, PointModel> _contact = new Dictionary<uint, PointModel>(); 
        #endregion

        private Dictionary<uint, PointModel> _firstContactTemp = new Dictionary<uint, PointModel>();
        private Dictionary<uint, PointModel> _contactTemp = new Dictionary<uint, PointModel>();

        public ExtendedCanvas() : base ()
        {
            #region comment
            //FirstContact = new Dictionary<uint, PointModel>();
            //Contact = new Dictionary<uint, PointModel>(); 
            #endregion

              
#if NETFX_CORE
            PointerPressed += ExtendedCanvas_PointerPressed;
            PointerMoved += ExtendedCanvas_PointerMoved;
            PointerReleased += ExtendedCanvas_PointerReleased;
#elif WINDOWS_PHONE
            //MouseLeftButtonDown += ExtendedCanvas_MouseLeftButtonDown;
            Touch.FrameReported += Touch_FrameReported;

            //ManipulationStarted +=ExtendedCanvas_ManipulationStarted;
            //ManipulationCompleted +=ExtendedCanvas_ManipulationCompleted;
            //ManipulationDelta +=ExtendedCanvas_ManipulationDelta;
#endif

        }

#if WINDOWS_PHONE
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            int pointsNumber = e.GetTouchPoints((ExtendedCanvas)sender).Count;
            //TouchPointCollection pointCollection = e.GetTouchPoints((ExtendedCanvas)sender);
            TouchPointCollection pointCollection = e.GetTouchPoints(this);

            for (int i = 0; i < pointsNumber; i++)
            {
                if (pointCollection[i].Action == TouchAction.Down)
                {

                    uint _pointerId = 0;
                    double _firstPointerPressedX = 0;
                    double _firstPointerPressedY = 0;

                    _firstPointerPressedX = pointCollection[i].Position.X;
                    _firstPointerPressedY = pointCollection[i].Position.Y;
                    _pointerId = (uint)pointCollection[i].TouchDevice.Id;

                    var firstPointerPressed = new PointModel() { X = _firstPointerPressedX, Y = _firstPointerPressedY };

                    _firstContactTemp = new Dictionary<uint, PointModel>(FirstContact);
                    _firstContactTemp[_pointerId] = firstPointerPressed;
                    FirstContact = _firstContactTemp;
                }
                if (pointCollection[i].Action == TouchAction.Move)
                {
                    uint _pointerId = 0;
                    double _currentPointerPressedX = 0;
                    double _currentPointerPressedY = 0;

                    _currentPointerPressedX = pointCollection[i].Position.X;
                    _currentPointerPressedY = pointCollection[i].Position.Y;
                    _pointerId = (uint)pointCollection[i].TouchDevice.Id;

                    if (((Dictionary<uint, PointModel>) FirstContact).ContainsKey(_pointerId))
                    {
                        _contactTemp = new Dictionary<uint, PointModel>(Contact);
                        _contactTemp[_pointerId] = new PointModel()
                        {
                            X = _currentPointerPressedX,
                            Y = _currentPointerPressedY
                        };
                        Contact = _contactTemp;

                    }






                    //Line line = new Line();

                    //line.X1 = preXArray[i];
                    //line.Y1 = preYArray[i];
                    //line.X2 = pointCollection[i].Position.X;
                    //line.Y2 = pointCollection[i].Position.Y;

                    //line.Stroke = new SolidColorBrush(Colors.Black);
                    //line.Fill = new SolidColorBrush(Colors.Black);
                    //drawCanvas.Children.Add(line);

                    //preXArray[i] = pointCollection[i].Position.X;
                    //preYArray[i] = pointCollection[i].Position.Y;
                }

                if (pointCollection[i].Action == TouchAction.Up)
                {
                    uint _pointerId = 0;
                    _pointerId = (uint)pointCollection[i].TouchDevice.Id;

                    ((Dictionary<uint, PointModel>)FirstContact).Remove(_pointerId);
                    ((Dictionary<uint, PointModel>)Contact).Remove(_pointerId);
                }
            }
        }
#endif

        //void ExtendedCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    var temp = e.StylusDevice.DeviceType.ToString();
        //}



#if NETFX_CORE
        void ExtendedCanvas_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
#elif WINDOWS_PHONE
        void ExtendedCanvas_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
#endif
        {
            //_isPointerHandled = false;

            uint _pointerId = 0;

#if NETFX_CORE
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint((ExtendedCanvas)sender);
            _pointerId = pt.PointerId;
#elif WINDOWS_PHONE
            
#endif
            ((Dictionary<uint, PointModel>)FirstContact).Remove(_pointerId);
            ((Dictionary<uint, PointModel>)Contact).Remove(_pointerId);

            //((Dictionary<uint, PointModel>)FirstContact).Remove(pt.PointerId);
            //((Dictionary<uint, PointModel>)Contact).Remove(pt.PointerId);

            e.Handled = true;
        }

#if NETFX_CORE
        void ExtendedCanvas_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
#elif WINDOWS_PHONE
        void ExtendedCanvas_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
#endif
        {



            uint _pointerId = 0;
            double _currentPointerPressedX = 0;
            double _currentPointerPressedY = 0;
            
#if NETFX_CORE
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint((ExtendedCanvas)sender);
            _currentPointerPressedX = pt.Position.X;
            _currentPointerPressedY = pt.Position.Y;
            _pointerId = pt.PointerId;
#elif WINDOWS_PHONE

            if (!(e.ManipulationOrigin.X < 0) && !(e.ManipulationOrigin.X > e.ManipulationContainer.RenderSize.Width))
            {
                _currentPointerPressedX = e.ManipulationOrigin.X;
            }
            else
            {
                _currentPointerPressedX = e.ManipulationOrigin.X < 0 ? 0 : e.ManipulationContainer.RenderSize.Width;
            }

            if (!(e.ManipulationOrigin.Y < 0) && !(e.ManipulationOrigin.Y > e.ManipulationContainer.RenderSize.Height))
            {
                _currentPointerPressedY = e.ManipulationOrigin.Y;
            }
            else
            {
                _currentPointerPressedY = e.ManipulationOrigin.Y < 0 ? 0 : e.ManipulationContainer.RenderSize.Height;
            }
            
            //_currentPointerPressedX = e.ManipulationOrigin.X;
            //_currentPointerPressedY = e.ManipulationOrigin.Y;
            
#endif
            ////Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint((ExtendedCanvas)sender);
            
            //if (_isPointerHandled)
            ////if (((Dictionary<uint, PointModel>)FirstContact).ContainsKey(pt.PointerId))
            if (((Dictionary<uint, PointModel>)FirstContact).ContainsKey(_pointerId))
            {
                #region comment
                //Dictionary<uint, PointModel> Temp = new Dictionary<uint, PointModel>();
                //Temp = (Dictionary<uint, PointModel>)Contact;
                //Temp.Add(pt.PointerId) = new PointModel() { X = pt.Position.X, Y = pt.Position.Y };
                //Contact = Temp;

                //Contact = new Dictionary<uint, PointModel>() { Keys = pt.PointerId, Values = };


                //((Dictionary<uint, PointModel>)Contact).Add(pt.PointerId, new PointModel() { X = pt.Position.X, Y = pt.Position.Y });
                //((Dictionary<uint, PointModel>)Contact)[pt.PointerId] = new PointModel() { X = pt.Position.X, Y = pt.Position.Y };

                //Contact = new PointModel() {X = pt.Position.X, Y = pt.Position.Y}; 
                #endregion

                _contactTemp = new Dictionary<uint, PointModel>(Contact);
                _contactTemp[_pointerId] = new PointModel() { X = _currentPointerPressedX, Y = _currentPointerPressedY };
                //_contactTemp[pt.PointerId] = new PointModel() { X = pt.Position.X, Y = pt.Position.Y };
                Contact = _contactTemp;

            }
            
        }

#if NETFX_CORE
        void ExtendedCanvas_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
#elif WINDOWS_PHONE
        //void ExtendedCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        void ExtendedCanvas_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
#endif
        {
            #region comment
            //TestDictionary.Add(1212, 4344.434);

            //TestCollection = new ObservableCollection<PointModel>(){new PointModel(){X=12,Y=21}};

            //TestCollection.Add(new PointModel() { X = 12, Y = 21 });

            //TestDictionary = new Dictionary<uint, double>() { { 1212, 232.32 } }; 
            #endregion

            uint _pointerId = 0;
            double _firstPointerPressedX = 0;
            double _firstPointerPressedY = 0;
            
#if NETFX_CORE
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint((ExtendedCanvas)sender);
            _firstPointerPressedX = pt.Position.X;
            _firstPointerPressedY = pt.Position.Y;
            _pointerId = pt.PointerId;
#elif WINDOWS_PHONE
            //var pt = e.GetPosition((ExtendedCanvas)sender);
            //var pt = e.ManipulationContainer.;
            _firstPointerPressedX = e.ManipulationOrigin.X;
            _firstPointerPressedY = e.ManipulationOrigin.Y;

            //_firstPointerPressedX = pt.X;
            //_firstPointerPressedY = pt.Y;
            //_pointerId = pt.PointerId;
#endif

            var firstPointerPressed = new PointModel() { X = _firstPointerPressedX, Y = _firstPointerPressedY };

            
#if NETFX_CORE
            // Accept input only from a pen or mouse with the left button pressed. 
            PointerDeviceType pointerDevType = e.Pointer.PointerDeviceType;
            if (pointerDevType == PointerDeviceType.Pen ||
                    pointerDevType == PointerDeviceType.Mouse &&
                    pt.Properties.IsLeftButtonPressed
                || pointerDevType == PointerDeviceType.Touch)
#endif
            {
           
                #region comment
                //_isPointerHandled = true;

                //_firstContact.Add(pt.PointerId, firstPointerPressed);
                //((Dictionary<uint, PointModel>)FirstContact).Add(pt.PointerId, firstPointerPressed);

                //((Dictionary<uint, PointModel>)FirstContact)[pt.PointerId] = firstPointerPressed;

                //Dictionary<uint, PointModel> Temp = new Dictionary<uint, PointModel>();
                //Temp[pt.PointerId] = firstPointerPressed; 
                #endregion

                _firstContactTemp = new Dictionary<uint, PointModel>(FirstContact); // (Dictionary<uint, PointModel>)FirstContact;
                //_firstContactTemp[pt.PointerId] = firstPointerPressed;
                _firstContactTemp[_pointerId] = firstPointerPressed;
                FirstContact = _firstContactTemp;
                
                e.Handled = true;
            }
        }
    }
}
