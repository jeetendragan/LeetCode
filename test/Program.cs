using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // string input = Console.ReadLine();
            // String[] strList = input.Trim().Split(',');
            List<int> numbers = new List<int>();
            numbers.Add(1);numbers.Add(2);numbers.Add(3);numbers.Add(4);numbers.Add(5);
            // foreach(String str in strList){
            //     numbers.Add(int.Parse(str));
            // }
            int maxSum = 0;
            foreach(int n in numbers){
                maxSum += n;
            }
            int minCount = int.MaxValue;
            GenerateSubsets(numbers, -1, ref minCount, new HashSet<int>(), maxSum, 0);
            Console.WriteLine("The smallest difference is: "+minCount);
        }

        static void GenerateSubsets(List<int> numbers, int pivot, ref int minCount, HashSet<int> set, int maxSum, int subsetSum)
        {
            if(pivot == numbers.Count-1){ //i.e we have reached the last index, we cannot add any more numbers
                // Print solution
                PrintSol(set);
                int amountOnOtherServer = Math.Abs(subsetSum-maxSum);
                int diff = Math.Abs(amountOnOtherServer - subsetSum);
                Console.Write("("+diff+")");
                if(diff < minCount)
                {
                    minCount = diff;
                }
                Console.WriteLine();
                return;
            }

            // Look at the next possibilities
            // for(int i = pivot+1; i < numbers.Count; i++)
            // {

                // Include the ith number
                // forward track
                set.Add(numbers[pivot+1]);
                GenerateSubsets(numbers, pivot+1, ref minCount, set, maxSum, subsetSum+numbers[pivot+1]);
                // Backtrack
                set.Remove(numbers[pivot+1]);

                // Exclude the ith number
                GenerateSubsets(numbers, pivot+1, ref minCount, set, maxSum, subsetSum);
            // }

        }

        static void PrintSol(HashSet<int> set)
        {
            foreach(int i in set){
                Console.Write(i);
            }
        }
    }
}