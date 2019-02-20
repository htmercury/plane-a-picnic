using System;
using System.Collections.Generic;
using System.Linq;
using plane_a_picnic.Models;

namespace plane_a_picnic.Utilities
{
    public class RunwayWeatherHandler
    {
        public List<RunwayModel> Runways { get; }

        public RunwayWeatherHandler()
        {
            this.Runways = new List<RunwayModel>();
        }
        public RunwayWeatherHandler(List<RunwayModel> runways)
        {
            this.Runways = runways.FindAll(r => r.LeHeadingDegT.HasValue).OrderBy(r => r.LeHeadingDegT).ToList();
        }

        public double CalcOppositeAngle(double angle)
        {
            return (angle + 180) % 360;
        }

        private RunwayModel ClosestRunway(double x)
        {
            if (x < this.Runways.First().LeHeadingDegT)
            {
                return this.Runways.First();
            }

            if (x > this.Runways.Last().LeHeadingDegT)
            {
                return this.Runways.Last();
            }

            int lo = 0;
            int hi = this.Runways.Count() - 1;

            while (lo <= hi)
            {
                int mid = (hi + lo) / 2;

                if (x < this.Runways[mid].LeHeadingDegT)
                {
                    hi = mid - 1;
                }
                else if (x > this.Runways[mid].LeHeadingDegT)
                {
                    lo = mid + 1;
                }
                else
                {
                    return this.Runways[mid];
                }
            }

            // Handle case where lo == hi + 1
            if ((this.Runways[lo].LeHeadingDegT - x) < (x - this.Runways[hi].LeHeadingDegT))
            {
                return this.Runways[lo];
            }
            else
            {
                return this.Runways[hi];
            }
        }

        private double CalcAngleProximity(double angle1, double angle2)
        {
            return 0; // filler
        }

        public RunwayModel CalcLandingRunway(double windAngle)
        {
            double opposingAngle = this.CalcOppositeAngle(windAngle);
            if (this.Runways.Count() == 0)
            {
                return null;
            }
            // Apply binary search since list is ordered
            return ClosestRunway(opposingAngle);
        }
    }
}