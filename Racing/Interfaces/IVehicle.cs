using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Interfaces;

public interface IVehicle
{
    double Speed { get; set; }
}

public interface IGroundVehicle : IVehicle
{
    double DrivingTime { get; set; }

    double GetRestTime(int idxStop);
}

public interface IAirVehicle : IVehicle
{
    double GetAcceleration(double traceDistance);
}