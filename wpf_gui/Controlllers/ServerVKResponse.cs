using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using wpf_gui.Models;

namespace wpf_gui.Controlllers
{
    internal class ServerVKResponse
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public ServerVKResponse(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<dynamic> GetUserInfoAsync(string userId)
        {
            try
            {
                // Выполняем запрос
                HttpResponseMessage responseMessage = await _httpClient.GetAsync($"http://localhost:5000/get_user_info?user_id={userId}");

                // Проверка успешности ответа
                responseMessage.EnsureSuccessStatusCode();

                // Чтение тела ответа
                string responseBody = await responseMessage.Content.ReadAsStringAsync();

                // Десериализация полученных данных в объект User
                var userData = JsonConvert.DeserializeObject<dynamic>(responseBody);

                return userData.response[0];
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                Console.WriteLine($"Ошибка при получении данных о пользователе: {ex.Message}");
                return null;
            }
        }
    }
}
