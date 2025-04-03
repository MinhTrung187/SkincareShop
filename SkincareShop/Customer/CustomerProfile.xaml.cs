using BLL.Services;
using DAL.Entities;
using SkincareShop.Models;
using SkincareShop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SkincareShop.Customer
{
    /// <summary>
    /// Interaction logic for CustomerProfile.xaml
    /// </summary>
    public partial class CustomerProfile : Window
    {
        private readonly UserService _Userservice;
        private readonly int _userId;
        private readonly OrderService orderService;

        public CustomerProfile(int id)
        {
            InitializeComponent();
            _userId = id;
            _Userservice = new UserService();
            orderService = new OrderService();

        }
        private void LoadCustomerData()
        {
            var user = _Userservice.GetUserById(_userId);
            txtFullName.Text = user.FullName;
            txtEmail.Text = user.Email;
            txtCreatedAt.Text=user.CreatedAt.ToString();

            //DataContext = user;
        }
        private void LoadOrderHistory()
        {
            List<Order>orders =orderService.GetOrderByUserId(_userId);
            DataContext = orders;
        }

        private void SaveProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomerData();
            LoadOrderHistory();

        }
    }
}
