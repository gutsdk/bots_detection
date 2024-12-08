namespace wpf_gui.Models
{
    internal class Country
    {
        internal int Id { get; set; }
        internal string Title { get; set; }

        public Country()
        {
            Id = 0;
            Title = string.Empty;
        }
        public Country(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
