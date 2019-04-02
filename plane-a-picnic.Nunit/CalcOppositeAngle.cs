using NUnit.Framework;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Utilities;

namespace plane_a_picnic.Nunit.Tests
{
    [TestFixture]
    public class CalcOppositeAngle
    {
        [Test]
        public void ShouldReturn180Given0()
        {
            AirportWeatherHandler RWH = new AirportWeatherHandler();
            Assert.AreEqual(RWH.CalcOppositeAngle(0), 180);
        }

        [Test]
        public void ShouldReturn135GivenNeg45()
        {
            AirportWeatherHandler RWH = new AirportWeatherHandler();
            Assert.AreEqual(RWH.CalcOppositeAngle(-45), 135);
        }

        [Test]
        public void ShouldReturn225Given45()
        {
            AirportWeatherHandler RWH = new AirportWeatherHandler();
            Assert.AreEqual(RWH.CalcOppositeAngle(45), 225);
        }  

        [Test]
        public void ShouldReturn180Given360()
        {
            AirportWeatherHandler RWH = new AirportWeatherHandler();
            Assert.AreEqual(RWH.CalcOppositeAngle(360), 180);
        }  

        [Test]
        public void ShouldReturn0Given180()
        {
            AirportWeatherHandler RWH = new AirportWeatherHandler();
            Assert.AreEqual(RWH.CalcOppositeAngle(180), 0);
        }          
    }
}