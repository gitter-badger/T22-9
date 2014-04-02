﻿using System;
using System.Drawing;
using System.Diagnostics;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// Movable object that represents a road user, like a car or a pedestrian.
    /// </summary>
    public abstract class RoadUser : IDrawable
    {
        /// <summary>
        /// The X coordinate of the road user (middle of image).
        /// All calculation for the position are done using doubles to prevent precision problems.
        /// The resulting position is written to the (integer) Location property.
        /// </summary>
        private double x;

        /// <summary>
        /// The Y coordinate of the road user (middle of image).
        /// All calculation for the position are done using doubles to prevent precision problems.
        /// The resulting position is written to the (integer) Location property.
        /// </summary>
        private double y;

        /// <summary>
        /// Displacement
        /// </summary>
        private double dx;
        private double dy;

        /// <summary>
        /// The location
        /// </summary>
        private Point location;

        /// <summary>
        /// the speed (see property for description)
        /// </summary>
        private double speed;
        private double initSpeed;

        /// <summary>
        /// The bounding box of the item.
        /// </summary>
        private Rectangle boundingBox;

        /// <summary>
        /// The image of the road user
        /// </summary>
        private Image image;

        /// <summary>
        /// The direction to which the road user is heading. Permitted values are 0..360.
        /// Where 0 is east, 90 is north, 180 is west, 270 is south and 360 is east again.
        /// </summary>
        private double direction;

        /// <summary>
        /// Cache of rotated images
        /// </summary>
        private RotatedImageCache rotatedImageCache;
        
        public Boolean exiting = false;
        public Boolean exited = false;
        public Boolean remove = false;
        public Boolean hasDestination = false;
        public Directions destination;
        public Directions origin;
        public int movesTillTurn;

        private Point prevLocation;
        private Rectangle prevBoundingBox;

        public RoadUserMode userMode;
        /// <summary>
        /// Creates a road user
        /// </summary>
        /// <param name="image">The image to use then painting the road user.</param>
        public RoadUser(Point location, double speed, Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            rotatedImageCache = new RotatedImageCache(image);
            Location = location;
            Speed = speed;
            initSpeed = speed;
            Direction = 0D;
            if(location.X <= 0)
            {
                origin = Directions.WEST;
            }
            if (location.X >= 400)
            {
                origin = Directions.EAST;
            }
            if (location.Y <= 0)
            {
                origin = Directions.NORTH;
            }
            if (location.Y >= 400)
            {
                origin = Directions.WEST;
            }
             
        }

        /// <summary>
        /// The 'speed' of the road user.
        /// Each call to the Move method will move the road user by 'Speed' pixels. 
        /// Fractions of pixels are also alowed.
        /// </summary>
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
                SetDXAndDY(Speed, Direction);
            }
        }

        /// <summary>
        /// the inital speed of the car.
        /// </summary>
        public double InitSpeed
        {
            get
            {
                return initSpeed;
            }
        }

        /// <summary>
        /// Sets the x and y displacement for moving in the given direction with 
        /// the given speed.
        /// </summary>
        /// <param name="speed">The speed, i.e. pixels to move.</param>
        /// <param name="direction">The direction to move to.</param>
        private void SetDXAndDY(double speed, double direction)
        {
            dx = speed * Math.Cos(MathHelper.DegreesToRadians(direction));
            dy = -speed * Math.Sin(MathHelper.DegreesToRadians(direction));
        }

        /// <summary>
        /// The location of the road user.
        /// Watch it: for roadUsers the location is at the center of the object.
        /// </summary>
        public Point Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                x = value.X;
                y = value.Y;
            }
        }

        /// <summary>
        /// The bounding box of the road user
        /// </summary>
        public Rectangle BoundingBox
        {
            get
            {
                return boundingBox;
            }
            private set
            {
                boundingBox = value;
            }
        }

        /// <summary>
        /// The image used tot draw the road user
        /// </summary>
        public Image Image
        {
            get { return image; }
            private set
            {
                image = value;
                boundingBox.X = Convert.ToInt32(x - (Image.Size.Width / 2D));
                boundingBox.Y = Convert.ToInt32(y - (Image.Size.Height / 2D));
                boundingBox.Size = image.Size;
            }
        }

        /// <summary>
        /// The direction to which the road user is heading. Permitted values are 0..360.
        /// Where 0 is east, 90 is north, 180 is west, 270 is south and 360 is east again.
        /// 
        /// When setting the direction both negative and positive values are allowed. 
        /// The direction wil be 'normalized' to a value in the range 0..360
        /// </summary>
        public double Direction
        {
            get { return direction; }
            set
            {
                direction = MathHelper.AbsModulus(value, 360D);
                Image = rotatedImageCache.GetImage(Convert.ToInt32(direction));
                SetDXAndDY(Speed, Direction);
            }
        }

        /// <summary>
        /// Moves the road user forwards or backwards taking its direction into account.
        /// Each call of this method moves the road user by 'Speed' pixels.
        /// </summary>
        public void Move()
        {
            if (hasDestination && speed > 0)
            {
                if (movesTillTurn > 0)
                {
                    movesTillTurn--;
                }
                else
                {
                    switch (destination)
                    {
                        case Directions.NORTH:
                            FaceTo(new Point((int)x, 0));
                            break;
                        case Directions.EAST:
                            FaceTo(new Point(1000, (int)y));
                            break;
                        case Directions.SOUTH:
                            FaceTo(new Point((int)x, 1000));
                            break;
                        case Directions.WEST:
                            FaceTo(new Point(0, (int)y));
                            break;

                    }
                    hasDestination = false;
                }
            }
            prevBoundingBox = boundingBox;
            prevLocation = location;
            x += dx;
            y += dy;
            location.X = Convert.ToInt32(x);
            location.Y = Convert.ToInt32(y);
            boundingBox.X = Convert.ToInt32(x - (Image.Size.Width / 2D));
            boundingBox.Y = Convert.ToInt32(y - (Image.Size.Height / 2D));
        }

        public Rectangle checkMove()
        {
            double x2 = x;
            double y2 = y;
            x2 += dx;
            y2 += dy;
            Point location2 = location;
            location2.X = Convert.ToInt32(x2);
            location2.Y = Convert.ToInt32(y2);
            Rectangle boundingBox2 = boundingBox;
            boundingBox2.X = Convert.ToInt32(x2 - (Image.Size.Width / 2D));
            boundingBox2.Y = Convert.ToInt32(y2 - (Image.Size.Height / 2D));

            Rectangle boudingBoxTurn;
            if (movesTillTurn == 0 && hasDestination)
            {
                boudingBoxTurn = new Rectangle((int)x2, (int)y2, boundingBox2.Height, boundingBox2.Width);
                return boudingBoxTurn;
            }
            return boundingBox2;
        }

        public void UnMove()
        {
            location = prevLocation;
            boundingBox = prevBoundingBox;
        }


        /// <summary>
        /// Change the direction so that it faces the given point.
        /// </summary>
        /// <param name="point">The point to face to</param>
        public void FaceTo(Point point)
        {
            double angle = MathHelper.GetDegreesAngle(Location, point);
            Direction = angle;
        }


        /// <summary>
        /// Draws the road user to the drawing surface.
        /// </summary>
        /// <param name="drawingSurface">The drawing surface to draw onto.</param>
        public void DrawTo(Graphics drawingSurface)
        {
            drawingSurface.DrawImageUnscaled(Image, BoundingBox);
        }
    }
}
