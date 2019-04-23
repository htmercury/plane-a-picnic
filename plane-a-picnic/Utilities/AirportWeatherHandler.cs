using System;
using System.Collections.Generic;
using System.Linq;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.ResourceModels;

namespace plane_a_picnic.Utilities
{
    public class AirportWeatherHandler
    {
        public int AirportId { get; set; }
        public List<RunwayResourceModel> Runways { get; set; }

        public AirportWeatherHandler()
        {
            this.Runways = new List<RunwayResourceModel>();
            this.AirportId = -1;
        }
        public AirportWeatherHandler(List<RunwayResourceModel> runways)
        {
            this.Runways = runways
                .FindAll(r => r.LeHeadingDegT.HasValue || r.HeHeadingDegT.HasValue)
                .OrderBy(r => r.LeHeadingDegT)
                .ToList();
        }

        public double CalcOppositeAngle(double angle)
        {
            return (angle + 180) % 360;
        }

        public double CalcAngleProximity(double angle1, double angle2)
        {
            double distance1 = Math.Abs(angle1 - angle2);
            double distance2;
            if (angle1 > angle2)
            {
                distance2 = 360 - angle1 + angle2;
            }
            else
            {
                distance2 = 360 - angle2 + angle1;
            }
            return Math.Min(distance1, distance2);
        }

        public RunwayResourceModel CalcLandingRunway(double windAngle)
        {
            double runwayCount = this.Runways.Count();
            double opposingAngle = this.CalcOppositeAngle(windAngle);
            if (runwayCount == 0)
            {
                return null;
            }
            // Map the proximity function to each runway to the opposing angle
            List<double> runwayProximities = this.Runways.Select(r => {
                    double? angle = r.LeHeadingDegT ?? this.CalcOppositeAngle((double)r.HeHeadingDegT);
                    return this.CalcAngleProximity((double)angle, opposingAngle);
                })
                .ToList();

            // Do a linear search on each runway and choose the one with min proximity to opposing angle
            int min = 0;
            for (int i = 1; i < runwayCount; i++)
            {
                if (runwayProximities[min] > runwayProximities[i])
                {
                    min = i;
                }
            }

            return this.Runways[min];
        }
    }
}