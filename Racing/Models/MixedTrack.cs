using Racing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models;

public class MixedTrack : ITrack
{
    public MixedTrack(double distance, List<IGroundVehicle> groundVehicles, List<IAirVehicle> airVehicles)
    {
        Distance = distance;
        GroundVehicles = groundVehicles;
        AirVehicles = airVehicles;
    }

    public double Distance { get ; set ; }
    public List<IGroundVehicle> GroundVehicles { get; set; }
    public List<IAirVehicle> AirVehicles { get; set; }
}
