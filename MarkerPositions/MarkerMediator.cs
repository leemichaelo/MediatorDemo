using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MarkerPositions
{
    public class MarkerMediator
    {
        private List<Marker> markers = new List<Marker>();

        public Marker CreateMarker()
        {
            var m = new Marker();
            m.SetMediator(this);
            markers.Add(m);
            return m;
        }

        public void Send(Point location, Marker marker)
        {
            markers.Where(m => m != marker).ToList().ForEach(m => m.ReceiveLocation(location));
        }
    }
}
