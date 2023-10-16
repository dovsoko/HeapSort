using System;

public class HeapSort<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        int n = arr.Length;

        // Build max heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }

        // Extract elements from the heap in max order
        for (int i = n - 1; i >= 0; i--)
        {
            // Swap the root (maximum element) with the last element
            T temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Call heapify on the reduced heap
            Heapify(arr, i, 0);
        }
    }

    private static void Heapify(T[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left].CompareTo(arr[largest]) > 0)
        {
            largest = left;
        }

        if (right < n && arr[right].CompareTo(arr[largest]) > 0)
        {
            largest = right;
        }

        if (largest != i)
        {
            // Swap arr[i] and arr[largest]
            T swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            // Recursively heapify the affected sub-tree
            Heapify(arr, n, largest);
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Example usage with integers
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Original array:");
        PrintArray(arr);

        HeapSort<int>.Sort(arr);

        Console.WriteLine("\nSorted array:");
        PrintArray(arr);
    }

    private static void PrintArray<T>(T[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

