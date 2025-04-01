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
    /// Interaction logic for ProductMenu.xaml
    /// </summary>
    public partial class ProductMenu : Window
    {
        private readonly ProductService _productService;

        public ProductMenu()
        {
            InitializeComponent();
            _productService = new ProductService();
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _productService.GetAllProducts();
            ProductsDataGrid.ItemsSource = products;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchText = SearchTextBox.Text;
            var products = _productService.SearchProduct(searchText);
            ProductsDataGrid.ItemsSource = products;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var productEditWindow = new ProductEdit(_productService);
            if (productEditWindow.ShowDialog() == true)
            {
                LoadProducts();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product selectedProduct)
            {
                var productEditWindow = new ProductEdit(_productService, selectedProduct);
                if (productEditWindow.ShowDialog() == true)
                {
                    LoadProducts();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product selectedProduct)
            {
                _productService.DeleteProduct(selectedProduct.ProductId);
                LoadProducts();
            }
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product selectedProduct)
            {
                var productDetailWindow = new ProductDetail(selectedProduct.ProductId);
                productDetailWindow.Show();
            }
        }
    }
}
