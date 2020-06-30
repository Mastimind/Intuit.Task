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
using INTU.Search.Model;
using INTU.Search.ViewModel;

namespace INTU.Search.Components
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlDashboard : UserControl
    {
       // private List<TweetsResult> _tweetsResult;
       // private List<ImagesResult> _imagesResult;
       private ImageResultViewModel _viewModel;
        public UserControlDashboard()
        {
            _viewModel= new ImageResultViewModel();
            DataContext = _viewModel;
            InitializeComponent();
         /*   _tweetsResult.Add(new TweetsResult(){Tweet = "Nature",Uri = "localhost",User="Me"});
            _tweetsResult.Add(new TweetsResult(){Tweet = "Nature",Uri = "localhost",User="Me"});
            _tweetsResult.Add(new TweetsResult(){Tweet = "Nature",Uri = "localhost",User="Me"});
            _tweetsResult.Add(new TweetsResult(){Tweet = "Nature",Uri = "localhost",User="Me"});
            _tweetsResult.Add(new TweetsResult(){Tweet = "Nature",Uri = "localhost",User="Me"});

            _imagesResult.Add(new ImagesResult("localhost/nature.jpg"));
            _imagesResult.Add(new ImagesResult("localhost/nature.jpg"));*/
        }

        private  void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
                _viewModel.SearchImage(TextBoxSearch.Text,5);
        }
    }
}