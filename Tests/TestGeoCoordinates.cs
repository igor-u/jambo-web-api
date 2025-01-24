using Jambo.Utils;

namespace Tests;

public class TestGeoCoordinates
{
    [Fact]
    public void TestGeoCoordinatesConstructorWithStringToDoubleConversion()
    {
        GeoCoordinates geoCoordinates = new GeoCoordinates("12.3456, 12.3456");

        Assert.True(geoCoordinates.Latitude.Equals(12.3456));
        Assert.True(geoCoordinates.Longitude.Equals(12.3456));
    }
}