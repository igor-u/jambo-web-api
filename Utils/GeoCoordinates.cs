using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Utils
{
    public class GeoCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoCoordinates(double latitude, double longitude) {
            this.Latitude = Coordinate(latitude, -90, 90);
            this.Longitude = Coordinate(longitude, -180, 180);
        }

        private double Coordinate(double coordinate, double lowerRange, double upperRange) {
            if (coordinate >= lowerRange && coordinate <= upperRange) {
                return Math.Round(coordinate, 4);
            }
            else return 0;
        }

        public override string ToString()
        {
            return $"{Latitude}, {Longitude}";
        }
    }
}