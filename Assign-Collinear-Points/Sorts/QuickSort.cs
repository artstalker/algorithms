using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorts
{
	static class QuickSort
	{
		public static void Sort2Way(int[] array)
		{

			SortRecursive2Way(array, 0, array.Count() - 1);
		}

		static void SortRecursive2Way(int[] array, int lo, int hi)
		{
			if (lo >= hi) return;

			int j = Partition(array, lo, hi);
			SortRecursive2Way(array, lo, j - 1);
			SortRecursive2Way(array, j + 1, hi);
		}

		static void SortRecursive3Way(int[] array, int lo, int hi)
		{
			if (lo >= hi) return;

			int lt = lo;
			int gt = hi;
			int v = array[lo];
			int i = 0;
			while (i <= gt)
			{
				if (array[i] < v)
				{
					swap(array, lt, i);
					lt++;
					i++;

				}
				else if (array[i] > v)
				{
					swap(array, i, gt);
					gt--;
				}
				else
				{
					i++;
				}

			}

			SortRecursive2Way(array, lo, lt - 1);
			SortRecursive2Way(array, gt + 1, hi);
		}

		static int Partition(int[] array, int lo, int hi)
		{
			int lt = lo + 1;
			while (true)
			{
				if (array[lt] < array[lo]) lt++;
				else if (array[lt] >= array[lo])
				{
					swap(array, lt, hi);
					hi--;
				}
				if (lt > hi)
				{
					break;
				}

			}
			swap(array, lo, hi);
			return hi;
		}

		static void swap(int[] array, int i, int j)
		{
			int aux = array[i];
			array[i] = array[j];
			array[j] = aux;
		}
	}
}
