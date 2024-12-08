namespace wpf_gui.Models
{
    internal class University
    {
        internal int Id { get; set; }
        internal int City { get; set; }
        internal string Name { get; set; }
        internal int Faculty { get; set; }
        internal string FacultyName { get; set; }
        internal int Chair { get; set; }
        internal string ChairName { get; set; }
        internal int Graduation { get; set; }
        internal string EducationForm { get; set; }
        internal string EducationStatus {  get; set; }

        public University()
        {
            Id = 0;
            City = 0;
            Name = string.Empty;
            Faculty = 0;
            FacultyName = string.Empty;
            Chair = 0;
            ChairName = string.Empty;
            Graduation = 0;
            EducationForm = string.Empty;
            EducationStatus = string.Empty;
        }
        public University(int id, int city, string name, int faculty, string facultyName, int chair, string chairName, int graduation, string educationForm, string educationStatus)
        {
            Id = id;
            City = city;
            Name = name;
            Faculty = faculty;
            FacultyName = facultyName;
            Chair = chair;
            ChairName = chairName;
            Graduation = graduation;
            EducationForm = educationForm;
            EducationStatus = educationStatus;
        }
    }
}
