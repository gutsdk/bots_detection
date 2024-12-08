namespace wpf_gui.Models
{
    internal class Military
    {
        internal string Unit { get; set; }
        internal int UnitId { get; set; }
        internal int From { get; set; }
        internal int Until { get; set; }

        public Military()
        {
            Unit = string.Empty;
            UnitId = 0;
            From = 0;
            Until = 0;
        }
        public Military(string unit, int unitId, int from, int until)
        {
            Unit = unit;
            UnitId = unitId;
            From = from;
            Until = until;
        }
    }
}
