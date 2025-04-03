using DAL.Entities;
using SkincareShop.ProductWindow;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkincareShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User? _currentUser;
        public MainWindow(User user)
        {
            _currentUser = user;
            InitializeComponent();
        }

        private void OpenProductWindow_Click(object sender, RoutedEventArgs e)
        {
            var productMenu = new ProductMenu();
            productMenu.Show();
        }

        private void ManageUser_Click(object sender, RoutedEventArgs e)
        {
            RegisterUserWindow registerUserWindow = new RegisterUserWindow(isEditing: true, _currentUser);
            registerUserWindow.ShowDialog();
        }
    }
    }