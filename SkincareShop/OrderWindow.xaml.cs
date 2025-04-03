using BLL.Services;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window, INotifyPropertyChanged
    {
        private readonly OrderService _orderService;
        private Order _selectedOrder;
        private User _currentUser;

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public OrderWindow(User currentUser)
        {
            InitializeComponent();
            _orderService = new OrderService();
            _currentUser = currentUser;
        }

        private void OrdersDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedOrder = OrdersDataGrid.SelectedItem as Order;
            if (SelectedOrder != null)
            {
                Console.WriteLine($"Selected Order ID: {SelectedOrder.OrderId}");
                Console.WriteLine($"Number of Order Details: {SelectedOrder.OrderDetails.Count}");
                OrderDetailsDataGrid.ItemsSource = SelectedOrder.OrderDetails;
            }
            else
            {
                OrderDetailsDataGrid.ItemsSource = null; // Xóa dữ liệu nếu không có Order được chọn
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrdersDataGrid.ItemsSource = _orderService.GetAllOrdersWithDetails();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow(_currentUser);
            managerWindow.Show();
            this.Close();
            
        }
    }

}

