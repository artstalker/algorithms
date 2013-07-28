using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Algorithms.Sorts;

namespace Algorithms.Puzzle
{
	class Solver
	{
		private readonly Board _initialBoard;

		PriorityQueue queue = new PriorityQueue();
		Queue<Board> solution = new Queue<Board>();
		public Solver(Board initialBoard)
		{
			_initialBoard = initialBoard;
			var s = _initialBoard.ToString();
		}

		private void Solve()
		{
			Board previousBoard = null;
			queue.Enqueue(_initialBoard,_initialBoard.Manhattan+Moves);
			while (true)
			{
				var board = (Board)queue.Dequeue();
				solution.Enqueue(board);
				if (board.IsGoal())
				{
					break;
				}

				Moves += 1;
				foreach (var neigbor in board.Neigbors())
				{
					if (!neigbor.Equals(previousBoard))
					{
						queue.Enqueue(neigbor, neigbor.Manhattan + Moves);
					}
				}
				previousBoard = board;
			}
			int k = 0;

			
		}

		public bool IsSolvable
		{
			get { return true; }
		}

		public int Moves { get; set; }

		public IEnumerable<Board> Solution
		{
			get { return solution; }
		}

		public static void Handle(params string[] args)
		{
			var reader = File.OpenText(args[0]);
			int N = int.Parse(reader.ReadLine());
			int[][] blocks = new int[N][];
			for (int i = 0; i < N; i++)
			{
				blocks[i] = new int[N];
			}
			for (int i = 0; i < N; i++)
			{
				string line = reader.ReadLine();
				var values = line.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
				for (int j = 0; j < N; j++)
				{
					blocks[i][j] = int.Parse(values[j]);
				}
			}
			Board initial = new Board(blocks);
			// solve the puzzle
			Solver solver = new Solver(initial);
			solver.Solve();
			// print solution to standard output
			if (!solver.IsSolvable)
				Console.WriteLine("No solution possible");
			else
			{
				Console.WriteLine("Minimum number of moves = " + solver.Moves);
				foreach (var board in solver.Solution)
				{
					Console.WriteLine(board);
				}
				
			}
		}
	}
}
