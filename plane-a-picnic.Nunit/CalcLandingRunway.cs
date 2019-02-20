using System.Collections.Generic;
using NUnit.Framework;
using plane_a_picnic.Models;
using plane_a_picnic.Utilities;

namespace plane_a_picnic.Nunit.Tests
{
    [TestFixture]
    public class CalcLandingRunway
    {
        private readonly RunwayWeatherHandler _RWH;

        public CalcLandingRunway()
        {
            List<RunwayModel> runways = new List<RunwayModel> {
                new RunwayModel{
                    RunwayId = 1,
                    LeHeadingDegT = 0
                },
                new RunwayModel{
                    RunwayId = 2,
                    LeHeadingDegT = 45
                },
                new RunwayModel{
                    RunwayId = 3,
                    LeHeadingDegT = 90
                },
                new RunwayModel{
                    RunwayId = 4,
                    LeHeadingDegT = 135
                },
                new RunwayModel{
                    RunwayId = 5,
                    LeHeadingDegT = 250
                }
            };
            _RWH = new RunwayWeatherHandler(runways);
        }

        [Test]
        public void ShouldReturnRunway4Given10()
        {
            RunwayModel result = _RWH.CalcLandingRunway(10);
            Assert.AreEqual(result.RunwayId, 4);
        }

        [Test]
        public void ShouldReturnRunway1Given160()
        {
            RunwayModel result = _RWH.CalcLandingRunway(160);
            Assert.AreEqual(result.RunwayId, 1);
        }

        [Test]
        public void ShouldReturnRunway5Given75()
        {
            RunwayModel result = _RWH.CalcLandingRunway(75);
            Assert.AreEqual(result.RunwayId, 5);
        }

        [Test]
        public void ShouldReturnRunway2Given240()
        {
            RunwayModel result = _RWH.CalcLandingRunway(240);
            Assert.AreEqual(result.RunwayId, 2);
        }

        [Test]
        public void ShouldReturnRunway3Given275()
        {
            RunwayModel result = _RWH.CalcLandingRunway(275);
            Assert.AreEqual(result.RunwayId, 3);
        }
    }
}