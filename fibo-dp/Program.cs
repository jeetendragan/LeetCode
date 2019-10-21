using System;
using System.Collections.Generic;

namespace fibo_dp
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<int> memo = new List<int>();
            // int n = 6;
            // for(int i = 0; i < n; i++){memo.Add(-1);}
            // int res = fibo(n, memo);
            // Console.WriteLine(res);

            int[] nums = new int[]{2,0,2,1,1,0};
            SortColors(nums);

        }

        // static int fibo(int n, List<int> memo){
        //     if(memo[n-1] != -1){
        //         return memo[n-1];
        //     }
        //     int result;
        //     if(n == 1 || n == 2){
        //         result = 1;
        //     }else{
        //         result = fibo(n-1, memo) + fibo(n-2, memo);
        //     }
        //     memo[n-1] = result;
        //     return result;
        // }

        // public static string RemoveKdigits(string num, int k) {
            
        // }

        public static void SortColors(int[] nums) {
            int zeroes = 0, ones = 0, twos = 0;
            foreach(int i in nums){
                if(i == 0)
                    zeroes++;
                if(i == 1)
                    ones++;
                if(i == 2)
                    twos++;
            }
            int lastZeroIndex = zeroes - 1;
            int lastOneIndex = zeroes + ones-1;
            for(int i = 0; i < nums.Length; i++){
                if(i <= lastZeroIndex){
                    nums[i] = 0;
                }
                if(i > lastZeroIndex && i <= lastOneIndex){
                    nums[i] = 1;
                }
                
                if(i>lastOneIndex){
                    nums[i] = 2;
                }
            }

            foreach(int i in nums){
                Console.WriteLine(i);
            }

        }


    }
}
