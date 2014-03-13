using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TrafficSimulatorUi;

namespace TrafficSimulator
{
    public partial class SimulatorForm : Form
    {
        /// <summary>
        /// List to keep track of all road users.
        /// You can put roadusers on intersections to make them appear there.
        /// </summary>
        private List<RoadUser> roadUsers;
        private List<IntersectionControl> intersectionControls;

        public SimulatorForm()
        {
            InitializeComponent();
            roadUsers = new List<RoadUser>();
            intersectionControls = new List<IntersectionControl>();

            intersectionControls.Add(intersectionControl1);
            intersectionControls.Add(intersectionControl2);
            intersectionControls.Add(intersectionControl3);
            intersectionControls.Add(intersectionControl4);

            roadUsers.Add(new BlueCar(new Point(-20, 216), 2));
            roadUsers.Add(new BlueSportsCar(new Point(-80, 216), 1));

            foreach (RoadUser r in roadUsers)
            {
                intersectionControl1.AddRoadUser(r);
            }

            // Testing: start all trafficlights on red
            intersectionControl1.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT).SwitchTo(SignalState.STOP);
            progressTimer.Start();
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            UpdateWorld();
        }

        private void UpdateWorld()
        {
            foreach (RoadUser roadUser in roadUsers)
            {
                roadUser.Move();
            }

            // update and redraw all intersections
            foreach (IntersectionControl intersectionControl in intersectionControls)
            {
                intersectionControl.UpdateIntersection();
            }

        }

        private void intersectionControl_TrafficLightClick(object sender, TrafficLightClickEventArgs e)
        {
            // Example code for interacting with traffic lights
            // Note: The goal of this example is to shows some code mechanics. Nothing more.
            //       Probably you want to remove most of it, because it does not do wat you want over here.
            //
            // The example code shows 
            // - How to handle TrafficLightClick events.
            // - How to get the state of a traffic light.
            // - How to set thet state of a traffic light.

            Debug.WriteLine("Clicked traffic light with lane id: " + e.LaneId + ", of intersection: ");
            IntersectionControl intersection = (IntersectionControl)sender;
            TrafficLight trafficLight = intersection.GetTrafficLight(e.LaneId);
            if (trafficLight.State == SignalState.STOP)
            {
                trafficLight.SwitchTo(SignalState.GO);
            }
            else
            {
                trafficLight.SwitchTo(SignalState.STOP);
            }
            
        }
    }
}
