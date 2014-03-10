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
        RoadUser yopCar2;


        public SimulatorForm()
        {
            InitializeComponent();
            roadUsers = new List<RoadUser>();

            RoadUser blueCar = new BlueCar(new Point(60,216), 2);
            RoadUser yopCar = new GreenSportsCar(new Point(216,60), 4);
            RoadUser greenSportsCar = new GreenSportsCar(new Point(155, 253), 0);
            yopCar2 = new BlueSportsCar(new Point(60, 216), 3);

            greenSportsCar.FaceTo(new Point(160, 260));



            roadUsers.Add(yopCar);
            roadUsers.Add(blueCar);
            roadUsers.Add(yopCar2);
            roadUsers.Add(greenSportsCar);

            foreach (RoadUser R in roadUsers)
            {
                intersectionControl1.AddRoadUser(R);
                intersectionControl2.AddRoadUser(R);
            }

            //intersectionControl1.AddRoadUser(roadUsers[0]);
            //intersectionControl1.AddRoadUser(roadUsers[1]);
            //intersectionControl1.AddRoadUser(roadUsers[2]);
            //intersectionControl1.AddRoadUser(roadUsers[3]);


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

            // redraw all intersections
            intersectionControl1.Invalidate();
            intersectionControl2.Invalidate();
            intersectionControl3.Invalidate();
            intersectionControl4.Invalidate();
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
            trafficLight.SwitchTo(SignalState.STOP);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yopCar2.FaceTo(new Point(yopCar2.Location.X, (yopCar2.Location.Y + 90)));
        }
    }
}
