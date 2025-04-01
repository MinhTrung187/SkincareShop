using BLL.Services;
using DAL.Entities;
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
    /// Interaction logic for UserListWindow.xaml
    /// </summary>
    public partial class UserListWindow : Window
    {
        private readonly UserService _userService;
        public List<User> Users { get; set; }

        public UserListWindow()
        {
            InitializeComponent();
            _userService = new UserService();
            LoadUsers();
        }

        private void LoadUsers()
        {
            Users = _userService.GetAllUsers();
            UserDataGrid.ItemsSource = Users;
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is User selectedUser)
            {
                RegisterUserWindow registerUserWindow = new RegisterUserWindow(isEditing: true, user: selectedUser);
                registerUserWindow.ShowDialog();
                LoadUsers();
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is User selectedUser)
            {
                MessageBoxResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa user {selectedUser.FullName}?",
                                                          "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    bool isDeleted = _userService.DeleteUser(selectedUser.UserId);
                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa user thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa user!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
