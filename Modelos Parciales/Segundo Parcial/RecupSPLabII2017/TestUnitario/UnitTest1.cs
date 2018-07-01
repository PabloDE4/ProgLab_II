using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructoresPacientes()
        {
            Paciente p = new Paciente("Nombre", "Apellido");
            Assert.AreEqual(1, p.Turno);
            Paciente p2 = new Paciente("Nombre", "Apellido", 5);
            Assert.AreEqual(5, p.Turno);
        }
    }
}
