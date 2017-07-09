using System.Collections.Generic;
using System.Linq;

namespace QDot.Location.Core.Models
{
    public class Location
    {
        public string State { get; set; }
        public List<Place> Places { get; set; }

        public override string ToString()
        {
            return $"Name: {State} Places: {string.Join(",", Places)}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var state = (Location)obj;
            return State.Equals(state.State) &&
                Places.SequenceEqual(state.Places);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = State != null ? (hash * 7) + State.GetHashCode() : hash;
            hash = Places != null ? (hash * 7) + Places.GetHashCode() : hash;

            return hash;
        }
    }
}
