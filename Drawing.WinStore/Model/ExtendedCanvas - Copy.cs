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

namespace Drawing.WinStore.Model
{
    public class ExtendedCanvas : Canvas
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

            PointerPressed += ExtendedCanvas_PointerPressed;
            PointerMoved += ExtendedCanvas_PointerMoved;
            PointerReleased += ExtendedCanvas_PointerReleased;
        }

        void ExtendedCanvas_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            //_isPointerHandled = false;

            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint((ExtendedCanvas)sender);

            ((Dictionary<uint, PointModel>)FirstContact).Remove(pt.PointerId);
            ((Dictionary<uint, PointModel>)Contact).Remove(pt.PointerId);

            e.Handled = true;
        }

        void ExtendedCanvas_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint((ExtendedCanvas)sender);
            
            //if (_isPointerHandled)
            if (((Dictionary<uint, PointModel>)FirstContact).ContainsKey(pt.PointerId))
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
                _contactTemp[pt.PointerId] = new PointModel() { X = pt.Position.X, Y = pt.Position.Y };
                Contact = _contactTemp;

            }
            
        }

        void ExtendedCanvas_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            #region comment
            //TestDictionary.Add(1212, 4344.434);

            //TestCollection = new ObservableCollection<PointModel>(){new PointModel(){X=12,Y=21}};

            //TestCollection.Add(new PointModel() { X = 12, Y = 21 });

            //TestDictionary = new Dictionary<uint, double>() { { 1212, 232.32 } }; 
            #endregion
            
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint((ExtendedCanvas)sender);

            var firstPointerPressed = new PointModel() { X = pt.Position.X, Y = pt.Position.Y };
            
            // Accept input only from a pen or mouse with the left button pressed. 
            PointerDeviceType pointerDevType = e.Pointer.PointerDeviceType;
            if (pointerDevType == PointerDeviceType.Pen ||
                    pointerDevType == PointerDeviceType.Mouse &&
                    pt.Properties.IsLeftButtonPressed
                || pointerDevType == PointerDeviceType.Touch)
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
                _firstContactTemp[pt.PointerId] = firstPointerPressed;
                FirstContact = _firstContactTemp;
                
                e.Handled = true;
            }
        }
    }
}
