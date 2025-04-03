using DAL.Entities;
using DAL;
using SkincareShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using BLL.Services;
namespace SkincareShop.Customer
{
    /// <summary>
    /// Interaction logic for ProductDetailWindow.xaml
    /// </summary>
    public partial class ProductDetailWindow : Window
    {
        private readonly OrderService _orderService;
        private readonly ProductService _productService; 
        private readonly FeedbackService _feedbackService;
        private readonly int _userId; 
        private readonly int _productId; 
        private Product _product; 

        public ProductDetailWindow(int userId, int productId)
        {
            InitializeComponent();
            _orderService = new OrderService();
            _productService = new ProductService(); 
            _feedbackService = new FeedbackService();
            _userId = userId;
            _productId = productId;
            LoadProductDetails();
            LoadFeedbacks();
        }

        private void LoadProductDetails()
        {
            _product = _productService.GetProductById(_productId);
            if (_product != null)
            {
                DataContext = _product; 
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void LoadFeedbacks()
        {
            var feedbacks = _feedbackService.GetFeedbacksByProductId(_productId);
            FeedbackListView.ItemsSource = feedbacks;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                bool success = _orderService.PlaceOrder(_userId, _productId, quantity);
                if (success)
                {
                    MessageBox.Show("Đặt hàng thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProductDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+"); 
            return !regex.IsMatch(text);
        }
    }
}
