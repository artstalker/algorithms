using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorts
{
	static class MergeSort
	{
		public static void Sort(int[] array)
		{
			int[] aux = new int[array.Count()];

			SortRecursive(array, aux, 0, array.Count() - 1);

		}

		static void SortRecursive(int[] array, int[] aux, int lo, int hi)
		{
			if (lo >= hi) return;
			int mid = lo + (hi - lo) / 2;
			SortRecursive(array, aux, lo, mid);
			SortRecursive(array, aux, mid + 1, hi);
			Merge(array, aux, lo, hi, mid);
		}

		static void Merge(int[] array, int[] aux, int lo, int hi, int mid)
		{
			for (int i1 = lo; i1 <= hi; i1++)
			{
				aux[i1] = array[i1];
			}
			int i = lo;
			int j = mid + 1;
			for (int z = lo; z <= hi; z++)
			{
				if (i > mid) array[z] = aux[j++];
				else if (j > hi) array[z] = aux[i++];
				else if (aux[i] <= aux[j]) array[z] = aux[i++];
				else array[z] = aux[j++];
			}
		}
	}
}
