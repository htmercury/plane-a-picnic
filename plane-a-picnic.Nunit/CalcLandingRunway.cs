using System.Collections.Generic;
using NUnit.Framework;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.ResourceModels;
using plane_a_picnic.Utilities;

namespace plane_a_picnic.Nunit.Tests
{
    [TestFixture]
    public class CalcLandingRunway
    {
        private readonly AirportWeatherHandler _RWH;

        public CalcLandingRunway()
        {
            List<RunwayResourceModel> runways = new List<RunwayResourceModel> {
                new RunwayResourceModel{
                    RunwayId = 1,
                    LeHeadingDegT = 0
                },
                new RunwayResourceModel{
                    RunwayId = 2,
                    LeHeadingDegT = 45
                },
                new RunwayResourceModel{
                    RunwayId = 3,
                    LeHeadingDegT = 90
                },
                new RunwayResourceModel{
                    RunwayId = 4,
                    LeHeadingDegT = 135
                },
                new RunwayResourceModel{
                    RunwayId = 5,
                    LeHeadingDegT = 250
                }
            };
            _RWH = new AirportWeatherHandler(runways);
        }

        [Test]
        public void ShouldReturnRunway4Given10()
        {
            RunwayResourceModel result = _RWH.CalcLandingRunway(10);
            Assert.AreEqual(result.RunwayId, 4);
        }

        [Test]
        public void ShouldReturnRunway1Given160()
        {
            RunwayResourceModel result = _RWH.CalcLandingRunway(160);
            Assert.AreEqual(result.RunwayId, 1);
        }

        [Test]
        public void ShouldReturnRunway5Given75()
        {
            RunwayResourceModel result = _RWH.CalcLandingRunway(75);
            Assert.AreEqual(result.RunwayId, 5);
        }

        [Test]
        public void ShouldReturnRunway2Given240()
        {
            RunwayResourceModel result = _RWH.CalcLandingRunway(240);
            Assert.AreEqual(result.RunwayId, 2);
        }

        [Test]
        public void ShouldReturnRunway3Given275()
        {
            RunwayResourceModel result = _RWH.CalcLandingRunway(275);
            Assert.AreEqual(result.RunwayId, 3);
        }
    }
}