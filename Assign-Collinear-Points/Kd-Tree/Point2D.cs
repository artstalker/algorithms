using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Kd_Tree
{
	public class Point2D : IComparable<Point2D>
	{
		private double x, y;
		public Point2D(double x, double y) // construct the point (x, y)
		{
			this.x = x;
			this.y = y;
		}
		public double X
		{
			get { return x; }
		}// x-coordinate
		public double Y
		{
			get { return y; }
		}// y-coordinate
		public double distanceTo(Point2D that)
		{
			double t = Math.Pow(X - that.x, 2) + Math.Pow(Y - that.Y, 2);
			return Math.Sqrt(t);
		}// Euclidean distance between two points
		public double distanceSquaredTo(Point2D that)
		{
			double t = Math.Pow(X - that.x, 2) + Math.Pow(Y - that.Y, 2);
			return t;
		}// square of Euclidean distance between two points

		public override bool Equals(object obj)
		{
			Point2D other = obj as Point2D;
			if (other == null)
			{
				return false;
			}
			if (other.X == X && other.Y == Y)
			{
				return true;
			}

			return false;
		}
		// does this point equal that?
		public void draw()
		{

		}// draw to standard draw
		// string representation
		public int CompareTo(Point2D other)
		{
			if (X == other.X && Y == other.Y)
			{
				return 0;
			}
			if (Y < other.Y || (Y == other.Y && X < other.X))
			{
				return -1;
			}
			else
			{
				return 1;
			}

		}

		public override string ToString()
		{
			return string.Format("({0};{1})", X, Y);
		}
	}
}
