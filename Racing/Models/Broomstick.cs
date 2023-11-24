﻿using Racing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models;

public class Broomstick : IAirVehicle
{
    public Broomstick(double speed)
    {
        Speed = speed;
    }

    public double Speed { get ; set ; }
    public string Name { get; } = "Метла";


    public double GetAcceleration(double traceDistance)
    {
        return Math.Exp(traceDistance);
    }
}
