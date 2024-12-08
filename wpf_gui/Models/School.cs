namespace wpf_gui.Models
{
    internal class School
    {
        internal int Id { get; set; }
        internal int City { get; set; }
        internal string Name { get; set; }
        internal int YearFrom { get; set; }
        internal int YearTo { get; set; }
        internal int YearGraduated { get; set; }
        internal string Speciality { get; set; }
        internal int Type { get; set; }
        internal string TypeStr { get; set; }

        public School()
        {
            Id = 0;
            City = 0;
            Name = string.Empty;
            YearFrom = 0;
            YearTo = 0;
            YearGraduated = 0;
            Speciality = string.Empty;
            Type = 0;
            TypeStr = string.Empty;
        }
        public School(int id, int city, string name, int yearFrom, int yearTo, int yearGraduated, string speciality, int type, string typeStr)
        {
            Id = id;
            City = city;
            Name = name;
            YearFrom = yearFrom;
            YearTo = yearTo;
            YearGraduated = yearGraduated;
            Speciality = speciality;
            Type = type;
            TypeStr = typeStr;
        }
    }
}
