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
    public string Name { get; } = "Ступа Бабы Яги";

    public double GetAcceleration(double traceDistance)
    {
        return Math.Sin(traceDistance) * 10;
    }
}
