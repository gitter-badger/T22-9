﻿namespace TrafficSimulator
{
    partial class SimulatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.tmrSpawn = new System.Windows.Forms.Timer(this.components);
            this.tmrTrafficlight = new System.Windows.Forms.Timer(this.components);
            this.intersectionControl4 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl3 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl1 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl2 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl5 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl6 = new TrafficSimulatorUi.IntersectionControl();
            this.SuspendLayout();
            // 
            // progressTimer
            // 
            this.progressTimer.Interval = 40;
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // tmrSpawn
            // 
            this.tmrSpawn.Enabled = true;
            this.tmrSpawn.Interval = 3000;
            this.tmrSpawn.Tick += new System.EventHandler(this.tmrSpawn_Tick);
            // 
            // tmrTrafficlight
            // 
            this.tmrTrafficlight.Interval = 7000;
            this.tmrTrafficlight.Tick += new System.EventHandler(this.tmrTrafficlight_Tick);
            // 
            // intersectionControl1
            // 
            this.intersectionControl1.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_2;
            this.intersectionControl1.Location = new System.Drawing.Point(0, 0);
            this.intersectionControl1.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl1.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl1.Name = "intersectionControl1";
            this.intersectionControl1.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl1.TabIndex = 1;
            this.intersectionControl1.TrafficLightClick += new System.EventHandler<TrafficSimulatorUi.TrafficLightClickEventArgs>(this.intersectionControl_TrafficLightClick);
            // 
            // intersectionControl2
            // 
            this.intersectionControl2.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_4;
            this.intersectionControl2.Location = new System.Drawing.Point(400, 0);
            this.intersectionControl2.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl2.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl2.Name = "intersectionControl2";
            this.intersectionControl2.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl2.TabIndex = 0;
            this.intersectionControl2.TrafficLightClick += new System.EventHandler<TrafficSimulatorUi.TrafficLightClickEventArgs>(this.intersectionControl_TrafficLightClick);
            // 
            // intersectionControl3
            // 
            this.intersectionControl3.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_1;
            this.intersectionControl3.Location = new System.Drawing.Point(0, 400);
            this.intersectionControl3.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl3.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl3.Name = "intersectionControl3";
            this.intersectionControl3.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl3.TabIndex = 2;
            this.intersectionControl3.TrafficLightClick += new System.EventHandler<TrafficSimulatorUi.TrafficLightClickEventArgs>(this.intersectionControl_TrafficLightClick);
            // 
            // intersectionControl4
            // 
            this.intersectionControl4.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_3;
            this.intersectionControl4.Location = new System.Drawing.Point(400, 400);
            this.intersectionControl4.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl4.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl4.Name = "intersectionControl4";
            this.intersectionControl4.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl4.TabIndex = 3;
            this.intersectionControl4.TrafficLightClick += new System.EventHandler<TrafficSimulatorUi.TrafficLightClickEventArgs>(this.intersectionControl_TrafficLightClick);
            // 
            // intersectionControl5
            // 
            this.intersectionControl5.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_RAILWAY;
            this.intersectionControl5.Location = new System.Drawing.Point(800, 0);
            this.intersectionControl5.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl5.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl5.Name = "intersectionControl5";
            this.intersectionControl5.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl5.TabIndex = 4;
            // 
            // intersectionControl6
            // 
            this.intersectionControl6.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_RAILWAY;
            this.intersectionControl6.Location = new System.Drawing.Point(800, 400);
            this.intersectionControl6.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl6.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl6.Name = "intersectionControl6";
            this.intersectionControl6.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl6.TabIndex = 5;
            // 
            // SimulatorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.intersectionControl6);
            this.Controls.Add(this.intersectionControl5);
            this.Controls.Add(this.intersectionControl4);
            this.Controls.Add(this.intersectionControl3);
            this.Controls.Add(this.intersectionControl1);
            this.Controls.Add(this.intersectionControl2);
            this.Name = "SimulatorForm";
            this.Text = "Traffic Simulator";
            this.ResumeLayout(false);

        }

        #endregion

        private TrafficSimulatorUi.IntersectionControl intersectionControl2;
        private TrafficSimulatorUi.IntersectionControl intersectionControl1;
        private TrafficSimulatorUi.IntersectionControl intersectionControl3;
        private TrafficSimulatorUi.IntersectionControl intersectionControl4;
        private System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.Timer tmrSpawn;
        private System.Windows.Forms.Timer tmrTrafficlight;
        private TrafficSimulatorUi.IntersectionControl intersectionControl5;
        private TrafficSimulatorUi.IntersectionControl intersectionControl6;



    }
}

