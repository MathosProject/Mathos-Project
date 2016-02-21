using System;
using Mathos.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Converter
{
    [TestClass]
    public class ConverterTest
    {
        [TestMethod]
        public void LengthConversion()
        {
            var kilometers = Mathos.Converter.Converter.From(Length.Mile, 2).To(Length.Kilometer);

            Assert.AreEqual(3.21869, Math.Round(kilometers, 5));

            kilometers = 2.From(Length.Mile).To(Length.Kilometer);

            Assert.AreEqual(3.21869, Math.Round(kilometers, 5));
        }

        [TestMethod]
        public void SpeedConversion()
        {
            var kmph = Mathos.Converter.Converter.From(Speed.MilesPerHour, 55).To(Speed.KilometersPerHour);

            Assert.AreEqual(88.5138, Math.Round(kmph, 4));
        }

        [TestMethod]
        public void MassConversion()
        {
            var pounds = Mathos.Converter.Converter.From(Mass.Pound, 150).To(Mass.Kilogram);

            Assert.AreEqual(68.0389, Math.Round(pounds, 4));
        }

        [TestMethod]
        public void VolumeConversion()
        {
            var volume = Mathos.Converter.Converter.From(Volume.GallonUs, 2).To(Volume.Liter);

            Assert.AreEqual(7.57083, Math.Round(volume, 5));
        }

        [TestMethod]
        public void AreaConversion()
        {
            var area = Mathos.Converter.Converter.From(Area.Acre, 2).To(Area.SquareFoot);

            Assert.AreEqual(87120, Math.Round(area, 0));

            area = Mathos.Converter.Converter.From(Area.SquareMile, 2).To(Area.Hectare);

            Assert.AreEqual(518.00, Math.Round(area, 2));
        }

        [TestMethod]
        public void PressureConversion()
        {
            var pressure = Mathos.Converter.Converter.From(Pressure.Atm, 1).To(Pressure.Pascal);

            Assert.AreEqual(101325, Math.Round(pressure));

            pressure = Mathos.Converter.Converter.From(Pressure.Bar, 1).To(Pressure.Psi);

            Assert.AreEqual(14.50377, Math.Round(pressure, 5));
        }

        [TestMethod]
        public void PowerConversion()
        {
            var power = Mathos.Converter.Converter.From(Power.MechanicalHp, 2).To(Power.FtLbSec);

            Assert.AreEqual(1100, Math.Round(power));

            power = Mathos.Converter.Converter.From(Power.ElectricalHp, 1).To(Power.Kilowatt);

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
            var resultA = Mathos.Converter.Converter.From(Length.Foot, 3).To(Length.Meter);
            var resultB = Mathos.Converter.Converter.From(Length.Meter, resultA).To(Length.Foot);

            Assert.AreEqual(resultB, 3); // ca 3
        }

        [TestMethod]
        public void NumberConverterTest()
        {
            // extend this test
            var resultA = Mathos.Converter.Converter.From(Base.Base2, "101").To(Base.Base16);
            //var resultB = Mathos.Converter.Converter.From(Base.Base2, "101.1").To(Base.Base10);

            Assert.AreEqual(resultA, "5");
        }

        [TestMethod]
        public void AngleConvertedTest()
        {
            var resultA = Mathos.Converter.Converter.From(Angle.Degree, 180).To(Angle.Radian);
            var resultB = Mathos.Converter.Converter.From(Angle.Radian, resultA).To(Angle.Degree);

            Assert.AreEqual(resultB, 180);
        }

        [TestMethod]
        public void TemperatureConveterTest()
        {
            var resultA = Mathos.Converter.Converter.From(Temperature.DegreeC, 20).To(Temperature.DegreeK);
            Assert.AreEqual(resultA, 293.15);

            var resultB = Mathos.Converter.Converter.From(Temperature.DegreeK, resultA).To(Temperature.DegreeC);
            Assert.AreEqual(resultB, 20);

            var resultC = Mathos.Converter.Converter.From(Temperature.DegreeF, 39).To(Temperature.DegreeC);
            Assert.AreEqual(resultC, 3.888888888888888888);

            var resultD = Mathos.Converter.Converter.From(Temperature.DegreeC, 51).To(Temperature.DegreeF);
            Assert.AreEqual(resultD, 123.8);

            var resultE = Mathos.Converter.Converter.From(Temperature.DegreeK, 62).To(Temperature.DegreeF);
            Assert.AreEqual(resultE, -348.07);

            var resultF = Mathos.Converter.Converter.From(Temperature.DegreeF, 23).To(Temperature.DegreeK);
            Assert.AreEqual(resultF, 268.15);
            
            var resultG = Mathos.Converter.Converter.From(Temperature.DegreeF, 23).To(Temperature.DegreeF);
            Assert.AreEqual(resultG, 23);
        }
    }
}