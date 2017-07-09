namespace QDot.Location.Core.Models
{
    public class Place
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ZipCode { get; set; }

        public Place()
        {
        }

        public Place(API.Client.Zippopotam.Models.Place apiPlace, string zipCode)
        {
            Name = apiPlace.PlaceName;
            Latitude = apiPlace.Latitude;
            Longitude = apiPlace.Longitude;
            ZipCode = zipCode;
        }

        public override string ToString()
        {
            return $"Name: {Name} Latitude: {Latitude} Longitude: {Longitude} ZipCode: {ZipCode}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var place = (Place)obj;
            return Name.Equals(place.Name) &&
                Latitude == place.Latitude &&
                Longitude == place.Longitude &&
                ZipCode.Equals(place.ZipCode);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = Name != null ? (hash * 7) + Name.GetHashCode() : hash;
            hash = (hash * 7) + Latitude.GetHashCode();
            hash = (hash * 7) + Longitude.GetHashCode();
            hash = ZipCode != null ? (hash * 7) + ZipCode.GetHashCode() : hash;

            return hash;
        }
    }
}