using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Lab2GisOpenApiServer.Model
{
    public class AtmStatusRepository : IAtmStatusRepository
    {
        private readonly Dictionary<string, AtmStatus> _statutes = new();

        private readonly string _atmStatusStorageFileName;

        public AtmStatusRepository(IConfiguration configuration)
        {
            _atmStatusStorageFileName = configuration.GetSection("AtmStatusFile").Value;
            if (!File.Exists(_atmStatusStorageFileName)) return;

            _statutes = JsonConvert.DeserializeObject<Dictionary<string, AtmStatus>>(File.ReadAllText(_atmStatusStorageFileName));
        }

        public AtmStatus Get(string atmId)
        {
            _statutes.TryGetValue(atmId, out var result);
            return result;
        }

        public void Insert(string atmId, AtmStatus newStatus)
        {
            _statutes.TryAdd(atmId, newStatus);
        }

        public void Update(string atmId, AtmStatus newStatus)
        {
            _statutes[atmId] = newStatus;
        }

        public void Commit()
        {
            File.WriteAllText(_atmStatusStorageFileName, JsonConvert.SerializeObject(_statutes));
        }
    }
}