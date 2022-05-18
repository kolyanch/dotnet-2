﻿using Lab2Gis.Properties;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab2Gis
{
    public class AtmRepository
    {
        private readonly GisOpenApiClient _openApiClient;

        public AtmRepository()
        {
            var httpClient = new HttpClient();
            var baseUrl = Settings.Default.OpenApiServer;
            _openApiClient = new GisOpenApiClient(baseUrl, httpClient);
        }

        public Task<ICollection<Atm>> GetAtmsAsync()
        {
            return _openApiClient.AtmAsync();
        }

        public Task<AtmStatus> GetAtmStatusAsync(string atmId)
        {
            return _openApiClient.AtmStatusAsync(atmId);
        }

        public Task UpdateAtmAsync(string atmId, AtmStatus atmStatus)
        {
            return _openApiClient.AtmStatus2Async(atmId, atmStatus);
        }
    }
}
