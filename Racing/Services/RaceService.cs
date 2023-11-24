using Racing.Data;
using Racing.Interfaces;
using Racing.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Racing.Services;

public class RaceService
{
    private ITrack _track;
    private int _type;

    public RaceService(ITrack track)
    {
        _track = track;
        if (track is AirTrack) _type = (int)TYPE_RACE.AIR;
        else if (track is GroundTrack) _type = (int)TYPE_RACE.GROUND;
        else if (track is MixedTrack) _type = (int)TYPE_RACE.MIXED;
        else _type = (int)TYPE_RACE.NOT_FOUND;
    }

    public Dictionary<string, double> StartRace()
    {
        var result = new Dictionary <string, double>();

        switch (_type)
        {
            case (int)TYPE_RACE.GROUND:
                result = StartGroundRace(_track.Distance, (_track as GroundTrack).GroundVehicles);
                break;

            case (int)TYPE_RACE.AIR:
                result = StartAirRace(_track.Distance, (_track as AirTrack).AirVehicles);
                break;

            case (int)TYPE_RACE.MIXED:
                result = StartMixedRace(_track.Distance, (_track as MixedTrack).GroundVehicles, (_track as MixedTrack).AirVehicles);
                break;

            default:
                result.Add("Не определено", 0);
                break;
        }
        return result;
    }

    private Dictionary<string, double> StartGroundRace(double distance, List<IGroundVehicle> groundVehicles)
    {
        Dictionary<string, double> dictionary = new Dictionary<string, double>();
        foreach (var vehicle in groundVehicles)
        {
            var countStops = 0;           
            var resultTime = distance / vehicle.Speed;
            double time = vehicle.DrivingTime;
            double restTime = 0;

            while (time < resultTime) 
            {
                time += vehicle.DrivingTime;
                countStops++;
                restTime += vehicle.GetRestTime(countStops);
            }
            resultTime += restTime;
            dictionary.Add(vehicle.Name, resultTime);
        }
        return dictionary.OrderBy(o => o.Value).ToDictionary(x => x.Key, x => x.Value);
    }

    private Dictionary<string, double> StartAirRace(double distance, List<IAirVehicle> airVehicles)
    {
        Dictionary<string, double> dictionary = new Dictionary<string, double>();
        foreach (var vehicle in airVehicles)
        {
            double time = vehicle.Speed / vehicle.GetAcceleration(distance);
            dictionary.Add(vehicle.Name, time);
        }
        return dictionary.OrderBy(o => o.Value).ToDictionary(x => x.Key, x => x.Value);
    }

    private Dictionary<string, double> StartMixedRace(double distance, List<IGroundVehicle> groundVehicles, List<IAirVehicle> airVehicles)
    {
        Dictionary<string, double> dictionary = new Dictionary<string, double>();
        var ground = StartGroundRace(distance, groundVehicles);
        var air = StartAirRace(distance, airVehicles);
        
        foreach (var g in ground)
        {
            dictionary.Add(g.Key, g.Value);
        }
        
        foreach (var a in air)
        {
            dictionary.Add(a.Key, a.Value);
        }

        return dictionary.OrderBy(o => o.Value).ToDictionary(x => x.Key, x => x.Value);
    }
}
