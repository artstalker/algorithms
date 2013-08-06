using System;
using System.Collections.Generic;
using System.IO;

namespace Algorithms.Kd_Tree
{
	class KdTreeSolver
	{
		static PointSET set = new PointSET();

		static KdTree<Point2D, Point2D> kdTree = new KdTree<Point2D, Point2D>((x, y) =>
			{ 
				int res = (int)((x.X - y.X) * 100);
				return res;
			}, (x, y) =>
				{ 
					int res = (int)((x.Y - y.Y) * 100);
					return res;
				});
		static IList<RectHV>  areas = new List<RectHV>();
		static IList<Point2D>  points = new List<Point2D>();

		public static void Solve(string fileName)
		{
			
			
			var reader = File.OpenText(fileName);
			
			int points_count = int.Parse(reader.ReadLine());
			for (int i = 0; i < points_count; i++)
			{
				var values = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				Point2D point = new Point2D(double.Parse(values[0]), double.Parse(values[1]));
				//set.insert(point);
				kdTree.Add(point,point);
			}

			int rectangles_count = int.Parse(reader.ReadLine());
			for (int i = 0; i < rectangles_count; i++)
			{
				var values = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				RectHV rect = new RectHV(double.Parse(values[0]), double.Parse(values[1]), double.Parse(values[2]), double.Parse(values[3]));
				areas.Add(rect);
			}

			points_count = int.Parse(reader.ReadLine());
			for (int i = 0; i < points_count; i++)
			{
				var values = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				Point2D point = new Point2D(double.Parse(values[0]), double.Parse(values[1]));
				points.Add(point);
			}

			foreach (var rectHv in areas)
			{
				var affectedPoints = kdTree.range(rectHv);
				Console.WriteLine("=====================================");
				Console.WriteLine("Rectnalge: {0}",rectHv);
				Console.WriteLine("Points:");
				foreach (var point2D in affectedPoints)
				{
					Console.WriteLine(point2D);
				}
			}

			
			
			//foreach (var point in points)
			//{
			//	var nearest_point = set.nearest(point);
			//	Console.WriteLine("=====================================");
			//	Console.WriteLine("Point: {0}", point);
			//	Console.Write("Nearest point:");
			//	Console.WriteLine(nearest_point);

			//}


		}

		
	}
}
