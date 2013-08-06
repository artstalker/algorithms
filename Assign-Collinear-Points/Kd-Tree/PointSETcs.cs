using System.Collections.Generic;

namespace Algorithms.Kd_Tree
{
	public class PointSET
	{
		private readonly LeftLeaningRedBlackTree<Point2D, Point2D> tree = new LeftLeaningRedBlackTree<Point2D, Point2D>((x, y) => x.CompareTo(y));
		public PointSET()
		{ }// construct an empty set of points
		public bool isEmpty()
		{
			return tree.Count == 0;
		}// is the set empty?
		public int size
		{
			get
			{
				return tree.Count;
			}
		}// number of points in the set
		public void insert(Point2D p)
		{
			tree.Add(p,p);
		}// add the point p to the set (if it is not already in the set)
		public bool contains(Point2D p)
		{
			return tree.GetValueForKey(p) != null;
		}// does the set contain the point p?
		public void draw()
		{

		}// draw all of the points to standard draw
		public IEnumerable<Point2D> range(RectHV rect)
		{
			IList<Point2D> selectedPoints = new List<Point2D>();
			var points = tree.GetValuesForAllKeys();
			foreach (var point2D in points)
			{
				if (rect.contains(point2D))
				{
					selectedPoints.Add(point2D);
				}
			}

			return selectedPoints;
		}// all points in the set that are inside the rectangle

		public Point2D nearest(Point2D p)
		{
			Point2D selectedPoint = null;
			var points = tree.GetValuesForAllKeys();
			double mindistance = double.PositiveInfinity;
			foreach (var point2D in points)
			{
				if (point2D.Equals(p))
				{
					continue;
				}
				double distance = point2D.distanceTo(p);
				if (distance < mindistance)
				{
					mindistance = distance;
					selectedPoint = point2D;
				}

			}

			return selectedPoint;
		}// a nearest neighbor in the set to p; null if set is empty
	}

	
}
