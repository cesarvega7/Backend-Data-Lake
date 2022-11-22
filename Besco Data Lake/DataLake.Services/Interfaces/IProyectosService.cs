using DataLake.Dto.Response;
using DataLake.Entities.Complex;

namespace DataLake.Services.Interfaces
{
    public interface IProyectosService
    {
        Task<BaseResponseEntity<ICollection<ProyectosInfo?>>> GetCollectionAsync();
        Task<BaseResponseEntity<ICollection<PeriodoInfo?>>> GetByIdAsync(int id);
    }
}
