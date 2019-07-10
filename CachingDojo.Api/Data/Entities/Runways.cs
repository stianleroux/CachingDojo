namespace CachingDojo.Data.Entities
{
    public partial class Runways
    {
        public string Id { get; set; }

        public string AirportRef { get; set; }

        public string AirportIdentity { get; set; }

        public string LengthFeett { get; set; }

        public string WidthFeet { get; set; }

        public string Surface { get; set; }

        public string Lighted { get; set; }

        public string Closed { get; set; }

        public string LeIdentity { get; set; }

        public string LeLatitude { get; set; }

        public string LeLongitude { get; set; }

        public string LeElevationFeet { get; set; }

        public string LeHeading { get; set; }

        public string LeDisplacedThresholdFeet { get; set; }

        public string HeIdent { get; set; }

        public string HeLatitude { get; set; }

        public string HeLongitude { get; set; }

        public string HeElevationFeet { get; set; }

        public string HeHeadingDegrees { get; set; }

        public string HeDisplacedThresholdFeet { get; set; }
    }
}