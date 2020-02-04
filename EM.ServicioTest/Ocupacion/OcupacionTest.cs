using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Dominio.Repositorio.Ocupacion;
using EM.Infraestructura.Context;
using EM.Infraestructura.Repositorio.Ocupacion;
using EM.IServicio.Ocupacion;
using EM.IServicio.Ocupacion.DTOs;
using EM.Servicio.Ocupacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.ServicioTest.Ocupacion
{
    [TestClass]
    public class OcupacionTest
    {
        [TestMethod]
        public void InsertOcupacionTest()
        {
            // Arrange
            IOcupacionRepositorio repo = new OcupacionRepositorio();
            IOcupacionServicio servicio = new OcupacionServicio(repo);
            OcupacionDto dto = new OcupacionDto
            {
                Descripcion = "Ocupacion 1"
            };

            // Act
            servicio.Agregar(dto);
            var result = servicio.ObtenerPorId(dto.Id);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateOcupacionTest()
        {
            IOcupacionRepositorio repo = new OcupacionRepositorio();
            OcupacionServicio servicio = new OcupacionServicio(repo);

            var ocupacionAModificar = new OcupacionDto
            {
                Id = 1,
                Descripcion = "Ocupacion 2"
            };

            servicio.Modificar(ocupacionAModificar);

            var ocupacion = servicio.ObtenerPorId(1);

            Assert.AreEqual("Ocupacion 2", ocupacion.Descripcion);
        }

        [TestMethod]
        public void DeleteOcupacionTest()
        {
            IOcupacionRepositorio repo = new OcupacionRepositorio();
            OcupacionServicio servicio = new OcupacionServicio(repo);

            var ocupacionEliminar = servicio.ObtenerPorId(1);

            servicio.Eliminar(ocupacionEliminar.Id);

            var result = servicio.ObtenerPorId(1);

            Assert.IsNull(result);
        }
        
    }
}
