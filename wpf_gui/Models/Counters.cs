namespace wpf_gui.Models
{
    internal class Counters
    {
        internal int Albums { get; set; }
        internal int Videos { get; set; }
        internal int Audios { get; set; }
        internal int Photos { get; set; }
        internal int Notes { get; set; }
        internal int Friends { get; set; }
        internal int Gifts { get; set; }
        internal int Groups { get; set; }
        internal int Followers { get; set; }
        internal int Pages { get; set; }
        internal int Subscriptions { get; set; }

        public Counters()
        {
            Albums = 0;
            Videos = 0;
            Audios = 0;
            Photos = 0;
            Notes = 0;
            Friends = 0;
            Gifts = 0;
            Groups = 0;
            Followers = 0;
            Pages = 0;
            Subscriptions = 0;
        }
        public Counters(int albums, int videos, int audios, int photos, int notes, int friends, int gifts, int groups, int followers, int pages, int subscriptions)
        {
            Albums = albums;
            Videos = videos;
            Audios = audios;
            Photos = photos;
            Notes = notes;
            Friends = friends;
            Gifts = gifts;
            Groups = groups;
            Followers = followers;
            Pages = pages;
            Subscriptions = subscriptions;
        }
    }
}
