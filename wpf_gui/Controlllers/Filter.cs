using wpf_gui.Models;

namespace wpf_gui.Controlllers
{
    internal class Filter
    {
        public Filter() { }

        public double CalculateBotProbability(User user)
        {
            int score = 0;

            // Проверка на деактивированность и закрытость профиля
            if (!string.IsNullOrEmpty(user.Deactivated)) score += 2; // Увеличиваем балл за деактивацию
            if (user.IsClosed) score += 1; // Увеличиваем балл за закрытость

            // Проверка на отсутствие имени и фамилии
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName)) score += 2; // Профиль без имени — повышенная вероятность бота

            // Проверка на отсутствие даты рождения
            if (string.IsNullOrEmpty(user.BDate) || user.BDate == "Не указан") score += 1; // Отсутствие даты рождения

            // Проверка на пустые поля "О себе" и другие
            if (string.IsNullOrEmpty(user.About) && string.IsNullOrEmpty(user.Activities) &&
                string.IsNullOrEmpty(user.Interests) && string.IsNullOrEmpty(user.Movies) && string.IsNullOrEmpty(user.Music) &&
                string.IsNullOrEmpty(user.Books) && string.IsNullOrEmpty(user.Games) && string.IsNullOrEmpty(user.Quotes)) score += 8; // Профиль практически пуст

            // Проверка наличия фото
            if (!user.HasPhoto) score += 3; // Нет фото — повышаем вероятность, что это бот

            // Проверка на наличие мобильного номера
            if (!user.HasMobile) score += 3; // Боты часто не имеют мобильных

            // Проверка на статус и сайт
            if (string.IsNullOrEmpty(user.Status) && string.IsNullOrEmpty(user.Site)) score += 2; // Нет информации о статусе или сайте

            // Проверка на отсутствие половых данных
            if (user.Sex == 0) score += 2; // Отсутствие информации о поле

            // Проверка на неактивность пользователя
            if (user.LastSeen.Time < (DateTime.UtcNow.AddMonths(-3).Ticks / TimeSpan.TicksPerSecond)) score += 1; // Неактивен в течение 3 месяцев

            // Проверка на странности или отсутствие данных о местоположении
            if (string.IsNullOrEmpty(user.City?.Title) || string.IsNullOrEmpty(user.Country?.Title)) score += 1; // Странные данные о городе или стране

            // Проверка на верификацию
            if (!user.Verified && !user.IsVerified) score += 1; // Не верифицированный пользователь

            // Проверка на наличие карьеры
            if (user.Career == null || !user.Career.Any(c => !string.IsNullOrEmpty(c.Company) && !string.IsNullOrEmpty(c.Position))) score += 2; // Отсутствие реальной карьеры

            // Проверка на наличие военной службы
            if (user.Militaries == null || !user.Militaries.Any()) score += 1; // Нет военной службы

            // Проверка на отсутствие школьного образования
            if (user.Schools == null || !user.Schools.Any()) score += 2; // Нет данных о школе

            // Проверка на отсутствие высшего образования
            if (user.Universities == null || !user.Universities.Any()) score += 1; // Нет данных о высшем образовании

            // Проверка на странности в личных данных
            if (user.Personal.Langs == null || !user.Personal.Langs.Any() ||
                string.IsNullOrEmpty(user.Personal.Religion) || string.IsNullOrEmpty(user.Personal.InspiredBy)) score += 2; // Пустые или странные личные данные

            // Проверка на пустые цитаты
            if (string.IsNullOrEmpty(user.Quotes)) score += 1; // Пустые цитаты

            if (user.Relation == 0) score += 1; // Отсутствие статуса отношений может быть признаком бота

            if (string.IsNullOrEmpty(user.Occupation?.Type)) score += 2; // Отсутствие информации о профессии или роде деятельности увеличивает вероятность бота

            if (user.Counters.Albums < 2) score += 1;
            if (user.Counters.Videos < 2) score += 1;
            if (user.Counters.Audios < 2) score += 1;
            if (user.Counters.Photos < 2) score += 2;
            if (user.Counters.Notes < 2) score += 1;
            if (user.Counters.Friends < 20) score += 1;
            if (user.Counters.Gifts < 2) score += 1;
            if (user.Counters.Groups < 2) score += 1;
            if (user.Counters.Followers < 20) score += 1;
            if (user.Counters.Pages < 2) score += 1;
            if (user.Counters.Subscriptions < 10) score += 1;


            // Возвращаем вероятность как процент от максимально возможного балла
            int maxScore = 50; // Максимальный балл после добавления всех условий
            return (score / (double)maxScore) * 100;
        }

    }
}
