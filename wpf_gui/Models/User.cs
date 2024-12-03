namespace wpf_gui.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BDate { get; set; }
        public City City { get; set; }
        public List<Career> Career { get; set; }

        // Конструктор, принимающий dynamic
        public User(dynamic userData)
        {
            FirstName = userData.first_name;
            LastName = userData.last_name;
            BDate = userData.bdate;

            // Инициализация города
            if (userData.city != null)
            {
                City = new City
                {
                    Id = userData.city.id,
                    Title = userData.city.title
                };
            }

            // Инициализация списка карьеры
            if (userData.career != null)
            {
                Career = new List<Career>();
                foreach (var career in userData.career)
                {
                    Career.Add(new Career
                    {
                        CityId = career.city_id,
                        Company = career.company,
                        Position = career.position,
                        From = career.from,
                        Until = career.until
                    });
                }
            }
        }
    }

    public class City
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class Career
    {
        public int? CityId { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public int? From { get; set; }
        public int? Until { get; set; }
    }

}
