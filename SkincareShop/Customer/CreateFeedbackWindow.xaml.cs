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
    /// Interaction logic for CreateFeedbackWindow.xaml
    /// </summary>
    public partial class CreateFeedbackWindow : Window
    {
        private readonly FeedbackService _feedbackService;
        private readonly int _userId;
        private readonly int _productId;

        public CreateFeedbackWindow(int userId, int productId)
        {
            InitializeComponent();
            _feedbackService = new FeedbackService();
            _userId = userId;
            _productId = productId;
        }

        private void SubmitFeedback_Click(object sender, RoutedEventArgs e)
        {
            if (cbRating.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn số sao!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int rating = int.Parse((cbRating.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "0");
            string comment = txtComment.Text.Trim();

            _feedbackService.AddFeedback(_userId, _productId, rating, comment);
            MessageBox.Show("Gửi đánh giá thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
