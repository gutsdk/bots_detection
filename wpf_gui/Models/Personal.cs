namespace wpf_gui.Models
{
    internal class Personal
    {
        internal int Political { get; set; }
        internal string Religion { get; set; }
        internal string InspiredBy { get; set; }
        internal int PeopleMain { get; set; }
        internal int LifeMain { get; set; }
        internal int Smoking { get; set; }
        internal int Alcohol { get; set; }
        internal List<string> Langs { get; set; }

        public Personal()
        {
            Political = 0;
            Religion = string.Empty;
            InspiredBy = string.Empty;
            PeopleMain = 0;
            LifeMain = 0;
            Smoking = 0;
            Alcohol = 0;
            Langs = new List<string>();
        }
        public Personal(int political, string religion, string inspiredBy, int peopleMain, int lifeMain, int smoking, int alcohol, List<string> langs)
        {
            Political = political;
            Religion = religion;
            InspiredBy = inspiredBy;
            PeopleMain = peopleMain;
            LifeMain = lifeMain;
            Smoking = smoking;
            Alcohol = alcohol;
            Langs = langs;
        }
    }
}
