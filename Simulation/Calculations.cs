using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    public static class Calculations
    {
        public static double GetFlight(double x, double speedObject, double time)
        {
            return x + speedObject * time;
        }

        public static double GetSpeedOnAxisX(double speedX, double speedY, double deltaTime, double k)
        {
            return speedX - k * speedX * Math.Sqrt(Math.Pow(speedX, 2) + Math.Pow(speedY, 2)) * deltaTime;
        }
        public static double GetSpeedOnAxisY(double speedX, double speedY, double deltaTime, double k, double g)
        {
            return speedY - (g + k * speedY * Math.Sqrt(Math.Pow(speedX, 2) + Math.Pow(speedY, 2))) * deltaTime;
        }

        //public static double GetYFlight(double y0, double v0, double angle, double time, double gravityY, double k)
        //{
        //    return y0 + v0 * Math.Sin(GetRadianFromDegrees(angle)) * time + gravityY * time * time / 2;
        //}

        public static double GetRadianFromDegrees(double andle)
        {
            return andle * Math.PI / 180;
        }

        public static double GetMaxHeight(double v0, double angle, double g)
        {
            return (v0 * v0 * Math.Pow(Math.Sin(GetRadianFromDegrees(angle)), 2)) / (2 * g);
        }

        public static double GetMaxLengthOfFlight(double v0, double angle, double g)
        {
            return (v0 * v0 * Math.Sin(GetRadianFromDegrees(2 * angle))) / g;
        }

        public static double GetStartedSpeedX(double speed, double angle)
        {
            return speed * Math.Cos(GetRadianFromDegrees(angle));
        }

        public static double GetStartedSpeedY(double speed, double angle)
        {
            return speed * Math.Sin(GetRadianFromDegrees(angle));
        }
    }
}
