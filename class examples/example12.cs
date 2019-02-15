using System;

namespace Ex1
{
	class MergeSort
	{
		static int[] GetInput(int size, int minValue, int maxValue)
		{
			if ((size < 1) || (size > 100000000))
				return null;        // also throw exception
			if (maxValue < 1)
				return null;        // also throw exception

			int[] input = new int[size];
			Random rand = new Random();
			for (int ii = 0; ii < input.Length; ++ii)
			{
				input[ii] = rand.Next(minValue, maxValue);
				//Console.Write(input[ii] + " ");
			}
			return input;
		}
		static public void ShowMergeSort()
		{
			int N = 10;
			int minValue = 0;
			int maxValue = 100;
			int[] input = GetInput(N, minValue, maxValue);

			PrintArray(input, "before sort");
			DoMergeSort(input, 0, input.Length - 1);
			PrintArray(input, "after sort");
		}

		static void DoMergeSort(int[] input, int start, int end)
		{
			if (start >= end)
				return;

			int middle = start + (end - start) / 2;
			// Question: Why not do int middle = ( start + end ) /2;

			DoMergeSort(input, start, middle);
			DoMergeSort(input, middle + 1, end);

			Merge(input, start, middle, end);
		}

		static void Merge(int[] input, int start, int middle, int end)
		{
			int[] mergedInput = new int[end - start + 1];
			int mergeIndex = 0;
			int index1 = start;
			int index2 = middle + 1;

			while ((index1 <= middle) && (index2 <= end))
			{
				if (input[index1] < input[index2])
				{
					mergedInput[mergeIndex] = input[index1];
					++index1;
				}
				else
				{
					mergedInput[mergeIndex] = input[index2];
					++index2;
				}
				++mergeIndex;
			}
			Array.Copy(input, index1, mergedInput, mergeIndex, (middle - index1) + 1);
			Array.Copy(input, index2, mergedInput, mergeIndex, (end - index2) + 1);

			Array.Copy(mergedInput, 0, input, start, (end - start) + 1);
		}

		static void PrintArray(int[] input, string message)
		{
			Console.WriteLine(message);
			foreach (int element in input)
			{
				Console.Write(element + " ");
			}
			Console.WriteLine("");
		}

		static void Main(string[] args)
		{
			ShowMergeSort();
		}
	}
}
