using BLL.Services;
using DAL.Entities;
using SkincareShop.Models;
using SkincareShop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class CustomerProfile : Window, INotifyPropertyChanged
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly int _userId;

        private string _fullName;
        private string _email;
        private string _createdAt;

        public ObservableCollection<OrderHistoryItem> OrderHistory { get; set; }

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string CreatedAt
        {
            get => _createdAt;
            set
            {
                _createdAt = value;
                OnPropertyChanged();
            }
        }

        public CustomerProfile(int id)
        {
            InitializeComponent();
            _userId = id;
            _userService = new UserService();
            _orderService = new OrderService();
            OrderHistory = new ObservableCollection<OrderHistoryItem>();
            DataContext = this;
            LoadCustomerData();
            LoadOrderHistory();
        }

        private void LoadCustomerData()
        {
            var user = _userService.GetUserById(_userId);
            FullName = user.FullName;
            Email = user.Email;
            CreatedAt = user.CreatedAt?.ToString();
        }

        private void LoadOrderHistory()
        {
            var orders = _orderService.GetOrderHistory(_userId);
            OrderHistory.Clear();
            foreach (var order in orders)
            {
                OrderHistory.Add(order);
            }
        }

        private void SaveProfile_Click(object sender, RoutedEventArgs e)
        {
            // Save profile changes logic here
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
