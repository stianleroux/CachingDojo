namespace CachingDojo.Data.Entities
{
    public partial class Airports
    {
        public string Id { get; set; }

        public string Identity { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string ElevationFeet { get; set; }

        public string Continent { get; set; }

        public string IsoCountry { get; set; }

        public string IsoRegion { get; set; }

        public string Municipality { get; set; }

        public string ScheduledService { get; set; }

        public string GpsCode { get; set; }

        public string IataCode { get; set; }

        public string LocalCode { get; set; }

        public string HomeLink { get; set; }

        public string WikipediaLink { get; set; }

        public string Keywords { get; set; }
    }
}