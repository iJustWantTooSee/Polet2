using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    public class Engine
    {
        const double C = 0.15;
        const double rho = 1.29;
        private ObjectInSimulation obj = null;
        private double K = 0;
        public double Time { get; private set; }
        public double DTime { get; private set; }
        public double GravityX { get; private set; }
        public double GravityY { get; private set; }
        public double Gravity { get; private set; }

        public Engine(Point initialPosition, double initialSpeed, double dt, double gX, double gY,
            double angle, double weight, double area, double gravity)
        {
            obj = new ObjectInSimulation(initialPosition, initialSpeed, angle);
            Time = 0;
            DTime = dt;
            GravityX = gX;
            GravityY = gY;
            Gravity = gravity;
            K = 0.5 * C * area * rho / weight;
            obj.CurrentSpeed = new Point(Calculations.GetStartedSpeedX(initialSpeed, angle),
                Calculations.GetStartedSpeedY(initialSpeed, angle));
            obj.CurrentPosition = obj.InitialPosition;
        }

        public Point GetNextPoint()
        {
            Time += DTime;

            obj.CurrentSpeed = new Point(Calculations.GetSpeedOnAxisX(obj.CurrentSpeed.X, obj.CurrentSpeed.Y, DTime, K),
                Calculations.GetSpeedOnAxisY(obj.CurrentSpeed.X, obj.CurrentSpeed.Y, DTime, K, Gravity)
                );
            obj.CurrentPosition =new Point (Calculations.GetFlight(obj.CurrentPosition.X, obj.CurrentSpeed.X, DTime),
                Calculations.GetFlight(obj.CurrentPosition.Y, obj.CurrentSpeed.Y, DTime));
            return obj.CurrentPosition;
        }
    }
}
