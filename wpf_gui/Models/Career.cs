namespace wpf_gui.Models
{
    internal class Career
    {
        internal int CityId { get; set; }
        internal string Company { get; set; }
        internal string Position { get; set; }
        internal int From { get; set; }
        internal int Until { get; set; }

        public Career()
        {
            CityId = 0;
            Company = string.Empty;
            Position = string.Empty;
            From = 0;
            Until = 0;
        }

        public Career(int city_id, string company, string position, int from, int until)
        {
            CityId = city_id;
            Company = company;
            Position = position;
            From = from;
            Until = until;
        }
    }
}
