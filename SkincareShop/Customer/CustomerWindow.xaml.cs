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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
        }

        private void SkinTest_Click(object sender, RoutedEventArgs e)
        {
            SkinTypeTestWindow testWindow = new SkinTypeTestWindow();
            testWindow.ShowDialog();

        }

        private void Skip_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
