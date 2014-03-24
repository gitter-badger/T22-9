using System.Drawing;

namespace TrafficSimulatorUi
{
    public class RedSportsCar : RoadUser
    {
        /// <summary>
        /// Create a new car
        /// </summary>
        public RedSportsCar(Point location, double speed)
            : base(location, speed, Properties.Resources.RedSportsCarImage)
        {
        }
    }
}
