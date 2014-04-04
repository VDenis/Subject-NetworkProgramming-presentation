using Cirrious.MvvmCross.WindowsStore.Views;
using Drawing.Core.ViewModels;

namespace Drawing.WinStore.Views
{
    public sealed partial class FirstView : MvxStorePage
    {

        #region comment
        //public new FirstViewModel ViewModel
        //{
        //    get { return (FirstViewModel)base.ViewModel; }
        //    set { base.ViewModel = value; }
        //} 
        #endregion

        public FirstView()
        {
            this.InitializeComponent();
        }

        #region comment
        //private void UpdateItemSourseButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        //    PointsItemsControl.ItemsSource = ViewModel.Points;
        //}

        /*private void MyCanvas_OnPointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(MyCanvas);
            
        }*/
        
        #endregion
    }
}
