using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jambo.Utils;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jambo.Converters
{
    public class GeoCoordinatesConverter : ValueConverter<GeoCoordinates, string>
    {
        public GeoCoordinatesConverter() : base(
            gc => gc.ToString(),
            str => new GeoCoordinates(str))
        {
        }
    }
}