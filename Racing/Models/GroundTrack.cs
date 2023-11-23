using Racing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models;

public class GroundTrack : ITrack
{
    public GroundTrack(double distance, List<IGroundVehicle> groundVehicles)
    {
        Distance = distance;
        GroundVehicles = groundVehicles;
    }

    public double Distance { get ; set ; }
    public List<IGroundVehicle> GroundVehicles { get; set ; }
}
