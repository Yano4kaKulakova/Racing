using Racing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models;

public class BootsFastwalkers : IGroundVehicle
{
    public BootsFastwalkers(double drivingTime, double speed)
    {
        DrivingTime = drivingTime;
        Speed = speed;
    }

    public double DrivingTime { get ; set ; }
    public double Speed { get ; set ; }
    public string Name { get; } = "Сапоги-скороходы";


    public double GetRestTime(int idxStop)
    {
        return idxStop * 3;
    }
}
