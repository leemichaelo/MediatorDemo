using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarkerPositions
{
    public class Marker : Label
    {
        private MarkerMediator mediator;
        private Point mouseDownLocation;

        internal void SetMediator(MarkerMediator mediator)
        {
            this.mediator = mediator;
        }

        public Marker()
        {
            Text = "{Drag Me}";
            TextAlign = ContentAlignment.MiddleCenter;
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Text = Location.ToString();
                Left = e.X + Left - mouseDownLocation.X;
                Top = e.Y + Top - mouseDownLocation.Y;
                mediator.Send(Location, this);
            }
        }

        public void ReceiveLocation(Point location)
        {
            var distance = CalcDistance(location);

            if(distance < 100 & BackColor != Color.Red)
            {
                BackColor = Color.Red;
            }
            else if(distance >= 100 && BackColor != Color.Green)
            {
                BackColor = Color.Green;
            }

            double CalcDistance(Point point) 
                => Math.Sqrt(Math.Pow(point.X - Location.X, 2) + Math.Pow(point.Y - Location.Y, 2));
        }

    }
}
