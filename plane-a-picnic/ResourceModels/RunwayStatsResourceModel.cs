using System.Collections.Generic;
using plane_a_picnic.Domain.Models;

namespace plane_a_picnic.ResourceModels
{
    public class RunwayStatsResourceModel
    {
        public double OpposingAngle { get; set; }
        public List<RunwayResourceModel> Runways { get; set; }
        public List<double> AngleProximities { get; set; }
    }
}