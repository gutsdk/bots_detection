namespace wpf_gui.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BDate { get; set; }
        public string Deactivated {  get; set; }
        public bool IsClosed { get; set; }
        public string About { get; set; }
        public string Activities { get; set; }
        public string Books { get; set; }
        public string Games { get; set; }
        public bool HasMobile { get; set; }
        public bool HasPhoto { get; set; }
        public string Interests { get; set; }
        public string Movies { get; set; }
        public string Music { get; set; }
        public string Quotes { get; set; }
        public int Relation {  get; set; }
        public int Sex { get; set; }
        public string Site { get; set; }
        public string Status { get; set; }
        public bool Verified { get; set; } // Верифицированная страница
        public bool IsVerified { get; set; } // Подвержденная страница
        public City City { get; set; }
        public LastSeen LastSeen { get; set; }
        public Counters Counters { get; set; }
        public Country Country { get; set; }
        public Occupation Occupation { get; set; }
        public Personal Personal { get; set; }
        public List<Career> Career { get; set; }
        public List<Military> Militaries { get; set; }
        public List<School> Schools { get; set; }
        public List<University> Universities { get; set; }

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
            City = userData.city != null ? new City
            {
                Id = userData.city.id,
                Title = userData.city.title
            } : new City
            {
                Id = 0,
                Title = ""
            };

            // Инициализация списка карьеры
            Career = new List<Career>();
            if (userData.career != null)
            {
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
            else
            {
                Career.Add(new Career
                {
                    CityId = 0,
                    Company = "",
                    Position = "",
                    From = 0,
                    Until = 0
                });
            }

            // Инициализация счётчиков
            Counters = userData.counters != null ? new Counters
            {
                Albums = userData.counters.albums ?? 0,
                Videos = userData.counters.videos ?? 0,
                Audios = userData.counters.audios ?? 0,
                Photos = userData.counters.photos ?? 0,
                Notes = userData.counters.notes ?? 0,
                Friends = userData.counters.friends ?? 0,
                Gifts = userData.counters.gifts ?? 0,
                Groups = userData.counters.groups ?? 0,
                Followers = userData.counters.followers ?? 0,
                Pages = userData.counters.pages ?? 0,
                Subscriptions = userData.counters.subscriptions ?? 0
            } : new Counters
            {
                Albums = 0,
                Videos = 0,
                Audios = 0,
                Photos = 0,
                Notes = 0,
                Friends = 0,
                Gifts = 0,
                Groups = 0,
                Followers = 0,
                Pages = 0,
                Subscriptions = 0
            };

            // Инициализация страны
            Country = userData.country != null ? new Country
            {
                Id = userData.country.id,
                Title = userData.country.title
            } : new Country
            {
                Id = 0,
                Title = ""
            };

            // Последнее время онлайн
            LastSeen = userData.last_seen != null ? new LastSeen
            {
                Time = userData.last_seen.time,
                Platform = userData.last_seen.platform
            } : new LastSeen
            {
                Time = 0,
                Platform = 0
            };

            // Инициализация службы
            Militaries = new List<Military>();
            if (userData.military != null)
            {
                foreach (var military in userData.military)
                {
                    Militaries.Add(new Military
                    {
                        UnitId = military.unit_id,
                        Unit = military.unit,
                        From = military.from,
                        Until = military.until
                    });
                }
            }
            else
            {
                Militaries.Add(new Military
                {
                    UnitId = 0,
                    Unit = "",
                    From = 0,
                    Until = 0
                });
            }

            // Род занятия
            Occupation = userData.occupation != null ? new Occupation
            {
                Type = userData.occupation.type,
                Id = userData.occupation.id,
                Name = userData.occupation.name
            } : new Occupation
            {
                Type = "",
                Id = 0,
                Name = ""
            };

            // Персоналий
            Personal = userData.personal != null ? new Personal
            {
                Political = userData.personal.political,
                Langs = userData.personal.langs,
                Religion = userData.personal.religion,
                InspiredBy = userData.personal.inspired_by,
                PeopleMain = userData.personal.people_main,
                LifeMain = userData.personal.life_main,
                Smoking = userData.personal.smoking,
                Alcohol = userData.personal.alcohol
            } : new Personal
            {
                Political = 0,
                Langs = new List<string>(),
                Religion = "",
                InspiredBy = "",
                PeopleMain = 0,
                LifeMain = 0,
                Smoking = 0,
                Alcohol = 0
            };

            // Инициализация шкьол
            Schools = new List<School>();
            if (userData.schools != null)
            {
                foreach (var school in userData.schools)
                {
                    Schools.Add(new School
                    {
                        Id = school.id,
                        City = school.city,
                        Name = school.name,
                        YearFrom = school.year_from,
                        YearTo = school.year_to,
                        YearGraduated = school.year_graduated,
                        Speciality = school.speciality,
                        Type = school.type,
                        TypeStr = school.type_str
                    });
                }
            }
            else
            {
                Schools.Add(new School
                {
                    Id = 0,
                    City = 0,
                    Name = "",
                    YearFrom = 0,
                    YearTo = 0,
                    YearGraduated = 0,
                    Speciality = "",
                    Type = 0,
                    TypeStr = ""
                });
            }

            // Инициализация списка карьеры
            Universities = new List<University>();
            if (userData.universities != null)
            {
                foreach (var university in userData.universities)
                {
                    Universities.Add(new University
                    {
                        Id = university.id,
                        City = university.city,
                        Name = university.name,
                        Faculty = university.faculty,
                        FacultyName = university.faculty_name,
                        Chair = university.chair,
                        ChairName = university.chair_name,
                        Graduation = university.graduation,
                        EducationForm = university.education_form,
                        EducationStatus = university.education_status
                    });
                }
            }
            else
            {
                Universities.Add(new University
                {
                    Id = 0,
                    City = 0,
                    Name = "",
                    Faculty = 0,
                    FacultyName = "",
                    Chair = 0,
                    ChairName = "",
                    Graduation = 0,
                    EducationForm = "",
                    EducationStatus = ""
                });
            }
        }
    }
}
