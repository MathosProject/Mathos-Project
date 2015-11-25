using System;
using Mathos.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos;

namespace MathosTest
{
    [TestClass]
    public class ConverterTest
    {
        [TestMethod]
        public void LengthConversion()
        {
            double kilometers = Converter.From(Length.Mile, 2).To(Length.Kilometer);

            Assert.AreEqual(3.21869, Math.Round(kilometers, 5));

            kilometers = 2.From(Length.Mile).To(Length.Kilometer);

            Assert.AreEqual(3.21869, Math.Round(kilometers, 5));
        }

        [TestMethod]
        public void SpeedConversion()
        {
            double kmph = Converter.From(Speed.MilesPerHour, 55).To(Speed.KilometersPerHour);

            Assert.AreEqual(88.5138, Math.Round(kmph, 4));
        }

        [TestMethod]
        public void MassConversion()
        {
            double pounds = Converter.From(Mass.Pound, 150).To(Mass.Kilogram);

            Assert.AreEqual(68.0389, Math.Round(pounds, 4));
        }

        [TestMethod]
        public void VolumeConversion()
        {
            double volume = Converter.From(Volume.GallonUs, 2).To(Volume.Liter);

            Assert.AreEqual(7.57083, Math.Round(volume, 5));
        }

        [TestMethod]
        public void AreaConversion()
        {
            double area = Converter.From(Area.Acre, 2).To(Area.SquareFoot);

            Assert.AreEqual(87120, Math.Round(area, 0));
            
            area = Converter.From(Area.SquareMile, 2).To(Area.Hectare);
            Assert.AreEqual(518.00, Math.Round(area,2));
        }

        [TestMethod]
        public void PressureConversion()
        {
            double pressure = Converter.From(Pressure.Atm, 1).To(Pressure.Pascal);
            Assert.AreEqual(101325, Math.Round(pressure));

            pressure = Converter.From(Pressure.Bar, 1).To(Pressure.Psi);
            Assert.AreEqual(14.50377, Math.Round(pressure, 5));
        }

        [TestMethod]
        public void PowerConversion()
        {
            double power = Converter.From(Power.MechanicalHp, 2).To(Power.FtLbSec);
            Assert.AreEqual(1100, Math.Round(power));

            power = Converter.From(Power.ElectricalHp, 1).To(Power.Kilowatt);
            Assert.AreEqual(0.746, Math.Round(power, 3));
        }

        [TestMethod]
        public void BaseConversions()
        {
            Assert.AreEqual("1011111", 95.From(Base.Base10).To(Base.Base2));

            Assert.AreEqual("5F", "1011111".From(Base.Base2).To(Base.Base16));

            Assert.AreEqual("95", "5F".From(Base.Hexadecimal).To(Base.Decimal));
        }

        [TestMethod]
        public void UnitConverterTest()
        {
            // extend this test
            double resultA = Converter.From(Length.Foot, 3).To(Length.Meter);
            double resultB = Converter.From(Length.Meter, resultA).To(Length.Foot);

            Assert.IsTrue(resultB == 3); // ca 3
        }

        [TestMethod]
        public void NumberConverterTest()
        {
            // extend this test
            string resultA = Converter.From(Base.Base2, "101").To(Base.Base16);
            string resultB = Converter.From(Base.Base2, "101.1").To(Base.Base10);

            Assert.IsTrue(resultA == "5");

        }

        [TestMethod]
        public void AngleConvertedTest()
        {
            double resultA = Converter.From(Angle.Degree, 180).To(Angle.Radian);
            double resultB = Converter.From(Angle.Radian, resultA).To(Angle.Degree);

            Assert.IsTrue(resultB == 180);


        }
        
        [TestMethod]
        public void TemperatureConveterTest()
        {
            double resultA = Converter.From(Temperature.DegreeC, 20).To(Temperature.DegreeK);
            Assert.AreEqual(resultA, 293.15);

            double resultB = Converter.From(Temperature.DegreeK, resultA).To(Temperature.DegreeC);
            Assert.AreEqual(resultB, 20);

            double resultC = Converter.From(Temperature.DegreeF, 39).To(Temperature.DegreeC);
            Assert.AreEqual(resultC, 3.888888888888888888);

            double resultD = Converter.From(Temperature.DegreeC, 51).To(Temperature.DegreeF);
            Assert.AreEqual(resultD, 123.8);

            double resultE = Converter.From(Temperature.DegreeK, 62).To(Temperature.DegreeF);
            Assert.AreEqual(resultE, -348.07);

            double resultF = Converter.From(Temperature.DegreeF, 23).To(Temperature.DegreeK);
            Assert.AreEqual(resultF, 268.15);


            double resultG = Converter.From(Temperature.DegreeF, 23).To(Temperature.DegreeF);
            Assert.AreEqual(resultG, 23);

        }
    }
}
