using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentralTelefonica;
using Ejercicio_37;

namespace TestUnitarioEJ44
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Valida que la lista de llamadas de la centralita esté instanciada al crear un nuevo objeto del tipo Centralita.
        /// </summary>
        [TestMethod]
        public void ValidarLlamadas()
        {
            Centralita c = new Centralita("Central");

            Assert.IsNotNull(c.Llamadas);
        }

        /// <summary>
        /// Controlar que la excepción CentralitaExcepcion se lance al intentar cargar 
        /// una segunda llamada con los mismos datos de origen y destino 
        /// de una llamada Local ya existente.
        /// </summary>
        [TestMethod]
        public void ValidarExcepcionLocal()
        {
            Centralita c = new Centralita("Central");
            Local l1 = new Local("Origen", 23, "Destino", 23);
            Local l2 = new Local("Origen", 23, "Destino", 23);

            try
            {
                c += l1;
                c += l2;
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is CentralitaException);
            }
        }

        /// <summary>
        /// Controlar que la excepción CentralitaExcepcion se lance al intentar 
        /// cargar una segunda llamada con solamente los mismos datos de origen y 
        /// destino de una llamada Provincial ya existente.
        /// </summary>
        [TestMethod]
        public void ValidarExcepcionProvincial()
        {
            Centralita c = new Centralita("Central");
            Provincial l1 = new Provincial("Origen", Provincial.Franja.Franja_1, 21, "Destino");
            Provincial l2 = new Provincial("Origen", Provincial.Franja.Franja_1, 21, "Destino");

            try
            {
                c += l1;
                c += l2;
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is CentralitaException);
            }
        }

        /// <summary>
        /// Dentro de un método de test unitario crear dos llamadas Local y dos Provincial, 
        /// todos con los mismos datos de origen y destino. 
        /// Luego comparar cada uno de estos cuatro objetos 
        /// contra los demás, debiendo ser iguales solamente las instancias de Local y de Provincial entre sí.
        /// </summary>
        [TestMethod]
        public void CompararLlamadas()
        {
            Centralita c = new Centralita("Centralita");
            Llamada p1 = new Provincial("Origen", Provincial.Franja.Franja_1, 21, "Destino");
            Llamada p2 = new Provincial("Origen", Provincial.Franja.Franja_1, 21, "Destino");
            Llamada l1 = new Local("Origen", 23, "Destino", 23);
            Llamada l2 = new Local("Origen", 53, "Destino", 43);

            Assert.IsTrue(p1 == p2);
            Assert.IsFalse(p1 == l1);
            Assert.IsFalse(p1 == l2);
            Assert.IsFalse(p2 == l1);
            Assert.IsFalse(p2 == l2);
            Assert.IsTrue(l1 == l2);

        }
    }
}
