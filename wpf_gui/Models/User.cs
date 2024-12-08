using Newtonsoft.Json.Linq;

namespace wpf_gui.Models
{
    internal class User
    {
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal string BDate { get; set; }
        internal string Deactivated {  get; set; }
        internal bool IsClosed { get; set; }
        internal string About { get; set; }
        internal string Activities { get; set; }
        internal string Books { get; set; }
        internal string Games { get; set; }
        internal bool HasMobile { get; set; }
        internal bool HasPhoto { get; set; }
        internal string Interests { get; set; }
        internal string Movies { get; set; }
        internal string Music { get; set; }
        internal string Quotes { get; set; }
        internal int Relation {  get; set; }
        internal int Sex { get; set; }
        internal string Site { get; set; }
        internal string Status { get; set; }
        internal bool Verified { get; set; } // Верифицированная страница
        internal bool IsVerified { get; set; } // Подвержденная страница
        internal City City { get; set; }
        internal LastSeen LastSeen { get; set; }
        internal Counters Counters { get; set; }
        internal Country Country { get; set; }
        internal Occupation Occupation { get; set; }
        internal Personal Personal { get; set; }
        internal List<Career> Career { get; set; }
        internal List<Military> Militaries { get; set; }
        internal List<School> Schools { get; set; }
        internal List<University> Universities { get; set; }

        // Конструктор, принимающий dynamic
        public User(dynamic userData)
        {
            FirstName = userData.first_name;
            LastName = userData.last_name;
            BDate = userData.bdate ?? "Не указан";
            Deactivated = userData.deactivated ?? "";
            IsClosed = userData.isClosed ?? false;
            About = userData.about ?? "";
            Activities = userData.activities ?? "";
            Books = userData.books ?? "";
            Games = userData.games ?? "";
            HasMobile = userData.has_mobile ?? false;
            HasPhoto = userData.has_photo ?? false;
            Interests = userData.interests ?? "";
            Movies = userData.movies ?? "";
            Music = userData.music ?? "";
            Quotes = userData.quotes ?? "";
            Relation = userData.relation ?? 0;
            Sex = userData.sex ?? 0;
            Site = userData.site ?? "";
            Status = userData.status ?? ""; 
            Verified = userData.verified ?? false;
            IsVerified = userData.is_verified ?? false;

            // Инициализация города
            City = userData.city != null ? new City((int)(userData.city.id ?? 0), (string)(userData.city.title ?? string.Empty)) : new City();

            // Инициализация списка карьеры
            Career = new List<Career>();
            if (userData.career != null)
            {
                foreach (var career in userData.career)
                {
                    Career.Add(new Career((int)(career.city_id ?? 0), (string)(career.company ?? string.Empty), (string)(career.position ?? string.Empty), (int)(career.from ?? 0), (int)(career.until ?? 0)));
                }
            }
            else
            {
                Career.Add(new Career());
            }

            // Инициализация счётчиков
            Counters = userData.counters != null ? new Counters((int)(userData.counters.albums ?? 0), (int)(userData.counters.videos ?? 0), (int)(userData.counters.audios ?? 0),
                (int)(userData.counters.photos ?? 0), (int)(userData.counters.notes ?? 0), (int)(userData.counters.friends ?? 0), (int)(userData.counters.gifts ?? 0), (int)(userData.counters.groups ?? 0),
                (int)(userData.counters.followers ?? 0), (int)(userData.counters.pages ?? 0), (int)(userData.counters.subscriptions ?? 0)) : new Counters();

            // Инициализация страны
            Country = userData.country != null ? new Country((int)(userData.country.id ?? 0), (string)(userData.country.title ?? string.Empty)) : new Country();

            // Последнее время онлайн
            LastSeen = userData.last_seen != null ? new LastSeen((int)(userData.last_seen.time ?? 0), (int)(userData.last_seen.platform ?? 0)) : new LastSeen();

            // Инициализация службы
            Militaries = new List<Military>();
            if (userData.military != null)
            {
                foreach (var military in userData.military)
                {
                    Militaries.Add(new Military((string)(military.unit ?? string.Empty), (int)(military.unit_id ?? 0), (int)(military.from ?? 0), (int)(military.until ?? 0)));
                }
            }
            else
            {
                Militaries.Add(new Military());
            }

            // Род занятия
            Occupation = userData.occupation != null ? new Occupation((string)(userData.occupation.type ?? string.Empty), (int)(userData.occupation.id ?? 0), 
                (string)(userData.occupation.name ?? string.Empty)) : new Occupation();

            // Персоналий
            Personal = userData.personal != null ? new Personal((int)(userData.personal.political ?? 0), (string)(userData.personal.religion ?? string.Empty), 
                (string)(userData.personal.inspired_by ?? string.Empty), (int)(userData.personal.people_main ?? 0), (int)(userData.personal.life_main ?? 0),
                (int)(userData.personal.smoking ?? 0), (int)(userData.personal.alcohol ?? 0), ((JArray)userData.personal.langs).ToObject<List<string>>() ?? new List<string>()) : new Personal();

            // Инициализация шкьол
            Schools = new List<School>();
            if (userData.schools != null)
            {
                foreach (var school in userData.schools)
                {
                    Schools.Add(new School((int)(school.id ?? 0), (int)(school.city ?? 0), (string)(school.name ?? string.Empty), (int)(school.year_from ?? 0), 
                        (int)(school.year_to ?? 0), (int)(school.year_graduated ?? 0), (string)(school.speciality ?? string.Empty), (int)(school.type ?? 0), 
                        (string)(school.type_str ?? string.Empty)));
                }
            }
            else
            {
                Schools.Add(new School());
            }

            // Инициализация списка карьеры
            Universities = new List<University>();
            if (userData.universities != null)
            {
                foreach (var university in userData.universities)
                {
                    Universities.Add(new University((int)(university.id ?? 0), (int)(university.city ?? 0), (string)(university.name ?? string.Empty), (int)(university.faculty ?? 0),
                        (string)(university.faculty_name ?? string.Empty), (int)(university.chair ?? 0), (string)(university.chair_name ?? string.Empty), (int)(university.graduation ?? 0), 
                        (string)(university.education_form ?? string.Empty), (string)(university.education_status ?? string.Empty)));
                }
            }
            else
            {
                Universities.Add(new University());
            }
        }
    }
}
