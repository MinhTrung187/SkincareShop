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
    /// Interaction logic for SkinTypeTestWindow.xaml
    /// </summary>
    public partial class SkinTypeTestWindow : Window
    {
        private readonly SkinTypeTestService _service;
        private List<TestQuestion> _questions;
        private int _currentQuestionIndex;
        private List<int?> _selectedSkinTypeIds; 

        public SkinTypeTestWindow()
        {
            InitializeComponent();
            _service = new SkinTypeTestService();
            _currentQuestionIndex = 0;
            _selectedSkinTypeIds = new List<int?>();

            LoadQuestions();
            DisplayCurrentQuestion();
        }

        private void LoadQuestions()
        {
            _questions = _service.GetAllQuestions();

            for (int i = 0; i < _questions.Count; i++)
            {
                _selectedSkinTypeIds.Add(null);
            }
        }
        private void DisplayCurrentQuestion()
        {
            if (_questions == null || _questions.Count == 0) return;

            var currentQuestion = _questions[_currentQuestionIndex];
            QuestionTextBlock.Text = $"Câu hỏi {_currentQuestionIndex + 1}: {currentQuestion.QuestionText}";

            AnswersStackPanel.Children.Clear();

            var questionAnswers = _service.GetAnswersForQuestion(currentQuestion.QuestionId);
            foreach (var answer in questionAnswers)
            {
                RadioButton radioButton = new RadioButton
                {
                    Content = answer.AnswerText,
                    Tag = answer.SkinTypeId, 
                    Margin = new Thickness(0, 5, 0, 5),
                    GroupName = "AnswersGroup" 
                };

                if (_selectedSkinTypeIds[_currentQuestionIndex] == answer.SkinTypeId)
                {
                    radioButton.IsChecked = true;
                }

                AnswersStackPanel.Children.Add(radioButton);
            }

            PreviousButton.IsEnabled = _currentQuestionIndex > 0;
            NextButton.Content = _currentQuestionIndex == _questions.Count - 1 ? "Hoàn thành" : "Tiếp theo";
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            SaveCurrentAnswer();
            _currentQuestionIndex--;
            DisplayCurrentQuestion();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRadioButton = AnswersStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            if (selectedRadioButton == null)
            {
                MessageBox.Show("Vui lòng chọn một câu trả lời trước khi tiếp tục.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveCurrentAnswer();

            if (_currentQuestionIndex < _questions.Count - 1)
            {
                _currentQuestionIndex++;
                DisplayCurrentQuestion();
            }
            else
            {
                var result = _service.CalculateSkinType(_selectedSkinTypeIds);
                MessageBox.Show($"Loại da của bạn là: {result}", "Kết quả bài test", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void SaveCurrentAnswer()
        {
            var selectedRadioButton = AnswersStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            if (selectedRadioButton != null)
            {
                _selectedSkinTypeIds[_currentQuestionIndex] = (int?)selectedRadioButton.Tag;
            }
        }
    }
}
