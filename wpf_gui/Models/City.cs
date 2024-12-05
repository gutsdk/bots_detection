namespace wpf_gui.Models
{
    internal class City
    {
        internal int Id { get; set; }
        internal string Title { get; set; }

        public City()
        {
            Id = 0;
            Title = string.Empty;
        }

        public City(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
