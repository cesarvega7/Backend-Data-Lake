using AutoMapper;
using DataLake.Entities;
using DataLake.Entities.Complex;

namespace DataLake.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProyectosInfo, Proyectos>();
            CreateMap<Proyectos, ProyectosInfo>();
        }
    }
}
