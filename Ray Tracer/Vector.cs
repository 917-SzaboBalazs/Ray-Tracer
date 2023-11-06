﻿using System;

namespace rt
{
    public class Vector
    {
        public static Vector I = new Vector(1, 0, 0);
        public static Vector J = new Vector(0, 1, 0);
        public static Vector K = new Vector(0, 0, 1);
        
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(Vector v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static double operator *(Vector v, Vector b)
        {
            return v.X * b.X + v.Y * b.Y + v.Z * b.Z;
        }

        public static Vector operator ^(Vector a, Vector b)
        {
            return new Vector(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        }

        public static Vector operator *(Vector v, double k)
        {
            return new Vector(v.X * k, v.Y * k, v.Z * k);
        }

        public static Vector operator /(Vector v, double k)
        {
            return new Vector(v.X / k, v.Y / k, v.Z / k);
        }

        public static bool operator ==(Vector v1, Vector v2)
        {

            return Math.Abs(v1.X - v2.X) < 0.001 && Math.Abs(v1.Y - v2.Y) < 0.001 && Math.Abs(v1.Z - v2.Z) < 0.001;
        }
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        public void Multiply(Vector k)
        {
            X *= k.X;
            Y *= k.Y;
            Z *= k.Z;
        }

        public void Divide(Vector k)
        {
            X /= k.X;
            Y /= k.Y;
            Z /= k.Z;
        }

        public double Length2()
        {
            return X * X + Y * Y + Z * Z;
        }

        public double Length()
        {
            return  Math.Sqrt(Length2());
        }

        public Vector Normalize()
        {
            var norm = Length();
            if (norm > 0.0)
            {
                X /= norm;
                Y /= norm;
                Z /= norm;
            }
            return this;
        }

        public override string ToString()
        {
            return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
        }
    }
}