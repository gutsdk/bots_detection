namespace wpf_gui.Models
{
    internal class Occupation
    {
        internal string Type { get; set; }
        internal int Id { get; set; }
        internal string Name { get; set; }

        public Occupation()
        {
            Type = string.Empty;
            Id = 0;
            Name = string.Empty;
        }
        public Occupation(string type, int id, string name)
        {
            Type = type;
            Id = id;
            Name = name;
        }
    }
}
