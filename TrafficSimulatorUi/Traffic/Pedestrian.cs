using System.Drawing;

namespace TrafficSimulatorUi
{
    public class Pedestrian : RoadUser
    {
        /// <summary>
        /// Create a new Pedestrian
        /// </summary>
        public Pedestrian(Point location, double speed)
            : base(location, speed, Properties.Resources.BluePedestrian)
        {
        }
    }
}
