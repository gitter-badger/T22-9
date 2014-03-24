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
        public List<IntersectionControl> intersectionControls;
        private Random rand = new Random();
        private List<Point> entryPoints;
        private bool trafficLightState;

        public SimulatorForm()
        {
            InitializeComponent();

            entryPoints = new List<Point>();
            entryPoints.Add(new Point(-20, 216));
            entryPoints.Add(new Point(-20, 244));
            entryPoints.Add(new Point(156, -20));
            entryPoints.Add(new Point(184, -20));

            roadUsers = new List<RoadUser>();
            intersectionControls = new List<IntersectionControl>();

            intersectionControls.Add(intersectionControl1);
            intersectionControls.Add(intersectionControl2);
            intersectionControls.Add(intersectionControl3);
            intersectionControls.Add(intersectionControl4);
            intersectionControls.Add(intersectionControl5);
            intersectionControls.Add(intersectionControl6);

            // Testing: start all trafficlights on red
            intersectionControl1.GetTrafficLight(LaneId.WEST_INBOUND_ROAD_LEFT).SwitchTo(SignalState.STOP);
            progressTimer.Start();
            tmrTrafficlight.Start();
            UpdateLights();
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            UpdateWorld();
        }

        private void UpdateWorld()
        {
            // update and redraw all intersections
            foreach (IntersectionControl intersectionControl in intersectionControls)
            {
                intersectionControl.UpdateIntersection();
            }
            bool shouldMove = true;
            foreach (RoadUser roadUser in roadUsers)
            {
                shouldMove = true;
                foreach (RoadUser otherRoadUser in roadUsers)
                {
                    if (roadUser != otherRoadUser && roadUser.checkMove().IntersectsWith(otherRoadUser.BoundingBox))
                    {
                        shouldMove = false;
                    }
                }
                if (shouldMove)
                {
                    roadUser.Move();
                }
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



        private void tmrSpawn_Tick(object sender, EventArgs e)
        {

            int directionIndex = rand.Next(0, 3);
            
            BlueCar checkCar = new BlueCar(entryPoints[directionIndex], 0);
            foreach (RoadUser otherRoadUser in roadUsers)
            {
                if (checkCar.BoundingBox.IntersectsWith(otherRoadUser.BoundingBox))
                {
                    return;
                }
            }
            int initSpeed = rand.Next(2, 5);
            switch (rand.Next(0,5))
            {
                case 0:
                    BlueCar bCar = new BlueCar(entryPoints[directionIndex], initSpeed);
                    roadUsers.Add(bCar);
                    intersectionControl1.AddRoadUser(bCar);
                    FaceCar(bCar, directionIndex);
                    break;
                case 1:
                    BlueSportsCar bsCar = new BlueSportsCar(entryPoints[directionIndex], initSpeed);
                    roadUsers.Add(bsCar);
                    intersectionControl1.AddRoadUser(bsCar);
                    FaceCar(bsCar, directionIndex);
                    break;
                case 2:
                    GreenSportsCar gCar = new GreenSportsCar(entryPoints[directionIndex], initSpeed);
                    roadUsers.Add(gCar);
                    intersectionControl1.AddRoadUser(gCar);
                    FaceCar(gCar, directionIndex);
                    break;
                case 3:
                    RedSportsCar rsCar = new RedSportsCar(entryPoints[directionIndex], initSpeed);
                    roadUsers.Add(rsCar);
                    intersectionControl1.AddRoadUser(rsCar);
                    FaceCar((rsCar), directionIndex);
                    break;
                default:
                    break;
            }
        }

        private void FaceCar(RoadUser rUser, int directionIndex)
        {
            switch (directionIndex)
            {
                case 2:
                    rUser.FaceTo(new Point(rUser.Location.X, 1000));
                    break;
                case 3:
                    rUser.FaceTo(new Point(rUser.Location.X, 1000));
                    break;
                default:
                    break;
            }
        }

        private void UpdateLights()
        {
            foreach (LaneId lane in (LaneId[])Enum.GetValues(typeof(LaneId)))
            {
                foreach (IntersectionControl ic in intersectionControls)
                {
                    TrafficLight light = ic.GetTrafficLight(lane);

                    if (light != null && trafficLightState)
                    {
                        if ((lane.ToString().Contains("NORTH") || lane.ToString().Contains("SOUTH")) && !lane.ToString().Contains("PAVEMENT"))
                        {
                            light.SwitchTo(SignalState.GO);
                        }
                        else
                        {
                            light.SwitchTo(SignalState.STOP);
                        }
                    }
                    else if (light != null)
                    {
                        if ((lane.ToString().Contains("EAST") || lane.ToString().Contains("WEST")) && !lane.ToString().Contains("PAVEMENT"))
                        {
                            light.SwitchTo(SignalState.GO);
                        }
                        else
                        {
                            light.SwitchTo(SignalState.STOP);
                        }
                    }
                }
                
            }


            trafficLightState = !trafficLightState;
        }

        private void tmrTrafficlight_Tick(object sender, EventArgs e)
        {
            UpdateLights();
        }
    }
}
