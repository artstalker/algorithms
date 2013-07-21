using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms.Puzzle
{
	class Board
	{
		
		private readonly int[][] _blocks;
		public Board(int[][] blocks)
		{
			_blocks = blocks;
		}

		public int Dimension
		{
			get { return _blocks.GetLength(0); }
		}

		public int Hamming
		{
			get
			{
				int value = 1;
				int outOfOrderCount = 0;
				for (int i = 0; i < Dimension; i++)
					for (int j = 0; j < Dimension; j++)
					{
						if (_blocks[i][j] != value++)
						{
							outOfOrderCount++;
						}
					}
				return outOfOrderCount;
			}
		}

		public int Manhattan
		{
			get
			{
				int value = 1;
				int distanceDiff = 0;
				for (int i = 0; i < Dimension; i++)
					for (int j = 0; j < Dimension; j++)
					{
						var currentBlock = _blocks[i][j];
						if (currentBlock != value && currentBlock !=0)
						{
							int correctRow = (currentBlock-1)/Dimension;
							int correctColumn = (currentBlock-1)%Dimension;

							
							distanceDiff += Math.Abs(correctRow - i) + Math.Abs(correctColumn - j);
						}
						value++;
					}
				return distanceDiff;
			}
		}

		public bool IsGoal()
		{
			int value = 1;
			for (int i=0;i< Dimension; i++)
				for (int j = 0; j < Dimension; j++)
				{
					if (i == Dimension - 1 && j == Dimension - 1)
					{
						break;
					}
					if (_blocks[i][j] != value++)
					{
						return false;
					}
				}
			return true;
		}

		public Board Twin()
		{
			var twin = new int[Dimension][];
			for (int i = 0; i < Dimension; i++)
			{
				twin[i] = new int[Dimension];
			}

			for(int i=0;i<Dimension;i++)
				for (int j = 0; j < Dimension; j++)
				{
					twin[i][j] = _blocks[i][j];
				}

			var temp = twin[0][0];
			twin[0][0] = twin[0][1];
			twin[0][1] = temp;

			Board twinBoard = new Board(twin);
			return twinBoard;

		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (this.GetType() != obj.GetType())
			{
				return false;
			}
			Board other = (Board)obj;
			for (int i=0;i<Dimension;i++)
				for (int j = 0; j < Dimension; j++)
				{
					if (_blocks[i][j] != other._blocks[i][j])
					{
						return false;
					}
				}
			return true;
		}

		public IEnumerable<Board> Neigbors()
		{
			List<Board> boards = new List<Board>();
			int empty_i = -1;
			int empty_j = -1;
			for (int i=0;i<Dimension;i++)
				for (int j = 0; j < Dimension; j++)
				{
					if (_blocks[i][j] == 0)
					{
						empty_i = i;
						empty_j = j;
						break;
					}
				}

			if (CanExchange(empty_i, empty_j, empty_i, empty_j - 1))
			{
				var blockCopy = Copy();
				exchange(blockCopy, empty_i, empty_j, empty_i, empty_j - 1);
				boards.Add(new Board(blockCopy));
			}
			if (CanExchange(empty_i, empty_j, empty_i+1, empty_j))
			{
				var blockCopy = Copy();
				exchange(blockCopy, empty_i, empty_j, empty_i+1, empty_j);
				boards.Add(new Board(blockCopy));
			}
			if (CanExchange(empty_i, empty_j, empty_i, empty_j + 1))
			{
				var blockCopy = Copy();
				exchange(blockCopy, empty_i, empty_j, empty_i, empty_j + 1);
				boards.Add(new Board(blockCopy));
			}
			if (CanExchange(empty_i, empty_j, empty_i -1, empty_j))
			{
				var blockCopy = Copy();
				exchange(blockCopy, empty_i, empty_j, empty_i -1, empty_j);
				boards.Add(new Board(blockCopy));
			}

			return boards;
		}

		private int[][] Copy()
		{
			var copy = new int[Dimension][];
			for (int i = 0; i < Dimension; i++)
			{
				copy[i] = new int[Dimension];
			}

			for (int i = 0; i < Dimension; i++)
				for (int j = 0; j < Dimension; j++)
				{
					copy[i][j] = _blocks[i][j];
				}

			return copy;
		}
		

		private bool CanExchange(int i, int j, int x, int y)
		{
			
			return i >= 0 && i < Dimension && j >= 0 && j < Dimension &
			                                            x >= 0 && x < Dimension && y >= 0 && y < Dimension;
		}
		private void exchange(int[][] a, int i, int j, int x, int y)
		{
			int temp = a[i][j];
			a[i][j] = a[x][y];
			a[x][y] = temp;
		}

		public override string ToString()
		{
			var text = new StringWriter();
			text.WriteLine(Dimension+string.Empty);
			for (int i = 0; i < Dimension; i++)
			{
				text.WriteLine(string.Join(" ", _blocks[i]) + string.Empty);
			}
			return text.ToString();

			
		}
	}
}
