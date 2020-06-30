using System.Windows;
using System.Windows.Controls;
using INTU.Search.ViewModel;

namespace INTU.Search.Components
{
    public partial class UserControlImageResult : UserControl
    {
        private ImageResultViewModel _viewModel;

        public UserControlImageResult()
        {
            _viewModel= new ImageResultViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            TextBlockLoading.Visibility = Visibility.Visible;
            _viewModel.SearchImage(TextBoxSearch.Text);
            TextBlockLoading.Visibility = Visibility.Collapsed;
        }
    }
}