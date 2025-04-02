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
    /// Interaction logic for ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : Window
    {
        private readonly ProductService _productService;
        private readonly Product? _product;
        private readonly SkinTypeService _skinTypeService;

        public ProductEdit(ProductService productService, Product? product = null)
        {
            InitializeComponent();
            _productService = productService;
            _skinTypeService = new SkinTypeService();
            _product = product;
            LoadSkinTypes();

            if (_product != null)
            {
                NameTextBox.Text = _product.Name;
                DescriptionTextBox.Text = _product.Description;
                PriceTextBox.Text = _product.Price.ToString();
                StockTextBox.Text = _product.Stock.ToString();
                SkinTypeComboBox.SelectedValue = _product.SkinTypeId;
                ImageUrlTextBox.Text = _product.ImageUrl;
            }
        }

        private void LoadSkinTypes()
        {
            var skinTypes = _skinTypeService.GetAllSkinTypes();
            SkinTypeComboBox.ItemsSource = skinTypes;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_product == null)
            {
                var newProduct = new Product
                {
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    Stock = int.Parse(StockTextBox.Text),
                    SkinTypeId = (int?)SkinTypeComboBox.SelectedValue,
                    ImageUrl = ImageUrlTextBox.Text
                };
                _productService.AddProduct(newProduct);
            }
            else
            {
                _product.Name = NameTextBox.Text;
                _product.Description = DescriptionTextBox.Text;
                _product.Price = decimal.Parse(PriceTextBox.Text);
                _product.Stock = int.Parse(StockTextBox.Text);
                _product.SkinTypeId = (int?)SkinTypeComboBox.SelectedValue;
                _product.ImageUrl = ImageUrlTextBox.Text;
                _productService.UpdateProduct(_product);
            }

            DialogResult = true;
            Close();
        }
    }
}
