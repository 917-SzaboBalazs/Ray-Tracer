using System;
using System.Runtime.InteropServices;

namespace rt
{
    public class Ellipsoid : Geometry
    {
        private Vector Center { get; }
        private Vector SemiAxesLength { get; }
        private double Radius { get; }
        
        
        public Ellipsoid(Vector center, Vector semiAxesLength, double radius, Material material, Color color) : base(material, color)
        {
            Center = center;
            SemiAxesLength = semiAxesLength;
            Radius = radius;
        }

        public Ellipsoid(Vector center, Vector semiAxesLength, double radius, Color color) : base(color)
        {
            Center = center;
            SemiAxesLength = semiAxesLength;
            Radius = radius;
        }

        public override Intersection GetIntersection(Line line, double minDist, double maxDist)
        {
            Vector o_c = line.X0 - Center;

            double delta = (line.Dx * o_c) * (line.Dx * o_c) - (o_c * o_c - Radius * Radius);

            if (delta < 0)
            {
                return new Intersection();
            }

            if (delta == 0)
            {
                double d = -(line.Dx * o_c);
                Vector pos = line.X0 + line.Dx * d;
                Vector norm = (pos - Center).Normalize();
                bool visible = minDist <= d && d <= maxDist;

                return new Intersection(true, visible, this, line, d, norm);
            }

            double d1 = -(line.Dx * o_c) - Math.Sqrt(delta);
            double d2 = -(line.Dx * o_c) + Math.Sqrt(delta);

            bool d1In = minDist <= d1 && d1 <= maxDist;
            bool d2In = minDist <= d2 && d2 <= maxDist;

            if (!d1In && !d2In)
            {
                return new Intersection();
            }

            if (d2In && !d1In)
            {
                Vector pos = line.X0 + line.Dx * d2;
                Vector norm = (pos - Center).Normalize();

                return new Intersection(true, true, this, line, d2, norm);
            }

            Vector pos_d = line.X0 + line.Dx * d1;
            Vector norm_d = (pos_d - Center).Normalize();

            return new Intersection(true, true, this, line, d1, norm_d);
        }
    }
}
