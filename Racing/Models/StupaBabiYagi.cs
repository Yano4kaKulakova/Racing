using Racing.Data;
using Racing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models;

public class StupaBabiYagi : IAirVehicle
{
    public StupaBabiYagi(double speed)
    {
        Speed = speed;
    }

    public double Speed { get; set; }
    public string Name { get; } = VehicleNames.StupaBabiYagi;


    public double GetAcceleration(double traceDistance)
    {
        return traceDistance / 500;
    }
}
