using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Algorithms.Puzzle;

namespace Algorithms
{
	class Program
	{

		static  List<Point>  Points = new List<Point>();
		static void Main(string[] args)
		{
			Solver.Handle("Puzzle04.txt");
			//var lines = File.ReadAllLines(args[0]).Skip(1);

			//foreach (var line in lines)
			//{
			//	var vars = line.Split(' ');
			//	int x = int.Parse(vars[0]);
			//	int y = int.Parse(vars[1]);
			//	Points.Add(new Point(x,y));
			//}

			//var results = BruteForceFindCollinearPoints();

			//foreach (var points in results)
			//{
			//	Console.WriteLine(string.Join(" ",points));
			//}

			Console.Read();

		}

		static IEnumerable<IEnumerable<Point>> BruteForceFindCollinearPoints()
		{
			List<List<Point>> result = new List<List<Point>>();

			for (int i = 0; i < Points.Count;i++ )
				for (int j = i+1; j < Points.Count; j++)
					for (int y = j+1; y < Points.Count; y++)
						for (int z = y+1; z < Points.Count; z++)
						{
							var I = Points[i];
							var J = Points[j];
							var Y = Points[y];
							var Z = Points[z];
							var assert = new List<Point>(new Point[] {I, J, Y, Z});
							
							
							var slope1 = I.SlopeTo(J);
							var slope2 = I.SlopeTo(Y);
							var slope3 = I.SlopeTo(Z);
							if (I.X == 3000 & I.Y == 4000 && J.X == 6000 & J.Y == 7000
							    && Y.X == 14000 & Y.Y == 15000 && Z.X == 20000 & Z.Y == 21000)
							{
								string s = string.Format("{0},{1},{2}", slope1, slope2, slope3);
							}
							if (slope1 == slope2 && slope1 == slope3)
							{
								result.Add(new List<Point>(new Point[] { I, J, Y, Z }));
							}
						}


				return result;
		}

		//static IEnumerable<IEnumerable<Point>> FastFindCollinearPoints()
		//{
		//	List<List<Point>> result = new List<List<Point>>();

		//	for (int i = 0; i < Points.Count; i++)
		//	{
		//		Points.Sort(Points[i].BySlope);
		//		if (Points  )
		//	}


		//	return result;
		//}
	}

	class SlopeComparer : IComparer<Point>
	{
		public Point OriginalPoint { get; private set; }

		public SlopeComparer(Point originalPoint)
		{
			OriginalPoint = originalPoint;
		}
		public int Compare(Point x, Point y)
		{
			var slopeX = OriginalPoint.SlopeTo(x);
			var slopeY = OriginalPoint.SlopeTo(y);
			return (int)(slopeX - slopeY);
		}
	}

	class Point : IComparable<Point>
	{
		public int X;

		public int Y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		
		public  readonly SlopeComparer BySlope ;

		public Point()
		{
			BySlope = new SlopeComparer(this);
		}

		public int CompareTo(Point other)
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

			return string.Format("({0},{1})", X, Y);
		}

		public double SlopeTo(Point p)
		{
			if (p.X == X && p.Y == Y)
			{
				return double.NegativeInfinity;
			}
			if (p.Y == Y)
			{
				return 0;
			}
			if (p.X == X)
			{
				return double.PositiveInfinity;
			}

			double res = (double)(p.Y - Y) / (double)(p.X - X);
			return res;
		}
	}
}
