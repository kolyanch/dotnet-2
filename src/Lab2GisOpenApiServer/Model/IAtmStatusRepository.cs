namespace Lab2GisOpenApiServer.Model
{
    public interface IAtmStatusRepository
    {
        AtmStatus Get(string atmId);

        void Insert(string atmId, AtmStatus newStatus);

        void Update(string atmId, AtmStatus newStatus);

        void Commit();
    }
}
