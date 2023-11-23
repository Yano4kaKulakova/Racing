using Racing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models;

public class AirTrack : ITrack
{
    public AirTrack(double distance, List<IAirVehicle> airVehicles)
    {
        Distance = distance;
        AirVehicles = airVehicles;
    }

    public double Distance { get ; set ; }
    public List<IAirVehicle> AirVehicles { get; set; }
}
