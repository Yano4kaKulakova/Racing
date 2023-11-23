﻿using Racing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models;

public class FlyingShip : IAirVehicle
{
    public double Speed { get ; set ; }

    public double GetAcceleration(double traceDistance)
    {
        return Math.Log(traceDistance);
    }
}
