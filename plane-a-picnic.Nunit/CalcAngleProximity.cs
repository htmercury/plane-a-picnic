using NUnit.Framework;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Utilities;

namespace plane_a_picnic.Nunit.Tests
{
    [TestFixture]
    public class CalcAngleProximity
    {
        [Test]
        public void ShouldReturn0Given360And360()
        {
            AirportWeatherHandler RWH = new AirportWeatherHandler();

            Assert.AreEqual(RWH.CalcAngleProximity(360, 360), 0);
        }

        [Test]
        public void ShouldReturn0Given0And360()
        {
            AirportWeatherHandler RWH = new AirportWeatherHandler();

            Assert.AreEqual(RWH.CalcAngleProximity(0, 360), 0);
        }    

        [Test]
        public void ShouldReturn10Given200And210()
        {
            AirportWeatherHandler RWH = new AirportWeatherHandler();

            Assert.AreEqual(RWH.CalcAngleProximity(200, 210), 10);
        }

        [Test]
        public void ShouldReturn1Given359And0()
        {
            AirportWeatherHandler RWH = new AirportWeatherHandler();

            Assert.AreEqual(RWH.CalcAngleProximity(359, 360), 1);
        }

        [Test]
        public void ShouldReturn51Given209And158()
        {
            AirportWeatherHandler RWH = new AirportWeatherHandler();

            Assert.AreEqual(RWH.CalcAngleProximity(209, 158),51);
        }
    }
}