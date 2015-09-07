using System;
using Mathos.Chemistry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Mathos_Main.Chemistry
{
    [TestClass]
    public class BasicChemistry
    {
        [TestMethod]
        public void WaterTest()
        {
            var water = new Compound(new[] { Elements.Hydrogen, Elements.Hydrogen }, Elements.Oxygen);

            Assert.IsTrue(water.ToString() == "H2 O");
            Console.WriteLine(water.ToString());

            var hydrogenPeroxide = new Compound(new[] { Elements.Hydrogen, Elements.Hydrogen },
                                                Elements.Oxygen, Elements.Oxygen);

            Assert.IsTrue(hydrogenPeroxide.ToString() == "H2 O2");
            Console.WriteLine(hydrogenPeroxide.ToString());
        }

        [TestMethod]
        public void NumberOfUniqueElementsTest()
        {
            // fix this var compounds = new Compounds( new Compound() { Elements = new List<Element> { new Element("H") } });
        }
    }
}
