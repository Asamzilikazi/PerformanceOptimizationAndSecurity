using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;

namespace PerformanceOptimizationAndSecurity
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generating a large dataset of random integers
            List<int> dataset = GenerateLargeDataset(1000000);

            // Optimize for performance: Use quicksort for sorting
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(dataset, 0, dataset.Count - 1);
            stopwatch.Stop();
            Console.WriteLine($"Time taken to sort the dataset: {stopwatch.ElapsedMilliseconds} milliseconds");

            // Implement security measures: Validate user input
            try
            {
                Console.WriteLine("Enter an index to access the sorted dataset:");
                string userInput = Console.ReadLine();
                int index = Convert.ToInt32(userInput);
                if (index >= 0 && index < dataset.Count)
                {
                    Console.WriteLine($"Value at index {index} is: {dataset[index]}");
                }
                else
                {
                    Console.WriteLine("Invalid index entered.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input value is too large.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        // Method to generate a large dataset of random integers
        static List<int> GenerateLargeDataset(int size)
        {
            List<int> dataset = new List<int>();
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                dataset.Add(random.Next());
            }
            return dataset;
        }

        // Quicksort algorithm for sorting the dataset
        static void QuickSort(List<int> dataset, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(dataset, low, high);
                QuickSort(dataset, low, partitionIndex - 1);
                QuickSort(dataset, partitionIndex + 1, high);
            }
        }

        static int Partition(List<int> dataset, int low, int high)
        {
            int pivot = dataset[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (dataset[j] < pivot)
                {
                    i++;
                    int temp = dataset[i];
                    dataset[i] = dataset[j];
                    dataset[j] = temp;
                }
            }
            int temp1 = dataset[i + 1];
            dataset[i + 1] = dataset[high];
            dataset[high] = temp1;
            return i + 1;
        }
    }
}
