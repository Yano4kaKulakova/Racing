using Racing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models;

public class CarpetPlane : IAirVehicle
{
    public double Speed { get ; set ; }
    public string Name { get; } = "Ковер-самолет";


    public double GetAcceleration(double traceDistance)
    {
        return Math.Sqrt(traceDistance / 2);
    }
}
