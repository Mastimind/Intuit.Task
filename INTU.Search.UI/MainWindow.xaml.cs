using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using INTU.Search.Components;
namespace INTU.Search.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, int> _transitionCmd;
        public MainWindow()
        {
            InitializeComponent();
            _transitionCmd= new Dictionary<string, int>();
            _transitionCmd.Add("Dashboard",0);
            _transitionCmd.Add("ImageResult",1);
            _transitionCmd.Add("AboutMe",2);
            _transitionCmd.Add("TwitterResult",3);

        }

        private void ButtonPopupLogout_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonMenuClose_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonMenuClose.Visibility = Visibility.Collapsed;
            ButtonMenuOpen.Visibility = Visibility.Visible;
        }

        private void ButtonMenuOpen_OnClick(object sender, RoutedEventArgs e)
        {

            ButtonMenuClose.Visibility = Visibility.Visible;
            ButtonMenuOpen.Visibility = Visibility.Collapsed;
        }

        private void Windows_MouseDown(object sender,MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void ButtonNav_Click(object sender, RoutedEventArgs e)
        {
            var screenName = ((Button) sender).Name;
            ((MaterialDesignThemes.Wpf.Transitions.Transitioner) GridMainContent.Children[0])
                .SelectedIndex = _transitionCmd[screenName];
        }

        private void AboutMe_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonNav_Click(sender, e);
        }

        private void ImageResult_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonNav_Click(sender, e);
        }

        private void TwitterResult_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonNav_Click(sender, e);
        }
    }
}
