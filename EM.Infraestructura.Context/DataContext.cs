using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EM.Dominio.Entity.Entidades;
using static EM.Aplicacion.ConnectionString.ConnectionString;

namespace EM.Infraestructura.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(GetStringConection)
        {
            Configuration.LazyLoadingEnabled = false;

            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Alojamiento> Alojamientos { get; set; }

        public IDbSet<Comprobante> Comprobantes { get; set; }

        public IDbSet<CondicionIva>  CondicionIvas { get; set; }

        public IDbSet<Domicilio> Domicilios { get; set; }

        public IDbSet<Empresa> Empresas { get; set; }

        public IDbSet<Entrada> Entradas { get; set; }

        public IDbSet<Estado> Estados { get; set; }

        public IDbSet<Evento> Eventos { get; set; }

        public IDbSet<EventoLugar> EventoLugares { get; set; }

        public IDbSet<Fecha> Fechas { get; set; }

        public IDbSet<FechaEvento> FechasEventos { get; set; }

        public IDbSet<FormaPago> FormaPagos { get; set; }

        public IDbSet<CreadorEvento> CreadorEventos { get; set; }

        public IDbSet<Gastronomia> Gastronomias { get; set; }

        public IDbSet<InscripcionCuenta> InscripcionCuentas { get; set; }

        public IDbSet<Localidad> Localidades { get; set; }

        public IDbSet<Lugar> Lugares { get; set; }

        public IDbSet<Ocupacion> Ocupaciones { get; set; }

        public IDbSet<Pais> Paises { get; set; }

        public IDbSet<Provincia> Provincias { get; set; }

        public IDbSet<Persona> Personas { get; set; }

        public IDbSet<PersonaEvento> PersonaEventos { get; set; }

        public IDbSet<Sala> Salas { get; set; }

        public IDbSet<TipoComprobante> TipoComprobantes { get; set; }

        public IDbSet<TipoEvento> TipoEventos { get; set; }

        public IDbSet<Transporte> Transportes { get; set; }

        public IDbSet<Usuario> Usuarios { get; set; }

        //public System.Data.Entity.DbSet<EM.IServicio.Persona.DTOs.PersonaDto> PersonaDtoes { get; set; }

        //public System.Data.Entity.DbSet<EM.IServicio.Persona.DTOs.PersonaDto> PersonaDtoes { get; set; }

        //public System.Data.Entity.DbSet<EM.IServicio.Persona.DTOs.PersonaDto> PersonaDtoes { get; set; }
    }
}