using Racing.Data;
using Racing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models;

public class FlyingShip : IAirVehicle
{
    public FlyingShip(double speed)
    {
        Speed = speed;
    }

    public double Speed { get ; set ; }
    public string Name { get; } = VehicleNames.FlyingShip;



    public double GetAcceleration(double traceDistance)
    {
        return Math.Log(traceDistance) / 10;
    }
}
