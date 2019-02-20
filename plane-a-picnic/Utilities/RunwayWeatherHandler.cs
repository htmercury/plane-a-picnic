using System;
using System.Collections.Generic;
using System.Linq;
using plane_a_picnic.Models;

namespace plane_a_picnic.Utilities
{
    public class RunwayWeatherHandler
    {
        public List<RunwayModel> Runways { get; }

        public RunwayWeatherHandler ()
        {
            this.Runways = new List<RunwayModel>();
        }
        public RunwayWeatherHandler(List<RunwayModel> runways)
        {
            this.Runways = runways.FindAll(r => r.LeHeadingDegT.HasValue).OrderBy(r => r.LeHeadingDegT).ToList();
        }

        public double CalcOppositeAngle (double angle)
        {
            return (angle + 180) % 360;
        }

        private RunwayModel ClosestRunway(int size, RunwayModel l, RunwayModel r)
        {
            return new RunwayModel(); // filler
        }

        public RunwayModel CalcLandingRunway (double windAngle)
        {
            double opposingAngle = this.CalcOppositeAngle(windAngle);
            // Apply binary search since list is ordered
            int size = this.Runways.Count();
            return ClosestRunway(size, this.Runways.First(), this.Runways.Last());
        }
    }
}