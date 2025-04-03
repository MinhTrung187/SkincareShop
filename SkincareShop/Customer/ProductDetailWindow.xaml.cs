using SkincareShop.Services;
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

namespace SkincareShop.Customer
{
    /// <summary>
    /// Interaction logic for ProductDetailWindow.xaml
    /// </summary>
    public partial class ProductDetailWindow : Window
    {
        private readonly ProductService _productService;
        private readonly FeedbackService _feedbackService;
        private readonly int _productId;

        public ProductDetailWindow(int productId)
        {
            InitializeComponent();
            _productService = new ProductService();
            _feedbackService = new FeedbackService();
            _productId = productId;

            LoadProductDetails();
            LoadFeedbacks();
        }

        private void LoadProductDetails()
        {
            var product = _productService.GetProductById(_productId);
            if (product != null)
            {
                DataContext = product; 
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
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
            MessageBox.Show("Chức năng đặt hàng đang được phát triển!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
