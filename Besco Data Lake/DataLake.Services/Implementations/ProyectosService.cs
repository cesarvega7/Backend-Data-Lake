using AutoMapper;
using DataLake.Dto.Response;
using DataLake.Entities.Complex;
using DataLake.Entities.Interfaces;
using DataLake.Services.Interfaces;
using Microsoft.VisualBasic;

namespace DataLake.Services.Implementations
{
    public class ProyectosService : IProyectosService
    {
        private readonly IProyectosRepository _repository;
        private readonly IMapper _mapper;

        public ProyectosService(IProyectosRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponseEntity<ICollection<ProyectosInfo?>>> GetCollectionAsync()
        {
            var response = new BaseResponseEntity<ICollection<ProyectosInfo?>>();
            try
            {
                var proyecto = await _repository.GetProyectosInfoCollectionAsync();
                response.ResponseResult = proyecto;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<ICollection<PeriodoInfo?>>> GetByIdAsync(int id)
        {
            var response = new BaseResponseEntity<ICollection<PeriodoInfo?>>();
            PeriodoInfo oPeriodoInfo;
            List<PeriodoInfo> lstPeriodoInfo = new List<PeriodoInfo>();

            try
            {
                var proyecto = await _repository.GetByIdAsync(id);
                
                int AnioIni = int.Parse(Strings.Right(proyecto?.FechaInicio?.Trim(), 4));
                string MesIni = proyecto.FechaInicio.Trim().Remove(proyecto.FechaInicio.Trim().Length - 8);
                int AnioFin = int.Parse(Strings.Right(proyecto?.FechaFin?.Trim(), 4));
                string MesFin = proyecto.FechaFin.Trim().Remove(proyecto.FechaFin.Trim().Length - 8);

                int Anios = ((AnioFin+1) - AnioIni);

                #region RegionMatrizes

                string[] MatrizMes = new string[12];
                MatrizMes[0] = "ENERO";
                MatrizMes[1] = "FEBRERO";
                MatrizMes[2] = "MARZO";
                MatrizMes[3] = "ABRIL";
                MatrizMes[4] = "MAYO";
                MatrizMes[5] = "JUNIO";
                MatrizMes[6] = "JULIO";
                MatrizMes[7] = "AGOSTO";
                MatrizMes[8] = "SEPTIEMBRE";
                MatrizMes[9] = "OCTUBRE";
                MatrizMes[10] = "NOVIEMBRE";
                MatrizMes[11] = "DICIEMBRE";

                string[] MatrizAnio = new string[Anios];

                for (int i = 0; i < Anios; i++)
                {
                    MatrizAnio[i] = (AnioIni + i).ToString();
                }

                #endregion

                bool SeInicio = false;

                for (int i = 0; i < MatrizAnio.Length; i++)
                {
                    for (int x = 0; x < MatrizMes.Length; x++)
                    {
                        if (MatrizMes[x] == MesIni.ToUpper() && AnioIni.ToString() == MatrizAnio[i])
                        {
                            SeInicio = true;
                        }
                        if (SeInicio)
                        {
                            string NumeroMes = (x + 1) < 10 ? "0" + (x + 1) : (x + 1).ToString();
                            oPeriodoInfo = new PeriodoInfo();
                            oPeriodoInfo.IdPeriodo = string.Concat(NumeroMes, MatrizAnio[i]);
                            oPeriodoInfo.NombrePeriodo = string.Concat(MatrizMes[x], " - ", MatrizAnio[i]);
                            lstPeriodoInfo.Add(oPeriodoInfo);
                        }
                        if (MatrizMes[x] == MesFin.ToUpper() && AnioFin.ToString() == MatrizAnio[i])
                        {
                            SeInicio = false;
                            break;
                        }
                    }
                    if (!SeInicio)
                    {
                        break;
                    }
                }

                response.ResponseResult = lstPeriodoInfo.ToArray();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

    }
}
