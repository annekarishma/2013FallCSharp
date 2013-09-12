using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Vehicle
    {
        public Vehicle()
        {
            Breakdown = delegate
    {
        Log +="\nWe Broke Down";
    };
}


        public string Log { get; set ;}
        public virtual void Drive()
        {
            Log += "\nWe Drove Somewhere";
        }

        public void Crash(Func<int, int> impact)
        {
            Log += "\r\nThe impact was: " + impact(speed);
        }
        public Action<string> BreakDown { get; set; }
     
    }

    public class Car : Vehicle
    {
        public void Park()
        {
            Drive;
        }
    }
}

public class Plane : Vehicle
{
    public Plane()
        : base()
    {
        Breakdown = () => Log += "\nWe Fell Down";

    }
          
    public override void Drive()
    {
        Log += "\nWe Flew Somewhere";
    }
}
