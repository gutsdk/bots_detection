using System.Net.Http;
using Newtonsoft.Json;  // Для парсинга JSON
using System.Windows;
using wpf_gui.Models;
using wpf_gui.Controlllers;
using System.Text.RegularExpressions;

namespace wpf_gui.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void getUserInfoButton_Click(object sender, RoutedEventArgs e)
        {
            string userId = userIdTextBox.Text;

            userIdTextBox.IsEnabled = false;
            getUserInfoButton.IsEnabled = false;

            try
            {
                var serverVKResponse = new ServerVKResponse(new HttpClient());
                var user = new User(await serverVKResponse.GetUserInfoAsync(userId));

                if (user == null)
                {
                    throw new Exception("Нет данных");
                }
                else
                {
                    userInfoTextBlock.Text = $"Имя пользователя: {user.FirstName}\nФамилия: {user.LastName}\nГород проживания: {user.City.Title}\nДата рождения: {user.BDate}";

                    if (user.Verified || user.IsVerified)
                    {
                        userInfoTextBlock.Text += user.Verified ? "\n\nПользователь верифицирован" : "\n\nПользователь подвержден";
                    }
                    else
                    {
                        if (user.Deactivated.Length < 1)
                        {
                            // filter
                            var filter = new Filter();

                            userInfoTextBlock.Text += $"\n\nВероятность, что пользователь является ботом: {filter.CalculateBotProbability(user)}%";
                        }
                        else
                        {
                            userInfoTextBlock.Text += user.Deactivated == "deleted" ? $"\n\nПользователь удалён" : $"\n\nПользователь заблокирован";
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Ошибка запроса: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла следующая ошибка: {ex.Message}");
            }

            userIdTextBox.IsEnabled = true;
            getUserInfoButton.IsEnabled = true;
        }
        private void userIdTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void userIdTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            var clipboard = e.DataObject.GetData(DataFormats.Text) as string;

            if (clipboard != null && clipboard.Any(c => !Char.IsDigit(c)))
            {
                e.CancelCommand();
            }
        }
    }
}