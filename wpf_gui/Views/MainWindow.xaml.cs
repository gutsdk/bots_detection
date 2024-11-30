using System.Net.Http;
using Newtonsoft.Json;  // Для парсинга JSON
using System.Windows;

namespace wpf_gui.Views
{
    public partial class MainWindow : Window
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void GetUserInfoButton_Click(object sender, RoutedEventArgs e)
        {
            string userId = userIdTextBox.Text;

            try
            {
                HttpResponseMessage responseMessage = await _httpClient.GetAsync($"http://localhost:5000/get_user_info?user_id={userId}");

                responseMessage.EnsureSuccessStatusCode();

                string responseBody = await responseMessage.Content.ReadAsStringAsync();

                var userData = JsonConvert.DeserializeObject<dynamic>(responseBody);

                if (userData.error != null)
                {
                    userInfoTextBlock.Text = $"Error: {userData.error}";
                }
                else
                {
                    //  Здесь требуется передать данные о пользователе в объект класса Filter, который уже в свою очередь вернет результат: Бот или не бот

                    // Выводим информацию о пользователе
                    //userInfoTextBlock.Text = $"Name: {userData.response[0].first_name} {userData.response[0].last_name}\n" +
                    //                         $"City: {userData.response[0].city.title}\n" +
                    //                         $"Followers: {userData.response[0].followers_count}";
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}");
            }
        }
    }
}