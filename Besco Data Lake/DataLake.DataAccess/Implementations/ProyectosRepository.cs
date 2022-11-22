using AutoMapper;
using DataLake.DataAccess;
using DataLake.Entities.Complex;
using DataLake.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLake.Entities.Implementations
{
    public class ProyectosRepository : IProyectosRepository
    {
        private readonly DataLakeDbContext _context;
        private readonly IMapper _mapper;

        public ProyectosRepository(DataLakeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<ICollection<Proyectos>> GetCollectionAsync()
        {
            return await _context.Set<Proyectos>()
                                .ToListAsync();
        }

        public async Task<ICollection<ProyectosInfo?>> GetProyectosInfoCollectionAsync()
        {
            return await _context.Set<Proyectos>()
                                .Select(x => _mapper.Map<ProyectosInfo?>(x))
                                .ToListAsync();
        }
        public async Task<ProyectosInfo?> GetByIdAsync(int id)
        {
            return await _context.Set<Proyectos>()
                                .Where(x => x.IdProyecto == id)
                                .Select(x => _mapper.Map<ProyectosInfo?>(x))
                                .SingleOrDefaultAsync();
        }
    }
}
