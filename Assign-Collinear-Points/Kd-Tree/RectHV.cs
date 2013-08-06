using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Kd_Tree
{
	public class RectHV
	{

		private readonly double xmin, xmax, ymin, ymax;

		public RectHV(double xmin, double ymin, // construct the rectangle [xmin, xmax] x [ymin, ymax]
						  double xmax, double ymax)
		{
			this.xmin = xmin;
			this.xmax = xmax;
			this.ymin = ymin;
			this.ymax = ymax;
		}// throw a java.lang.IllegalArgumentException if (xmin > xmax) or (ymin > ymax)
		public double Xmin()
		{
			return xmin;
		}// minimum x-coordinate of rectangle
		public double Ymin()
		{
			return ymin;
		}// minimum y-coordinate of rectangle
		public double Xmax()
		{
			return xmax;
		}// maximum x-coordinate of rectangle
		public double Ymax()
		{
			return ymax;
		}// maximum y-coordinate of rectangle
		public bool contains(Point2D p)
		{
			return xmin <= p.X && p.X <= xmax && ymin <= p.Y && p.Y <= ymax;
		}// does this rectangle contain the point p (either inside or on boundary)?
		public bool intersects(RectHV that)
		{
			return that.xmin <= xmax && that.xmax >= xmin && that.ymin <= ymax && that.ymax >= ymin;
		}// does this rectangle intersect that rectangle (at one or more points)?
		public double distanceTo(Point2D p)
		{
			if (p.X < xmin)
			{ // Region I, VIII, or VII
				if (p.Y < ymin)
				{ // I
					// Vector2 diff = p - new Vector2(xmin, ymin);
					return p.distanceTo(new Point2D(xmin, ymin));
				}
				else if (p.Y > ymax)
				{ // VII
					// Vector2 diff = p - new Vector2(xmin, ymax);
					return p.distanceTo(new Point2D(xmin, ymax));
				}
				else
				{ // VIII
					return xmin - p.X;
				}
			}
			else if (p.X > xmax)
			{ // Region III, IV, or V
				if (p.Y < ymin)
				{ // III
					//Vector2 diff = p - new Vector2(xmax,ymin);
					return p.distanceTo(new Point2D(xmax, ymin));
				}
				else if (p.Y > ymax)
				{ // V
					//Vector2 diff = p - new Vector2(xmax, ymax);
					return p.distanceTo(new Point2D(xmax, ymax));
				}
				else
				{ // IV
					return p.X - xmax;
				}
			}
			else
			{ // Region II, IX, or VI
				if (p.Y < ymin)
				{ // II
					return ymin - p.Y;
				}
				else if (p.Y > ymax)
				{ // VI
					return p.Y - ymax;
				}
				else
				{ // IX
					return 0f;
				}
			}
		}// Euclidean distance from point p to the closest point in rectangle
		public double distanceSquaredTo(Point2D p)
		{
			return Math.Pow(distanceTo(p), 2);
		}// square of Euclidean distance from point p to closest point in rectangle
		public override bool Equals(object obj)
		{
			RectHV other = obj as RectHV;
			if (other == null)
			{
				return false;
			}

			return xmin == other.xmin && ymin == other.ymin && xmax == other.xmax && ymax == other.ymax;
		}// does this rectangle equal that?
		public void draw()
		{

		}// draw to standard draw
		public override string ToString()
		{
			return string.Format("Min:({0};{1}) Max:({2};{3})", xmin, ymin, xmax, ymax);
		}
		// string representation
	}
}
