using DataLake.Entities.Complex;

namespace DataLake.Entities.Interfaces
{
    public interface IProyectosRepository
    {
        Task<ICollection<Proyectos>> GetCollectionAsync();
        Task<ICollection<ProyectosInfo?>> GetProyectosInfoCollectionAsync();
        Task<ProyectosInfo?> GetByIdAsync(int id);
    }
}
