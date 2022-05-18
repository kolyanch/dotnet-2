using Microsoft.Extensions.Configuration;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Lab2GisOpenApiServer.Model
{
    public class AtmRepository : IAtmRepository
    {
        private readonly List<Atm> _features = new();

        public AtmRepository(IConfiguration configuration)
        {
            var atmStorageFileName = configuration.GetSection("AtmFile").Value;

            var serializer = GeoJsonSerializer.Create();
            using var reader = File.OpenText(atmStorageFileName);
            using var jsonReader = new JsonTextReader(reader);
            var geoJsonFeatures = serializer.Deserialize<FeatureCollection>(jsonReader);
            foreach (var feature in geoJsonFeatures)
            {
                var point = (Point)feature.Geometry;
                string atmName = null;
                if (feature.Attributes.Exists("name"))
                {
                    atmName = feature.Attributes["name"].ToString();
                }
                else if (feature.Attributes.Exists("operator"))
                {
                    atmName = feature.Attributes["operator"].ToString();
                }
                _features.Add(new Atm
                {
                    Id = feature.Attributes["id"].ToString(),
                    Name = atmName,
                    Latitude = point.X,
                    Longitude = point.Y
                }
                );
            }
        }

        public List<Atm> GetAtms()
        {
            return _features;
        }
    }
}