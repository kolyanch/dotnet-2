using System.Collections.Generic;

namespace Lab2GisOpenApiServer.Model
{
    public interface IAtmRepository
    {
        List<Atm> GetAtms();
    }
}
