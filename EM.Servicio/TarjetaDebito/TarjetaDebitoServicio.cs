using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.TarjetaDebito;
using EM.Infraestructura.Repositorio.TarjetaDebito;
using EM.IServicio.TarjetaDebito;
using EM.IServicio.TarjetaDebito.DTO;

namespace EM.Servicio.TarjetaDebito
{
    public class TarjetaDebitoServicio : ITarjetaDebitoServicio
    {
        private readonly ITarjetaDebitoRepositorio _tarjetaDebitoRepositorio = new TarjetaDebitoRepositorio();

        public void Insertar(TarjetaDebitoDto dto)
        {
            var Tarjeta = new Dominio.Entity.Entidades.TarjetaDebito()
            {
                NombreTitular = dto.NombreTitular,
                Tarjeta = dto.Tarjeta,
                Mes = dto.Mes,
                Año = dto.Año,
                CCV = dto.CCV,
                ComprobanteId = dto.ComprobanteId
            };

            _tarjetaDebitoRepositorio.Add(Tarjeta);
            Guardar();
        }

        public void Modificar(TarjetaDebitoDto dto)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TarjetaDebitoDto> Obtener()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TarjetaDebitoDto> ObtenerPorFiltro(string cadena)
        {
            throw new NotImplementedException();
        }

        public TarjetaDebitoDto ObtenerPorId(long id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            _tarjetaDebitoRepositorio.Save();
        }
    }
}
