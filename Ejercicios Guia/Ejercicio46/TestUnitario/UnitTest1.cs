using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio30;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Valida que la lista de vehículos de la competencia esté instanciada 
        /// al crear un nuevo objeto. 
        /// </summary>
        [TestMethod]
        public void ListaCompetencia()
        {
            Competencia c = new Competencia(15, 3, Ejercicio30.TipoCompetencia.F1);
            Assert.IsNotNull(c.Competidores);
        }

        /// <summary>
        /// Controla que la excepción CompetenciaNoDisponible se lance al 
        /// querer cargar un AutoF1 en una competencia del tipo MotoCross.
        /// </summary>
        [TestMethod]
        public void ExcepcionF1enMotocross()
        {
            Competencia c = new Competencia(15, 3, Ejercicio30.TipoCompetencia.Motocross);
            AutoF1 a1 = new AutoF1(1, "Mercedes");

            try
            {
                bool aux = c + a1;                 
                             
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is CompetenciaNoDisponibleException);
            }
        }

        /// <summary>
        /// Controla que la excepción CompetenciaNoDisponible no se lance al 
        /// querer cargar un objeto del tipo MotoCross en una competencia del tipo MotoCross.
        /// </summary>
        [TestMethod]
        public void ExcepcionNoSeLanceMotoenMoto()
        {
            Competencia c = new Competencia(15, 3, Ejercicio30.TipoCompetencia.Motocross);
            MotoCross m1 = new MotoCross(4, "FMX");

            try
            {
                bool aux = c + m1;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(CompetenciaNoDisponibleException));
            }
        }

        /// <summary>
        /// Comprueba que al cargar un nuevo vehículo en la competencia esté figure en la lista.
        /// </summary>
        [TestMethod]
        public void VehiculoEnCompetencia()
        {
            Competencia c1 = new Competencia(15, 3, Ejercicio30.TipoCompetencia.F1);
            AutoF1 a1 = new AutoF1(1, "Mercedes");

            if (c1 + a1)
            {
                Assert.IsTrue(c1 == a1);
            }
        }

        /// <summary>
        /// Comprueba que al quitar un vehículo existente en la competencia esté ya no figure en la lista.
        /// </summary>
        [TestMethod]
        public void VehiculoNoEstaEnCompetencia()
        {
            Competencia c1 = new Competencia(15, 3, Ejercicio30.TipoCompetencia.F1);
            AutoF1 a1 = new AutoF1(1, "Mercedes");

            if (c1 - a1)
            {
                Assert.IsTrue(c1 != a1);
            }
        }
    }
}
