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
            servicio.Insert(dto);
            var result = servicio.GetById(1);

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

            servicio.Update(ocupacionAModificar);

            var ocupacion = servicio.GetById(1);

            Assert.AreEqual("Ocupacion 2", ocupacion.Descripcion);
        }

        [TestMethod]
        public void DeleteOcupacionTest()
        {
            IOcupacionRepositorio repo = new OcupacionRepositorio();
            OcupacionServicio servicio = new OcupacionServicio(repo);

            var ocupacionEliminar = servicio.GetById(1);

            servicio.Delete(ocupacionEliminar.Id);

            var result = servicio.GetById(1);

            Assert.IsNull(result);
        }
        
    }
}
