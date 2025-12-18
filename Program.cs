using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] sizes = { 100, 1000, 5000, 10000 };

        foreach (int size in sizes)
        {
            int[] array = GenerateRandomArray(size);
            int[] arrayCopy = (int[])array.Clone();

            Console.WriteLine($"\nArray size: {size}");

            // Insertion Sort
            Stopwatch sw = Stopwatch.StartNew();
            InsertionSort(array);
            sw.Stop();
            Console.WriteLine($"Insertion Sort Time: {sw.ElapsedMilliseconds} ms");

            // Merge Sort
            sw.Restart();
            MergeSort(arrayCopy, 0, arrayCopy.Length - 1);
            sw.Stop();
            Console.WriteLine($"Merge Sort Time: {sw.ElapsedMilliseconds} ms");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static int[] GenerateRandomArray(int size)
    {
        Random rand = new Random();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = rand.Next(0, 100000);
        }

        return array;
    }

    static void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }

    static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);

            Merge(array, left, middle, right);
        }
    }

    static void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = array[left + i];
        for (int j = 0; j < n2; j++)
            R[j] = array[middle + 1 + j];

        int iIndex = 0, jIndex = 0, k = left;

        while (iIndex < n1 && jIndex < n2)
        {
            if (L[iIndex] <= R[jIndex])
                array[k++] = L[iIndex++];
            else
                array[k++] = R[jIndex++];
        }

        while (iIndex < n1)
            array[k++] = L[iIndex++];

        while (jIndex < n2)
            array[k++] = R[jIndex++];
        //
    }
}
