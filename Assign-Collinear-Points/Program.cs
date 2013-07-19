using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assign_Collinear_Points
{
	class Program
	{

		static  List<Point>  Points = new List<Point>();
		static void Main(string[] args)
		{
			var lines = File.ReadAllLines(args[0]).Skip(1);

			foreach (var line in lines)
			{
				var vars = line.Split(' ');
				int x = int.Parse(vars[0]);
				int y = int.Parse(vars[1]);
				Points.Add(new Point(x,y));
			}

		}
	}

	class Point
	{
		public int X;

		public int Y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}
		public override string ToString()
		{

			return string.Format("{{0},{1}}", X, Y);
		}

		public double SlopeTo(Point p)
		{
			return 0;
		}
	}
}
