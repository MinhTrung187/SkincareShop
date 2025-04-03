using BLL.Services;
using DAL.Entities;
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
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        private readonly ProductService _service;
        private readonly int _userId;

        public ProductListWindow(int userId)
        {
            InitializeComponent();
            _service = new ProductService();
            _userId = userId;
            LoadProducts();
        }

        // Tải danh sách sản phẩm từ dịch vụ
        private void LoadProducts(int? skinTypeId = null)
        {
            var products = skinTypeId == null || skinTypeId == 0
                ? _service.GetAllProducts()
                : _service.GetProductsBySkinType(skinTypeId.Value);
            ProductListView.ItemsSource = products;
        }

        private void SkinTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SkinTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                int skinTypeId = int.Parse(selectedItem.Tag.ToString());
                LoadProducts(skinTypeId);
            }
        }
        private void ProductListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProductListView.SelectedItem is Product selectedProduct)
            {
                ProductDetailWindow detailWindow = new ProductDetailWindow(_userId,selectedProduct.ProductId);
                detailWindow.ShowDialog();
            }
        }
    }
}
