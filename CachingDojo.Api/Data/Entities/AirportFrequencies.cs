namespace CachingDojo.Data.Entities
{
    public partial class AirportFrequencies
    {
        public int Id { get; set; }

        public string AirportReference { get; set; }

        public string AirportIdentity { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public double FrequencyMhz { get; set; }
    }
}
