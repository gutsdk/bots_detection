namespace wpf_gui.Models
{
    internal class LastSeen
    {
        internal int Time {  get; set; }
        internal int Platform { get; set; }

        public LastSeen()
        {
            Time = 0;
            Platform = 0;
        }
        public LastSeen(int time, int platform)
        {
            Time = time;
            Platform = platform;
        }
    }
}
