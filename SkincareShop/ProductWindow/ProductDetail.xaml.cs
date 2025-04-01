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

namespace SkincareShop.ProductWindow
{
    /// <summary>
    /// Interaction logic for ProductDetail.xaml
    /// </summary>
    public partial class ProductDetail : Window
    {
        private readonly ProductService _productService;

        public ProductDetail(int productId)
        {
            InitializeComponent();
            _productService = new ProductService();
            LoadProductData(productId);
        }

        private void LoadProductData(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product != null)
            {
                DataContext = new ProductDetailViewModel(product);
            }
            else
            {
                MessageBox.Show("Product not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }
    }
}
