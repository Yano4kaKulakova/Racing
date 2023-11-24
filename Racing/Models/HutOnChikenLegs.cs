using Racing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models;

public class HutOnChikenLegs : IGroundVehicle
{
    public HutOnChikenLegs(double drivingTime, double speed)
    {
        DrivingTime = drivingTime;
        Speed = speed;
    }

    public double DrivingTime { get ; set ; }
    public double Speed { get ; set ; }
    public string Name { get; } = "Избушка на курьих ножках";

    public double GetRestTime(int idxStop)
    {
        return 2 * Math.Pow(idxStop, 2) - 4 * idxStop + 3;
    }
}
