using DAL.Entities;
using SkincareShop.ProductWindow;
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
using System.Windows.Shapes;

namespace SkincareShop
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private User _currentUser;
        public ManagerWindow(User currentUser)
        {
            InitializeComponent();
            DisplayWelcomeMessage();
            _currentUser = currentUser;
        }

        private void DisplayWelcomeMessage()
        {
            if (_currentUser != null)
            {
                WelcomeTextBlock.Text = $"Xin chào {_currentUser.FullName}";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayWelcomeMessage();
        }

        private void ManageOrderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(_currentUser);
            orderWindow.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        //private User? _currentUser;
        //public ManagerWindow(User user)
        //{
        //    _currentUser = user;
        //    InitializeComponent();
        //}

        private void ManageUserButton_Click(object sender, RoutedEventArgs e)
        {
            UserListWindow userListWindow = new UserListWindow();
            userListWindow.ShowDialog();

        }

        private void ManageProductButton_Click(object sender, RoutedEventArgs e)
        {
            var productMenu = new ProductMenu();
            productMenu.Show();
        }


    }
}
