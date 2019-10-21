using System;

namespace merge_lists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7 }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 2, 3, 4 }, new int[] { }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 8, 9, 10 }, new int[] { 1, 6, 20, 30 }));
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            if (m == 0 && n == 0)
            {
                return 0;
            }
            else if (m > 0 && n == 0)
            {
                int mid1 = m / 2;
                double midVal1;
                if (m % 2 == 0)
                {
                    midVal1 = ((double)nums1[mid1] + (double)nums1[mid1 - 1]) / 2;
                }
                else
                {
                    midVal1 = (double)nums1[mid1];
                }
                return midVal1;
            }
            else if (m == 0 && n > 0)
            {
                int mid2 = n / 2;
                double midVal2;
                if (n % 2 == 0)
                {
                    midVal2 = ((double)nums2[mid2] + (double)nums2[mid2 - 1]) / 2;
                }
                else
                {
                    midVal2 = (double)nums2[mid2];
                }
                return midVal2;
            }

            int p1 = 0, p2 = 0, p = 0, pb = 0, numbersSeen = 0;
            bool isOddList = (m + n) % 2 == 0 ? false : true;
            int listMid = (m + n) / 2;
            int[] newList = new int[m+n];

            while (true)
            {
                if(p1 == m && p2 == n)
                    break;
                
                if (p1 != m & p2 != n)
                {
                    if (nums1[p1] < nums2[p2])
                    {
                        pb = p;
                        p = nums1[p1];
                        p1++;
                    }
                    else
                    {
                        pb = p;
                        p = nums2[p2];
                        p2++;
                    }
                }else if(p1 != m){
                    pb = p;
                    p = nums1[p1];
                    p1++;
                }else if(p2 != n){
                    pb = p;
                    p = nums2[p2];
                    p2++;
                }

                if (numbersSeen == listMid)
                {
                    break;
                }
                numbersSeen++;
            }

            if (isOddList)
            {
                return p;
            }
            else
            {
                return ((double)p + (double)pb) / 2;
            }
        }
    }
}
